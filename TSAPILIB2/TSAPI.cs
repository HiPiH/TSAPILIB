using System.Collections.Generic;
using System.Threading.Tasks;

namespace TSAPILIB2
{
    public class Tsapi : Event
    {
       public Tsapi(string server, string login, string password, string appName, string apiVersion,
            string privateVersion) :
                base(server, login, password, appName, apiVersion, privateVersion)
        {
         
        }
        
  


        public Task<QueryAcdSplitEventReturn> GetQueryAcdSplit(string deviceId)
        {
            return CreateTask<QueryAcdSplitEventReturn>((u, t) =>
                NativeMethods.attQueryAcdSplit(ref t, deviceId) |
                NativeMethods.cstaEscapeService(AcsHandle, u, ref t)
                , $"GetQueryAcdSplit('{deviceId}')");
          
        }


    

        public Task<QueryDeviceInfoReturn> GetQueryDeviceInfo(string device)
        {
         
            return CreateTask<QueryDeviceInfoReturn>((invokeId, pd) =>NativeMethods.cstaQueryDeviceInfo(AcsHandle, invokeId, device, ref pd),$"GetQueryDeviceInfo('{device}')");
        }

        public Task<GetDeviceListEventReturn> GetDeviceList(int index, CSTALevel_t level)
        {
            return CreateTask<GetDeviceListEventReturn>((invokeId, pd) =>NativeMethods.cstaGetDeviceList(AcsHandle, invokeId, index, level), $"GetDeviceList('{index}','{level}')");
        }


        public Task<QueryStationStatusEventReturn> GetQueryStationStatus(string deviceId)
        {


            return CreateTask<QueryStationStatusEventReturn>((invokeId, pd) =>
                NativeMethods.attQueryStationStatus(ref pd, deviceId) |
                NativeMethods.cstaEscapeService(AcsHandle, invokeId, ref pd)
                , $"GetQueryStationStatus('{deviceId}')"
                );
        }

        public Task<QueryUcidEventReturn> GetQueryUcid(ConnectionID_t call)
        {

            return CreateTask<QueryUcidEventReturn>((invokeId, pd) =>
                NativeMethods.attQueryUCID(ref pd, ref call) |
                NativeMethods.cstaEscapeService(AcsHandle, invokeId, ref pd), $"GetQueryUCID('{call}')"
                );
        }

        public Task<NullTsapiReturn> SetSendDtmfTone(ConnectionID_t call, string tone, int pauseDuartion)
        {


            var list = new ATTV4ConnIDList_t();
            return CreateTask<NullTsapiReturn>((invokeId, pd) =>
                NativeMethods.attSendDTMFTone(ref pd, ref call, ref list, tone, 0, 0) |
                NativeMethods.cstaEscapeService(AcsHandle, invokeId, ref pd), $"SetSendDTMFTone('{call}','{tone}','{pauseDuartion}')"
                );
        }

        public Task<MakeCallEventReturn> SetMakeCall(string callingDevice, string calledDevice, string destroute,
            bool priorityCall, string info)
        {
            return CreateTask<MakeCallEventReturn>((invokeId, pd) =>
            {
                var info2 = GetUuiFromString(info);
                var ret = NativeMethods.attV6MakeCall(ref pd, destroute, priorityCall, ref info2) |
                          NativeMethods.cstaMakeCall(AcsHandle, invokeId, callingDevice, calledDevice, ref pd);
                return ret;
            },$"SetMakeCall('{callingDevice}','{calledDevice}','{destroute}','{priorityCall}','{info}')"
                );
        }

        public Task<NullTsapiReturn> SetAlternateCall(ConnectionID_t activeCall, ConnectionID_t otherCall)
        {
            
            return CreateTask<NullTsapiReturn>((invokeId, pd) =>
                NativeMethods.cstaAlternateCall(AcsHandle, invokeId, ref activeCall, ref otherCall, ref pd)
                , $"SetAlternateCall('{activeCall}','{otherCall}')"
                );
        }

        public Task<NullTsapiReturn> SetAnswerCall(ConnectionID_t allertingCall)
        {


            return CreateTask<NullTsapiReturn>((invokeId, pd) =>
                NativeMethods.cstaAnswerCall(AcsHandle, invokeId, ref allertingCall, ref pd)
                , $"SetAnswerCall('{allertingCall}')"
                );
        }

        public Task<NullTsapiReturn> SetCallCompletion(ConnectionID_t call, Feature_t feature)
        {

            return CreateTask<NullTsapiReturn>((invokeId, pd) =>
                NativeMethods.cstaCallCompletion(AcsHandle, invokeId, feature, ref call, ref pd), $"SetCallCompletion('{call}','{feature}')"
                );
        }

