using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using log4net;

namespace TSAPILIB2
{

    class NativeMethods
    {

        public static readonly ILog Log = LogManager.GetLogger(typeof(NativeMethods)); 
        public static T GetStruct<T>(byte[] body)
        {
            if (body == null || body.Length == 0)
            { 
                return default(T);
            }
            var adr = Marshal.UnsafeAddrOfPinnedArrayElement(body, 0);

            try
            {
                return (T)Marshal.PtrToStructure(adr, typeof(T));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            return default (T);
        }

        public struct SafeArrasyPoint
        {
            public uint count;
            public IntPtr point;
        }

        public static List<T> GetArrayStruct<T>(IntPtr point)
        {
            var t = Marshal.PtrToStructure<SafeArrasyPoint>(point);
            if (t.count > 0)
                return GetArrayStruct<T>(t.point, t.count);
            return new List<T>();
        }
        public static List<T> GetArrayStruct<T>(IntPtr point, uint count)
        {

            var ret = new List<T>();
            if (point != IntPtr.Zero)
            for (var x = 0; x < count; x++)
            {
                try
                {
                    ret.Add(
                        (T)
                        Marshal.PtrToStructure(
                            IntPtr.Add(point, x*Marshal.SizeOf(typeof (T))),
                            typeof (T))
                        );
                }
                catch (Exception ex)
                {
                   Log.Error(ex);
                }
            }
            return ret;
        }


        
        public static List<int> GetArrayInt(IntPtr point, uint count)
        {
            var ret = new List<int>();
            for (var x = 0; x < count; x++)
            {
                ret.Add(
                        Marshal.ReadInt32(IntPtr.Add(point, x * sizeof(int)))
                );
            }
            return ret;
        }
        public static List<T> GetArrayEnum<T>(IntPtr point, uint count)
        {
            var ret = new List<T>();
            for (var x = 0; x < count; x++)
            {
           
                    ret.Add(
                        (T)Enum.ToObject(typeof(T),
                            Marshal.ReadInt32(IntPtr.Add(point, x * sizeof(int)))
                            )
                    );
            }
            return ret;
        }
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void ACSEventCallBack(int lParam);

        [DllImport("Csta32.DLL", ExactSpelling = true)]
        public static extern ACSFunctionRet_t acsGetEventBlock(uint acsHandle, IntPtr eventBuf, ref ushort eventBufSize, ref PrivateData_t privData, out ushort numEvents);
        [DllImport("Csta32.DLL", ExactSpelling = true)]
        public static extern ACSFunctionRet_t acsGetEventPoll(uint acsHandle, IntPtr point, ref ushort eventBufSize, IntPtr privData, out ushort numEvents);
   
        [DllImport("Csta32.DLL",CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern ACSFunctionRet_t cstaQueryDeviceInfo(uint acsHandle, uint invokeId, [ MarshalAs ( UnmanagedType . LPStr )]string device, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t acsEnumServerNames(StreamType_t streamType, EnumServerNamesCb callback, uint lParam);


        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi, ExactSpelling = true)]
        public static extern ACSFunctionRet_t acsOpenStream(out uint acsHandle, InvokeIDType_t invokeIdType, uint invokeId, StreamType_t streamType, [ MarshalAs ( UnmanagedType . LPStr )]string serverId, [ MarshalAs ( UnmanagedType . LPStr )]string loginId, [ MarshalAs ( UnmanagedType . LPStr )]string passwd, [ MarshalAs ( UnmanagedType . LPStr )]string applicationName, Level_t acsLevelReq, [ MarshalAs ( UnmanagedType . LPStr )]string apiVer, ushort sendQSize, ushort sendExtraBufs, ushort recvQSize, ushort recvExtraBufs, ref PrivateData_t priv);



        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t acsCloseStream(uint acsHandle, UInt32 invokeId, ref PrivateData_t pd);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t acsAbortStream(uint acsHandle, ref PrivateData_t pd);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t acsFlushEventQueue(uint acsHandle);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t acsEventNotify(uint acsHandle, int hwnd, uint msg, bool notifyAll);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t acsSetESR(uint acsHandle, ACSEventCallBack cb, uint mesrParamsg, bool notifyAll);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t acsQueryAuthInfo([ MarshalAs ( UnmanagedType . LPStr )]string serverId, ref ACSAuthInfo_t authInfo);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaAlternateCall(uint acsHandle, uint invokeId, ref ConnectionID_t activeCall, ref ConnectionID_t otherCall, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaAnswerCall(uint acsHandle, uint invokeId, ref ConnectionID_t alertingCall, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaCallCompletion(uint acsHandle, uint invokeId, Feature_t feature, ref ConnectionID_t call, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaClearCall(uint acsHandle, uint invokeId, ref ConnectionID_t call, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaClearConnection(uint acsHandle, uint invokeId, ref ConnectionID_t call, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaConferenceCall(uint acsHandle, uint invokeId, ref ConnectionID_t heldCall, ref ConnectionID_t activeCall, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaConsultationCall(uint acsHandle, uint invokeId, ref ConnectionID_t activeCall, [ MarshalAs ( UnmanagedType . LPStr )]string calledDevice, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaDeflectCall(uint acsHandle, uint invokeId, ref ConnectionID_t deflectCall, [ MarshalAs ( UnmanagedType . LPStr )]string calledDevice, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaGroupPickupCall(uint acsHandle, uint invokeId, ref ConnectionID_t deflectCall, [ MarshalAs ( UnmanagedType . LPStr )]string pickupDevice, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaHoldCall(uint acsHandle, uint invokeId, ref ConnectionID_t activeCall, bool reservation, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL",CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaMakeCall(uint acsHandle, uint invokeId, [ MarshalAs ( UnmanagedType . LPStr )]string callingDevice, [ MarshalAs ( UnmanagedType . LPStr )]string calledDevice, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaMakePredictiveCall(uint acsHandle, uint invokeId, [ MarshalAs ( UnmanagedType . LPStr )]string callingDevice, [ MarshalAs ( UnmanagedType . LPStr )]string calledDevice, AllocationState_t allocationState, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaPickupCall(uint acsHandle, uint invokeId, ref ConnectionID_t deflectCall, [ MarshalAs ( UnmanagedType . LPStr )]string calledDevice, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaReconnectCall(uint acsHandle, uint invokeId, ref ConnectionID_t activeCall, ref ConnectionID_t heldCall, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaRetrieveCall(uint acsHandle, uint invokeId, ref ConnectionID_t heldCall, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaTransferCall(uint acsHandle, uint invokeId, ref ConnectionID_t heldCall, ref ConnectionID_t activeCall, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaSetMsgWaitingInd(uint acsHandle, uint invokeId, [ MarshalAs ( UnmanagedType . LPStr )]string device, bool messages, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaSetDoNotDisturb(uint acsHandle, uint invokeId, [ MarshalAs ( UnmanagedType . LPStr )]string device, byte doNotDisturb, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaSetForwarding(uint acsHandle, uint invokeId, [ MarshalAs ( UnmanagedType . LPStr )]string device, ForwardingType_t forwardingType, byte forwardingOn, [ MarshalAs ( UnmanagedType . LPStr )]string forwardingDestination, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaSetAgentState(uint acsHandle, uint invokeId, [ MarshalAs ( UnmanagedType . LPStr )]string device, AgentMode_t agentMode, [ MarshalAs ( UnmanagedType . LPStr )]string agentId, [ MarshalAs ( UnmanagedType . LPStr )]string agentGroup, [ MarshalAs ( UnmanagedType . LPStr )]string agentPassword, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaQueryMsgWaitingInd(uint acsHandle, uint invokeId, [ MarshalAs ( UnmanagedType . LPStr )]string device, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaQueryDoNotDisturb(uint acsHandle, uint invokeId, [ MarshalAs ( UnmanagedType . LPStr )]string device, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaQueryForwarding(uint acsHandle, uint invokeId, [ MarshalAs ( UnmanagedType . LPStr )]string device, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaQueryAgentState(uint acsHandle, uint invokeId, [ MarshalAs ( UnmanagedType . LPStr )]string device, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaQueryLastNumber(uint acsHandle, uint invokeId, [ MarshalAs ( UnmanagedType . LPStr )]string device, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaMonitorDevice(uint acsHandle, uint invokeId, [ MarshalAs ( UnmanagedType . LPStr )]string deviceId, ref CSTAMonitorFilter_t monitorFilter, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaMonitorCall(uint acsHandle, uint invokeId, ref ConnectionID_t call, ref CSTAMonitorFilter_t monitorFilter, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaMonitorCallsViaDevice(uint acsHandle, uint invokeId, [ MarshalAs ( UnmanagedType . LPStr )]string deviceId, ref CSTAMonitorFilter_t monitorFilter, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaChangeMonitorFilter(uint acsHandle, uint invokeId, uint monitorCrossRefId, ref CSTAMonitorFilter_t filterlist, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaMonitorStop(uint acsHandle, uint invokeId, uint monitorCrossRefId, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaSnapshotCallReq(uint acsHandle, uint invokeId, ref ConnectionID_t snapshotObj, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaSnapshotDeviceReq(uint acsHandle, uint invokeId, [ MarshalAs ( UnmanagedType . LPStr )]string snapshotObj, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaRouteRegisterReq(uint acsHandle, uint invokeId, [ MarshalAs ( UnmanagedType . LPStr )]string routingDevice, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaRouteRegisterCancel(uint acsHandle, uint invokeId, int routeRegisterReqId, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaRouteSelect(uint acsHandle, int routeRegisterReqId, int routingCrossRefId, [ MarshalAs ( UnmanagedType . LPStr )]string routeSelected, short remainRetry, ref SetUpValues_t setupInformation, byte routeUsedReq, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaRouteEnd(uint acsHandle, int routeRegisterReqId, int routingCrossRefId, CSTAUniversalFailure_t errorValue, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t cstaRouteSelectInv(uint acsHandle, uint invokeId, int routeRegisterReqId, int routingCrossRefId, [ MarshalAs ( UnmanagedType . LPStr )]string routeSelected, short remainRetry, ref SetUpValues_t setupInformation, byte routeUsedReq, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaRouteEndInv(uint acsHandle, uint invokeId, int routeRegisterReqId, int routingCrossRefId, CSTAUniversalFailure_t errorValue, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaEscapeService(uint acsHandle, uint invokeId, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaEscapeServiceConf(uint acsHandle, uint invokeId, CSTAUniversalFailure_t error, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaSendPrivateEvent(uint acsHandle, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaSysStatReq(uint acsHandle, uint invokeId, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaSysStatStart(uint acsHandle, uint invokeId, byte statusFilter, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaSysStatStop(uint acsHandle, uint invokeId, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaChangeSysStatFilter(uint acsHandle, uint invokeId, byte statusFilter, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaSysStatReqConf(uint acsHandle, uint invokeId, SystemStatus_t systemStatus, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaSysStatEvent(uint acsHandle, SystemStatus_t systemStatus, ref PrivateData_t privateData);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaGetAPICaps(uint acsHandle, uint invokeId);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaGetDeviceList(uint acsHandle, uint invokeId, int index, CSTALevel_t level);
        [DllImport("Csta32.DLL")]
        public static extern ACSFunctionRet_t cstaQueryCallMonitor(uint acsHandle, uint invokeId);






        [DllImport("ATTPRV32.DLL")]
        //public static extern ACSFunctionRet_t attPrivateData(ref PrivateData_t privateData, IntPtr eventBuffer);
        public static extern ACSFunctionRet_t attPrivateData(IntPtr privateData, IntPtr eventBuffer);




        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attMakeVersionstring([ MarshalAs ( UnmanagedType . LPStr )]string requestedVersion, [ MarshalAs ( UnmanagedType . LPStr )]string supportedVersion);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t encodePrivate(int pdunum, [ MarshalAs ( UnmanagedType . LPStr )]string pdu, ref PrivateData_t priv);
        [DllImport("ATTPRV32.DLL")]
      
        public static extern ACSFunctionRet_t attClearConnection(ref PrivateData_t privateData, ATTDropResource_t dropResource, ref ATTV5UserToUserInfo_t userInfo);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attConsultationCall(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string destRoute, bool priorityCalling, ref ATTV5UserToUserInfo_t userInfo);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attMakeCall(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string destRoute, bool priorityCalling, ref ATTV5UserToUserInfo_t userInfo);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attDirectAgentCall(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string split, bool priorityCalling, ref ATTV5UserToUserInfo_t userInfo);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attMakePredictiveCall(ref PrivateData_t privateData, bool priorityCalling, short maxRings, ATTAnswerTreat_t answerTreat, [ MarshalAs ( UnmanagedType . LPStr )]string destRoute, ref ATTV5UserToUserInfo_t userInfo);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attSupervisorAssistCall(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string split, ref ATTV5UserToUserInfo_t userInfo);
        [DllImport("ATTPRV32.DLL")]
        public static extern ACSFunctionRet_t attReconnectCall(ref PrivateData_t privateData, ATTDropResource_t dropResource, ref ATTV5UserToUserInfo_t userInfo);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attSendDTMFTone(ref PrivateData_t privateData, ref ConnectionID_t sender, ref ATTV4ConnIDList_t receivers, [ MarshalAs ( UnmanagedType . LPStr )]string tones, short toneDuration, short pauseDuration);
        [DllImport("ATTPRV32.DLL")]
        public static extern ACSFunctionRet_t attSetAgentState(ref PrivateData_t privateData, ATTWorkMode_t workMode);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attQueryAcdSplit(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string device);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attQueryAgentLogin(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string device);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attQueryAgentState(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string device);
        [DllImport("ATTPRV32.DLL")]
        public static extern ACSFunctionRet_t attQueryCallClassifier(ref PrivateData_t privateData);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attQueryDeviceName(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string device);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attQueryStationStatus(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string device);
        [DllImport("ATTPRV32.DLL")]
        public static extern ACSFunctionRet_t attQueryTimeOfDay(ref PrivateData_t privateData);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attQueryTrunkGroup(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string device);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attQueryAgentMeasurements(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string agentId, ATTAgentTypeID_t typeId, ATTSplitSkill_t splitSkill, ref ATTAgentMeasurementsPresent_t requestItems, short interval);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attQuerySplitSkillMeasurements(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string device, ref ATTSplitSkillMeasurementsPresent_t requestItems, short interval);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attQueryTrunkGroupMeasurements(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string device, ref ATTTrunkGroupMeasurementsPresent_t requestItems, short interval);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attQueryVdnMeasurements(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string device, ref ATTVdnMeasurementsPresent_t requestItems, short interval);
        [DllImport("ATTPRV32.DLL")]
        public static extern ACSFunctionRet_t attMonitorFilter(ref PrivateData_t privateData, byte privateFilter);
        [DllImport("ATTPRV32.DLL")]
        public static extern ACSFunctionRet_t attMonitorStopOnCall(ref PrivateData_t privateData, int monitorCrossRefId, ref ConnectionID_t call);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attRouteSelect(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string callingDevice, [ MarshalAs ( UnmanagedType . LPStr )]string directAgentCallSplit, byte priorityCalling, [ MarshalAs ( UnmanagedType . LPStr )]string destRoute, ref ATTUserCollectCode_t collectCode, ref ATTUserProvidedCode_t userProvidedCode, ref ATTV5UserToUserInfo_t userInfo);
        [DllImport("ATTPRV32.DLL")]
        public static extern ACSFunctionRet_t attSysStat(ref PrivateData_t privateData, byte linkStatusReq);


        
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attSingleStepConferenceCall(ref PrivateData_t privateData, ref ConnectionID_t activeCall, [ MarshalAs ( UnmanagedType . LPStr )]string deviceToBeJoin, ATTParticipationType_t participationType, byte alertDestination);
        [DllImport("ATTPRV32.DLL")]
        public static extern ACSFunctionRet_t attSelectiveListeningHold(ref PrivateData_t privateData, ref ConnectionID_t subjectConnection, byte allParties, ref ConnectionID_t selectedParty);
        [DllImport("ATTPRV32.DLL")]
        public static extern ACSFunctionRet_t attSelectiveListeningRetrieve(ref PrivateData_t privateData, ref ConnectionID_t subjectConnection, byte allParties, ref ConnectionID_t selectedParty);
        [DllImport("ATTPRV32.DLL")]
        public static extern ACSFunctionRet_t attSetAgentStateExt(ref PrivateData_t privateData, ATTWorkMode_t workMode, int reasonCode);
        [DllImport("ATTPRV32.DLL")]
        public static extern ACSFunctionRet_t attSetBillRate(ref PrivateData_t privateData, ref ConnectionID_t call, ATTBillType_t billType, float billRate);
        
        [DllImport("ATTPRV32.DLL")]
        public static extern ACSFunctionRet_t attQueryUCID(ref PrivateData_t privateData, ref ConnectionID_t call);

        [DllImport("ATTPRV32.DLL")]
        public static extern ACSFunctionRet_t attSetAdviceOfCharge(ref PrivateData_t privateData, byte flag);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attSendDTMFToneExt(ref PrivateData_t privateData, ref ConnectionID_t sender, ref ATTConnIDList_t receivers, [ MarshalAs ( UnmanagedType . LPStr )]string tones, short toneDuration, short pauseDuration);
        [DllImport("ATTPRV32.DLL")]
        public static extern ACSFunctionRet_t attMonitorFilterExt(ref PrivateData_t privateData, byte privateFilter);
        [DllImport("ATTPRV32.DLL")]
        public static extern ACSFunctionRet_t attV6SetAgentState(ref PrivateData_t privateData, ATTWorkMode_t workMode, int reasonCode, byte enablePending);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attV6MakeCall(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string destRoute, bool priorityCalling, ref ATTUserToUserInfo_t userInfo);
        [DllImport("ATTPRV32.DLL")]
        public static extern ACSFunctionRet_t attV6ClearConnection(ref PrivateData_t privateData, ATTDropResource_t dropResource, ref ATTUserToUserInfo_t userInfo);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attV6ConsultationCall(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string destRoute, bool priorityCalling, ref ATTUserToUserInfo_t userInfo);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attV6DirectAgentCall(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string split, byte priorityCalling, ref ATTUserToUserInfo_t userInfo);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attV6MakePredictiveCall(ref PrivateData_t privateData, bool priorityCalling, short maxRings, ATTAnswerTreat_t answerTreat, [ MarshalAs ( UnmanagedType . LPStr )]string destRoute, ref ATTUserToUserInfo_t userInfo);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attV6SupervisorAssistCall(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string split, ref ATTUserToUserInfo_t userInfo);
        [DllImport("ATTPRV32.DLL")]
        public static extern ACSFunctionRet_t attV6ReconnectCall(ref PrivateData_t privateData, ATTDropResource_t dropResource, ref ATTUserToUserInfo_t userInfo);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attV6RouteSelect(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string callingDevice, [ MarshalAs ( UnmanagedType . LPStr )]string directAgentCallSplit, byte priorityCalling, [ MarshalAs ( UnmanagedType . LPStr )]string destRoute, ref ATTUserCollectCode_t collectCode, ref ATTUserProvidedCode_t userProvidedCode, ref ATTUserToUserInfo_t userInfo);
        [DllImport("ATTPRV32.DLL", CharSet = CharSet.Ansi)]
        public static extern ACSFunctionRet_t attV7RouteSelect(ref PrivateData_t privateData, [ MarshalAs ( UnmanagedType . LPStr )]string callingDevice, [ MarshalAs ( UnmanagedType . LPStr )]string directAgentCallSplit, byte priorityCalling, [ MarshalAs ( UnmanagedType . LPStr )]string destRoute, ref ATTUserCollectCode_t collectCode, ref ATTUserProvidedCode_t userProvidedCode, ref ATTUserToUserInfo_t userInfo, ATTRedirectType_t networkredirect);





    }



    /********************************/

    public delegate void EnumServerNamesCb([ MarshalAs ( UnmanagedType . LPStr )]string serverName, ulong lParam);
    public delegate void AcsEventCallBack(ulong esrParam);
    public delegate void AcsSetEsrCallBack(ulong esrParam);





}
