using System;
using System.Linq;
using System.Runtime.InteropServices;


namespace TSAPILIB2
{
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct AcsUnsolicitedEvent
    {
        private readonly eventTypeACS _type;
        public ACSUniversalFailureEvent_t failureEvent;

        public AcsUnsolicitedEvent(IntPtr point, eventTypeACS type)
        {
            _type = type;
            failureEvent =
                (ACSUniversalFailureEvent_t) Marshal.PtrToStructure(point, typeof (ACSUniversalFailureEvent_t));
        }

        public eventTypeACS GetTypeEvent()
        {
            return _type;
        }
    }

    [Serializable,StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ACSConfirmationEvent
    {
        public uint invokeID;
        public ACSOpenStreamConfEvent_t ascOpen;
        public ACSCloseStreamConfEvent_t acsclose;
        public ACSUniversalFailureConfEvent_t failureEvent;

        public ACSConfirmationEvent(IntPtr point, eventTypeACS type)
        {
            ascOpen = new ACSOpenStreamConfEvent_t();
            acsclose = new ACSCloseStreamConfEvent_t();
            failureEvent = new ACSUniversalFailureConfEvent_t();
            invokeID = (uint) Marshal.ReadInt32(point);
            point = IntPtr.Add(point, Marshal.SizeOf(invokeID));
            switch (type)
            {

                case eventTypeACS.ACS_OPEN_STREAM_CONF:
                    ascOpen =
                        (ACSOpenStreamConfEvent_t) Marshal.PtrToStructure(point, typeof (ACSOpenStreamConfEvent_t));
                    break;
                case eventTypeACS.ACS_CLOSE_STREAM_CONF:
                    acsclose =
                        (ACSCloseStreamConfEvent_t) Marshal.PtrToStructure(point, typeof (ACSCloseStreamConfEvent_t));
                    break;
                case eventTypeACS.ACS_UNIVERSAL_FAILURE_CONF:
                    failureEvent =
                        (ACSUniversalFailureConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (ACSUniversalFailureConfEvent_t));
                    break;
            }
        }
    }

    [Serializable,StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct AcsConfirmationEvent
    {
        public uint invokeID;
        public ACSOpenStreamConfEvent_t ascOpen;
        public ACSCloseStreamConfEvent_t acsclose;
        public ACSUniversalFailureConfEvent_t failureEvent;

        public AcsConfirmationEvent(IntPtr point, eventTypeACS type)
        {
            ascOpen = new ACSOpenStreamConfEvent_t();
            acsclose = new ACSCloseStreamConfEvent_t();
            failureEvent = new ACSUniversalFailureConfEvent_t();
            invokeID = (uint) Marshal.ReadInt32(point);
            point = IntPtr.Add(point, Marshal.SizeOf(invokeID));
            switch (type)
            {

                case eventTypeACS.ACS_OPEN_STREAM_CONF:
                    ascOpen =
                        (ACSOpenStreamConfEvent_t) Marshal.PtrToStructure(point, typeof (ACSOpenStreamConfEvent_t));
                    break;
                case eventTypeACS.ACS_CLOSE_STREAM_CONF:
                    acsclose =
                        (ACSCloseStreamConfEvent_t) Marshal.PtrToStructure(point, typeof (ACSCloseStreamConfEvent_t));
                    break;
                case eventTypeACS.ACS_UNIVERSAL_FAILURE_CONF:
                    failureEvent =
                        (ACSUniversalFailureConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (ACSUniversalFailureConfEvent_t));
                    break;
            }
        }
    }

    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CstaRequestEvent
    {
        public uint invokeID;
        public CSTARouteRequestEvent_t routeRequest;
        public CSTARouteRequestExtEvent_t routeRequestExt;
        public CSTAReRouteRequest_t reRouteRequest;
        public CSTAEscapeSvcReqEvent_t escapeSvcReqeust;
        public CSTASysStatReqEvent_t sysStatRequest;

        public CstaRequestEvent(IntPtr point, eventTypeCSTA type)
        {
            routeRequest = new CSTARouteRequestEvent_t();
            routeRequestExt = new CSTARouteRequestExtEvent_t();
            reRouteRequest = new CSTAReRouteRequest_t();
            escapeSvcReqeust = new CSTAEscapeSvcReqEvent_t();
            sysStatRequest = new CSTASysStatReqEvent_t();
            invokeID = (uint) Marshal.ReadInt32(point);
            point = IntPtr.Add(point, Marshal.SizeOf(invokeID));
            switch (type)
            {

                case eventTypeCSTA.CSTA_ROUTE_REQUEST:
                    routeRequest =
                        (CSTARouteRequestEvent_t) Marshal.PtrToStructure(point, typeof (CSTARouteRequestEvent_t));
                    break;
                case eventTypeCSTA.CSTA_ROUTE_SELECT_REQUEST:
                    break;
                case eventTypeCSTA.CSTA_RE_ROUTE_REQUEST:
                    reRouteRequest = (CSTAReRouteRequest_t) Marshal.PtrToStructure(point, typeof (CSTAReRouteRequest_t));
                    break;
                case eventTypeCSTA.CSTA_ROUTE_END_REQUEST:
                    break;
                case eventTypeCSTA.CSTA_ESCAPE_SVC:
                    break;
                case eventTypeCSTA.CSTA_ESCAPE_SVC_CONF:
                    break;
                case eventTypeCSTA.CSTA_ESCAPE_SVC_REQ:
                    break;
                case eventTypeCSTA.CSTA_ESCAPE_SVC_REQ_CONF:
                    escapeSvcReqeust =
                        (CSTAEscapeSvcReqEvent_t) Marshal.PtrToStructure(point, typeof (CSTAEscapeSvcReqEvent_t));
                    break;
                case eventTypeCSTA.CSTA_REQ_SYS_STAT:
                    break;
                case eventTypeCSTA.CSTA_SYS_STAT_REQ:
                    sysStatRequest =
                        (CSTASysStatReqEvent_t) Marshal.PtrToStructure(point, typeof (CSTASysStatReqEvent_t));
                    break;
                case eventTypeCSTA.CSTA_SYS_STAT_START:
                    break;
                case eventTypeCSTA.CSTA_SYS_STAT_START_CONF:
                    break;
                case eventTypeCSTA.CSTA_SYS_STAT_STOP:
                    break;
                case eventTypeCSTA.CSTA_SYS_STAT_STOP_CONF:
                    break;
                case eventTypeCSTA.CSTA_REQ_SYS_STAT_CONF:
                    break;
                case eventTypeCSTA.CSTA_ROUTE_REQUEST_EXT:
                    routeRequestExt =
                        (CSTARouteRequestExtEvent_t) Marshal.PtrToStructure(point, typeof (CSTARouteRequestExtEvent_t));
                    break;
                case eventTypeCSTA.CSTA_ROUTE_USED_EXT:
                    break;
                case eventTypeCSTA.CSTA_ROUTE_SELECT_INV_REQUEST:
                    break;
                case eventTypeCSTA.CSTA_ROUTE_END_INV_REQUEST:
                    break;
            }
        }
    }

    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CstaUnsolicitedEvent
    {
        private readonly eventTypeCSTA _type;
        public uint monitorCrossRefId;
        public CSTACallClearedEvent_t callCleared;
        public CSTAConferencedEvent_t conferenced;
        public CSTAConnectionClearedEvent_t connectionCleared;
        public CSTADeliveredEvent_t delivered;
        public CSTADivertedEvent_t diverted;
        public CSTAEstablishedEvent_t established;
        public CSTAFailedEvent_t failed;
        public CSTAHeldEvent_t held;
        public CSTANetworkReachedEvent_t networkReached;
        public CSTAOriginatedEvent_t originated;
        public CSTAQueuedEvent_t queued;
        public CSTARetrievedEvent_t retrieved;
        public CSTAServiceInitiatedEvent_t serviceInitiated;
        public CSTATransferredEvent_t transferred;
        public CSTACallInformationEvent_t callInformation;
        public CSTADoNotDisturbEvent_t doNotDisturb;
        public CSTAForwardingEvent_t forwarding;
        public CSTAMessageWaitingEvent_t messageWaiting;
        public CSTALoggedOnEvent_t loggedOn;
        public CSTALoggedOffEvent_t loggedOff;
        public CSTANotReadyEvent_t notReady;
        public CSTAReadyEvent_t ready;
        public CSTAWorkNotReadyEvent_t workNotReady;
        public CSTAWorkReadyEvent_t workReady;
        public CSTABackInServiceEvent_t backInService;
        public CSTAOutOfServiceEvent_t outOfService;
        public CSTAPrivateStatusEvent_t privateStatus;
        public CSTAMonitorEndedEvent_t monitorEnded;

        public eventTypeCSTA GetTypeEvent()
        {
            return _type;
        }

        public CstaUnsolicitedEvent(IntPtr point, eventTypeCSTA type)
        {
            _type = type;
            monitorCrossRefId = (uint) Marshal.ReadInt32(point);
            point = IntPtr.Add(point, Marshal.SizeOf(monitorCrossRefId));
            callCleared = new CSTACallClearedEvent_t();
            connectionCleared = new CSTAConnectionClearedEvent_t();
            conferenced = new CSTAConferencedEvent_t();
            transferred = new CSTATransferredEvent_t();
            callCleared = new CSTACallClearedEvent_t();
            conferenced = new CSTAConferencedEvent_t();
            connectionCleared = new CSTAConnectionClearedEvent_t();
            delivered = new CSTADeliveredEvent_t();
            diverted = new CSTADivertedEvent_t();
            established = new CSTAEstablishedEvent_t();
            failed = new CSTAFailedEvent_t();
            held = new CSTAHeldEvent_t();
            networkReached = new CSTANetworkReachedEvent_t();
            originated = new CSTAOriginatedEvent_t();
            queued = new CSTAQueuedEvent_t();
            retrieved = new CSTARetrievedEvent_t();
            serviceInitiated = new CSTAServiceInitiatedEvent_t();
            transferred = new CSTATransferredEvent_t();
            callInformation = new CSTACallInformationEvent_t();
            doNotDisturb = new CSTADoNotDisturbEvent_t();
            forwarding = new CSTAForwardingEvent_t();
            messageWaiting = new CSTAMessageWaitingEvent_t();
            loggedOn = new CSTALoggedOnEvent_t();
            loggedOff = new CSTALoggedOffEvent_t();
            notReady = new CSTANotReadyEvent_t();
            ready = new CSTAReadyEvent_t();
            workNotReady = new CSTAWorkNotReadyEvent_t();
            workReady = new CSTAWorkReadyEvent_t();
            privateStatus = new CSTAPrivateStatusEvent_t();
            backInService = new CSTABackInServiceEvent_t();
            outOfService = new CSTAOutOfServiceEvent_t();
            monitorEnded = new CSTAMonitorEndedEvent_t();

            switch (type)
            {

                case eventTypeCSTA.CSTA_CLEAR_CALL:
                    callCleared =
                        (CSTACallClearedEvent_t) Marshal.PtrToStructure(point, typeof (CSTACallClearedEvent_t));
                    break;
                case eventTypeCSTA.CSTA_CLEAR_CONNECTION:
                    connectionCleared =
                        (CSTAConnectionClearedEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTAConnectionClearedEvent_t));
                    break;
                case eventTypeCSTA.CSTA_CONFERENCE_CALL:
                    conferenced =
                        (CSTAConferencedEvent_t) Marshal.PtrToStructure(point, typeof (CSTAConferencedEvent_t));
                    break;
                case eventTypeCSTA.CSTA_TRANSFER_CALL:
                    transferred =
                        (CSTATransferredEvent_t) Marshal.PtrToStructure(point, typeof (CSTATransferredEvent_t));
                    break;
                case eventTypeCSTA.CSTA_CALL_CLEARED:
                    callCleared =
                        (CSTACallClearedEvent_t) Marshal.PtrToStructure(point, typeof (CSTACallClearedEvent_t));
                    break;
                case eventTypeCSTA.CSTA_CONFERENCED:
                    conferenced =
                        (CSTAConferencedEvent_t) Marshal.PtrToStructure(point, typeof (CSTAConferencedEvent_t));
                    break;
                case eventTypeCSTA.CSTA_CONNECTION_CLEARED:
                    connectionCleared =
                        (CSTAConnectionClearedEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTAConnectionClearedEvent_t));
                    break;
                case eventTypeCSTA.CSTA_DELIVERED:
                    delivered = (CSTADeliveredEvent_t) Marshal.PtrToStructure(point, typeof (CSTADeliveredEvent_t));
                    break;
                case eventTypeCSTA.CSTA_DIVERTED:
                    diverted = (CSTADivertedEvent_t) Marshal.PtrToStructure(point, typeof (CSTADivertedEvent_t));
                    break;
                case eventTypeCSTA.CSTA_ESTABLISHED:
                    established =
                        (CSTAEstablishedEvent_t) Marshal.PtrToStructure(point, typeof (CSTAEstablishedEvent_t));
                    break;
                case eventTypeCSTA.CSTA_FAILED:
                    failed = (CSTAFailedEvent_t) Marshal.PtrToStructure(point, typeof (CSTAFailedEvent_t));
                    break;
                case eventTypeCSTA.CSTA_HELD:
                    held = (CSTAHeldEvent_t) Marshal.PtrToStructure(point, typeof (CSTAHeldEvent_t));
                    break;
                case eventTypeCSTA.CSTA_NETWORK_REACHED:
                    networkReached =
                        (CSTANetworkReachedEvent_t) Marshal.PtrToStructure(point, typeof (CSTANetworkReachedEvent_t));
                    break;
                case eventTypeCSTA.CSTA_ORIGINATED:
                    originated = (CSTAOriginatedEvent_t) Marshal.PtrToStructure(point, typeof (CSTAOriginatedEvent_t));
                    break;
                case eventTypeCSTA.CSTA_QUEUED:
                    queued = (CSTAQueuedEvent_t) Marshal.PtrToStructure(point, typeof (CSTAQueuedEvent_t));
                    break;
                case eventTypeCSTA.CSTA_RETRIEVED:
                    retrieved = (CSTARetrievedEvent_t) Marshal.PtrToStructure(point, typeof (CSTARetrievedEvent_t));
                    break;
                case eventTypeCSTA.CSTA_SERVICE_INITIATED:
                    serviceInitiated =
                        (CSTAServiceInitiatedEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTAServiceInitiatedEvent_t));
                    break;
                case eventTypeCSTA.CSTA_TRANSFERRED:
                    transferred =
                        (CSTATransferredEvent_t) Marshal.PtrToStructure(point, typeof (CSTATransferredEvent_t));
                    break;
                case eventTypeCSTA.CSTA_CALL_INFORMATION:
                    callInformation =
                        (CSTACallInformationEvent_t) Marshal.PtrToStructure(point, typeof (CSTACallInformationEvent_t));
                    break;
                case eventTypeCSTA.CSTA_DO_NOT_DISTURB:
                    doNotDisturb =
                        (CSTADoNotDisturbEvent_t) Marshal.PtrToStructure(point, typeof (CSTADoNotDisturbEvent_t));
                    break;
                case eventTypeCSTA.CSTA_FORWARDING:
                    forwarding = (CSTAForwardingEvent_t) Marshal.PtrToStructure(point, typeof (CSTAForwardingEvent_t));
                    break;
                case eventTypeCSTA.CSTA_MESSAGE_WAITING:
                    messageWaiting =
                        (CSTAMessageWaitingEvent_t) Marshal.PtrToStructure(point, typeof (CSTAMessageWaitingEvent_t));
                    break;
                case eventTypeCSTA.CSTA_LOGGED_ON:
                    loggedOn = (CSTALoggedOnEvent_t) Marshal.PtrToStructure(point, typeof (CSTALoggedOnEvent_t));
                    break;
                case eventTypeCSTA.CSTA_LOGGED_OFF:
                    loggedOff = (CSTALoggedOffEvent_t) Marshal.PtrToStructure(point, typeof (CSTALoggedOffEvent_t));
                    break;
                case eventTypeCSTA.CSTA_NOT_READY:
                    notReady = (CSTANotReadyEvent_t) Marshal.PtrToStructure(point, typeof (CSTANotReadyEvent_t));
                    break;
                case eventTypeCSTA.CSTA_READY:
                    ready = (CSTAReadyEvent_t) Marshal.PtrToStructure(point, typeof (CSTAReadyEvent_t));
                    break;
                case eventTypeCSTA.CSTA_WORK_NOT_READY:
                    workNotReady =
                        (CSTAWorkNotReadyEvent_t) Marshal.PtrToStructure(point, typeof (CSTAWorkNotReadyEvent_t));
                    break;
                case eventTypeCSTA.CSTA_WORK_READY:
                    workReady = (CSTAWorkReadyEvent_t) Marshal.PtrToStructure(point, typeof (CSTAWorkReadyEvent_t));
                    break;
                case eventTypeCSTA.CSTA_PRIVATE_STATUS:
                    privateStatus =
                        (CSTAPrivateStatusEvent_t) Marshal.PtrToStructure(point, typeof (CSTAPrivateStatusEvent_t));
                    break;
                case eventTypeCSTA.CSTA_SEND_PRIVATE:
                    break;
                case eventTypeCSTA.CSTA_BACK_IN_SERVICE:
                    backInService =
                        (CSTABackInServiceEvent_t) Marshal.PtrToStructure(point, typeof (CSTABackInServiceEvent_t));
                    break;
                case eventTypeCSTA.CSTA_OUT_OF_SERVICE:
                    outOfService =
                        (CSTAOutOfServiceEvent_t) Marshal.PtrToStructure(point, typeof (CSTAOutOfServiceEvent_t));
                    break;
                case eventTypeCSTA.CSTA_REQ_SYS_STAT:
                    break;
                case eventTypeCSTA.CSTA_MONITOR_ENDED:
                    monitorEnded =
                        (CSTAMonitorEndedEvent_t) Marshal.PtrToStructure(point, typeof (CSTAMonitorEndedEvent_t));
                    break;
            }
        }
    }

    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CstaConfirmationEvent
    {
        public uint invokeID;
        public CSTAAlternateCallConfEvent_t alternateCall;
        public CSTAAnswerCallConfEvent_t answerCall;
        public CSTACallCompletionConfEvent_t callCompletion;
        public CSTAClearCallConfEvent_t clearCall;
        public CSTAClearConnectionConfEvent_t clearConnection;
        public CSTAConferenceCallConfEvent_t conferenceCall;
        public CSTAConsultationCallConfEvent_t consultationCall;
        public CSTADeflectCallConfEvent_t deflectCall;
        public CSTAPickupCallConfEvent_t pickupCall;
        public CSTAGroupPickupCallConfEvent_t groupPickupCall;
        public CSTAHoldCallConfEvent_t holdCall;
        public CSTAMakeCallConfEvent_t makeCall;
        public CSTAMakePredictiveCallConfEvent_t makePredictiveCall;
        public CSTAQueryMwiConfEvent_t queryMwi;
        public CSTAQueryDndConfEvent_t queryDnd;
        public CSTAQueryFwdConfEvent_t queryFwd;
        public CSTAQueryAgentStateConfEvent_t queryAgentState;
        public CSTAQueryLastNumberConfEvent_t queryLastNumber;
        public CSTAQueryDeviceInfoConfEvent_t queryDeviceInfo;
        public CSTAReconnectCallConfEvent_t reconnectCall;
        public CSTARetrieveCallConfEvent_t retrieveCall;
        public CSTASetMwiConfEvent_t setMwi;
        public CSTASetDndConfEvent_t setDnd;
        public CSTASetFwdConfEvent_t setFwd;
        public CSTASetAgentStateConfEvent_t setAgentState;
        public CSTATransferCallConfEvent_t transferCall;
        public CSTAUniversalFailureConfEvent_t universalFailure;
        public CSTAMonitorConfEvent_t monitorStart;
        public CSTAChangeMonitorFilterConfEvent_t changeMonitorFilter;
        public CSTAMonitorStopConfEvent_t monitorStop;
        public CSTASnapshotDeviceConfEvent_t snapshotDevice;
        public CSTASnapshotCallConfEvent_t snapshotCall;
        public CSTARouteRegisterReqConfEvent_t routeRegister;
        public CSTARouteRegisterCancelConfEvent_t routeCancel;
        public CSTAEscapeSvcConfEvent_t escapeService;
        public CSTASysStatReqConfEvent_t sysStatReq;
        public CSTASysStatStartConfEvent_t sysStatStart;
        public CSTASysStatStopConfEvent_t sysStatStop;
        public CSTAChangeSysStatFilterConfEvent_t changeSysStatFilter;
        public CSTAGetAPICapsConfEvent_t getAPICaps;
        public CSTAGetDeviceListConfEvent_t getDeviceList;
        public CSTAQueryCallMonitorConfEvent_t queryCallMonitor;

        public CstaConfirmationEvent(IntPtr point, eventTypeCSTA type)
        {
            alternateCall = new CSTAAlternateCallConfEvent_t();
            answerCall = new CSTAAnswerCallConfEvent_t();
            callCompletion = new CSTACallCompletionConfEvent_t();
            clearCall = new CSTAClearCallConfEvent_t();
            clearConnection = new CSTAClearConnectionConfEvent_t();
            conferenceCall = new CSTAConferenceCallConfEvent_t();
            consultationCall = new CSTAConsultationCallConfEvent_t();
            deflectCall = new CSTADeflectCallConfEvent_t();
            pickupCall = new CSTAPickupCallConfEvent_t();
            groupPickupCall = new CSTAGroupPickupCallConfEvent_t();
            holdCall = new CSTAHoldCallConfEvent_t();
            makeCall = new CSTAMakeCallConfEvent_t();
            makePredictiveCall = new CSTAMakePredictiveCallConfEvent_t();
            queryMwi = new CSTAQueryMwiConfEvent_t();
            queryDnd = new CSTAQueryDndConfEvent_t();
            queryFwd = new CSTAQueryFwdConfEvent_t();
            queryAgentState = new CSTAQueryAgentStateConfEvent_t();
            queryLastNumber = new CSTAQueryLastNumberConfEvent_t();
            queryDeviceInfo = new CSTAQueryDeviceInfoConfEvent_t();
            reconnectCall = new CSTAReconnectCallConfEvent_t();
            retrieveCall = new CSTARetrieveCallConfEvent_t();
            setMwi = new CSTASetMwiConfEvent_t();
            setDnd = new CSTASetDndConfEvent_t();
            setFwd = new CSTASetFwdConfEvent_t();
            setAgentState = new CSTASetAgentStateConfEvent_t();
            transferCall = new CSTATransferCallConfEvent_t();
            universalFailure = new CSTAUniversalFailureConfEvent_t();
            monitorStart = new CSTAMonitorConfEvent_t();
            changeMonitorFilter = new CSTAChangeMonitorFilterConfEvent_t();
            monitorStop = new CSTAMonitorStopConfEvent_t();
            snapshotDevice = new CSTASnapshotDeviceConfEvent_t();
            snapshotCall = new CSTASnapshotCallConfEvent_t();
            routeRegister = new CSTARouteRegisterReqConfEvent_t();
            routeCancel = new CSTARouteRegisterCancelConfEvent_t();
            escapeService = new CSTAEscapeSvcConfEvent_t();
            sysStatReq = new CSTASysStatReqConfEvent_t();
            sysStatStart = new CSTASysStatStartConfEvent_t();
            sysStatStop = new CSTASysStatStopConfEvent_t();
            changeSysStatFilter = new CSTAChangeSysStatFilterConfEvent_t();
            getAPICaps = new CSTAGetAPICapsConfEvent_t();
            getDeviceList = new CSTAGetDeviceListConfEvent_t();
            queryCallMonitor = new CSTAQueryCallMonitorConfEvent_t();

            invokeID = (uint) Marshal.ReadInt32(point);
            point = IntPtr.Add(point, Marshal.SizeOf(invokeID));
            switch (type)
            {
                case eventTypeCSTA.CSTA_ALTERNATE_CALL_CONF:
                    alternateCall =
                        (CSTAAlternateCallConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTAAlternateCallConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_ANSWER_CALL_CONF:
                    answerCall =
                        (CSTAAnswerCallConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTAAnswerCallConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_CALL_COMPLETION_CONF:
                    callCompletion =
                        (CSTACallCompletionConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTACallCompletionConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_CLEAR_CALL_CONF:
                    clearCall =
                        (CSTAClearCallConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTAClearCallConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_CLEAR_CONNECTION_CONF:
                    clearConnection =
                        (CSTAClearConnectionConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTAClearConnectionConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_CONFERENCE_CALL_CONF:
                    conferenceCall =
                        (CSTAConferenceCallConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTAConferenceCallConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_CONSULTATION_CALL_CONF:
                    consultationCall =
                        (CSTAConsultationCallConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTAConsultationCallConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_DEFLECT_CALL_CONF:
                    deflectCall =
                        (CSTADeflectCallConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTADeflectCallConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_PICKUP_CALL_CONF:
                    pickupCall =
                        (CSTAPickupCallConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTAPickupCallConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_GROUP_PICKUP_CALL_CONF:
                    groupPickupCall =
                        (CSTAGroupPickupCallConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTAGroupPickupCallConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_HOLD_CALL_CONF:
                    holdCall = (CSTAHoldCallConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTAHoldCallConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_MAKE_CALL_CONF:
                    makeCall = (CSTAMakeCallConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTAMakeCallConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_MAKE_PREDICTIVE_CALL_CONF:
                    makePredictiveCall =
                        (CSTAMakePredictiveCallConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTAMakePredictiveCallConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_QUERY_MWI_CONF:
                    queryMwi = (CSTAQueryMwiConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTAQueryMwiConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_QUERY_DND_CONF:
                    queryDnd = (CSTAQueryDndConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTAQueryDndConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_QUERY_FWD_CONF:
                    queryFwd = (CSTAQueryFwdConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTAQueryFwdConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_QUERY_AGENT_STATE_CONF:
                    queryAgentState =
                        (CSTAQueryAgentStateConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTAQueryAgentStateConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_QUERY_LAST_NUMBER_CONF:
                    queryLastNumber =
                        (CSTAQueryLastNumberConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTAQueryLastNumberConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_QUERY_DEVICE_INFO_CONF:
                    queryDeviceInfo =
                        (CSTAQueryDeviceInfoConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTAQueryDeviceInfoConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_RECONNECT_CALL_CONF:
                    reconnectCall =
                        (CSTAReconnectCallConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTAReconnectCallConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_RETRIEVE_CALL_CONF:
                    retrieveCall =
                        (CSTARetrieveCallConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTARetrieveCallConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_SET_MWI_CONF:
                    setMwi = (CSTASetMwiConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTASetMwiConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_SET_DND_CONF:
                    setDnd = (CSTASetDndConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTASetDndConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_SET_FWD_CONF:
                    setFwd = (CSTASetFwdConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTASetFwdConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_SET_AGENT_STATE_CONF:
                    setAgentState =
                        (CSTASetAgentStateConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTASetAgentStateConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_TRANSFER_CALL_CONF:
                    transferCall =
                        (CSTATransferCallConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTATransferCallConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_UNIVERSAL_FAILURE_CONF:
                    universalFailure =
                        (CSTAUniversalFailureConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTAUniversalFailureConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_MONITOR_CONF:
                    monitorStart =
                        (CSTAMonitorConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTAMonitorConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_CHANGE_MONITOR_FILTER_CONF:
                    changeMonitorFilter =
                        (CSTAChangeMonitorFilterConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTAChangeMonitorFilterConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_MONITOR_STOP_CONF:
                    monitorStop =
                        (CSTAMonitorStopConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTAMonitorStopConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_SNAPSHOT_DEVICE_CONF:
                    snapshotDevice =
                        (CSTASnapshotDeviceConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTASnapshotDeviceConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_SNAPSHOT_CALL_CONF:
                    snapshotCall =
                        (CSTASnapshotCallConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTASnapshotCallConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_ROUTE_REGISTER_REQ_CONF:
                    routeRegister =
                        (CSTARouteRegisterReqConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTARouteRegisterReqConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_ROUTE_REGISTER_CANCEL_CONF:
                    routeCancel =
                        (CSTARouteRegisterCancelConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTARouteRegisterCancelConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_ESCAPE_SVC_CONF:
                    escapeService =
                        (CSTAEscapeSvcConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTAEscapeSvcConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_SYS_STAT_REQ_CONF:
                    sysStatReq =
                        (CSTASysStatReqConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTASysStatReqConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_SYS_STAT_START_CONF:
                    sysStatStart =
                        (CSTASysStatStartConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTASysStatStartConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_SYS_STAT_STOP_CONF:
                    sysStatStop =
                        (CSTASysStatStopConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTASysStatStopConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_CHANGE_SYS_STAT_FILTER_CONF:
                    changeSysStatFilter =
                        (CSTAChangeSysStatFilterConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTAChangeSysStatFilterConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_GETAPI_CAPS_CONF:
                    getAPICaps =
                        (CSTAGetAPICapsConfEvent_t) Marshal.PtrToStructure(point, typeof (CSTAGetAPICapsConfEvent_t));
                    break;
                case eventTypeCSTA.CSTA_GET_DEVICE_LIST_CONF:
                    getDeviceList =(CSTAGetDeviceListConfEvent_t)Marshal.PtrToStructure(point, typeof (CSTAGetDeviceListConfEvent_t));
                    
                    break;
                case eventTypeCSTA.CSTA_QUERY_CALL_MONITOR_CONF:
                    queryCallMonitor =
                        (CSTAQueryCallMonitorConfEvent_t)
                            Marshal.PtrToStructure(point, typeof (CSTAQueryCallMonitorConfEvent_t));
                    break;
            }
        }


    }

    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CstaEventReport
    {
        private readonly eventTypeCSTA _type;
        public CSTARouteRegisterAbortEvent_t registerAbort;
        public CSTARouteUsedEvent_t routeUsed;
        public CSTARouteUsedExtEvent_t routeUsedExt;
        public CSTARouteEndEvent_t routeEnd;
        public CSTAPrivateEvent_t privateEvent;
        public CSTASysStatEvent_t sysStat;
        public CSTASysStatEndedEvent_t sysStatEnded;

        public eventTypeCSTA GetTypeEvent()
        {
            return _type;
        }

        public CstaEventReport(IntPtr point, eventTypeCSTA type)
        {
            registerAbort = new CSTARouteRegisterAbortEvent_t();
            routeUsed = new CSTARouteUsedEvent_t();
            routeUsedExt = new CSTARouteUsedExtEvent_t();
            routeEnd = new CSTARouteEndEvent_t();
            privateEvent = new CSTAPrivateEvent_t();
            sysStat = new CSTASysStatEvent_t();
            sysStatEnded = new CSTASysStatEndedEvent_t();
            _type = type;
            registerAbort =
                (CSTARouteRegisterAbortEvent_t) Marshal.PtrToStructure(point, typeof (CSTARouteRegisterAbortEvent_t));
            routeUsed = (CSTARouteUsedEvent_t) Marshal.PtrToStructure(point, typeof (CSTARouteUsedEvent_t));
            routeUsedExt = (CSTARouteUsedExtEvent_t) Marshal.PtrToStructure(point, typeof (CSTARouteUsedExtEvent_t));
            routeEnd = (CSTARouteEndEvent_t) Marshal.PtrToStructure(point, typeof (CSTARouteEndEvent_t));
            privateEvent = (CSTAPrivateEvent_t) Marshal.PtrToStructure(point, typeof (CSTAPrivateEvent_t));
            sysStat = (CSTASysStatEvent_t) Marshal.PtrToStructure(point, typeof (CSTASysStatEvent_t));
            sysStatEnded = (CSTASysStatEndedEvent_t) Marshal.PtrToStructure(point, typeof (CSTASysStatEndedEvent_t));
        }


    }
    
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
// ReSharper disable once InconsistentNaming
    public struct CSTAEvent_t
    {
        public ACSEventHeader_t eventHeader;
        public AcsUnsolicitedEvent acsUnsolicited;
        public ACSConfirmationEvent acsConfirmation;
        public CstaRequestEvent cstaRequest;
        public CstaUnsolicitedEvent cstaUnsolicited;
        public CstaConfirmationEvent cstaConfirmation;
        public CstaEventReport cstaEventReport;

        public CSTAEvent_t(IntPtr point)
        {

            acsUnsolicited = new AcsUnsolicitedEvent();
            acsConfirmation = new ACSConfirmationEvent();
            cstaRequest = new CstaRequestEvent();
            cstaUnsolicited = new CstaUnsolicitedEvent();
            cstaConfirmation = new CstaConfirmationEvent();
            cstaEventReport = new CstaEventReport();
            eventHeader = (ACSEventHeader_t) Marshal.PtrToStructure(point, typeof (ACSEventHeader_t));
            point = IntPtr.Add(point, Marshal.SizeOf(eventHeader));
            switch (eventHeader.eventClass)
            {
                case EventClass_t.ACSCONFIRMATION:
                    acsConfirmation = new ACSConfirmationEvent(point, eventHeader.eventTypeACS);
                    break;
                case EventClass_t.ACSUNSOLICITED:
                    acsUnsolicited = new AcsUnsolicitedEvent(point, eventHeader.eventTypeACS);
                    break;
                case EventClass_t.CSTACONFIRMATION:
                    cstaConfirmation = new CstaConfirmationEvent(point, eventHeader.eventTypeCSTA);
                    break;
                case EventClass_t.CSTAEVENTREPORT:
                    cstaEventReport = new CstaEventReport(point, eventHeader.eventTypeCSTA);
                    break;
                case EventClass_t.CSTAUNSOLICITED:
                    cstaUnsolicited = new CstaUnsolicitedEvent(point, eventHeader.eventTypeCSTA);
                    break;
                case EventClass_t.CSTAREQUEST:
                    cstaRequest = new CstaRequestEvent(point, eventHeader.eventTypeCSTA);
                    break;

            }


        }

    }












    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
// ReSharper disable once InconsistentNaming
    public struct ATTEvent_t
    {
        public TypeATTEvent eventType;
        public ATTSingleStepConferenceCallConfEvent_t ssconference;
        public ATTSelectiveListeningHoldConfEvent_t slhold;
        public ATTSelectiveListeningRetrieveConfEvent_t slretrieve;
        public ATTSendDTMFToneConfEvent_t sendDTMFTone;
        public ATTQueryAcdSplitConfEvent_t queryAcdSplit;
        public ATTQueryAgentLoginConfEvent_t queryAgentLogin;
        public ATTQueryAgentLoginResp_t queryAgentLoginResp;
        public ATTQueryAgentStateConfEvent_t queryAgentState;
        public ATTQueryCallClassifierConfEvent_t queryCallClassifier;
        public ATTQueryDeviceInfoConfEvent_t queryDeviceInfo;
        public ATTQueryDeviceNameConfEvent_t queryDeviceName;
        public ATTQueryMwiConfEvent_t queryMwi;
        public ATTQueryStationStatusConfEvent_t queryStationStatus;
        public ATTQueryTodConfEvent_t queryTod;
        public ATTQueryTgConfEvent_t queryTg;
        public ATTQueryAgentMeasurementsConfEvent_t queryAgentMeas;
        public ATTQuerySplitSkillMeasurementsConfEvent_t querySplitSkillMeas;
        public ATTQueryTrunkGroupMeasurementsConfEvent_t queryTrunkGroupMeas;
        public ATTQueryVdnMeasurementsConfEvent_t queryVdnMeas;
        public ATTSnapshotDeviceConfEvent_t snapshotDevice;
        public ATTMonitorConfEvent_t monitorStart;
        public ATTMonitorCallConfEvent_t monitorCallStart;
        public ATTMonitorStopOnCallConfEvent_t monitorStopOnCall;
        public ATTCallClearedEvent_t callClearedEvent;
        public ATTConferencedEvent_t conferencedEvent;
        public ATTConnectionClearedEvent_t connectionClearedEvent;
        public ATTDeliveredEvent_t deliveredEvent;
        public ATTEnteredDigitsEvent_t enteredDigitsEvent;
        public ATTEstablishedEvent_t establishedEvent;
        public ATTLoggedOnEvent_t loggedOnEvent;
        public ATTNetworkReachedEvent_t networkReachedEvent;
        public ATTOriginatedEvent_t originatedEvent;
        public ATTTransferredEvent_t transferredEvent;
        public ATTRouteRequestEvent_t routeRequest;
        public ATTRouteUsedEvent_t routeUsed;
        public ATTLinkStatusEvent_t linkStatus;
        public ATTGetAPICapsConfEvent_t getAPICaps;
        public ATTServiceInitiatedEvent_t serviceInitiated;
        public ATTChargeAdviceEvent_t chargeAdviceEvent;
        public ATTSetBillRateConfEvent_t setBillRate;
        public ATTQueryUcidConfEvent_t queryUCID;
        public ATTLoggedOffEvent_t loggedOffEvent;
        public ATTConsultationCallConfEvent_t consultationCall;
        public ATTConferenceCallConfEvent_t conferenceCall;
        public ATTMakeCallConfEvent_t makeCall;
        public ATTMakePredictiveCallConfEvent_t makePredictiveCall;
        public ATTTransferCallConfEvent_t transferCall;
        public ATTSetAdviceOfChargeConfEvent_t setAdviceOfCharge;
        public ATTSetAgentStateConfEvent_t setAgentState;
        public ATTQueuedEvent_t queuedEvent;
        public ATTDivertedEvent_t divertedEvent;
        public ATTFailedEvent_t failedEvent;
        public ATTSnapshotCallConfEvent_t snapshotCallConf;
        public ATTV3ConferencedEvent_t v3conferencedEvent;
        public ATTV3DeliveredEvent_t v3deliveredEvent;
        public ATTV3EstablishedEvent_t v3establishedEvent;
        public ATTV3TransferredEvent_t v3transferredEvent;
        public ATTV3LinkStatusEvent_t v3linkStatus;
        public ATTV4QueryDeviceInfoConfEvent_t v4queryDeviceInfo;
        public ATTV4GetAPICapsConfEvent_t v4getAPICaps;
        public ATTV4SnapshotDeviceConfEvent_t v4snapshotDevice;
        public ATTV4ConferencedEvent_t v4conferencedEvent;
        public ATTV4DeliveredEvent_t v4deliveredEvent;
        public ATTV4EstablishedEvent_t v4establishedEvent;
        public ATTV4TransferredEvent_t v4transferredEvent;
        public ATTV4LinkStatusEvent_t v4linkStatus;
        public ATTV4RouteRequestEvent_t v4routeRequest;
        public ATTV4QueryAgentStateConfEvent_t v4queryAgentState;
        public ATTV4QueryDeviceNameConfEvent_t v4queryDeviceName;
        public ATTV4MonitorConfEvent_t v4monitorStart;
        public ATTV4MonitorCallConfEvent_t v4monitorCallStart;
        public ATTV4NetworkReachedEvent_t v4networkReachedEvent;
        public ATTV5QueryAgentStateConfEvent_t v5queryAgentState;
        public ATTV5RouteRequestEvent_t v5routeRequest;
        public ATTV5TransferredEvent_t v5transferredEvent;
        public ATTV5ConferencedEvent_t v5conferencedEvent;
        public ATTV5ConnectionClearedEvent_t v5connectionClearedEvent;
        public ATTV5OriginatedEvent_t v5originatedEvent;
        public ATTV5EstablishedEvent_t v5establishedEvent;
        public ATTV5DeliveredEvent_t v5deliveredEvent;
        public ATTV6NetworkReachedEvent_t v6networkReachedEvent;
        public ATTV6ConferencedEvent_t v6conferencedEvent;
        public ATTV6DeliveredEvent_t v6deliveredEvent;
        public ATTV6EstablishedEvent_t v6establishedEvent;
        public ATTV6TransferredEvent_t v6transferredEvent;
        public ATTV6QueryDeviceNameConfEvent_t v6queryDeviceName;
        public ATTV6GetAPICapsConfEvent_t v6getAPICaps;
        public ATTV6ConnectionClearedEvent_t v6connectionClearedEvent;
        public ATTV6RouteRequestEvent_t v6routeRequest;
        public ATTClearConnection_t clearConnectionReq;
        public ATTConsultationCall_t consultationCallReq;
        public ATTMakeCall_t makeCallReq;
        public ATTDirectAgentCall_t directAgentCallReq;
        public ATTMakePredictiveCall_t makePredictiveCallReq;
        public ATTSupervisorAssistCall_t supervisorAssistCallReq;
        public ATTReconnectCall_t reconnectCallReq;
        public ATTSendDTMFTone_t sendDTMFToneReq;
        public ATTSingleStepConferenceCall_t ssconferenceReq;
        public ATTSelectiveListeningHold_t slholdReq;
        public ATTSelectiveListeningRetrieve_t slretrieveReq;
        public ATTSetAgentState_t setAgentStateReq;
        public ATTQueryAgentState_t queryAgentStateReq;
        public ATTQueryAcdSplit_t queryAcdSplitReq;
        public ATTQueryAgentLogin_t queryAgentLoginReq;
        public ATTQueryCallClassifier_t queryCallClassifierReq;
        public ATTQueryDeviceName_t queryDeviceNameReq;
        public ATTQueryStationStatus_t queryStationStatusReq;
        public ATTQueryTod_t queryTodReq;
        public ATTQueryTg_t queryTgReq;
        public ATTQueryAgentMeasurements_t queryAgentMeasReq;
        public ATTQuerySplitSkillMeasurements_t querySplitSkillMeasReq;
        public ATTQueryTrunkGroupMeasurements_t queryTrunkGroupMeasReq;
        public ATTQueryVdnMeasurements_t queryVdnMeasReq;
        public ATTMonitorFilter_t monitorFilterReq;
        public ATTMonitorStopOnCall_t monitorStopOnCallReq;
        public ATTRouteSelect_t routeSelectReq;
        public ATTSysStat_t sysStatReq;
        public ATTSetBillRate_t setBillRateReq;
        public ATTQueryUcid_t queryUCIDReq;
        public ATTSetAdviceOfCharge_t adviceOfChargeReq;
        public ATTV4SendDTMFTone_t v4sendDTMFToneReq;
        public ATTV4SetAgentState_t v4setAgentStateReq;
        public ATTV4MonitorFilter_t v4monitorFilterReq;
        public ATTV5SetAgentState_t v5setAgentStateReq;
        public ATTV5ClearConnection_t v5clearConnectionReq;
        public ATTV5ConsultationCall_t v5consultationCallReq;
        public ATTV5MakeCall_t v5makeCallReq;
        public ATTV5DirectAgentCall_t v5directAgentCallReq;
        public ATTV5MakePredictiveCall_t v5makePredictiveCallReq;
        public ATTV5SupervisorAssistCall_t v5supervisorAssistCallReq;
        public ATTV5ReconnectCall_t v5reconnectCallReq;
        public ATTV5RouteSelect_t v5routeSelectReq;
        public ATTV6RouteSelect_t v6routeSelectReq;
        public ATTEvent_t(IntPtr point)
        {

            ssconference = new ATTSingleStepConferenceCallConfEvent_t();
            slhold = new ATTSelectiveListeningHoldConfEvent_t();
            slretrieve = new ATTSelectiveListeningRetrieveConfEvent_t();
            sendDTMFTone = new ATTSendDTMFToneConfEvent_t();
            queryAcdSplit = new ATTQueryAcdSplitConfEvent_t();
            queryAgentLogin = new ATTQueryAgentLoginConfEvent_t();
            queryAgentLoginResp = new ATTQueryAgentLoginResp_t();
            queryAgentState = new ATTQueryAgentStateConfEvent_t();
            queryCallClassifier = new ATTQueryCallClassifierConfEvent_t();
            queryDeviceInfo = new ATTQueryDeviceInfoConfEvent_t();
            queryDeviceName = new ATTQueryDeviceNameConfEvent_t();
            queryMwi = new ATTQueryMwiConfEvent_t();
            queryStationStatus = new ATTQueryStationStatusConfEvent_t();
            queryTod = new ATTQueryTodConfEvent_t();
            queryTg = new ATTQueryTgConfEvent_t();
            queryAgentMeas = new ATTQueryAgentMeasurementsConfEvent_t();
            querySplitSkillMeas = new ATTQuerySplitSkillMeasurementsConfEvent_t();
            queryTrunkGroupMeas = new ATTQueryTrunkGroupMeasurementsConfEvent_t();
            queryVdnMeas = new ATTQueryVdnMeasurementsConfEvent_t();
            snapshotDevice = new ATTSnapshotDeviceConfEvent_t();
            monitorStart = new ATTMonitorConfEvent_t();
            monitorCallStart = new ATTMonitorCallConfEvent_t();
            monitorStopOnCall = new ATTMonitorStopOnCallConfEvent_t();
            callClearedEvent = new ATTCallClearedEvent_t();
            conferencedEvent = new ATTConferencedEvent_t();
            connectionClearedEvent = new ATTConnectionClearedEvent_t();
            deliveredEvent = new ATTDeliveredEvent_t();
            enteredDigitsEvent = new ATTEnteredDigitsEvent_t();
            establishedEvent = new ATTEstablishedEvent_t();
            loggedOnEvent = new ATTLoggedOnEvent_t();
            networkReachedEvent = new ATTNetworkReachedEvent_t();
            originatedEvent = new ATTOriginatedEvent_t();
            transferredEvent = new ATTTransferredEvent_t();
            routeRequest = new ATTRouteRequestEvent_t();
            routeUsed = new ATTRouteUsedEvent_t();
            linkStatus = new ATTLinkStatusEvent_t();
            getAPICaps = new ATTGetAPICapsConfEvent_t();
            serviceInitiated = new ATTServiceInitiatedEvent_t();
            chargeAdviceEvent = new ATTChargeAdviceEvent_t();
            setBillRate = new ATTSetBillRateConfEvent_t();
            queryUCID = new ATTQueryUcidConfEvent_t();
            loggedOffEvent = new ATTLoggedOffEvent_t();
            consultationCall = new ATTConsultationCallConfEvent_t();
            conferenceCall = new ATTConferenceCallConfEvent_t();
            makeCall = new ATTMakeCallConfEvent_t();
            makePredictiveCall = new ATTMakePredictiveCallConfEvent_t();
            transferCall = new ATTTransferCallConfEvent_t();
            setAdviceOfCharge = new ATTSetAdviceOfChargeConfEvent_t();
            setAgentState = new ATTSetAgentStateConfEvent_t();
            queuedEvent = new ATTQueuedEvent_t();
            divertedEvent = new ATTDivertedEvent_t();
            failedEvent = new ATTFailedEvent_t();
            snapshotCallConf = new ATTSnapshotCallConfEvent_t();
            v3conferencedEvent = new ATTV3ConferencedEvent_t();
            v3deliveredEvent = new ATTV3DeliveredEvent_t();
            v3establishedEvent = new ATTV3EstablishedEvent_t();
            v3transferredEvent = new ATTV3TransferredEvent_t();
            v3linkStatus = new ATTV3LinkStatusEvent_t();
            v4queryDeviceInfo = new ATTV4QueryDeviceInfoConfEvent_t();
            v4getAPICaps = new ATTV4GetAPICapsConfEvent_t();
            v4snapshotDevice = new ATTV4SnapshotDeviceConfEvent_t();
            v4conferencedEvent = new ATTV4ConferencedEvent_t();
            v4deliveredEvent = new ATTV4DeliveredEvent_t();
            v4establishedEvent = new ATTV4EstablishedEvent_t();
            v4transferredEvent = new ATTV4TransferredEvent_t();
            v4linkStatus = new ATTV4LinkStatusEvent_t();
            v4routeRequest = new ATTV4RouteRequestEvent_t();
            v4queryAgentState = new ATTV4QueryAgentStateConfEvent_t();
            v4queryDeviceName = new ATTV4QueryDeviceNameConfEvent_t();
            v4monitorStart = new ATTV4MonitorConfEvent_t();
            v4monitorCallStart = new ATTV4MonitorCallConfEvent_t();
            v4networkReachedEvent = new ATTV4NetworkReachedEvent_t();
            v5queryAgentState = new ATTV5QueryAgentStateConfEvent_t();
            v5routeRequest = new ATTV5RouteRequestEvent_t();
            v5transferredEvent = new ATTV5TransferredEvent_t();
            v5conferencedEvent = new ATTV5ConferencedEvent_t();
            v5connectionClearedEvent = new ATTV5ConnectionClearedEvent_t();
            v5originatedEvent = new ATTV5OriginatedEvent_t();
            v5establishedEvent = new ATTV5EstablishedEvent_t();
            v5deliveredEvent = new ATTV5DeliveredEvent_t();
            v6networkReachedEvent = new ATTV6NetworkReachedEvent_t();
            v6conferencedEvent = new ATTV6ConferencedEvent_t();
            v6deliveredEvent = new ATTV6DeliveredEvent_t();
            v6establishedEvent = new ATTV6EstablishedEvent_t();
            v6transferredEvent = new ATTV6TransferredEvent_t();
            v6queryDeviceName = new ATTV6QueryDeviceNameConfEvent_t();
            v6getAPICaps = new ATTV6GetAPICapsConfEvent_t();
            v6connectionClearedEvent = new ATTV6ConnectionClearedEvent_t();
            v6routeRequest = new ATTV6RouteRequestEvent_t();
            clearConnectionReq = new ATTClearConnection_t();
            consultationCallReq = new ATTConsultationCall_t();
            makeCallReq = new ATTMakeCall_t();
            directAgentCallReq = new ATTDirectAgentCall_t();
            makePredictiveCallReq = new ATTMakePredictiveCall_t();
            supervisorAssistCallReq = new ATTSupervisorAssistCall_t();
            reconnectCallReq = new ATTReconnectCall_t();
            sendDTMFToneReq = new ATTSendDTMFTone_t();
            ssconferenceReq = new ATTSingleStepConferenceCall_t();
            slholdReq = new ATTSelectiveListeningHold_t();
            slretrieveReq = new ATTSelectiveListeningRetrieve_t();
            setAgentStateReq = new ATTSetAgentState_t();
            queryAgentStateReq = new ATTQueryAgentState_t();
            queryAcdSplitReq = new ATTQueryAcdSplit_t();
            queryAgentLoginReq = new ATTQueryAgentLogin_t();
            queryCallClassifierReq = new ATTQueryCallClassifier_t();
            queryDeviceNameReq = new ATTQueryDeviceName_t();
            queryStationStatusReq = new ATTQueryStationStatus_t();
            queryTodReq = new ATTQueryTod_t();
            queryTgReq = new ATTQueryTg_t();
            queryAgentMeasReq = new ATTQueryAgentMeasurements_t();
            querySplitSkillMeasReq = new ATTQuerySplitSkillMeasurements_t();
            queryTrunkGroupMeasReq = new ATTQueryTrunkGroupMeasurements_t();
            queryVdnMeasReq = new ATTQueryVdnMeasurements_t();
            monitorFilterReq = new ATTMonitorFilter_t();
            monitorStopOnCallReq = new ATTMonitorStopOnCall_t();
            routeSelectReq = new ATTRouteSelect_t();
            sysStatReq = new ATTSysStat_t();
            setBillRateReq = new ATTSetBillRate_t();
            queryUCIDReq = new ATTQueryUcid_t();
            adviceOfChargeReq = new ATTSetAdviceOfCharge_t();
            v4sendDTMFToneReq = new ATTV4SendDTMFTone_t();
            v4setAgentStateReq = new ATTV4SetAgentState_t();
            v4monitorFilterReq = new ATTV4MonitorFilter_t();
            v5setAgentStateReq = new ATTV5SetAgentState_t();
            v5clearConnectionReq = new ATTV5ClearConnection_t();
            v5consultationCallReq = new ATTV5ConsultationCall_t();
            v5makeCallReq = new ATTV5MakeCall_t();
            v5directAgentCallReq = new ATTV5DirectAgentCall_t();
            v5makePredictiveCallReq = new ATTV5MakePredictiveCall_t();
            v5supervisorAssistCallReq = new ATTV5SupervisorAssistCall_t();
            v5reconnectCallReq = new ATTV5ReconnectCall_t();
            v5routeSelectReq = new ATTV5RouteSelect_t();
            v6routeSelectReq = new ATTV6RouteSelect_t();

             
            eventType = (TypeATTEvent)Marshal.ReadInt16(point);
            point = IntPtr.Add(point, Marshal.SizeOf(typeof(Int32)));
            switch (eventType)
            {
                  case TypeATTEvent.ATTSingleStepConferenceCallConfEvent_t_PDU:
                     ssconference = (ATTSingleStepConferenceCallConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTSingleStepConferenceCallConfEvent_t));
                    break;
                    case TypeATTEvent.ATTSelectiveListeningHoldConfEvent_t_PDU:
                     slhold = (ATTSelectiveListeningHoldConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTSelectiveListeningHoldConfEvent_t));
                    break;
                    case TypeATTEvent.ATTSelectiveListeningRetrieveConfEvent_t_PDU:
                     slretrieve = (ATTSelectiveListeningRetrieveConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTSelectiveListeningRetrieveConfEvent_t));
                    break;
                    case TypeATTEvent.ATTSendDTMFToneConfEvent_t_PDU:
                     sendDTMFTone = (ATTSendDTMFToneConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTSendDTMFToneConfEvent_t));
                    break;
                    case TypeATTEvent.ATTQueryAcdSplitConfEvent_t_PDU:
                     queryAcdSplit = (ATTQueryAcdSplitConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTQueryAcdSplitConfEvent_t));
                    break;
                    case TypeATTEvent.ATTQueryAgentLoginConfEvent_t_PDU:
                     queryAgentLogin = (ATTQueryAgentLoginConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTQueryAgentLoginConfEvent_t));
                    break;
                    case TypeATTEvent.ATTQueryAgentLoginResp_t_PDU:
                     queryAgentLoginResp = (ATTQueryAgentLoginResp_t)Marshal.PtrToStructure(point, typeof(ATTQueryAgentLoginResp_t));
                    break;
                    case TypeATTEvent.ATTQueryAgentStateConfEvent_t_PDU:
                     queryAgentState = (ATTQueryAgentStateConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTQueryAgentStateConfEvent_t));
                    break;
                    case TypeATTEvent.ATTQueryCallClassifierConfEvent_t_PDU:
                     queryCallClassifier = (ATTQueryCallClassifierConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTQueryCallClassifierConfEvent_t));
                    break;
                    case TypeATTEvent.ATTQueryDeviceInfoConfEvent_t_PDU:
                     queryDeviceInfo = (ATTQueryDeviceInfoConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTQueryDeviceInfoConfEvent_t));
                    break;
                    case TypeATTEvent.ATTQueryDeviceNameConfEvent_t_PDU:
                     queryDeviceName = (ATTQueryDeviceNameConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTQueryDeviceNameConfEvent_t));
                    break;
                    case TypeATTEvent.ATTQueryMwiConfEvent_t_PDU:
                     queryMwi = (ATTQueryMwiConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTQueryMwiConfEvent_t));
                    break;
                    case TypeATTEvent.ATTQueryStationStatusConfEvent_t_PDU:
                     queryStationStatus = (ATTQueryStationStatusConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTQueryStationStatusConfEvent_t));
                    break;
                    case TypeATTEvent.ATTQueryTodConfEvent_t_PDU:
                     queryTod = (ATTQueryTodConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTQueryTodConfEvent_t));
                    break;
                    case TypeATTEvent.ATTQueryTgConfEvent_t_PDU:
                     queryTg = (ATTQueryTgConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTQueryTgConfEvent_t));
                    break;
                    case TypeATTEvent.ATTQueryAgentMeasurementsConfEvent_t_PDU:
                     queryAgentMeas = (ATTQueryAgentMeasurementsConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTQueryAgentMeasurementsConfEvent_t));
                    break;
                    case TypeATTEvent.ATTQuerySplitSkillMeasurementsConfEvent_t_PDU:
                     querySplitSkillMeas = (ATTQuerySplitSkillMeasurementsConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTQuerySplitSkillMeasurementsConfEvent_t));
                    break;
                    case TypeATTEvent.ATTQueryTrunkGroupMeasurementsConfEvent_t_PDU:
                     queryTrunkGroupMeas = (ATTQueryTrunkGroupMeasurementsConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTQueryTrunkGroupMeasurementsConfEvent_t));
                    break;
                    case TypeATTEvent.ATTQueryVdnMeasurementsConfEvent_t_PDU:
                     queryVdnMeas = (ATTQueryVdnMeasurementsConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTQueryVdnMeasurementsConfEvent_t));
                    break;
                    case TypeATTEvent.ATTSnapshotDeviceConfEvent_t_PDU:
                     snapshotDevice = (ATTSnapshotDeviceConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTSnapshotDeviceConfEvent_t));
                    snapshotDevice.list = snapshotDevice.list.Take((int) snapshotDevice.count).ToArray();
                    //snapshotDevice.list = NativeMethods.GetArrayStruct<ATTSnapshotDevice_t>(point);
                    break;
                    case TypeATTEvent.ATTMonitorConfEvent_t_PDU:
                     monitorStart = (ATTMonitorConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTMonitorConfEvent_t));
                    break;
                    case TypeATTEvent.ATTMonitorCallConfEvent_t_PDU:
                     monitorCallStart = (ATTMonitorCallConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTMonitorCallConfEvent_t));
                    break;
                    case TypeATTEvent.ATTMonitorStopOnCallConfEvent_t_PDU:
                     monitorStopOnCall = (ATTMonitorStopOnCallConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTMonitorStopOnCallConfEvent_t));
                    break;
                    case TypeATTEvent.ATTCallClearedEvent_t_PDU:
                     callClearedEvent = (ATTCallClearedEvent_t)Marshal.PtrToStructure(point, typeof(ATTCallClearedEvent_t));
                    break;
                    case TypeATTEvent.ATTConferencedEvent_t_PDU:
                     conferencedEvent = (ATTConferencedEvent_t)Marshal.PtrToStructure(point, typeof(ATTConferencedEvent_t));
                    break;
                    case TypeATTEvent.ATTConnectionClearedEvent_t_PDU:
                     connectionClearedEvent = (ATTConnectionClearedEvent_t)Marshal.PtrToStructure(point, typeof(ATTConnectionClearedEvent_t));
                    break;
                    case TypeATTEvent.ATTDeliveredEvent_t_PDU:
                     deliveredEvent = (ATTDeliveredEvent_t)Marshal.PtrToStructure(point, typeof(ATTDeliveredEvent_t));
                    break;
                    case TypeATTEvent.ATTEnteredDigitsEvent_t_PDU:
                     enteredDigitsEvent = (ATTEnteredDigitsEvent_t)Marshal.PtrToStructure(point, typeof(ATTEnteredDigitsEvent_t));
                    break;
                    case TypeATTEvent.ATTEstablishedEvent_t_PDU:
                     establishedEvent = (ATTEstablishedEvent_t)Marshal.PtrToStructure(point, typeof(ATTEstablishedEvent_t));
                    break;
                    case TypeATTEvent.ATTLoggedOnEvent_t_PDU:
                     loggedOnEvent = (ATTLoggedOnEvent_t)Marshal.PtrToStructure(point, typeof(ATTLoggedOnEvent_t));
                    break;
                    case TypeATTEvent.ATTNetworkReachedEvent_t_PDU:
                     networkReachedEvent = (ATTNetworkReachedEvent_t)Marshal.PtrToStructure(point, typeof(ATTNetworkReachedEvent_t));
                    break;
                    case TypeATTEvent.ATTOriginatedEvent_t_PDU:
                     originatedEvent = (ATTOriginatedEvent_t)Marshal.PtrToStructure(point, typeof(ATTOriginatedEvent_t));
                    break;
                    case TypeATTEvent.ATTTransferredEvent_t_PDU:
                     transferredEvent = (ATTTransferredEvent_t)Marshal.PtrToStructure(point, typeof(ATTTransferredEvent_t));
                    break;
                    case TypeATTEvent.ATTRouteRequestEvent_t_PDU:
                     routeRequest = (ATTRouteRequestEvent_t)Marshal.PtrToStructure(point, typeof(ATTRouteRequestEvent_t));
                    break;
                    case TypeATTEvent.ATTRouteUsedEvent_t_PDU:
                     routeUsed = (ATTRouteUsedEvent_t)Marshal.PtrToStructure(point, typeof(ATTRouteUsedEvent_t));
                    break;
                    case TypeATTEvent.ATTLinkStatusEvent_t_PDU:
                     linkStatus = (ATTLinkStatusEvent_t)Marshal.PtrToStructure(point, typeof(ATTLinkStatusEvent_t));
                    break;
                    case TypeATTEvent.ATTGetAPICapsConfEvent_t_PDU:
                     getAPICaps = (ATTGetAPICapsConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTGetAPICapsConfEvent_t));
                    break;
                    case TypeATTEvent.ATTServiceInitiatedEvent_t_PDU:
                     serviceInitiated = (ATTServiceInitiatedEvent_t)Marshal.PtrToStructure(point, typeof(ATTServiceInitiatedEvent_t));
                    break;
                    case TypeATTEvent.ATTChargeAdviceEvent_t_PDU:
                     chargeAdviceEvent = (ATTChargeAdviceEvent_t)Marshal.PtrToStructure(point, typeof(ATTChargeAdviceEvent_t));
                    break;
                    case TypeATTEvent.ATTSetBillRateConfEvent_t_PDU:
                     setBillRate = (ATTSetBillRateConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTSetBillRateConfEvent_t));
                    break;
                    case TypeATTEvent.ATTQueryUcidConfEvent_t_PDU:
                     queryUCID = (ATTQueryUcidConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTQueryUcidConfEvent_t));
                    break;
                    case TypeATTEvent.ATTLoggedOffEvent_t_PDU:
                     loggedOffEvent = (ATTLoggedOffEvent_t)Marshal.PtrToStructure(point, typeof(ATTLoggedOffEvent_t));
                    break;
                    case TypeATTEvent.ATTConsultationCallConfEvent_t_PDU:
                     consultationCall = (ATTConsultationCallConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTConsultationCallConfEvent_t));
                    break;
                    case TypeATTEvent.ATTConferenceCallConfEvent_t_PDU:
                     conferenceCall = (ATTConferenceCallConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTConferenceCallConfEvent_t));
                    break;
                    case TypeATTEvent.ATTMakeCallConfEvent_t_PDU:
                     makeCall = (ATTMakeCallConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTMakeCallConfEvent_t));
                    break;
                    case TypeATTEvent.ATTMakePredictiveCallConfEvent_t_PDU:
                     makePredictiveCall = (ATTMakePredictiveCallConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTMakePredictiveCallConfEvent_t));
                    break;
                    case TypeATTEvent.ATTTransferCallConfEvent_t_PDU:
                     transferCall = (ATTTransferCallConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTTransferCallConfEvent_t));
                    break;
                    case TypeATTEvent.ATTSetAdviceOfChargeConfEvent_t_PDU:
                     setAdviceOfCharge = (ATTSetAdviceOfChargeConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTSetAdviceOfChargeConfEvent_t));
                    break;
                    case TypeATTEvent.ATTSetAgentStateConfEvent_t_PDU:
                     setAgentState = (ATTSetAgentStateConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTSetAgentStateConfEvent_t));
                    break;
                    case TypeATTEvent.ATTQueuedEvent_t_PDU:
                     queuedEvent = (ATTQueuedEvent_t)Marshal.PtrToStructure(point, typeof(ATTQueuedEvent_t));
                    break;
                    case TypeATTEvent.ATTDivertedEvent_t_PDU:
                     divertedEvent = (ATTDivertedEvent_t)Marshal.PtrToStructure(point, typeof(ATTDivertedEvent_t));
                    break;
                    case TypeATTEvent.ATTFailedEvent_t_PDU:
                     failedEvent = (ATTFailedEvent_t)Marshal.PtrToStructure(point, typeof(ATTFailedEvent_t));
                    break;
                    case TypeATTEvent.ATTSnapshotCallConfEvent_t_PDU:
                     snapshotCallConf = (ATTSnapshotCallConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTSnapshotCallConfEvent_t));
                    break;
                    case TypeATTEvent.ATTV3ConferencedEvent_t_PDU:
                     v3conferencedEvent = (ATTV3ConferencedEvent_t)Marshal.PtrToStructure(point, typeof(ATTV3ConferencedEvent_t));
                    break;
                    case TypeATTEvent.ATTV3DeliveredEvent_t_PDU:
                     v3deliveredEvent = (ATTV3DeliveredEvent_t)Marshal.PtrToStructure(point, typeof(ATTV3DeliveredEvent_t));
                    break;
                    case TypeATTEvent.ATTV3EstablishedEvent_t_PDU:
                     v3establishedEvent = (ATTV3EstablishedEvent_t)Marshal.PtrToStructure(point, typeof(ATTV3EstablishedEvent_t));
                    break;
                    case TypeATTEvent.ATTV3TransferredEvent_t_PDU:
                     v3transferredEvent = (ATTV3TransferredEvent_t)Marshal.PtrToStructure(point, typeof(ATTV3TransferredEvent_t));
                    break;
                    case TypeATTEvent.ATTV3LinkStatusEvent_t_PDU:
                     v3linkStatus = (ATTV3LinkStatusEvent_t)Marshal.PtrToStructure(point, typeof(ATTV3LinkStatusEvent_t));
                    break;
                    case TypeATTEvent.ATTV4QueryDeviceInfoConfEvent_t_PDU:
                     v4queryDeviceInfo = (ATTV4QueryDeviceInfoConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTV4QueryDeviceInfoConfEvent_t));
                    break;
                    case TypeATTEvent.ATTV4GetAPICapsConfEvent_t_PDU:
                     v4getAPICaps = (ATTV4GetAPICapsConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTV4GetAPICapsConfEvent_t));
                    break;
                    case TypeATTEvent.ATTV4SnapshotDeviceConfEvent_t_PDU:
                     v4snapshotDevice = (ATTV4SnapshotDeviceConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTV4SnapshotDeviceConfEvent_t));
                    break;
                    case TypeATTEvent.ATTV4ConferencedEvent_t_PDU:
                     v4conferencedEvent = (ATTV4ConferencedEvent_t)Marshal.PtrToStructure(point, typeof(ATTV4ConferencedEvent_t));
                    break;
                    case TypeATTEvent.ATTV4DeliveredEvent_t_PDU:
                     v4deliveredEvent = (ATTV4DeliveredEvent_t)Marshal.PtrToStructure(point, typeof(ATTV4DeliveredEvent_t));
                    break;
                    case TypeATTEvent.ATTV4EstablishedEvent_t_PDU:
                     v4establishedEvent = (ATTV4EstablishedEvent_t)Marshal.PtrToStructure(point, typeof(ATTV4EstablishedEvent_t));
                    break;
                    case TypeATTEvent.ATTV4TransferredEvent_t_PDU:
                     v4transferredEvent = (ATTV4TransferredEvent_t)Marshal.PtrToStructure(point, typeof(ATTV4TransferredEvent_t));
                    break;
                    case TypeATTEvent.ATTV4LinkStatusEvent_t_PDU:
                     v4linkStatus = (ATTV4LinkStatusEvent_t)Marshal.PtrToStructure(point, typeof(ATTV4LinkStatusEvent_t));
                    break;
                    case TypeATTEvent.ATTV4RouteRequestEvent_t_PDU:
                     v4routeRequest = (ATTV4RouteRequestEvent_t)Marshal.PtrToStructure(point, typeof(ATTV4RouteRequestEvent_t));
                    break;
                    case TypeATTEvent.ATTV4QueryAgentStateConfEvent_t_PDU:
                     v4queryAgentState = (ATTV4QueryAgentStateConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTV4QueryAgentStateConfEvent_t));
                    break;
                    case TypeATTEvent.ATTV4QueryDeviceNameConfEvent_t_PDU:
                     v4queryDeviceName = (ATTV4QueryDeviceNameConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTV4QueryDeviceNameConfEvent_t));
                    break;
                    case TypeATTEvent.ATTV4MonitorConfEvent_t_PDU:
                     v4monitorStart = (ATTV4MonitorConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTV4MonitorConfEvent_t));
                    break;
                    case TypeATTEvent.ATTV4MonitorCallConfEvent_t_PDU:
                     v4monitorCallStart = (ATTV4MonitorCallConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTV4MonitorCallConfEvent_t));
                    break;
                    case TypeATTEvent.ATTV4NetworkReachedEvent_t_PDU:
                     v4networkReachedEvent = (ATTV4NetworkReachedEvent_t)Marshal.PtrToStructure(point, typeof(ATTV4NetworkReachedEvent_t));
                    break;
                    case TypeATTEvent.ATTV5QueryAgentStateConfEvent_t_PDU:
                     v5queryAgentState = (ATTV5QueryAgentStateConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTV5QueryAgentStateConfEvent_t));
                    break;
                    case TypeATTEvent.ATTV5RouteRequestEvent_t_PDU:
                     v5routeRequest = (ATTV5RouteRequestEvent_t)Marshal.PtrToStructure(point, typeof(ATTV5RouteRequestEvent_t));
                    break;
                    case TypeATTEvent.ATTV5TransferredEvent_t_PDU:
                     v5transferredEvent = (ATTV5TransferredEvent_t)Marshal.PtrToStructure(point, typeof(ATTV5TransferredEvent_t));
                    break;
                    case TypeATTEvent.ATTV5ConferencedEvent_t_PDU:
                     v5conferencedEvent = (ATTV5ConferencedEvent_t)Marshal.PtrToStructure(point, typeof(ATTV5ConferencedEvent_t));
                    break;
                    case TypeATTEvent.ATTV5ConnectionClearedEvent_t_PDU:
                     v5connectionClearedEvent = (ATTV5ConnectionClearedEvent_t)Marshal.PtrToStructure(point, typeof(ATTV5ConnectionClearedEvent_t));
                    break;
                    case TypeATTEvent.ATTV5OriginatedEvent_t_PDU:
                     v5originatedEvent = (ATTV5OriginatedEvent_t)Marshal.PtrToStructure(point, typeof(ATTV5OriginatedEvent_t));
                    break;
                    case TypeATTEvent.ATTV5EstablishedEvent_t_PDU:
                     v5establishedEvent = (ATTV5EstablishedEvent_t)Marshal.PtrToStructure(point, typeof(ATTV5EstablishedEvent_t));
                    break;
                    case TypeATTEvent.ATTV5DeliveredEvent_t_PDU:
                     v5deliveredEvent = (ATTV5DeliveredEvent_t)Marshal.PtrToStructure(point, typeof(ATTV5DeliveredEvent_t));
                    break;
                    case TypeATTEvent.ATTV6NetworkReachedEvent_t_PDU:
                     v6networkReachedEvent = (ATTV6NetworkReachedEvent_t)Marshal.PtrToStructure(point, typeof(ATTV6NetworkReachedEvent_t));
                    break;
                    case TypeATTEvent.ATTV6ConferencedEvent_t_PDU:
                     v6conferencedEvent = (ATTV6ConferencedEvent_t)Marshal.PtrToStructure(point, typeof(ATTV6ConferencedEvent_t));
                    break;
                    case TypeATTEvent.ATTV6DeliveredEvent_t_PDU:
                     v6deliveredEvent = (ATTV6DeliveredEvent_t)Marshal.PtrToStructure(point, typeof(ATTV6DeliveredEvent_t));
                    break;
                    case TypeATTEvent.ATTV6EstablishedEvent_t_PDU:
                     v6establishedEvent = (ATTV6EstablishedEvent_t)Marshal.PtrToStructure(point, typeof(ATTV6EstablishedEvent_t));
                    break;
                    case TypeATTEvent.ATTV6TransferredEvent_t_PDU:
                     v6transferredEvent = (ATTV6TransferredEvent_t)Marshal.PtrToStructure(point, typeof(ATTV6TransferredEvent_t));
                    break;
                    case TypeATTEvent.ATTV6QueryDeviceNameConfEvent_t_PDU:
                     v6queryDeviceName = (ATTV6QueryDeviceNameConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTV6QueryDeviceNameConfEvent_t));
                    break;
                    case TypeATTEvent.ATTV6GetAPICapsConfEvent_t_PDU:
                     v6getAPICaps = (ATTV6GetAPICapsConfEvent_t)Marshal.PtrToStructure(point, typeof(ATTV6GetAPICapsConfEvent_t));
                    break;
                    case TypeATTEvent.ATTV6ConnectionClearedEvent_t_PDU:
                     v6connectionClearedEvent = (ATTV6ConnectionClearedEvent_t)Marshal.PtrToStructure(point, typeof(ATTV6ConnectionClearedEvent_t));
                    break;
                    case TypeATTEvent.ATTV6RouteRequestEvent_t_PDU:
                     v6routeRequest = (ATTV6RouteRequestEvent_t)Marshal.PtrToStructure(point, typeof(ATTV6RouteRequestEvent_t));
                    break;
                    case TypeATTEvent.ATTClearConnection_t_PDU:
                     clearConnectionReq = (ATTClearConnection_t)Marshal.PtrToStructure(point, typeof(ATTClearConnection_t));
                    break;
                    case TypeATTEvent.ATTConsultationCall_t_PDU:
                     consultationCallReq = (ATTConsultationCall_t)Marshal.PtrToStructure(point, typeof(ATTConsultationCall_t));
                    break;
                    case TypeATTEvent.ATTMakeCall_t_PDU:
                     makeCallReq = (ATTMakeCall_t)Marshal.PtrToStructure(point, typeof(ATTMakeCall_t));
                    break;
                    case TypeATTEvent.ATTDirectAgentCall_t_PDU:
                     directAgentCallReq = (ATTDirectAgentCall_t)Marshal.PtrToStructure(point, typeof(ATTDirectAgentCall_t));
                    break;
                    case TypeATTEvent.ATTMakePredictiveCall_t_PDU:
                     makePredictiveCallReq = (ATTMakePredictiveCall_t)Marshal.PtrToStructure(point, typeof(ATTMakePredictiveCall_t));
                    break;
                    case TypeATTEvent.ATTSupervisorAssistCall_t_PDU:
                     supervisorAssistCallReq = (ATTSupervisorAssistCall_t)Marshal.PtrToStructure(point, typeof(ATTSupervisorAssistCall_t));
                    break;
                    case TypeATTEvent.ATTReconnectCall_t_PDU:
                     reconnectCallReq = (ATTReconnectCall_t)Marshal.PtrToStructure(point, typeof(ATTReconnectCall_t));
                    break;
                    case TypeATTEvent.ATTSendDTMFTone_t_PDU:
                     sendDTMFToneReq = (ATTSendDTMFTone_t)Marshal.PtrToStructure(point, typeof(ATTSendDTMFTone_t));
                    break;
                    case TypeATTEvent.ATTSingleStepConferenceCall_t_PDU:
                     ssconferenceReq = (ATTSingleStepConferenceCall_t)Marshal.PtrToStructure(point, typeof(ATTSingleStepConferenceCall_t));
                    break;
                    case TypeATTEvent.ATTSelectiveListeningHold_t_PDU:
                     slholdReq = (ATTSelectiveListeningHold_t)Marshal.PtrToStructure(point, typeof(ATTSelectiveListeningHold_t));
                    break;
                    case TypeATTEvent.ATTSelectiveListeningRetrieve_t_PDU:
                     slretrieveReq = (ATTSelectiveListeningRetrieve_t)Marshal.PtrToStructure(point, typeof(ATTSelectiveListeningRetrieve_t));
                    break;
                    case TypeATTEvent.ATTSetAgentState_t_PDU:
                     setAgentStateReq = (ATTSetAgentState_t)Marshal.PtrToStructure(point, typeof(ATTSetAgentState_t));
                    break;
                    case TypeATTEvent.ATTQueryAgentState_t_PDU:
                     queryAgentStateReq = (ATTQueryAgentState_t)Marshal.PtrToStructure(point, typeof(ATTQueryAgentState_t));
                    break;
                    case TypeATTEvent.ATTQueryAcdSplit_t_PDU:
                     queryAcdSplitReq = (ATTQueryAcdSplit_t)Marshal.PtrToStructure(point, typeof(ATTQueryAcdSplit_t));
                    break;
                    case TypeATTEvent.ATTQueryAgentLogin_t_PDU:
                     queryAgentLoginReq = (ATTQueryAgentLogin_t)Marshal.PtrToStructure(point, typeof(ATTQueryAgentLogin_t));
                    break;
                    case TypeATTEvent.ATTQueryCallClassifier_t_PDU:
                     queryCallClassifierReq = (ATTQueryCallClassifier_t)Marshal.PtrToStructure(point, typeof(ATTQueryCallClassifier_t));
                    break;
                    case TypeATTEvent.ATTQueryDeviceName_t_PDU:
                     queryDeviceNameReq = (ATTQueryDeviceName_t)Marshal.PtrToStructure(point, typeof(ATTQueryDeviceName_t));
                    break;
                    case TypeATTEvent.ATTQueryStationStatus_t_PDU:
                     queryStationStatusReq = (ATTQueryStationStatus_t)Marshal.PtrToStructure(point, typeof(ATTQueryStationStatus_t));
                    break;
                    case TypeATTEvent.ATTQueryTod_t_PDU:
                     queryTodReq = (ATTQueryTod_t)Marshal.PtrToStructure(point, typeof(ATTQueryTod_t));
                    break;
                    case TypeATTEvent.ATTQueryTg_t_PDU:
                     queryTgReq = (ATTQueryTg_t)Marshal.PtrToStructure(point, typeof(ATTQueryTg_t));
                    break;
                    case TypeATTEvent.ATTQueryAgentMeasurements_t_PDU:
                     queryAgentMeasReq = (ATTQueryAgentMeasurements_t)Marshal.PtrToStructure(point, typeof(ATTQueryAgentMeasurements_t));
                    break;
                    case TypeATTEvent.ATTQuerySplitSkillMeasurements_t_PDU:
                     querySplitSkillMeasReq = (ATTQuerySplitSkillMeasurements_t)Marshal.PtrToStructure(point, typeof(ATTQuerySplitSkillMeasurements_t));
                    break;
                    case TypeATTEvent.ATTQueryTrunkGroupMeasurements_t_PDU:
                     queryTrunkGroupMeasReq = (ATTQueryTrunkGroupMeasurements_t)Marshal.PtrToStructure(point, typeof(ATTQueryTrunkGroupMeasurements_t));
                    break;
                    case TypeATTEvent.ATTQueryVdnMeasurements_t_PDU:
                     queryVdnMeasReq = (ATTQueryVdnMeasurements_t)Marshal.PtrToStructure(point, typeof(ATTQueryVdnMeasurements_t));
                    break;
                    case TypeATTEvent.ATTMonitorFilter_t_PDU:
                     monitorFilterReq = (ATTMonitorFilter_t)Marshal.PtrToStructure(point, typeof(ATTMonitorFilter_t));
                    break;
                    case TypeATTEvent.ATTMonitorStopOnCall_t_PDU:
                     monitorStopOnCallReq = (ATTMonitorStopOnCall_t)Marshal.PtrToStructure(point, typeof(ATTMonitorStopOnCall_t));
                    break;
                    case TypeATTEvent.ATTRouteSelect_t_PDU:
                     routeSelectReq = (ATTRouteSelect_t)Marshal.PtrToStructure(point, typeof(ATTRouteSelect_t));
                    break;
                    case TypeATTEvent.ATTSysStat_t_PDU:
                     sysStatReq = (ATTSysStat_t)Marshal.PtrToStructure(point, typeof(ATTSysStat_t));
                    break;
                    case TypeATTEvent.ATTSetBillRate_t_PDU:
                     setBillRateReq = (ATTSetBillRate_t)Marshal.PtrToStructure(point, typeof(ATTSetBillRate_t));
                    break;
                    case TypeATTEvent.ATTQueryUcid_t_PDU:
                     queryUCIDReq = (ATTQueryUcid_t)Marshal.PtrToStructure(point, typeof(ATTQueryUcid_t));
                    break;
                    case TypeATTEvent.ATTSetAdviceOfCharge_t_PDU:
                     adviceOfChargeReq = (ATTSetAdviceOfCharge_t)Marshal.PtrToStructure(point, typeof(ATTSetAdviceOfCharge_t));
                    break;
                    case TypeATTEvent.ATTV4SendDTMFTone_t_PDU:
                     v4sendDTMFToneReq = (ATTV4SendDTMFTone_t)Marshal.PtrToStructure(point, typeof(ATTV4SendDTMFTone_t));
                    break;
                    case TypeATTEvent.ATTV4SetAgentState_t_PDU:
                     v4setAgentStateReq = (ATTV4SetAgentState_t)Marshal.PtrToStructure(point, typeof(ATTV4SetAgentState_t));
                    break;
                    case TypeATTEvent.ATTV4MonitorFilter_t_PDU:
                     v4monitorFilterReq = (ATTV4MonitorFilter_t)Marshal.PtrToStructure(point, typeof(ATTV4MonitorFilter_t));
                    break;
                    case TypeATTEvent.ATTV5SetAgentState_t_PDU:
                     v5setAgentStateReq = (ATTV5SetAgentState_t)Marshal.PtrToStructure(point, typeof(ATTV5SetAgentState_t));
                    break;
                    case TypeATTEvent.ATTV5ClearConnection_t_PDU:
                     v5clearConnectionReq = (ATTV5ClearConnection_t)Marshal.PtrToStructure(point, typeof(ATTV5ClearConnection_t));
                    break;
                    case TypeATTEvent.ATTV5ConsultationCall_t_PDU:
                     v5consultationCallReq = (ATTV5ConsultationCall_t)Marshal.PtrToStructure(point, typeof(ATTV5ConsultationCall_t));
                    break;
                    case TypeATTEvent.ATTV5MakeCall_t_PDU:
                     v5makeCallReq = (ATTV5MakeCall_t)Marshal.PtrToStructure(point, typeof(ATTV5MakeCall_t));
                    break;
                    case TypeATTEvent.ATTV5DirectAgentCall_t_PDU:
                     v5directAgentCallReq = (ATTV5DirectAgentCall_t)Marshal.PtrToStructure(point, typeof(ATTV5DirectAgentCall_t));
                    break;
                    case TypeATTEvent.ATTV5MakePredictiveCall_t_PDU:
                     v5makePredictiveCallReq = (ATTV5MakePredictiveCall_t)Marshal.PtrToStructure(point, typeof(ATTV5MakePredictiveCall_t));
                    break;
                    case TypeATTEvent.ATTV5SupervisorAssistCall_t_PDU:
                     v5supervisorAssistCallReq = (ATTV5SupervisorAssistCall_t)Marshal.PtrToStructure(point, typeof(ATTV5SupervisorAssistCall_t));
                    break;
                    case TypeATTEvent.ATTV5ReconnectCall_t_PDU:
                     v5reconnectCallReq = (ATTV5ReconnectCall_t)Marshal.PtrToStructure(point, typeof(ATTV5ReconnectCall_t));
                    break;
                    case TypeATTEvent.ATTV5RouteSelect_t_PDU:
                     v5routeSelectReq = (ATTV5RouteSelect_t)Marshal.PtrToStructure(point, typeof(ATTV5RouteSelect_t));
                    break;
                    case TypeATTEvent.ATTV6RouteSelect_t_PDU:
                     v6routeSelectReq = (ATTV6RouteSelect_t)Marshal.PtrToStructure(point, typeof(ATTV6RouteSelect_t));
                    break;
            }
        }
    }
}
