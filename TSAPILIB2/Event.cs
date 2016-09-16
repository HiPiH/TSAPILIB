using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace TSAPILIB2
{
    public enum StatusConection
    {
        Close,
        Open
    }

    public class Event : IDisposable
    {
        public delegate void DelegateClosed(object sender, EventArgs e);

        public delegate void DelegateConnected(object sender, EventArgs e);

        public delegate void DelegateUniversalFailureSys(object sender, UniversalFailureSys e);

        public delegate void DelegateUniversalFailure(object sender, UniversalFailureEventArg e);


        protected const int Timeout = 5000;
        public static readonly ILog Log = LogManager.GetLogger(typeof (Event));
        private static readonly object GlobalLock = new object();
       
        private readonly CancellationTokenSource _closed = new CancellationTokenSource();
    
        private readonly ReaderWriterLock _rw = new ReaderWriterLock();
        //
        private readonly AutoResetEvent _waitClient = new AutoResetEvent(false);
        protected readonly CbTask<int> CbTaskForToPartNew = new CbTask<int>();
        protected readonly CbTask<uint> CbTaskNew;
        protected readonly ConcurrentDictionary<object, object> ReportArray = new ConcurrentDictionary<object, object>();
        private uint _acsHandle;
        private NativeMethods.ACSEventCallBack _callBackAnkor;
        private int _invokeId;
        private StatusConection _statusConnection = StatusConection.Close;

       /* protected ConcurrentDictionary<string, MonitorEventAgentCollection> Agents =
            new ConcurrentDictionary<string, MonitorEventAgentCollection>();*/

        protected string ApiVersion;
        protected string AppName;
        protected bool Blocked;
        protected AcsEventCallBack CbEvent;
        protected bool Disposed;
        protected object InvokeIDlock = new object();
        protected string Login;
        protected IAsyncResult MainLoopResult;

        protected ConcurrentDictionary<int, MonitorEventCollection> Monitors =
            new ConcurrentDictionary<int, MonitorEventCollection>();

        protected string Password;
        protected string PrivateVersion;
        public ushort RecvExtraBufs = 0;
        public ushort RecvQSize = 400;
        public ushort SendExtraBufs = 0;
        public ushort SendQSize = 200;
        protected string Server;

        public Event()
        {
            CbTaskNew = new CbTask<uint>(SendQSize);
            Log.DebugFormat("{0} : Constructor", LinkName);
           
        }

        public Event(string server, string login, string password, string appName, string apiVersion,
            string privateVersion)
            : this()
        {
            Server = server;
            Login = login;
            Password = password;
            AppName = appName;
            ApiVersion = apiVersion;
            PrivateVersion = privateVersion;
        }

        public uint AcsHandle
        {
            get
            {
                lock (this)
                {
                    return _acsHandle;
                }
            }
            set
            {
                lock (this)
                {
                    _acsHandle = value;
                }
            }
        }

        private Timer _timerWakUp;
        public uint InvokeId
        {
            get
            {
                lock (InvokeIDlock)
                {
                    if (Blocked)
                    {
                        Thread.Sleep(100);
                        Log.DebugFormat("Blocked {0} to 100 ms", LinkName);
                    }
                    var ret = (uint) Interlocked.Increment(ref _invokeId);
                    if (ret > 32000) _invokeId = 0;
                    
                    _timerWakUp.Change(60*1000,60*1000*10);
 ;                   return ret;
                }
            }
        }

        public StatusConection StatusConnection
        {
            get
            {
                _rw.AcquireReaderLock(Timeout);
                var ret = _statusConnection;
                _rw.ReleaseReaderLock();
                return ret;
            }
            set
            {
                _rw.AcquireWriterLock(Timeout);
                _statusConnection = value;
                _rw.ReleaseWriterLock();
            }
        }

        public string LinkName => AppName;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected ATTUserToUserInfo_t GetUuiFromString(string info)
        {
            var info2 = new ATTUserToUserInfo_t();
            if (!string.IsNullOrEmpty(info))
            {
                info2.data = new ATTUserToUserInfo_Data
                {
                    length = (ushort) info.Length,
                    value = info
                };
                info2.type = ATTUUIProtocolType_t.uuiIa5Ascii;
            }
            return info2;
        }

        public event DelegateConnected OnConnnectedEvent;
        public event DelegateClosed OnClosedEvent;
        public event DelegateUniversalFailure OnUniversalFailureEvent;
        public event DelegateUniversalFailureSys OnUniversalFailureSysEvent;

        ~Event()
        {
            
            Dispose(false);
        }


        static public T DeepCopy<T>(T obj)
        {
            BinaryFormatter s = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                s.Serialize(ms, obj);
                ms.Position = 0;
                T t = (T)s.Deserialize(ms);

                return t;
            }
        }

        //  [SecurityPermission(SecurityAction.Demand, UnmanagedCode = true)]
        protected void EventCallBack(int lParam)
        {

            if (AcsHandle == 0) return;
            try
            {
                const int size = 1040*4;
                var pd = new PrivateData_t {length = size};
           
                var ptrCsta = Marshal.AllocHGlobal(size);
                var ptrPd = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(pd, ptrPd, true);
                try
                {
                    ushort count;
                    do
                    {


                        var tt = NativeMethods.acsGetEventPoll(AcsHandle, ptrCsta, ref pd.length,
                            ptrPd, out count);
                        if (tt == ACSFunctionRet_t.ACSPOSITIVE_ACK)
                        {
                            var cstaEvent = new CSTAEvent_t(ptrCsta);
                            var attEvent = new ATTEvent_t();

                            if (
                                NativeMethods.attPrivateData(ptrPd, ptrCsta) ==
                                ACSFunctionRet_t.ACSPOSITIVE_ACK)
                            {
                                attEvent = new ATTEvent_t(ptrCsta);
                            }

                            var csta = DeepCopy(cstaEvent);
                            var att = DeepCopy(attEvent);
                            switch (csta.eventHeader.eventClass)
                            {
                                case EventClass_t.ACSCONFIRMATION:
                                    Acsconfirmation(csta.acsConfirmation, csta.eventHeader.eventTypeACS);
                                    break;
                                case EventClass_t.ACSUNSOLICITED:
                                    Acsunsolicited(csta.acsUnsolicited, csta.eventHeader.eventTypeACS);
                                    break;
                                case EventClass_t.CSTACONFIRMATION:
                                    Cstaconfirmation(csta.cstaConfirmation, att,
                                        csta.eventHeader.eventTypeCSTA);
                                    break;
                                case EventClass_t.CSTAEVENTREPORT:
                                    Cstaeventreport(csta.cstaEventReport, att,
                                        csta.eventHeader.eventTypeCSTA);
                                    break;
                                case EventClass_t.CSTAREQUEST:
                                    Cstarequest(csta.cstaRequest, att,
                                        csta.eventHeader.eventTypeCSTA);
                                    break;
                                case EventClass_t.CSTAUNSOLICITED:
                                    Cstaunsolicited(csta.cstaUnsolicited, att,
                                        csta.eventHeader.eventTypeCSTA);
                                    break;
                            }

                        }
                        else
                        {
                            if (tt != ACSFunctionRet_t.ACSERR_NOMESSAGE && tt != ACSFunctionRet_t.ACSERR_BADHDL)
                            {
                                Log.Error(new Exeption("acsGetEventPoll", tt));
                            }
                            return;
                        }
                    } while (count > 0);


                }
                catch (Exception ex)
                {
                    Log.Error("EventCallBack", ex);
                }
                finally
                {
                    Marshal.FreeHGlobal(ptrCsta);
                    Marshal.FreeHGlobal(ptrPd);
                  /*  ptrCsta.Free();
                    ptrPd.Free();
                    */
                }
            }catch(Exception ex)
            {
                Log.Error("EventCallBack", ex);
            }
        }

        protected Task<TRet> CreateTask<TRet>(Func<uint, PrivateData_t, ACSFunctionRet_t> functFunc,
            string commandDescription = "")
        {
            var invokeId = InvokeId;
            var pd = new PrivateData_t();
            var t = CbTaskNew.Add(invokeId,command: commandDescription);
        //    Thread.Sleep(5000);
            var ret = functFunc(invokeId, pd);
            if (ret != ACSFunctionRet_t.ACSPOSITIVE_ACK && StatusConnection == StatusConection.Open)
            {
                CbTaskNew.Set(invokeId, default(TRet));
                switch (ret)
                {
                    case ACSFunctionRet_t.ACSERR_APIVERDENIED:
                    case ACSFunctionRet_t.ACSERR_UNKNOWN:
                        break;
                    case ACSFunctionRet_t.ACSERR_NOBUFFERS:
                    case ACSFunctionRet_t.ACSERR_QUEUE_FULL:
                        Blocked = true;
                        break;
                    default:
                        AbortStream();
                        AlertClose();
                        break;
                }
                throw new Exeption(ret);
            }
            Blocked = false;
            /*t.ContinueWith(task =>
            {
                var ex = task.Exception;
                if (ex == null) return;
                foreach (var exc in ex.Flatten().InnerExceptions)
                {
                    Log.Error(commandDescription, exc);
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            return t.ContinueWith(task =>
                (TRet) task.Result);*/

            return t.ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    var ex = task.Exception;
                    if (ex != null)
                    {
                        foreach (var exc in ex.Flatten().InnerExceptions)
                        {
                            Log.Error(commandDescription, exc);
                        }
                        throw ex;
                    }
                }
                return (TRet) task.Result;
            });
        }

        public Task<ApiCapsEventReturn> GetApiCaps()
        {
            return CreateTask<ApiCapsEventReturn>((u, t) => NativeMethods.cstaGetAPICaps(AcsHandle, u), "GetAPICaps");
        }
        private void Callback(object state)
        {
            GetApiCaps();
        }
        public void OpenStream()
        {
            _timerWakUp = new Timer(Callback, this, 60 * 1000, 60 * 1000 * 10);
            Log.DebugFormat("{0} : Open stream ", LinkName);
            _acsHandle = 0;
            _invokeId = 0;
            if (MainLoopResult != null)
            {
                Log.DebugFormat("{0} : Wait last main_loop_result", LinkName);
                MainLoopResult.AsyncWaitHandle.WaitOne(10000);
                MainLoopResult = null;
            }
            _callBackAnkor = EventCallBack;
            ACSFunctionRet_t ret;
            lock (GlobalLock)
            {
                var pd = new PrivateData_t {vendor = "VERSION"};
                pd.Set(PrivateVersion);
                ret = NativeMethods.acsOpenStream(
                    out _acsHandle,
                    InvokeIDType_t.APP_GEN_ID,
                    0,
                    StreamType_t.stCsta,
                    Server,
                    Login,
                    Password,
                    AppName,
                    0,
                    ApiVersion,
                    SendQSize,
                    SendExtraBufs,
                    RecvQSize,
                    RecvExtraBufs,
                    ref pd
                    );
            }
            if (ret == ACSFunctionRet_t.ACSPOSITIVE_ACK)
                NativeMethods.acsSetESR(_acsHandle, _callBackAnkor, 0, true);

            _waitClient.WaitOne();
            foreach (var monitorEventCollection in Monitors)
            {
                monitorEventCollection.Value.Dispose();
            }
            Monitors.Clear();
        }

      

        public void CloseStream()
        {
            Log.DebugFormat("{0} : Close stream ", LinkName);
            StatusConnection = StatusConection.Close;
            if (_acsHandle != 0)
            {
                CreateTask<object>((key, pd) => NativeMethods.acsCloseStream(AcsHandle, key, ref pd));
            }
        }

        public void AbortStream()
        {
            Log.DebugFormat("{0} : Abort stream ", LinkName);
            StatusConnection = StatusConection.Close;
            if (_acsHandle != 0)
            {
                var pd = new PrivateData_t();
                NativeMethods.acsAbortStream(AcsHandle, ref pd);
                /*if (ret != ACSFunctionRet_t.ACSPOSITIVE_ACK)
                {
                    throw new Exeption("AbortStream", ret);
                }*/
            }
            AlertClose();
        }

        protected void AnalizeFailurs(ACSUniversalFailure_t error)
        {
            switch (error)
            {
                case ACSUniversalFailure_t.tserverStreamFailed:
                case ACSUniversalFailure_t.tserverNoThread:
                case ACSUniversalFailure_t.tserverDeadDriver:
                case ACSUniversalFailure_t.tserverBadStreamType:
                case ACSUniversalFailure_t.tserverNoNdsOamPermission:
                case ACSUniversalFailure_t.tserverOpenSdbLogFailed:
                case ACSUniversalFailure_t.tserverInvalidLogSize:
                case ACSUniversalFailure_t.tserverWriteSdbLogFailed:
                case ACSUniversalFailure_t.tserverNtFailure:
                case ACSUniversalFailure_t.tserverRegistrationFailed:
                case ACSUniversalFailure_t.tserverBadPwEncryption:
                case ACSUniversalFailure_t.tserverNoVersion:
                case ACSUniversalFailure_t.tserverBadPdu:
                case ACSUniversalFailure_t.tserverBadConnection:
                case ACSUniversalFailure_t.tserverDecodeFailed:
                case ACSUniversalFailure_t.tserverEncodeFailed:
                case ACSUniversalFailure_t.tserverNoMemory:
                case ACSUniversalFailure_t.tserverSpxFailed:
                case ACSUniversalFailure_t.tserverReceiveFromDriver:
                case ACSUniversalFailure_t.tserverSendToDriver:
                case ACSUniversalFailure_t.tserverFreeBufferFailed:
                case ACSUniversalFailure_t.tserverBadServerid:
                case ACSUniversalFailure_t.tserverRequiredModulesNotLoaded:
                case ACSUniversalFailure_t.tserverLoadLibFailed:
                case ACSUniversalFailure_t.tserverInvalidDriver:
                case ACSUniversalFailure_t.tserverDriverLoaded:
                case ACSUniversalFailure_t.tserverBadDriverProtocol:
                    Log.ErrorFormat("{0} : Error ACSUniversalFailure_t : {1} ", LinkName, error);
                    AbortStream();
                    break;
            }
        }

        protected void AlertClose()
        {
            StatusConnection = StatusConection.Close;
            _acsHandle = 0;
            _invokeId = 0;
            OnClosedEvent?.Invoke(this, null);
        }

        protected void Acsconfirmation(ACSConfirmationEvent data, eventTypeACS eventType)
        {
            switch (eventType)
            {
                case eventTypeACS.ACS_ABORT_STREAM:
                    AlertClose();
                    break;

                case eventTypeACS.ACS_CLOSE_STREAM_CONF:
                    AlertClose();
                    break;

                case eventTypeACS.ACS_OPEN_STREAM_CONF:
                    OnConnnectedEvent?.Invoke(this, null);
                    CbTaskNew.Set(data.invokeID, new NullTsapiReturn());
                    StatusConnection = StatusConection.Open;
                    _waitClient.Set();
                    break;

                case eventTypeACS.ACS_UNIVERSAL_FAILURE_CONF:
                    if (OnUniversalFailureEvent != null)
                    {
                        OnUniversalFailureSysEvent?.Invoke(this,
                            new UniversalFailureSys {Error = data.failureEvent.error, EventType = eventType});
                    }
                    CbTaskNew.Clear();
                    AnalizeFailurs(data.failureEvent.error);
                    break;

                default:
                    Log.Error($"{LinkName} : Error ACSCONFIRMATION  ",
                        new ProgrammingExeption($"Не обработан event '{eventType}' в ACSCONFIRMATION"));
                    throw new ProgrammingExeption($"Не обработан event '{eventType}' в ACSCONFIRMATION");
            }
        }

        protected void Acsunsolicited(AcsUnsolicitedEvent data, eventTypeACS eventType)
        {
            AnalizeFailurs(data.failureEvent.error);

            if (OnUniversalFailureEvent != null)
            {
                OnUniversalFailureSysEvent?.Invoke(this,
                    new UniversalFailureSys {Error = data.failureEvent.error, EventType = eventType});
            }
        }

        protected void Cstaconfirmation(CstaConfirmationEvent data, ATTEvent_t attPd, eventTypeCSTA eventType)
        {
            if (eventType == eventTypeCSTA.CSTA_UNIVERSAL_FAILURE_CONF)
            {
                CbTaskNew.SetError(data.invokeID, data.universalFailure.error);
                return;
            }
            object ret;

            switch (eventType)
            {
                case eventTypeCSTA.CSTA_QUERY_DEVICE_INFO_CONF:
                    ret = new QueryDeviceInfoReturn(data, attPd);
                    break;
                case eventTypeCSTA.CSTA_MAKE_CALL_CONF:
                    ret = new MakeCallEventReturn(data, attPd);
                    break;
                case eventTypeCSTA.CSTA_CONSULTATION_CALL_CONF:
                    ret = new ConsultationCallEventReturn(data, attPd);
                    break;
                case eventTypeCSTA.CSTA_MAKE_PREDICTIVE_CALL_CONF:
                    ret = new MakePredictiveCallEventReturn(data, attPd);
                    break;
                case eventTypeCSTA.CSTA_TRANSFER_CALL_CONF:
                    ret = new TransferCallEventReturn(data, attPd);
                    break;
                case eventTypeCSTA.CSTA_QUERY_AGENT_STATE_CONF:
                    ret = new QueryAgentStateEventReturn(data, attPd);
                    break;
                case eventTypeCSTA.CSTA_QUERY_LAST_NUMBER_CONF:
                    ret = new QueryLastNumberEventReturn(data);
                    break;
                case eventTypeCSTA.CSTA_MONITOR_CONF:
                    ret = new SetupMonitorEventReturn(data, attPd);
                    break;
                case eventTypeCSTA.CSTA_CHANGE_MONITOR_FILTER_CONF:
                    ret = new ChangeMonitorFilterEventReturn(data);
                    break;
                case eventTypeCSTA.CSTA_SNAPSHOT_DEVICE_CONF:
                    ret = new SnapshotDeviceEventReturn(data, attPd);
                    break;
                case eventTypeCSTA.CSTA_SNAPSHOT_CALL_CONF:
                    ret = new SnapshotCallEventReturn(data, attPd);
                    break;
                case eventTypeCSTA.CSTA_QUERY_CALL_MONITOR_CONF:
                    ret = new QueryCallMonitorEventReturn(data);
                    break;
                case eventTypeCSTA.CSTA_GET_DEVICE_LIST_CONF:
                    ret = new GetDeviceListEventReturn(data);
                    break;
                case eventTypeCSTA.CSTA_GETAPI_CAPS_CONF:
                    ret = new ApiCapsEventReturn(data, attPd);
                    break;
                case eventTypeCSTA.CSTA_ESCAPE_SVC_CONF:
                    switch (attPd.eventType)
                    {
                        case TypeATTEvent.ATTQueryUcidConfEvent_t_PDU:
                            ret = new QueryUcidEventReturn(attPd);
                            break;
                        case TypeATTEvent.ATTQueryAcdSplitConfEvent_t_PDU:
                            ret = new QueryAcdSplitEventReturn(attPd);
                            break;
                        case TypeATTEvent.ATTQueryAgentLoginConfEvent_t_PDU:
                            ret = new QueryAgentLoginEventReturn(attPd);
                            var task = CbTaskNew.GeTask(data.invokeID);
                            if (task != null)
                            {
                                CbTaskForToPartNew.Add(((QueryAgentLoginEventReturn) ret).Att.privEventCrossRefID, task);
                            }
                            break;
                        default:
                            ret = new NullTsapiReturn();
                            break;
                    }
                    break;
                default:
                    ret = new NullTsapiReturn();
                    break;
            }

            CbTaskNew.Set(data.invokeID, ret);
        }

        protected void Cstaeventreport(CstaEventReport data, ATTEvent_t pd, eventTypeCSTA eventType)
        {
            switch (pd.eventType)
            {
                case TypeATTEvent.ATTQueryAgentLoginResp_t_PDU:
                    var crid = pd.queryAgentLoginResp.privEventCrossRefID;
                    if (pd.queryAgentLoginResp.list.count != 0)
                    {
                        var list =
                            pd.queryAgentLoginResp.list.list.Take(pd.queryAgentLoginResp.list.count)
                                .Select(_ => _.device)
                                .ToList();
                        ReportArray.AddOrUpdate(crid,
                            list,
                            (u, o) =>
                            {
                                var l = o as List<string>;
                                if (l != null)
                                    l.AddRange(list);
                                return (object) l;
                            });
                        CbTaskForToPartNew.UpdateTimeout(crid);
                    }
                    else
                    {
                        object obj;
                        var flag = ReportArray.TryRemove(crid, out obj);
                        CbTaskForToPartNew.Set(crid, flag ? obj : new List<string>());
                    }
                    break;
            }
        }

        protected void Cstarequest(CstaRequestEvent data, ATTEvent_t pd, eventTypeCSTA eventType)
        {
        }

        protected void Cstaunsolicited(CstaUnsolicitedEvent data, ATTEvent_t pd, eventTypeCSTA eventType)
        {
            MonitorEventCollection evnt;
            if (Monitors.TryGetValue((int) data.monitorCrossRefId, out evnt))
            {
                if (eventType == eventTypeCSTA.CSTA_DELIVERED)
                {
                }
                evnt.Invoke(data, eventType, pd, data.monitorCrossRefId);
                if (eventType == eventTypeCSTA.CSTA_MONITOR_STOP || eventType == eventTypeCSTA.CSTA_MONITOR_ENDED)
                {
                    Monitors.TryRemove((int) data.monitorCrossRefId, out evnt);
                    evnt.Dispose();
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            Log.DebugFormat("Wait command: {0}", CbTaskNew.CurrentCommand());
            Log.DebugFormat("{0} : Destructor", LinkName);
            if (Disposed) return;
            if (disposing)
            {
            }
            _timerWakUp.Dispose();
            _acsHandle = 0;

            try
            {
                _closed.Cancel(false);
                _closed.Dispose();
            }
            catch (ObjectDisposedException)
            {
                //Deleted object
            }
            foreach (var variable in CbTaskNew)
            {
                variable.Value.Set(null);
            }
            CbTaskNew.Clear();

            foreach (var variable in Monitors)
            {
                variable.Value.Dispose();
            }
            Monitors.Clear();

            /*foreach (var variable in Agents)
            {
                variable.Value.Dispose();
            }*/
           // Agents.Clear();
            CbEvent = null;
            _callBackAnkor = null;
        }

    }
}