        public Task<NullTsapiReturn> SetClearCall(ConnectionID_t call)
        {
            return CreateTask<NullTsapiReturn>((invokeId, pd) =>
                NativeMethods.cstaClearCall(AcsHandle, invokeId, ref call, ref pd)
                , $"SetClearCall('{call}')"
                );
        }

        public Task<NullTsapiReturn> SetClearConnection(ConnectionID_t call, ATTDropResource_t resourse,
            string info)
        {
  
            return CreateTask<NullTsapiReturn>((invokeId, pd) =>
            {
                var info2 = GetUuiFromString(info);
                return NativeMethods.attV6ClearConnection(ref pd, resourse, ref info2) |
                NativeMethods.cstaClearConnection(AcsHandle, invokeId, ref call, ref pd);
            }                , $"SetClearConnection('{call}','{resourse}','{info}')"
                );
        }

        public Task<ConferenceCallEventReturn> SetConferenceCall(ConnectionID_t activeCall, ConnectionID_t otherCall)
        {


            return CreateTask<ConferenceCallEventReturn>((invokeId, pd) =>
                NativeMethods.cstaConferenceCall(AcsHandle, invokeId, ref otherCall, ref activeCall, ref pd)
                , $"SetConferenceCall('{activeCall}','{otherCall}')"
                );
        }

        public Task<ConsultationCallEventReturn> SetConsultationCall(ConnectionID_t activeCall, string calledDevice,
            string destRoute, bool priorityCalling, string info)
        {

            return CreateTask<ConsultationCallEventReturn>((invokeId, pd) =>
            {
                var info2 = GetUuiFromString(info);
                var ret = NativeMethods.attV6ConsultationCall(ref pd, destRoute, priorityCalling, ref info2) |
                          NativeMethods.cstaConsultationCall(AcsHandle, invokeId, ref activeCall, calledDevice, ref pd);
                return ret;
            },$"SetConsultationCall('{activeCall}','{calledDevice}','{destRoute}','{priorityCalling}','{info}')"
                );
        }

        public Task<NullTsapiReturn> SetDeflectCall(ConnectionID_t deflectCall, string calledDevice)
        {
            return CreateTask<NullTsapiReturn>((invokeId, pd) =>
                NativeMethods.cstaDeflectCall(AcsHandle, invokeId, ref deflectCall, calledDevice, ref pd)
                , $"SetDeflectCall('{deflectCall}','{calledDevice}')"
                );
        }

        public Task<NullTsapiReturn> SetGroupPickupCall(ConnectionID_t deflectCall, string pickupDevice)
        {
            
            return CreateTask<NullTsapiReturn>((invokeId, pd) =>
                NativeMethods.cstaGroupPickupCall(AcsHandle, invokeId, ref deflectCall, pickupDevice, ref pd)
                , $"SetGroupPickupCall('{deflectCall}','{pickupDevice}')"
                );
        }

        public Task<NullTsapiReturn> SetHoldCall(ConnectionID_t activeCall)
        {
            return CreateTask<NullTsapiReturn>((invokeId, pd) =>
                NativeMethods.cstaHoldCall(AcsHandle, invokeId, ref activeCall, false, ref pd)
                , $"SetHoldCall('{activeCall}')"
                );
        }

        public Task<MakePredictiveCallEventReturn> SetMakePredictiveCall(string callingDevice, string calledDevice,
            AllocationState_t allocationState, string destRoute, bool priorityCalling, short maxRing,
            ATTAnswerTreat_t answerTreat, string info)
        {
            return CreateTask<MakePredictiveCallEventReturn>((invokeId, pd) =>
            {
                var info2 = GetUuiFromString(info);
                return NativeMethods.attV6MakePredictiveCall(ref pd, priorityCalling, maxRing, answerTreat, destRoute, ref info2) |
                NativeMethods.cstaMakePredictiveCall(AcsHandle, invokeId, callingDevice, calledDevice, allocationState,
                    ref pd);
            },$"SetMakePredictiveCall('{callingDevice}','{calledDevice}','{allocationState}','{destRoute}','{priorityCalling}','{maxRing}','{answerTreat}','{info}')");
        }

        public Task<NullTsapiReturn> SetPickupCall(ConnectionID_t deflectCall, string calledDevice)
        {
            return CreateTask<NullTsapiReturn>((invokeId, pd) =>
                NativeMethods.cstaPickupCall(AcsHandle, invokeId, ref deflectCall, calledDevice, ref pd), $"SetPickupCall('{deflectCall}','{calledDevice}')"
                );
        }

        public Task<NullTsapiReturn> SetReconnectCall(ConnectionID_t activeCall, ConnectionID_t heldCall,
            ATTDropResource_t resource, string info)
        {
            return CreateTask<NullTsapiReturn>((invokeId, pd) =>
            {
                var info2 = GetUuiFromString(info);
                return NativeMethods.attV6ReconnectCall(ref pd, resource, ref info2) |
                       NativeMethods.cstaReconnectCall(AcsHandle, invokeId, ref activeCall, ref heldCall, ref pd);
            }, $"SetReconnectCall('{activeCall}','{heldCall}','{resource}','{info}')");  
        }

        public Task<NullTsapiReturn> SetRetrieveCall(ConnectionID_t heldCall)
        {
            return CreateTask<NullTsapiReturn>((invokeId, pd) => NativeMethods.cstaRetrieveCall(AcsHandle, invokeId, ref heldCall, ref pd), $"SetRetrieveCall('{heldCall}')");
        }

        public Task<TransferCallEventReturn> SetTransferCall(ConnectionID_t activeCall, ConnectionID_t heldCall)
        {
            return CreateTask<TransferCallEventReturn>((invokeId, pd) =>
                NativeMethods.cstaTransferCall(AcsHandle, invokeId, ref activeCall, ref heldCall, ref pd), $"SetTransferCall('{activeCall}','{heldCall}')"
                );
        }

        public Task<NullTsapiReturn> SetSetMsgWaitingInd(string deviceId, bool messages)
        {
            return CreateTask<NullTsapiReturn>((invokeId, pd) =>
                NativeMethods.cstaSetMsgWaitingInd(AcsHandle, invokeId, deviceId, messages, ref pd)
                , $"SetSetMsgWaitingInd('{deviceId}','{messages}')"
                );
        }

        public Task<NullTsapiReturn> SetAgentState(string deviceId, string agentId, string agentGroup, string lpassword,
            AgentMode_t mode, ATTWorkMode_t wmode, int reasonCode)
        {
            return CreateTask<NullTsapiReturn>((invokeId, pd) =>
                NativeMethods.attSetAgentStateExt(ref pd, wmode, reasonCode) |
                NativeMethods.cstaSetAgentState(AcsHandle, invokeId, deviceId, mode, agentId, agentGroup, lpassword,
                    ref pd) , $"SetAgentState('{deviceId}','{agentId}','{agentGroup}','{lpassword}','{mode}','{wmode}','{reasonCode}')"
                );
        }

        public Task<QueryMsgWaitingEventReturn> GetQueryMsgWaitingInd(string deviceId)
        {
            return CreateTask<QueryMsgWaitingEventReturn>((invokeId, pd) =>
                NativeMethods.cstaQueryMsgWaitingInd(AcsHandle, invokeId, deviceId, ref pd)
                , $"GetQueryMsgWaitingInd('{deviceId}')"
                );
        }

        public Task<QueryAgentStateEventReturn> GetQueryAgentState(string deviceId)
        {
            return CreateTask<QueryAgentStateEventReturn>((invokeId, pd) =>
                NativeMethods.cstaQueryAgentState(AcsHandle, invokeId, deviceId, ref pd)
                , $"GetQueryAgentState('{deviceId}')"
                ) /*
                   MonitorEventAgentCollection evnt;
                    if (Agents.TryGetValue(deviceId, out evnt))
                    {
                        evnt.Invoke(task.Result.Csta, task.Result.Att);
                    }
                    return task.Result;
                })*/;
        }

        public Task<QueryLastNumberEventReturn> GetQueryLastNumber(string deviceId)
        {
            return CreateTask<QueryLastNumberEventReturn>((invokeId, pd) =>
                NativeMethods.cstaQueryLastNumber(AcsHandle, invokeId, deviceId, ref pd)
                , $"GetQueryLastNumber('{deviceId}')"
                );
        }


        public Task<NullTsapiReturn> SetMonitorStop(uint monitorCrossId)
        {
        //if (Monitors.ContainsKey((int) monitorCrossId))
            
                return
                    CreateTask<NullTsapiReturn>(
                        (invokeId, pd) =>NativeMethods.cstaMonitorStop(AcsHandle, invokeId, monitorCrossId, ref pd),
                        $"SetMonitorStop('{monitorCrossId}')")
                        .ContinueWith(task =>
                        {
                            MonitorEventCollection evnt;
                            if (!Monitors.TryGetValue((int) monitorCrossId, out evnt)) return task.Result;
                            evnt.MonitorEndedInvoke(new CSTAMonitorEndedEvent_t(), monitorCrossId);
                            Monitors.TryRemove((int) monitorCrossId, out evnt);
                            evnt.Dispose();
                            return task.Result;
                        });
        }

        public Task<ChangeMonitorFilterEventReturn> SetChangeMonitorFilter(uint monitorCrossId,
            CSTAMonitorFilter_t filter)
        {
            return CreateTask<ChangeMonitorFilterEventReturn>((invokeId, pd) =>
                NativeMethods.cstaChangeMonitorFilter(AcsHandle, invokeId, monitorCrossId, ref filter, ref pd)
                , $"SetChangeMonitorFilter('{monitorCrossId}','{filter}')"
                );
        }

        public Task<SnapshotCallEventReturn> SetSnapshotCallReq(ConnectionID_t call)
        {
            return CreateTask<SnapshotCallEventReturn>((invokeId, pd) =>
                NativeMethods.cstaSnapshotCallReq(AcsHandle, invokeId, ref call, ref pd)
                , $"SetSnapshotCallReq('{call}')"
                );
        }

        public Task<SnapshotDeviceEventReturn> SetSnapshotDeviceReq(string deviceId)
        {

            return CreateTask<SnapshotDeviceEventReturn>((invokeId, pd) =>
                NativeMethods.cstaSnapshotDeviceReq(AcsHandle, invokeId, deviceId, ref pd)
                , $"SetSnapshotDeviceReq('{deviceId}')"
                );
        }

        public Task<List<string>> GetQueryAgentLogin(string deviceId)
        {
            return CreateTask<List<string>>((invokeId, pd) =>
                NativeMethods.attQueryAgentLogin(ref pd, deviceId) |
                NativeMethods.cstaEscapeService(AcsHandle, invokeId, ref pd)
                , $"GetQueryAgentLogin('{deviceId}')"
                );
        }


        public Task<QueryCallMonitorEventReturn> SetQueryCallMonitor(string deviceId)
        {

            return CreateTask<QueryCallMonitorEventReturn>((invokeId, pd) =>
                NativeMethods.cstaQueryCallMonitor(AcsHandle, invokeId)
                , $"SetQueryCallMonitor('{deviceId}')"
                );
        }

        public Task<MonitorEventCollection> SetMonitorDevice(string deviceId, CSTAMonitorFilter_t filter)
        {
            return CreateTask<SetupMonitorEventReturn>((invokeId, pd) =>
                NativeMethods.cstaMonitorDevice(AcsHandle, invokeId, deviceId, ref filter, ref pd)
                , $"SetMonitorDevice('{deviceId}','{filter}')"
                ).ContinueWith(task =>
                {
                    var monitoEvent = new MonitorEventCollection(task.Result.Csta.monitorCrossRefID, deviceId);
                    Monitors.TryAdd((int) task.Result.Csta.monitorCrossRefID, monitoEvent);
                    return monitoEvent;
                });
        }

        public Task<MonitorEventCollection> SetMonitorCall(ConnectionID_t call, CSTAMonitorFilter_t filter)
        {
            return CreateTask<SetupMonitorEventReturn>((invokeId, pd) =>
                NativeMethods.cstaMonitorCall(AcsHandle, invokeId, ref call, ref filter, ref pd)
                , $"SetMonitorCall('{call}','{filter}')"
                ).ContinueWith(task =>
                {
                    var monitoEvent = new MonitorEventCollection(task.Result.Csta.monitorCrossRefID, call);
                    Monitors.TryAdd((int) task.Result.Csta.monitorCrossRefID, monitoEvent);
                    return monitoEvent;
                });
        }

        public Task<MonitorEventCollection> SetMonitorCallsViaDevice(string deviceId, CSTAMonitorFilter_t filter)
        {
            return CreateTask<SetupMonitorEventReturn>((invokeId, pd) =>
                NativeMethods.cstaMonitorCallsViaDevice(AcsHandle, invokeId, deviceId, ref filter, ref pd)
                , $"SetMonitorCallsViaDevice('{deviceId}','{filter}')"
                ).ContinueWith(task =>
                {
                    var monitoEvent = new MonitorEventCollection(task.Result.Csta.monitorCrossRefID, deviceId);
                    Monitors.TryAdd((int) task.Result.Csta.monitorCrossRefID, monitoEvent);
                    return monitoEvent;
                });
        }

      /*  public MonitorEventAgentCollection SetMonitorAgent(string agentId)
        {
            if (StatusConnection != StatusConection.Open) return null;
            GetQueryAgentState(agentId);
            var mon = new MonitorEventAgentCollection(this, agentId, Agents.Count);
            if (!Agents.TryAdd(agentId, mon))
            {
                mon.Dispose();
                Agents.TryGetValue(agentId, out mon);
            }
            return mon;
        }

        public void SetMonitorAgentStop(string agentId)
        {
            if (StatusConnection != StatusConection.Open) return;
            MonitorEventAgentCollection mon;
            Agents.TryRemove(agentId, out mon);
            mon.Dispose();
        }
        */
        protected override void Dispose(bool disposing)
        {
            if (Disposed) return;
            if (disposing)
            {
                StatusConnection = StatusConection.Close;
            }


            base.Dispose(false);
        }
    }
}