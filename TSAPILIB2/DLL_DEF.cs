using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace TSAPILIB2
{
    // ReSharper disable InconsistentNaming

    [Flags]
    [DataContract]
    public enum ACSFunctionRet_t
    {

        ACSPOSITIVE_ACK = 0,

        ACSERR_APIVERDENIED = -1,
        ACSERR_BADPARAMETER = -2,
        ACSERR_DUPSTREAM = -3,
        ACSERR_NODRIVER = -4,
        ACSERR_NOSERVER = -5,
        ACSERR_NORESOURCE = -6,
        ACSERR_UBUFSMALL = -7,
        ACSERR_NOMESSAGE = -8,
        ACSERR_UNKNOWN = -9,
        ACSERR_BADHDL = -10,
        ACSERR_STREAM_FAILED = -11,
        ACSERR_NOBUFFERS = -12,
        ACSERR_QUEUE_FULL = -13,
        ACSERR_ERROR_SEND_TO_QUEUR = -14,
        ACSERR_BAD_SESSION_ID = -15
    }
    public enum StreamType_t
    {
        stCsta = 1,
        stOam = 2,
        stDirectory = 3,
        stNmsrv = 4
    }
    public enum InvokeIDType_t
    {
        APP_GEN_ID,
        LIB_GEN_ID
}
    public enum Level_t
    {
        acsLevel1 = 1,
        acsLevel2 = 2,
        acsLevel3 = 3,
        acsLevel4 = 4
    }
    [Serializable,StructLayout(LayoutKind.Sequential)]
    public struct PrivateData_t
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string vendor;
        public ushort length;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst= 1024 * 2)]
        public char[] data;
        public void Set(string ldata)
        {
           data = new char[1024*2];
           ldata.ToCharArray().CopyTo(data, 1);
           length = (ushort)(ldata.Length+2);
        }
    }
    public enum TypeATTEvent 
    {
        ATTV5ClearConnection_t_PDU = 1,
        ATTV5ConsultationCall_t_PDU = 2,
        ATTV5MakeCall_t_PDU = 3,
        ATTV5DirectAgentCall_t_PDU = 4,
        ATTV5MakePredictiveCall_t_PDU = 5,
        ATTV5SupervisorAssistCall_t_PDU = 6,
        ATTV5ReconnectCall_t_PDU = 7,
        ATTV4SendDTMFTone_t_PDU = 8,
        ATTSendDTMFToneConfEvent_t_PDU = 9,
        ATTV4SetAgentState_t_PDU = 10,
        ATTQueryAcdSplit_t_PDU = 11,
        ATTQueryAcdSplitConfEvent_t_PDU = 12,
        ATTQueryAgentLogin_t_PDU = 13,
        ATTQueryAgentLoginConfEvent_t_PDU = 14,
        ATTQueryAgentLoginResp_t_PDU = 15,
        ATTQueryAgentState_t_PDU = 16,
        ATTV4QueryAgentStateConfEvent_t_PDU = 17,
        ATTQueryCallClassifier_t_PDU = 18,
        ATTQueryCallClassifierConfEvent_t_PDU = 19,
        ATTV4QueryDeviceInfoConfEvent_t_PDU = 20,
        ATTQueryMwiConfEvent_t_PDU = 21,
        ATTQueryStationStatus_t_PDU = 22,
        ATTQueryStationStatusConfEvent_t_PDU = 23,
        ATTQueryTod_t_PDU = 24,
        ATTQueryTodConfEvent_t_PDU = 25,
        ATTQueryTg_t_PDU = 26,
        ATTQueryTgConfEvent_t_PDU = 27,
        ATTV4SnapshotDeviceConfEvent_t_PDU = 28,
        ATTV4MonitorFilter_t_PDU = 29,
        ATTV4MonitorConfEvent_t_PDU = 30,
        ATTMonitorStopOnCall_t_PDU = 31,
        ATTMonitorStopOnCallConfEvent_t_PDU = 32,
        ATTV4MonitorCallConfEvent_t_PDU = 33,
        ATTCallClearedEvent_t_PDU = 34,
        ATTV3ConferencedEvent_t_PDU = 35,
        ATTV5ConnectionClearedEvent_t_PDU = 36,
        ATTV3DeliveredEvent_t_PDU = 37,
        ATTEnteredDigitsEvent_t_PDU = 38,
        ATTV3EstablishedEvent_t_PDU = 39,
        ATTV4NetworkReachedEvent_t_PDU = 40,
        ATTV3TransferredEvent_t_PDU = 41,
        ATTV4RouteRequestEvent_t_PDU = 42,
        ATTV5RouteSelect_t_PDU = 43,
        ATTRouteUsedEvent_t_PDU = 44,
        ATTSysStat_t_PDU = 45,
        ATTV3LinkStatusEvent_t_PDU = 46,
        ATTV5OriginatedEvent_t_PDU = 47,
        ATTLoggedOnEvent_t_PDU = 48,
        ATTQueryDeviceName_t_PDU = 49,
        ATTV4QueryDeviceNameConfEvent_t_PDU = 50,
        ATTQueryAgentMeasurements_t_PDU = 51,
        ATTQueryAgentMeasurementsConfEvent_t_PDU = 52,
        ATTQuerySplitSkillMeasurements_t_PDU = 53,
        ATTQuerySplitSkillMeasurementsConfEvent_t_PDU = 54,
        ATTQueryTrunkGroupMeasurements_t_PDU = 55,
        ATTQueryTrunkGroupMeasurementsConfEvent_t_PDU = 56,
        ATTQueryVdnMeasurements_t_PDU = 57,
        ATTQueryVdnMeasurementsConfEvent_t_PDU = 58,
        ATTV4ConferencedEvent_t_PDU = 59,
        ATTV4DeliveredEvent_t_PDU = 60,
        ATTV4EstablishedEvent_t_PDU = 61,
        ATTV4TransferredEvent_t_PDU = 62,
        ATTV4LinkStatusEvent_t_PDU = 63,
        ATTV4GetAPICapsConfEvent_t_PDU = 64,
        ATTSingleStepConferenceCall_t_PDU = 65,
        ATTSingleStepConferenceCallConfEvent_t_PDU = 66,
        ATTSelectiveListeningHold_t_PDU = 67,
        ATTSelectiveListeningHoldConfEvent_t_PDU = 68,
        ATTSelectiveListeningRetrieve_t_PDU = 69,
        ATTSelectiveListeningRetrieveConfEvent_t_PDU = 70,
        ATTSendDTMFTone_t_PDU = 71,
        ATTSnapshotDeviceConfEvent_t_PDU = 72,
        ATTLinkStatusEvent_t_PDU = 73,
        ATTSetBillRate_t_PDU = 74,
        ATTSetBillRateConfEvent_t_PDU = 75,
        ATTQueryUcid_t_PDU = 76,
        ATTQueryUcidConfEvent_t_PDU = 77,
        ATTV5ConferencedEvent_t_PDU = 78,
        ATTLoggedOffEvent_t_PDU = 79,
        ATTV5DeliveredEvent_t_PDU = 80,
        ATTV5EstablishedEvent_t_PDU = 81,
        ATTV5TransferredEvent_t_PDU = 82,
        ATTV5RouteRequestEvent_t_PDU = 83,
        ATTConsultationCallConfEvent_t_PDU = 84,
        ATTMakeCallConfEvent_t_PDU = 85,
        ATTMakePredictiveCallConfEvent_t_PDU = 86,
        ATTV5SetAgentState_t_PDU = 87,
        ATTV5QueryAgentStateConfEvent_t_PDU = 88,
        ATTV6QueryDeviceNameConfEvent_t_PDU = 89,
        ATTConferenceCallConfEvent_t_PDU = 90,
        ATTTransferCallConfEvent_t_PDU = 91,
        ATTMonitorFilter_t_PDU = 92,
        ATTMonitorConfEvent_t_PDU = 93,
        ATTMonitorCallConfEvent_t_PDU = 94,
        ATTServiceInitiatedEvent_t_PDU = 95,
        ATTChargeAdviceEvent_t_PDU = 96,
        ATTV6GetAPICapsConfEvent_t_PDU = 97,
        ATTQueryDeviceInfoConfEvent_t_PDU = 98,
        ATTSetAdviceOfCharge_t_PDU = 99,
        ATTSetAdviceOfChargeConfEvent_t_PDU = 100,
        ATTV6NetworkReachedEvent_t_PDU = 101,
        ATTSetAgentState_t_PDU = 102,
        ATTSetAgentStateConfEvent_t_PDU = 103,
        ATTQueryAgentStateConfEvent_t_PDU = 104,
        ATTV6RouteRequestEvent_t_PDU = 105,
        ATTV6TransferredEvent_t_PDU = 106,
        ATTV6ConferencedEvent_t_PDU = 107,
        ATTClearConnection_t_PDU = 108,
        ATTConsultationCall_t_PDU = 109,
        ATTMakeCall_t_PDU = 110,
        ATTDirectAgentCall_t_PDU = 111,
        ATTMakePredictiveCall_t_PDU = 112,
        ATTSupervisorAssistCall_t_PDU = 113,
        ATTReconnectCall_t_PDU = 114,
        ATTV6ConnectionClearedEvent_t_PDU = 115,
        ATTV6RouteSelect_t_PDU = 116,
        ATTV6DeliveredEvent_t_PDU = 117,
        ATTV6EstablishedEvent_t_PDU = 118,
        ATTOriginatedEvent_t_PDU = 119,
        Reserved_t_PDU = 120,
        Reserved2_t_PDU = 121,
        Reserved3_t_PDU = 122,
        Reserved4_t_PDU = 123,
        Reserved5_t_PDU = 124,
        ATTQueryDeviceNameConfEvent_t_PDU = 125,
        ATTRouteSelect_t_PDU = 126,
        ATTGetAPICapsConfEvent_t_PDU = 127,
        ATTDeliveredEvent_t_PDU = 128,
        ATTEstablishedEvent_t_PDU = 129,
        ATTQueuedEvent_t_PDU = 130,
        ATTRouteRequestEvent_t_PDU = 131,
        ATTTransferredEvent_t_PDU = 132,
        ATTConferencedEvent_t_PDU = 133,
        ATTConnectionClearedEvent_t_PDU = 134,
        ATTDivertedEvent_t_PDU = 135,
        ATTNetworkReachedEvent_t_PDU = 136,
        ATTFailedEvent_t_PDU = 137,
        ATTSnapshotCallConfEvent_t_PDU = 138
    };
    public enum ACSUniversalFailure_t
    {
        tserverStreamFailed = 0,
        tserverNoThread = 1,
        tserverBadDriverId = 2,
        tserverDeadDriver = 3,
        tserverMessageHighWaterMark = 4,
        tserverFreeBufferFailed = 5,
        tserverSendToDriver = 6,
        tserverReceiveFromDriver = 7,
        tserverRegistrationFailed = 8,
        tserverSpxFailed = 9,
        tserverTrace = 10,
        tserverNoMemory = 11,
        tserverEncodeFailed = 12,
        tserverDecodeFailed = 13,
        tserverBadConnection = 14,
        tserverBadPdu = 15,
        tserverNoVersion = 16,
        tserverEcbMaxExceeded = 17,
        tserverNoEcbs = 18,
        tserverNoSdb = 19,
        tserverNoSdbCheckNeeded = 20,
        tserverSdbCheckNeeded = 21,
        tserverBadSdbLevel = 22,
        tserverBadServerid = 23,
        tserverBadStreamType = 24,
        tserverBadPasswordOrLogin = 25,
        tserverNoUserRecord = 26,
        tserverNoDeviceRecord = 27,
        tserverDeviceNotOnList = 28,
        tserverUsersRestrictedHome = 30,
        tserverNoAwaypermission = 31,
        tserverNoHomepermission = 32,
        tserverNoAwayWorktop = 33,
        tserverBadDeviceRecord = 34,
        tserverDeviceNotSupported = 35,
        tserverInsufficientPermission = 36,
        tserverNoResourceTag = 37,
        tserverInvalidMessage = 38,
        tserverExceptionList = 39,
        tserverNotOnOamList = 40,
        tserverPbxIdNotInSdb = 41,
        tserverUserLicensesExceeded = 42,
        tserverOamDropConnection = 43,
        tserverNoVersionRecord = 44,
        tserverOldVersionRecord = 45,
        tserverBadPacket = 46,
        tserverOpenFailed = 47,
        tserverOamInUse = 48,
        tserverDeviceNotOnHomeList = 49,
        tserverDeviceNotOnCallControlList = 50,
        tserverDeviceNotOnAwayList = 51,
        tserverDeviceNotOnRouteList = 52,
        tserverDeviceNotOnMonitorDeviceList = 53,
        tserverDeviceNotOnMonitorCallDeviceList = 54,
        tserverNoCallCallMonitorPermission = 55,
        tserverHomeDeviceListEmpty = 56,
        tserverCallControlListEmpty = 57,
        tserverAwayListEmpty = 58,
        tserverRouteListEmpty = 59,
        tserverMonitorDeviceListEmpty = 60,
        tserverMonitorCallDeviceListEmpty = 61,
        tserverUserAtHomeWorktop = 62,
        tserverDeviceListEmpty = 63,
        tserverBadGetDeviceLevel = 64,
        tserverDriverUnregistered = 65,
        tserverNoAcsStream = 66,
        tserverDropOam = 67,
        tserverEcbTimeout = 68,
        tserverBadEcb = 69,
        tserverAdvertiseFailed = 70,
        tserverNetwareFailure = 71,
        tserverTdiQueueFault = 72,
        tserverDriverCongestion = 73,
        tserverNoTdiBuffers = 74,
        tserverOldInvokeid = 75,
        tserverHwmarkToLarge = 76,
        tserverSetEcbToLow = 77,
        tserverNoRecordInFile = 78,
        tserverEcbOverdue = 79,
        tserverBadPwEncryption = 80,
        tserverBadTservProtocol = 81,
        tserverBadDriverProtocol = 82,
        tserverBadTransportType = 83,
        tserverPduVersionMismatch = 84,
        tserverVersionMismatch = 85,
        tserverLicenseMismatch = 86,
        tserverBadAttributeList = 87,
        tserverBadTlistType = 88,
        tserverBadProtocolFormat = 89,
        tserverOldTslib = 90,
        tserverBadLicenseFile = 91,
        tserverNoPatches = 92,
        tserverSystemError = 93,
        tserverOamListEmpty = 94,
        tserverTcpFailed = 95,
        tserverSpxDisabled = 96,
        tserverTcpDisabled = 97,
        tserverRequiredModulesNotLoaded = 98,
        tserverTransportInUseByOam = 99,
        tserverNoNdsOamPermission = 100,
        tserverOpenSdbLogFailed = 101,
        tserverInvalidLogSize = 102,
        tserverWriteSdbLogFailed = 103,
        tserverNtFailure = 104,
        tserverLoadLibFailed = 105,
        tserverInvalidDriver = 106,
        tserverRegistryError = 107,
        tserverDuplicateEntry = 108,
        tserverDriverLoaded = 109,
        tserverDriverNotLoaded = 110,
        tserverNoLogonPermission = 111,
        tserverAccountDisabled = 112,
        tserverNoNetlogon = 113,
        tserverAcctRestricted = 114,
        tserverInvalidLogonTime = 115,
        tserverInvalidWorkstation = 116,
        tserverAcctLockedOut = 117,
        tserverPasswordExpired = 118,
        driverDuplicateAcshandle = 1000,
        driverInvalidAcsRequest = 1001,
        driverAcsHandleRejection = 1002,
        driverInvalidClassRejection = 1003,
        driverGenericRejection = 1004,
        driverResourceLimitation = 1005,
        driverAcshandleTermination = 1006,
        driverLinkUnavailable = 1007,
        driverOamInUse = 1008
    }
    public enum EventClass_t : ushort
    {
        ACSREQUEST = 0,
        ACSUNSOLICITED = 1,
        ACSCONFIRMATION = 2,
        CSTAREQUEST = 3,
        CSTAUNSOLICITED = 4,
        CSTACONFIRMATION = 5,
        CSTAEVENTREPORT = 6
    }
    public enum DeviceIDType_t
    {
        deviceIdentifier = 0,
        explicitPublic = 20,
        explicitPublicUnknown = 30,
        explicitPublicInternational = 31,
        explicitPublicNational = 32,
        explicitPublicNetworkSpecific = 33,
        explicitPublicSubscriber = 34,
        explicitPublicAbbreviated = 35,
        explicitPrivate = 40,
        explicitPrivateUnknown = 50,
        explicitPrivateLevel3RegionalNumber = 51,
        explicitPrivateLevel2RegionalNumber = 52,
        explicitPrivateLevel1RegionalNumber = 53,
        explicitPrivatePtnSpecificNumber = 54,
        explicitPrivateLocalNumber = 55,
        explicitPrivateAbbreviated = 56,
        otherPlan = 60,
        trunkIdentifier = 70,
        trunkGroupIdentifier = 71
    }
    public enum SelectValue_t
    {
        svNormal = 0,
        svLeastCost = 1,
        svEmergency = 2,
        svAcd = 3,
        svUserDefined = 4
    }
    public enum eventTypeACS : ushort
    {
        ACS_OPEN_STREAM = 1,
        ACS_OPEN_STREAM_CONF = 2,
        ACS_CLOSE_STREAM = 3,
        ACS_CLOSE_STREAM_CONF = 4,
        ACS_ABORT_STREAM = 5,
        ACS_UNIVERSAL_FAILURE_CONF = 6,
        ACS_UNIVERSAL_FAILURE = 7,
        ACS_KEY_REQUEST = 8,
        ACS_KEY_REPLY = 9,
        ACS_NAME_SRV_REQUEST = 10,
        ACS_NAME_SRV_REPLY = 11,
        ACS_AUTH_REPLY = 12,
        ACS_AUTH_REPLY_TWO = 13
    }

   
    public enum ConnectionID_Device_t
    {
        staticId = 0,
        dynamicId = 1,
    }
    [Serializable,StructLayout(LayoutKind.Sequential)]
    public struct ConnectionID_t
    {
        public int callID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string deviceID;
        public ConnectionID_Device_t devIDType;
        public ConnectionID_t(int call, String device)
        {
           callID = call;
           deviceID = device;
           devIDType = ConnectionID_Device_t.staticId;
        }
           public ConnectionID_t(int call, String device, ConnectionID_Device_t type)
        {
           callID = call;
           deviceID = device;
           devIDType = type;
        }

        public override string ToString()
        {
            return String.Format("ConnectionID_t{{'callID':'{0}','deviceID':'{1}','devIDType':'{2}',}}", callID, deviceID, devIDType);
        }
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct SetUpValues_t
    {
        public uint length;
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        public string value;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTARouteRequestEvent_t
    {
        public int routeRegisterReqID;
        public int routingCrossRefID;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string currentRoute;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string callingDevice;
        public ConnectionID_t routedCall;
        public SelectValue_t routedSelAlgorithm;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool priority;
        public SetUpValues_t setupInformation;
    }
    public enum DeviceIDStatus_t
    {
        idProvided = 0,
        idNotKnown = 1,
        idNotRequired = 2,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ExtendedDeviceID_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string deviceID;
        public DeviceIDType_t deviceIDType;
        public DeviceIDStatus_t deviceIDStatus;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTARouteRequestExtEvent_t
    {
        public int routeRegisterReqID;
        public int routingCrossRefID;
        public ExtendedDeviceID_t currentRoute;
        public ExtendedDeviceID_t callingDevice;
        public ConnectionID_t routedCall;
        public SelectValue_t routedSelAlgorithm;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool priority;
        public SetUpValues_t setupInformation;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAReRouteRequest_t
    {
        public int routeRegisterReqID;
        public int routingCrossRefID;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAEscapeSvcReqEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASysStatReqEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
   
  
    public enum CSTAEventCause_t
    {
        ecNone = -1,
        ecInitNone = 0,
        ecActiveMonitor = 1,
        ecAlternate = 2,
        ecBusy = 3,
        ecCallBack = 4,
        ecCallCancelled = 5,
        ecCallForwardAlways = 6,
        ecCallForwardBusy = 7,
        ecCallForwardNoAnswer = 8,
        ecCallForward = 9,
        ecCallNotAnswered = 10,
        ecCallPickup = 11,
        ecCampOn = 12,
        ecDestNotObtainable = 13,
        ecDoNotDisturb = 14,
        ecIncompatibleDestination = 15,
        ecInvalidAccountCode = 16,
        ecKeyConference = 17,
        ecLockout = 18,
        ecMaintenance = 19,
        ecNetworkCongestion = 20,
        ecNetworkNotObtainable = 21,
        ecNewCall = 22,
        ecNoAvailableAgents = 23,
        ecOverride = 24,
        ecPark = 25,
        ecOverflow = 26,
        ecRecall = 27,
        ecRedirected = 28,
        ecReorderTone = 29,
        ecResourcesNotAvailable = 30,
        ecSilentMonitor = 31,
        ecTransfer = 32,
        ecTrunksBusy = 33,
        ecVoiceUnitInitiator = 34,
        ecNetworkSignal = 46,
        ecAlertTimeExpired = 60,
        ecDestOutOfOrder = 65,
        ecNotSupportedBearerService = 80,
        ecUnassignedNumber = 81,
        ecIncompatibleBearerService = 87,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTACallClearedEvent_t
    {
        public ConnectionID_t clearedCall;
        public LocalConnectionState_t localConnectionInfo;
        public CSTAEventCause_t cause;
    }
    
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAConferencedEvent_t
    {
        public ConnectionID_t primaryOldCall;
        public ConnectionID_t secondaryOldCall;
        public ExtendedDeviceID_t confController;
        public ExtendedDeviceID_t addedParty;
        //public ConnectionList_t conferenceConnections;
        public List<Connection_t> conferenceConnections;
        public LocalConnectionState_t localConnectionInfo;
        public CSTAEventCause_t cause;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAConnectionClearedEvent_t
    {
        public ConnectionID_t droppedConnection;
        public ExtendedDeviceID_t releasingDevice;
        public LocalConnectionState_t localConnectionInfo;
        public CSTAEventCause_t cause;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTADeliveredEvent_t
    {
        public ConnectionID_t connection;
        public ExtendedDeviceID_t alertingDevice;
        public ExtendedDeviceID_t callingDevice;
        public ExtendedDeviceID_t calledDevice;
        public ExtendedDeviceID_t lastRedirectionDevice;
        public LocalConnectionState_t localConnectionInfo;
        public CSTAEventCause_t cause;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTADivertedEvent_t
    {
        public ConnectionID_t connection;
        public ExtendedDeviceID_t divertingDevice;
        public ExtendedDeviceID_t newDestination;
        public LocalConnectionState_t localConnectionInfo;
        public CSTAEventCause_t cause;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAEstablishedEvent_t
    {
        public ConnectionID_t establishedConnection;
        public ExtendedDeviceID_t answeringDevice;
        public ExtendedDeviceID_t callingDevice;
        public ExtendedDeviceID_t calledDevice;
        public ExtendedDeviceID_t lastRedirectionDevice;
        public LocalConnectionState_t localConnectionInfo;
        public CSTAEventCause_t cause;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAFailedEvent_t
    {
        public ConnectionID_t failedConnection;
        public ExtendedDeviceID_t failingDevice;
        public ExtendedDeviceID_t calledDevice;
        public LocalConnectionState_t localConnectionInfo;
        public CSTAEventCause_t cause;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAHeldEvent_t
    {
        public ConnectionID_t heldConnection;
        public ExtendedDeviceID_t holdingDevice;
        public LocalConnectionState_t localConnectionInfo;
        public CSTAEventCause_t cause;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTANetworkReachedEvent_t
    {
        public ConnectionID_t connection;
        public ExtendedDeviceID_t trunkUsed;
        public ExtendedDeviceID_t calledDevice;
        public LocalConnectionState_t localConnectionInfo;
        public CSTAEventCause_t cause;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAOriginatedEvent_t
    {
        public ConnectionID_t originatedConnection;
        public ExtendedDeviceID_t callingDevice;
        public ExtendedDeviceID_t calledDevice;
        public LocalConnectionState_t localConnectionInfo;
        public CSTAEventCause_t cause;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAQueuedEvent_t
    {
        public ConnectionID_t queuedConnection;
        public ExtendedDeviceID_t queue;
        public ExtendedDeviceID_t callingDevice;
        public ExtendedDeviceID_t calledDevice;
        public ExtendedDeviceID_t lastRedirectionDevice;
        public short numberQueued;
        public LocalConnectionState_t localConnectionInfo;
        public CSTAEventCause_t cause;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTARetrievedEvent_t
    {
        public ConnectionID_t retrievedConnection;
        public ExtendedDeviceID_t retrievingDevice;
        public LocalConnectionState_t localConnectionInfo;
        public CSTAEventCause_t cause;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAServiceInitiatedEvent_t
    {
        public ConnectionID_t initiatedConnection;
        public LocalConnectionState_t localConnectionInfo;
        public CSTAEventCause_t cause;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTATransferredEvent_t
    {
        public ConnectionID_t primaryOldCall;
        public ConnectionID_t secondaryOldCall;
        public ExtendedDeviceID_t transferringDevice;
        public ExtendedDeviceID_t transferredDevice;
        public ConnectionList_t transferredConnections;
        public LocalConnectionState_t localConnectionInfo;
        public CSTAEventCause_t cause;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTACallInformationEvent_t
    {
        public ConnectionID_t connection;
        public ExtendedDeviceID_t device;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string accountInfo;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string authorisationCode;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTADoNotDisturbEvent_t
    {
        public ExtendedDeviceID_t device;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool doNotDisturbOn;
    }
    public enum ForwardingType_t
    {
        fwdImmediate = 0,
        fwdBusy = 1,
        fwdNoAns = 2,
        fwdBusyInt = 3,
        fwdBusyExt = 4,
        fwdNoAnsInt = 5,
        fwdNoAnsExt = 6,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ForwardingInfo_t
    {
        public ForwardingType_t forwardingType;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool forwardingOn;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string forwardDN;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAForwardingEvent_t
    {
        public ExtendedDeviceID_t device;
        public ForwardingInfo_t forwardingInformation;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAMessageWaitingEvent_t
    {
        public ExtendedDeviceID_t deviceForMessage;
        public ExtendedDeviceID_t invokingDevice;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool messageWaitingOn;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTALoggedOnEvent_t
    {
        public ExtendedDeviceID_t agentDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string agentID;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string agentGroup;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string password;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTALoggedOffEvent_t
    {
        public ExtendedDeviceID_t agentDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string agentID;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string agentGroup;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTANotReadyEvent_t
    {
        public ExtendedDeviceID_t agentDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string agentID;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTAReadyEvent_t
    {
        public ExtendedDeviceID_t agentDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string agentID;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTAWorkNotReadyEvent_t
    {
        public ExtendedDeviceID_t agentDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string agentID;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTAWorkReadyEvent_t
    {
        public ExtendedDeviceID_t agentDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string agentID;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTARouteRegisterReq_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string routingDevice;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTARouteRegisterReqConfEvent_t
    {
        public int registerReqID;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTARouteRegisterCancel_t
    {
        public int routeRegisterReqID;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTARouteRegisterCancelConfEvent_t
    {
        public int routeRegisterReqID;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTARouteRegisterAbortEvent_t
    {
        public int routeRegisterReqID;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTARouteSelectRequest_t
    {
        public int routeRegisterReqID;
        public int routingCrossRefID;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string routeSelected;
        public short remainRetry;
        public SetUpValues_t setupInformation;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool routeUsedReq;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTARouteUsedEvent_t
    {
        public int routeRegisterReqID;
        public int routingCrossRefID;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string routeUsed;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string callingDevice;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool domain;
    }



    
    public enum CSTAUniversalFailure_t
    {
        genericUnspecified = 0,
        genericOperation = 1,
        requestIncompatibleWithObject = 2,
        valueOutOfRange = 3,
        objectNotKnown = 4,
        invalidCallingDevice = 5,
        invalidCalledDevice = 6,
        invalidForwardingDestination = 7,
        privilegeViolationOnSpecifiedDevice = 8,
        privilegeViolationOnCalledDevice = 9,
        privilegeViolationOnCallingDevice = 10,
        invalidCstaCallIdentifier = 11,
        invalidCstaDeviceIdentifier = 12,
        invalidCstaConnectionIdentifier = 13,
        invalidDestination = 14,
        invalidFeature = 15,
        invalidAllocationState = 16,
        invalidCrossRefId = 17,
        invalidObjectType = 18,
        securityViolation = 19,
        genericStateIncompatibility = 21,
        invalidObjectState = 22,
        invalidConnectionIdForActiveCall = 23,
        noActiveCall = 24,
        noHeldCall = 25,
        noCallToClear = 26,
        noConnectionToClear = 27,
        noCallToAnswer = 28,
        noCallToComplete = 29,
        genericSystemResourceAvailability = 31,
        serviceBusy = 32,
        resourceBusy = 33,
        resourceOutOfService = 34,
        networkBusy = 35,
        networkOutOfService = 36,
        overallMonitorLimitExceeded = 37,
        conferenceMemberLimitExceeded = 38,
        genericSubscribedResourceAvailability = 41,
        objectMonitorLimitExceeded = 42,
        externalTrunkLimitExceeded = 43,
        outstandingRequestLimitExceeded = 44,
        genericPerformanceManagement = 51,
        performanceLimitExceeded = 52,
        unspecifiedSecurityError = 60,
        sequenceNumberViolated = 61,
        timeStampViolated = 62,
        pacViolated = 63,
        sealViolated = 64,
        genericUnspecifiedRejection = 70,
        genericOperationRejection = 71,
        duplicateInvocationRejection = 72,
        unrecognizedOperationRejection = 73,
        mistypedArgumentRejection = 74,
        resourceLimitationRejection = 75,
        acsHandleTerminationRejection = 76,
        serviceTerminationRejection = 77,
        requestTimeoutRejection = 78,
        requestsOnDeviceExceededRejection = 79,
        unrecognizedApduRejection = 80,
        mistypedApduRejection = 81,
        badlyStructuredApduRejection = 82,
        initiatorReleasingRejection = 83,
        unrecognizedLinkedidRejection = 84,
        linkedResponseUnexpectedRejection = 85,
        unexpectedChildOperationRejection = 86,
        mistypedResultRejection = 87,
        unrecognizedErrorRejection = 88,
        unexpectedErrorRejection = 89,
        mistypedParameterRejection = 90,
        nonStandard = 100,
        operationTimeout = 101,
        CBTaskIsFull = 102,
        allOK = 999
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTARouteEndEvent_t
    {
        public int routeRegisterReqID;
        public int routingCrossRefID;
        public CSTAUniversalFailure_t errorValue;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTARouteEndRequest_t
    {
        public int routeRegisterReqID;
        public int routingCrossRefID;
        public CSTAUniversalFailure_t errorValue;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAEscapeSvc_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAEscapeSvcConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAEscapeSvcReqConf_t
    {
        public CSTAUniversalFailure_t errorValue;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAPrivateEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAPrivateStatusEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASendPrivateEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTABackInServiceEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string device;
        public CSTAEventCause_t cause;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTAOutOfServiceEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string device;
        public CSTAEventCause_t cause;
    }
    public enum SystemStatus_t
    {
        ssInitializing = 0,
        ssEnabled = 1,
        ssNormal = 2,
        ssMessagesLost = 3,
        ssDisabled = 4,
        ssOverloadImminent = 5,
        ssOverloadReached = 6,
        ssOverloadRelieved = 7,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAReqSysStat_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASysStatReqConfEvent_t
    {
        public SystemStatus_t systemStatus;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASysStatStart_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool statusFilter;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASysStatStartConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool statusFilter;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASysStatStop_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASysStatStopConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAChangeSysStatFilter_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool statusFilter;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAChangeSysStatFilterConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool statusFilterSelected;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool statusFilterActive;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASysStatEvent_t
    {
        public SystemStatus_t systemStatus;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASysStatEndedEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAReqSysStatConf_t
    {
        public SystemStatus_t systemStatus;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASysStatEventSend_t
    {
        public SystemStatus_t systemStatus;
    }

    public enum CSTACallFilter_t:ushort {
        cfCallCleared=0x8000,
        cfConferenced=0x4000,
        cfConnectionCleared=0x2000,
        cfDelivered=0x1000,
        cfDiverted=0x0800,
        cfEstablished=0x0400,
        cfFailed=0x0200,
        cfHeld=0x0100,
        cfNetworkReached=0x0080,
        cfOriginated=0x0040,
        cfQueued=0x0020,
        cfRetrieved=0x0010,
        cfServiceInitiated=0x0008,
        cfTransferred=0x0004
    }
    public enum CSTAFeatureFilter_t:byte{
            ffCallInformation=0x80,
            ffDoNotDisturb=0x40,
            ffForwarding=0x20,
            ffMessageWaiting=0x10
    }
      public enum CSTAAgentFilter_t:byte{
            afLoggedOn=0x80,
         afLoggedOff=0x40,
         afNotReady=0x20,
         afReady=0x10,
         afWorkNotReady=0x08,
         afWorkReady=0x04

      }
      public enum CSTAMaintenanceFilter_t : byte
      {

          mfBackInService = 0x80,
          mfOutOfService = 0x40
      }



    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAMonitorFilter_t
    {
        public CSTACallFilter_t call;
        public CSTAFeatureFilter_t feature;
        public CSTAAgentFilter_t agent;
        public CSTAMaintenanceFilter_t maintenance;
        public int privateFilter;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTAMonitorDevice_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string deviceID;
        public CSTAMonitorFilter_t monitorFilter;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAMonitorCall_t
    {
        public ConnectionID_t call;
        public CSTAMonitorFilter_t monitorFilter;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTAMonitorCallsViaDevice_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string deviceID;
        public CSTAMonitorFilter_t monitorFilter;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAMonitorConfEvent_t
    {
        public uint monitorCrossRefID;
        public CSTAMonitorFilter_t monitorFilter;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAChangeMonitorFilter_t
    {
        public int monitorCrossRefID;
        public CSTAMonitorFilter_t monitorFilter;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAChangeMonitorFilterConfEvent_t
    {
        public CSTAMonitorFilter_t monitorFilter;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAMonitorStop_t
    {
        public int monitorCrossRefID;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAMonitorStopConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAMonitorEndedEvent_t
    {
        public CSTAEventCause_t cause;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASnapshotCall_t
    {
        public ConnectionID_t snapshotObject;
    }

   
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAAlternateCallConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAAnswerCallConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAAnswerCall_t
    {
        public ConnectionID_t alertingCall;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTACallCompletionConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTAConsultationCall_t
    {
        public ConnectionID_t activeCall;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string calledDevice;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAClearCallConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAClearConnectionConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAConferenceCallConfEvent_t
    {
        public ConnectionID_t newCall;
        public ConnectionList_t connList;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAConsultationCallConfEvent_t
    {
        public ConnectionID_t newCall;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTADeflectCallConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAPickupCallConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAGroupPickupCallConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAHoldCallConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAMakeCallConfEvent_t
    {
        public ConnectionID_t newCall;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAMakePredictiveCallConfEvent_t
    {
        public ConnectionID_t newCall;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAQueryMwiConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool messages;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAQueryDndConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool doNotDisturb;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ListForwardParameters_t
    {
        public ushort count;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.Struct)]
        public ForwardingInfo_t[] param;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAQueryFwdConfEvent_t
    {
        public ListForwardParameters_t forward;
    }
    public enum AgentState_t
    {
        agNotReady = 0,
        agNull = 1,
        agReady = 2,
        agWorkNotReady = 3,
        agWorkReady = 4,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAQueryAgentStateConfEvent_t
    {
        public AgentState_t agentState;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTAQueryLastNumberConfEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string lastNumber;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAUniversalFailureConfEvent_t
    {
        public CSTAUniversalFailure_t error;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAGetAPICapsConfEvent_t
    {
        public short alternateCall;
        public short answerCall;
        public short callCompletion;
        public short clearCall;
        public short clearConnection;
        public short conferenceCall;
        public short consultationCall;
        public short deflectCall;
        public short pickupCall;
        public short groupPickupCall;
        public short holdCall;
        public short makeCall;
        public short makePredictiveCall;
        public short queryMwi;
        public short queryDnd;
        public short queryFwd;
        public short queryAgentState;
        public short queryLastNumber;
        public short queryDeviceInfo;
        public short reconnectCall;
        public short retrieveCall;
        public short setMwi;
        public short setDnd;
        public short setFwd;
        public short setAgentState;
        public short transferCall;
        public short eventReport;
        public short callClearedEvent;
        public short conferencedEvent;
        public short connectionClearedEvent;
        public short deliveredEvent;
        public short divertedEvent;
        public short establishedEvent;
        public short failedEvent;
        public short heldEvent;
        public short networkReachedEvent;
        public short originatedEvent;
        public short queuedEvent;
        public short retrievedEvent;
        public short serviceInitiatedEvent;
        public short transferredEvent;
        public short callInformationEvent;
        public short doNotDisturbEvent;
        public short forwardingEvent;
        public short messageWaitingEvent;
        public short loggedOnEvent;
        public short loggedOffEvent;
        public short notReadyEvent;
        public short readyEvent;
        public short workNotReadyEvent;
        public short workReadyEvent;
        public short backInServiceEvent;
        public short outOfServiceEvent;
        public short privateEvent;
        public short routeRequestEvent;
        public short reRoute;
        public short routeSelect;
        public short routeUsedEvent;
        public short routeEndEvent;
        public short monitorDevice;
        public short monitorCall;
        public short monitorCallsViaDevice;
        public short changeMonitorFilter;
        public short monitorStop;
        public short monitorEnded;
        public short snapshotDeviceReq;
        public short snapshotCallReq;
        public short escapeService;
        public short privateStatusEvent;
        public short escapeServiceEvent;
        public short escapeServiceConf;
        public short sendPrivateEvent;
        public short sysStatReq;
        public short sysStatStart;
        public short sysStatStop;
        public short changeSysStatFilter;
        public short sysStatReqEvent;
        public short sysStatReqConf;
        public short sysStatEvent;
    }
    public enum SDBLevel_t
    {
        noSdbChecking = -1,
        acsOnly = 1,
        acsAndCstaChecking = 0,
    }
    public enum CSTALevel_t
    {
        cstaHomeWorkTop = 1,
        cstaAwayWorkTop = 2,
        cstaDeviceDeviceMonitor = 3,
        cstaCallDeviceMonitor = 4,
        cstaCallControl = 5,
        cstaRouting = 6,
        cstaCallCallMonitor = 7,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct DeviceList_t
    {
        public ushort count;
        private IntPtr point;
        /*[MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.SysUInt)]
        public byte[][] device;*/
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAGetDeviceListConfEvent_t
    {
        public SDBLevel_t driverSdbLevel;
        public CSTALevel_t level;
        public int index;
        public DeviceList_t devList;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAQueryCallMonitorConfEvent_t
    {
        public bool callMonitor;
    }
    public enum DeviceType_t
    {
        dtStation = 0,
        dtLine = 1,
        dtButton = 2,
        dtAcd = 3,
        dtTrunk = 4,
        dtOperator = 5,
        dtStationGroup = 16,
        dtLineGroup = 17,
        dtButtonGroup = 18,
        dtAcdGroup = 19,
        dtTrunkGroup = 20,
        dtOperatorGroup = 21,
        dtOther = 255,
    }

    public enum DeviceClass_t
    {
        DC_VOICE=0x80,
        DC_DATA=0x40,
        DC_IMAGE=0x20,
        DC_OTHER=0x10
    }

    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSTAQueryDeviceInfoConfEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string device;
        public DeviceType_t deviceType;
        public DeviceClass_t deviceClass;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTAReconnectCallConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTARetrieveCallConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASetMwiConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASetDndConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASetFwdConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASetAgentStateConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }

    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ConnectionList_t
    {

        public uint count;
       // public Connection_t[] list;
        private readonly IntPtr point;
        public Connection_t[] list { get { return NativeMethods.GetArrayStruct<Connection_t>(point,count).ToArray(); } }

    }

    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTATransferCallConfEvent_t
    {
        public ConnectionID_t newCall;
        public ConnectionList_t connList;
    }

    public enum LocalConnectionState_t
    {
        csNone = -1,
        csNull = 0,
        csInitiate = 1,
        csAlerting = 2,
        csConnect = 3,
        csHold = 4,
        csQueued = 5,
        csFail = 6,
    }

    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTACallState_t
    {
        private readonly uint count;
        private readonly IntPtr point;
        public LocalConnectionState_t[] inf
        {
            get{
                return NativeMethods.GetArrayEnum<LocalConnectionState_t>(point,count).ToArray();
            }
        }
        
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
     public struct CSTASnapshotDeviceResponseInfo_t
    {
        public ConnectionID_t callIdentifier;
        public CSTACallState_t localCallState;
    }

    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASnapshotDeviceData_t
    {
        private readonly uint count;
        private readonly IntPtr point;
        public CSTASnapshotDeviceResponseInfo_t[] info
        {
            get
            {
                return NativeMethods.GetArrayStruct<CSTASnapshotDeviceResponseInfo_t>(point,count).ToArray();
            }
        }
    }

    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASnapshotDeviceConfEvent_t
    {
        public CSTASnapshotDeviceData_t snapshotData;
      
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASnapshotCallConfEvent_t
    {
        public CSTASnapshotCallData_t snapshotData;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASnapshotCallData_t
    {
         private readonly uint count;
         private readonly IntPtr point;
         public CSTASnapshotCallResponseInfo_t[] info{get{return NativeMethods.GetArrayStruct<CSTASnapshotCallResponseInfo_t>(point,count).ToArray();}}
    }

    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTARouteUsedExtEvent_t
    {
        public int routeRegisterReqID;
        public int routingCrossRefID;
        public ExtendedDeviceID_t routeUsed;
        public ExtendedDeviceID_t callingDevice;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool domain;
    }
 
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ACSEventHeader_t
    {
        public uint acsHandle;
        public EventClass_t eventClass;
        private readonly ushort eventType;
        public eventTypeACS eventTypeACS => (eventTypeACS)eventType;
        public eventTypeCSTA eventTypeCSTA => (eventTypeCSTA)eventType;
    }

 



    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
    public struct ACSUniversalFailureEvent_t
    {
        public ACSUniversalFailure_t error;
    }

    [Serializable,StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ACSOpenStreamConfEvent_t
    {

        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 21)]
        public char[] _apiVer;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 21)]
        public char[] _libVer;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 21)]
        public char[] _tsrvVer;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 21)]
        public char[] _drvrVer;



         public string apiVer => _apiVer.Aggregate("", (s, c) => s + c);
        
         public string libVer => _libVer.Aggregate("", (s, c) => s + c);

        public string tsrvVer => _tsrvVer.Aggregate("", (s, c) => s + c);

        public string drvrVer => _drvrVer.Aggregate("", (s, c) => s + c);


    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential,  Pack = 1)]
    public struct ACSUniversalFailureConfEvent_t
    {
        public ACSUniversalFailure_t error;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ACSCloseStreamConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)]
        public bool data;
    }


  
    public enum Feature_t
    {
        ftCampOn = 0,
        ftCallBack = 1,
        ftIntrude = 2,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ACSAuthInfo_t
    {

        public ACSAuthType_t authType;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 49)]
        public string authLoginID;
    }
    public enum ACSAuthType_t
    {
        requiresExternalAuth = -1,
        authLoginIdOnly = 0,
        authLoginIdIsDefault = 1,
        needLoginIdAndPasswd = 2,
        anyLoginId = 3,
    }
    public enum AllocationState_t
    {
        asCallDelivered = 0,
        asCallEstablished = 1,
    }
    public enum AgentMode_t
    {
        amLogIn = 0,
        amLogOut = 1,
        amNotReady = 2,
        amReady = 3,
        amWorkNotReady = 4,
        amWorkReady = 5,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTSingleStepConferenceCallConfEvent_t
    {
        public ConnectionID_t newCall;
        public ConnectionList_t connList;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTSelectiveListeningHoldConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTSelectiveListeningRetrieveConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
   
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct Connection_t
    {
        public ConnectionID_t party;
        public ExtendedDeviceID_t staticDevice;
    }



 
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct CSTASnapshotCallResponseInfo_t
    {
        public ExtendedDeviceID_t deviceOnCall;
        public ConnectionID_t callIdentifier;
        public LocalConnectionState_t localConnectionState;
    }

    public enum ATTUUIProtocolType_t
    {
        uuiNone = -1,
        uuiUserSpecific = 0,
        uuiIa5Ascii = 4,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV5UserToUserInfo_t
    {
        public ATTUUIProtocolType_t type;
        public ushort length;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string value;

        public override string ToString()
        {
            return String.Format("ATTV5UserToUserInfo_t{{'value':'{0}'}}", value);
        }
    }
    public enum ATTInterflow_t
    {
        laiNoInterflow = -1,
        laiAllInterflow = 0,
        laiThresholdInterflow = 1,
        laiVectoringInterflow = 2,
    }
    public enum ATTPriority_t
    {
        laiNotInQueue = 0,
        laiLow = 1,
        laiMedium = 2,
        laiHigh = 3,
        laiTop = 4,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV4LookaheadInfo_t
    {
        public ATTInterflow_t type;
        public ATTPriority_t priority;
        public short hours;
        public short minutes;
        public short seconds;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string sourceVDN;
    }
    public enum ATTUserEnteredCodeType_t
    {
        ueNone = -1,
        ueAny = 0,
        ueLoginDigits = 2,
        ueCallPrompter = 5,
        ueDataBaseProvided = 17,
        ueToneDetector = 32,
    }
    public enum ATTUserEnteredCodeIndicator_t
    {
        ueCollect = 0,
        ueEntered = 1,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTUserEnteredCode_t
    {
        public ATTUserEnteredCodeType_t type;
        public ATTUserEnteredCodeIndicator_t indicator;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 25)]
        public string data;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string collectVDN;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV4ConnIDList_t
    {
        public ushort count;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.Struct)]
        public ConnectionID_t[] party;
    }
    public enum ATTProgressLocation_t
    {
        plNone = -1,
        plUser = 0,
        plPubLocal = 1,
        plPubRemote = 4,
        plPrivRemote = 5,
    }
    public enum ATTProgressDescription_t
    {
        pdNone = -1,
        pdCallOffIsdn = 1,
        pdDestNotIsdn = 2,
        pdOrigNotIsdn = 3,
        pdCallOnIsdn = 4,
        pdInband = 8,
    }
    public enum ATTWorkMode_t
    {
        wmNone = -1,
        wmAuxWork = 1,
        wmAftcalWk = 2,
        wmAutoIn = 3,
        wmManualIn = 4,
    }
    public enum ATTTalkState_t
    {
        tsOnCall = 0,
        tsIdle = 1,
    }
    public enum ATTExtensionClass_t
    {
        ecVdn = 0,
        ecAcdSplit = 1,
        ecAnnouncement = 2,
        ecData = 4,
        ecAnalog = 5,
        ecProprietary = 6,
        ecBri = 7,
        ecCti = 8,
        ecLogicalAgent = 9,
        ecOther = 10,
    }
    public enum ATTAnswerTreat_t
    {
        atNoTreatment = 0,
        atNone = 1,
        atDrop = 2,
        atConnect = 3,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)] 
    public struct ATTV4SnapshotCall_t
    {
        public ushort count;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.Struct)]
        public CSTASnapshotCallResponseInfo_t[] info;
    }
    public enum ATTLocalCallState_t
    {
        attNone = 0,
        attCsInitiated = 1,
        attCsAlerting = 2,
        attCsConnected = 3,
        attCsHeld = 4,
        attCsBridged = 5,
        attCsOther = 6,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTSnapshotDevice_t
    {
        public ConnectionID_t call;
        public ATTLocalCallState_t state;
    }
    public enum ATTCollectCodeType_t
    {
        ucNone = 0,
        ucToneDetector = 32,
    }
    public enum ATTProvidedCodeType_t
    {
        upNone = 0,
        upDataBaseProvided = 17,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTUserProvidedCode_t
    {
        public ATTProvidedCodeType_t type;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 25)]
        public string data;
    }
    public enum ATTSpecificEvent_t
    {
        seAnswer = 11,
        seDisconnect = 4,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTUserCollectCode_t
    {
        public ATTCollectCodeType_t type;
        public short digitsToBeCollected;
        public short timeout;
        public ConnectionID_t collectParty;
        public ATTSpecificEvent_t specificEvent;
    }
    public enum ATTDropResource_t
    {
        drNone = -1,
        drCallClassifier = 0,
        drToneGenerator = 1,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV5ClearConnection_t
    {
        public ATTDropResource_t dropResource;
        public ATTV5UserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV5ConsultationCall_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string destRoute;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool priorityCalling;
        public ATTV5UserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV5MakeCall_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string destRoute;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool priorityCalling;
        public ATTV5UserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV5DirectAgentCall_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string split;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool priorityCalling;
        public ATTV5UserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV5MakePredictiveCall_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool priorityCalling;
        public short maxRings;
        public ATTAnswerTreat_t answerTreat;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string destRoute;
        public ATTV5UserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV5SupervisorAssistCall_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string split;
        public ATTV5UserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV5ReconnectCall_t
    {
        public ATTDropResource_t dropResource;
        public ATTV5UserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV4SendDTMFTone_t
    {
        public ConnectionID_t sender;
        public ATTV4ConnIDList_t receivers;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string tones;
        public short toneDuration;
        public short pauseDuration;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTSendDTMFToneConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV4SetAgentState_t
    {
        public ATTWorkMode_t workMode;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTQueryAcdSplit_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string device;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQueryAcdSplitConfEvent_t
    {
        public short availableAgents;
        public short callsInQueue;
        public short agentsLoggedIn;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTQueryAgentLogin_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string device;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQueryAgentLoginConfEvent_t
    {
        public int privEventCrossRefID;
    }


    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DeviceString
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public String device;
    }


    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQueryAgentLoginDeviceList
    {
        public ushort count;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 10, ArraySubType = UnmanagedType.LPTStr)]
        public DeviceString[] list;


    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQueryAgentLoginResp_t
    {
        public int privEventCrossRefID;
        public ATTQueryAgentLoginDeviceList list;
        
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTQueryAgentState_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string split;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV4QueryAgentStateConfEvent_t
    {
        public ATTWorkMode_t workMode;
        public ATTTalkState_t talkState;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQueryCallClassifier_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQueryCallClassifierConfEvent_t
    {
        public short numAvailPorts;
        public short numInUsePorts;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV4QueryDeviceInfoConfEvent_t
    {
        public ATTExtensionClass_t extensionClass;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQueryMwiConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool applicationType;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTQueryStationStatus_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string device;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQueryStationStatusConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool stationStatus;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQueryTod_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQueryTodConfEvent_t
    {
        public short year;
        public short month;
        public short day;
        public short hour;
        public short minute;
        public short second;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTQueryTg_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string device;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQueryTgConfEvent_t
    {
        public short idleTrunks;
        public short usedTrunks;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV4SnapshotDeviceConfEvent_t
    {
        public ushort count;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.Struct)]
        public ATTSnapshotDevice_t[] snapshotDevice;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV4MonitorFilter_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool privateFilter;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV4MonitorConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool usedFilter;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTMonitorStopOnCall_t
    {
        public int monitorCrossRefID;
        public ConnectionID_t call;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTMonitorStopOnCallConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV4MonitorCallConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool usedFilter;
        public ATTV4SnapshotCall_t snapshotCall;
    }
    public enum ATTReasonCode_t
    {
        arNone = 0,
        arAnswerNormal = 1,
        arAnswerTimed = 2,
        arAnswerVoiceEnergy = 3,
        arAnswerMachineDetected = 4,
        arSitReorder = 5,
        arSitNoCircuit = 6,
        arSitIntercept = 7,
        arSitVacantCode = 8,
        arSitIneffectiveOther = 9,
        arSitUnknown = 10,
        arInQueue = 11,
        arServiceObserver = 12,
    }
    public enum ATTReasonForCallInfo_t
    {
        orNone = 0,
        orConsultation = 1,
        orConferenced = 2,
        orTransferred = 3,
        orNewCall = 4,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV4OriginalCallInfo_t
    {
        public ATTReasonForCallInfo_t reason;
        public ExtendedDeviceID_t callingDevice;
        public ExtendedDeviceID_t calledDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunk;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
        public ATTV4LookaheadInfo_t lookaheadInfo;
        public ATTUserEnteredCode_t userEnteredCode;
        public ATTV5UserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTCallClearedEvent_t
    {
        public ATTReasonCode_t reason;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV3ConferencedEvent_t
    {
        public ATTV4OriginalCallInfo_t originalCallInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV5ConnectionClearedEvent_t
    {
        public ATTV5UserToUserInfo_t userInfo;
    }
    public enum ATTDeliveredType_t
    {
        deliveredToAcd = 1,
        deliveredToStation = 2,
        deliveredOther = 3,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV3DeliveredEvent_t
    {
        public ATTDeliveredType_t deliveredType;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunk;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string split;
        public ATTV4LookaheadInfo_t lookaheadInfo;
        public ATTUserEnteredCode_t userEnteredCode;
        public ATTV5UserToUserInfo_t userInfo;
        public ATTReasonCode_t reason;
        public ATTV4OriginalCallInfo_t originalCallInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTEnteredDigitsEvent_t
    {
        public ConnectionID_t connection;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 25)]
        public string digits;
        public LocalConnectionState_t localConnectionInfo;
        public CSTAEventCause_t cause;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV3EstablishedEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunk;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string split;
        public ATTV4LookaheadInfo_t lookaheadInfo;
        public ATTUserEnteredCode_t userEnteredCode;
        public ATTV5UserToUserInfo_t userInfo;
        public ATTReasonCode_t reason;
        public ATTV4OriginalCallInfo_t originalCallInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV4NetworkReachedEvent_t
    {
        public ATTProgressLocation_t progressLocation;
        public ATTProgressDescription_t progressDescription;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV3TransferredEvent_t
    {
        public ATTV4OriginalCallInfo_t originalCallInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV4RouteRequestEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunk;
        public ATTV4LookaheadInfo_t lookaheadInfo;
        public ATTUserEnteredCode_t userEnteredCode;
        public ATTV5UserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV5RouteSelect_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string callingDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string directAgentCallSplit;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool priorityCalling;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string destRoute;
        public ATTUserCollectCode_t collectCode;
        public ATTUserProvidedCode_t userProvidedCode;
        public ATTV5UserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTRouteUsedEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string destRoute;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTSysStat_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool linkStatusReq;
    }
    public enum ATTLinkState_t
    {
        lsLinkUnavail = 0,
        lsLinkUp = 1,
        lsLinkDown = 2,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTLinkStatus_t
    {
        public short linkID;
        public ATTLinkState_t linkState;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV3LinkStatusEvent_t
    {
        public ushort count;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.Struct)]
        public ATTLinkStatus_t[] linkStatus;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV5OriginatedEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string logicalAgent;
        public ATTV5UserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTLoggedOnEvent_t
    {
        public ATTWorkMode_t workMode;
    }
    public enum ATTDeviceType_t
    {
        attDtAcdSplit = 1,
        attDtAnnouncement = 2,
        attDtData = 3,
        attDtLogicalAgent = 4,
        attDtStation = 5,
        attDtTrunkAccessCode = 6,
        attDtVdn = 7,
        attDtOther = 8,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTQueryDeviceName_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string device;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV4QueryDeviceNameConfEvent_t
    {
        public ATTDeviceType_t deviceType;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string device;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string name;
    }
    public enum ATTAgentTypeID_t
    {
        extensionId = 0,
        logicalId = 1,
    }
    public enum ATTSplitSkill_t
    {
        splitSkillNone = -1,
        splitSkillAll = 0,
        splitSkill1 = 1,
        splitSkill2 = 2,
        splitSkill3 = 3,
        splitSkill4 = 4,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTAgentMeasurements_t
    {
        public int acdCalls;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 6)]
        public string extension;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string name;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool state;
        public int avgACDTalkTime;
        public int avgExtensionTime;
        public int callRate;
        public short elapsedTime;
        public int extensionCalls;
        public int extensionIncomingCalls;
        public int extensionOutgoingCalls;
        public int shiftACDCalls;
        public int shiftAvgACDTalkTime;
        public short splitAcceptableSvcLevel;
        public int splitACDCalls;
        public int splitAfterCallSessions;
        public short splitAgentsAvailable;
        public short splitAgentsInAfterCall;
        public short splitAgentsInAux;
        public short splitAgentsInOther;
        public short splitAgentsOnACDCalls;
        public short splitAgentsOnExtCalls;
        public short splitAgentsStaffed;
        public int splitAvgACDTalkTime;
        public int splitAvgAfterCallTime;
        public short splitAvgSpeedOfAnswer;
        public short splitAvgTimeToAbandon;
        public int splitCallRate;
        public int splitCallsAbandoned;
        public int splitCallsFlowedIn;
        public int splitCallsFlowedOut;
        public short splitCallsWaiting;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string splitName;
        public short splitNumber;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 6)]
        public string splitExtension;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 6)]
        public string splitObjective;
        public short splitOldestCallWaiting;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitPercentInSvcLevel;
        public int splitTotalACDTalkTime;
        public int splitTotalAfterCallTime;
        public int splitTotalAuxTime;
        public int timeAgentEnteredState;
        public int totalACDTalkTime;
        public int totalAfterCallTime;
        public int totalAuxTime;
        public int totalAvailableTime;
        public int totalHoldTime;
        public int totalStaffedTime;
        public int totalACDCallTime;
        public int avgACDCallTime;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTSplitSkillMeasurements_t
    {
        public short acceptableSvcLevel;
        public int acdCalls;
        public int afterCallSessions;
        public short agentsAvailable;
        public short agentsInAfterCall;
        public short agentsInAux;
        public short agentsInOther;
        public short onACDCalls;
        public short agentsOnExtensionCalls;
        public short agentsStaffed;
        public int avgACDTalkTime;
        public int afterCallTime;
        public short avgSpeedOfAnswer;
        public short avgTimeToAbandon;
        public int callRate;
        public int callsAbandoned;
        public int callsFlowedIn;
        public int callsFlowedOut;
        public short callsWaiting;
        public short oldestCallWaiting;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool percentInSvcLevel;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string name;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 6)]
        public string extension;
        public short number;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 6)]
        public string objective;
        public int totalAfterCallTime;
        public int totalAuxTime;
        public int totalACDTalkTime;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTTrunkGroupMeasurements_t
    {
        public int avgIncomingCallTime;
        public int avgOutgoingCallTime;
        public int incomingAbandonedCalls;
        public int incomingCalls;
        public int incomingUsage;
        public short numberOfTrunks;
        public int outgoingCalls;
        public int outgoingCompletedCalls;
        public int outgoingUsage;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool percentAllTrunksBusy;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool percentTrunksMaintBusy;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string trunkGroupName;
        public short trunkGroupNumber;
        public short trunksInUse;
        public short trunksMaintBusy;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTVdnMeasurements_t
    {
        public short acceptableSvcLevel;
        public int acdCalls;
        public int avgACDTalkTime;
        public short avgSpeedOfAnswer;
        public short avgTimeToAbandon;
        public int callsAbandoned;
        public int callsFlowedOut;
        public int callsForcedBusyDisc;
        public int callsOffered;
        public short callsWaiting;
        public int callsNonACD;
        public short oldestCallWaiting;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool percentInSvcLevel;
        public int totalACDTalkTime;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 6)]
        public string extension;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string name;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTAgentMeasurementsPresent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool allMeasurements;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool acdCalls;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool extension;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool name;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool state;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool avgACDTalkTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool avgExtensionTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool callRate;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool elapsedTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool extensionCalls;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool extensionIncomingCalls;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool extensionOutgoingCalls;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool shiftACDCalls;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool shiftAvgACDTalkTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitAcceptableSvcLevel;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitACDCalls;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitAfterCallSessions;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitAgentsAvailable;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitAgentsInAfterCall;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitAgentsInAux;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitAgentsInOther;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitAgentsOnACDCalls;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitAgentsOnExtCalls;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitAgentsStaffed;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitAvgACDTalkTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitAvgAfterCallTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitAvgSpeedOfAnswer;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitAvgTimeToAbandon;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitCallRate;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitCallsAbandoned;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitCallsFlowedIn;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitCallsFlowedOut;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitCallsWaiting;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitName;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitNumber;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitExtension;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitObjective;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitOldestCallWaiting;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitPercentInSvcLevel;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitTotalACDTalkTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitTotalAfterCallTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool splitTotalAuxTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool timeAgentEnteredState;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool totalACDTalkTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool totalAfterCallTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool totalAuxTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool totalAvailableTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool totalHoldTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool totalStaffedTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool totalACDCallTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool avgACDCallTime;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTSplitSkillMeasurementsPresent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool allMeasurements;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool acceptableSvcLevel;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool acdCalls;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool afterCallSessions;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool agentsAvailable;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool agentsInAfterCall;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool agentsInAux;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool agentsInOther;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool onACDCalls;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool agentsOnExtensionCalls;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool agentsStaffed;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool avgACDTalkTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool afterCallTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool avgSpeedOfAnswer;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool avgTimeToAbandon;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool callRate;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool callsAbandoned;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool callsFlowedIn;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool callsFlowedOut;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool callsWaiting;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool oldestCallWaiting;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool percentInSvcLevel;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool name;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool extension;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool number;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool objective;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool totalAfterCallTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool totalAuxTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool totalACDTalkTime;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTTrunkGroupMeasurementsPresent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool allMeasurements;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool avgIncomingCallTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool avgOutgoingCallTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool incomingAbandonedCalls;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool incomingCalls;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool incomingUsage;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool numberOfTrunks;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool outgoingCalls;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool outgoingCompletedCalls;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool outgoingUsage;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool percentAllTrunksBusy;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool percentTrunksMaintBusy;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool trunkGroupName;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool trunkGroupNumber;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool trunksInUse;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool trunksMaintBusy;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTVdnMeasurementsPresent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool allMeasurements;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool acceptableSvcLevel;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool acdCalls;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool avgACDTalkTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool avgSpeedOfAnswer;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool avgTimeToAbandon;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool callsAbandoned;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool callsFlowedOut;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool callsForcedBusyDisc;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool callsOffered;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool callsWaiting;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool callsNonACD;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool oldestCallWaiting;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool percentInSvcLevel;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool totalACDTalkTime;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool extension;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool name;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTQueryAgentMeasurements_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string agentID;
        public ATTAgentTypeID_t typeID;
        public ATTSplitSkill_t splitSkill;
        public ATTAgentMeasurementsPresent_t requestItems;
        public short interval;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQueryAgentMeasurementsConfEvent_t
    {
        public ATTAgentMeasurementsPresent_t returnedItems;
        public ATTAgentMeasurements_t values;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTQuerySplitSkillMeasurements_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string device;
        public ATTSplitSkillMeasurementsPresent_t requestItems;
        public short interval;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQuerySplitSkillMeasurementsConfEvent_t
    {
        public ATTSplitSkillMeasurementsPresent_t returnedItems;
        public ATTSplitSkillMeasurements_t values;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTQueryTrunkGroupMeasurements_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string device;
        public ATTTrunkGroupMeasurementsPresent_t requestItems;
        public short interval;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQueryTrunkGroupMeasurementsConfEvent_t
    {
        public ATTTrunkGroupMeasurementsPresent_t returnedItems;
        public ATTTrunkGroupMeasurements_t values;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTQueryVdnMeasurements_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string device;
        public ATTVdnMeasurementsPresent_t requestItems;
        public short interval;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQueryVdnMeasurementsConfEvent_t
    {
        public ATTVdnMeasurementsPresent_t returnedItems;
        public ATTVdnMeasurements_t values;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV4ConferencedEvent_t
    {
        public ATTV4OriginalCallInfo_t originalCallInfo;
        public ExtendedDeviceID_t distributingDevice;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV4DeliveredEvent_t
    {
        public ATTDeliveredType_t deliveredType;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunk;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string split;
        public ATTV4LookaheadInfo_t lookaheadInfo;
        public ATTUserEnteredCode_t userEnteredCode;
        public ATTV5UserToUserInfo_t userInfo;
        public ATTReasonCode_t reason;
        public ATTV4OriginalCallInfo_t originalCallInfo;
        public ExtendedDeviceID_t distributingDevice;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV4EstablishedEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunk;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string split;
        public ATTV4LookaheadInfo_t lookaheadInfo;
        public ATTUserEnteredCode_t userEnteredCode;
        public ATTV5UserToUserInfo_t userInfo;
        public ATTReasonCode_t reason;
        public ATTV4OriginalCallInfo_t originalCallInfo;
        public ExtendedDeviceID_t distributingDevice;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV4TransferredEvent_t
    {
        public ATTV4OriginalCallInfo_t originalCallInfo;
        public ExtendedDeviceID_t distributingDevice;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV4LinkStatusEvent_t
    {
        public ushort count;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.Struct)]
        public ATTLinkStatus_t[] linkStatus;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV4GetAPICapsConfEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string switchVersion;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool sendDTMFTone;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool enteredDigitsEvent;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool queryDeviceName;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool queryAgentMeas;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool querySplitSkillMeas;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool queryTrunkGroupMeas;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool queryVdnMeas;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool reserved1;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool reserved2;
    }
    public enum ATTParticipationType_t
    {
        ptActive = 1,
        ptSilent = 0,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTSingleStepConferenceCall_t
    {
        public ConnectionID_t activeCall;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string deviceToBeJoin;
        public ATTParticipationType_t participationType;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool alertDestination;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTSelectiveListeningHold_t
    {
        public ConnectionID_t subjectConnection;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool allParties;
        public ConnectionID_t selectedParty;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTSelectiveListeningRetrieve_t
    {
        public ConnectionID_t subjectConnection;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool allParties;
        public ConnectionID_t selectedParty;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential,CharSet=CharSet.Ansi)]
    public  struct ATTUnicodeDeviceID
    {
        public ushort count;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string value;
        /*[MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I2)]
        public Int16[] value;*/
        //[MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType=UnmanagedType.I2)]

        /*[MarshalAsAttribute(UnmanagedType.LPTStr, SizeConst=64)]
        public string value;*/
        /**/
        /*[MarshalAsAttribute(UnmanagedType.SafeArray, SizeParamIndex = 0, ArraySubType = UnmanagedType.I2)]
         public short[] value;*/
        /*[MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst=64, ArraySubType = UnmanagedType.I2)]
        public short[] value;*/
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTLookaheadInfo_t
    {
        public ATTInterflow_t type;
        public ATTPriority_t priority;
        public short hours;
        public short minutes;
        public short seconds;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string sourceVDN;
        public ATTUnicodeDeviceID uSourceVDN;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTCallOriginatorInfo_t
    {
        [MarshalAs(UnmanagedType.I1)] 
        public bool hasInfo;
        public short callOriginatorType;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV5OriginalCallInfo_t
    {
        public ATTReasonForCallInfo_t reason;
        public ExtendedDeviceID_t callingDevice;
        public ExtendedDeviceID_t calledDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkGroup;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
        public ATTLookaheadInfo_t lookaheadInfo;
        public ATTUserEnteredCode_t userEnteredCode;
        public ATTV5UserToUserInfo_t userInfo;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
        public ATTCallOriginatorInfo_t callOriginatorInfo;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool flexibleBilling;
    }
    [Serializable,StructLayout(LayoutKind.Sequential)]
    public struct ATTConnIDList_t
    {
        private readonly uint count;
        private readonly IntPtr point;
        public ConnectionID_t[] list { get { return NativeMethods.GetArrayStruct<ConnectionID_t>(point,count).ToArray(); } }

    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTSendDTMFTone_t
    {
        public ConnectionID_t sender;
        public ATTConnIDList_t receivers;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 33)]
        public string tones;
        public short toneDuration;
        public short pauseDuration;
    }

    class SaferyArrayFromNativeMarchal : ICustomMarshaler
    {
        public object MarshalNativeToManaged(IntPtr pNativeData)
        {
            return NativeMethods.GetArrayStruct<ATTSnapshotDevice_t>(pNativeData).ToArray();
        }

        public IntPtr MarshalManagedToNative(object ManagedObj)
        {
            return  new IntPtr();
        }

        public void CleanUpNativeData(IntPtr pNativeData)
        {
            
        }

        public void CleanUpManagedData(object ManagedObj)
        {
            
        }

        public int GetNativeDataSize()
        {
            return 0;
        }
    }


    [Serializable,StructLayoutAttribute(LayoutKind.Sequential,Pack = 2)]
    public class ATTSnapshotDeviceConfEvent_t
    {
        /*  
            private readonly uint count;
            private readonly IntPtr point;
            //public ATTSnapshotDevice_t[] list { get; set; }
            public ATTSnapshotDevice_t[] _list
            {
                get
                {
                    return NativeMethods.GetArrayStruct<ATTSnapshotDevice_t>(point, count).ToArray();
                }
            }
        */

        public long count;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public ATTSnapshotDevice_t[] list;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTLinkStatusEvent_t
    {

        private readonly uint count;
        private readonly IntPtr point;
        public ATTLinkStatus_t[] list { get { return NativeMethods.GetArrayStruct<ATTLinkStatus_t>(point,count).ToArray(); } }
    }
    public enum ATTBillType_t
    {
        btNewRate = 16,
        btFlatRate = 17,
        btPremiumCharge = 18,
        btPremiumCredit = 19,
        btFreeCall = 24,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTSetBillRate_t
    {
        public ConnectionID_t call;
        public ATTBillType_t billType;
        public float billRate;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTSetBillRateConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQueryUcid_t
    {
        public ConnectionID_t call;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTQueryUcidConfEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV5ConferencedEvent_t
    {
        public ATTV5OriginalCallInfo_t originalCallInfo;
        public ExtendedDeviceID_t distributingDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTLoggedOffEvent_t
    {
        public int reasonCode;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV5DeliveredEvent_t
    {
        public ATTDeliveredType_t deliveredType;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkGroup;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string split;
        public ATTLookaheadInfo_t lookaheadInfo;
        public ATTUserEnteredCode_t userEnteredCode;
        public ATTV5UserToUserInfo_t userInfo;
        public ATTReasonCode_t reason;
        public ATTV5OriginalCallInfo_t originalCallInfo;
        public ExtendedDeviceID_t distributingDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
        public ATTCallOriginatorInfo_t callOriginatorInfo;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool flexibleBilling;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV5EstablishedEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkGroup;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string split;
        public ATTLookaheadInfo_t lookaheadInfo;
        public ATTUserEnteredCode_t userEnteredCode;
        public ATTV5UserToUserInfo_t userInfo;
        public ATTReasonCode_t reason;
        public ATTV5OriginalCallInfo_t originalCallInfo;
        public ExtendedDeviceID_t distributingDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
        public ATTCallOriginatorInfo_t callOriginatorInfo;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool flexibleBilling;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV5TransferredEvent_t
    {
        public ATTV5OriginalCallInfo_t originalCallInfo;
        public ExtendedDeviceID_t distributingDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV5RouteRequestEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkGroup;
        public ATTLookaheadInfo_t lookaheadInfo;
        public ATTUserEnteredCode_t userEnteredCode;
        public ATTV5UserToUserInfo_t userInfo;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
        public ATTCallOriginatorInfo_t callOriginatorInfo;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool flexibleBilling;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTConsultationCallConfEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTMakeCallConfEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTMakePredictiveCallConfEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV5SetAgentState_t
    {
        public ATTWorkMode_t workMode;
        public int reasonCode;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV5QueryAgentStateConfEvent_t
    {
        public ATTWorkMode_t workMode;
        public ATTTalkState_t talkState;
        public int reasonCode;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV6QueryDeviceNameConfEvent_t
    {
        public ATTDeviceType_t deviceType;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string device;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string name;
        public ATTUnicodeDeviceID uname;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTConferenceCallConfEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTTransferCallConfEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTMonitorFilter_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool privateFilter;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTMonitorConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool usedFilter;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTSnapshotCall_t
    {
        private readonly uint count;
        private readonly IntPtr point;
        public CSTASnapshotCallResponseInfo_t[] list { get { return NativeMethods.GetArrayStruct<CSTASnapshotCallResponseInfo_t>(point,count).ToArray(); } }

    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTMonitorCallConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool usedFilter;
        public ATTSnapshotCall_t snapshotCall;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTServiceInitiatedEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
    }
    public enum ATTChargeType_t
    {
        ctIntermediateCharge = 1,
        ctFinalCharge = 2,
        ctSplitCharge = 3,
    }
    public enum ATTChargeError_t
    {
        ceNone = 0,
        ceNoFinalCharge = 1,
        ceLessFinalCharge = 2,
        ceChargeTooLarge = 3,
        ceNetworkBusy = 4,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTChargeAdviceEvent_t
    {
        public ConnectionID_t connection;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string calledDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string chargingDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkGroup;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
        public ATTChargeType_t chargeType;
        public int charge;
        public ATTChargeError_t error;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV6GetAPICapsConfEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string switchVersion;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool sendDTMFTone;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool enteredDigitsEvent;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool queryDeviceName;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool queryAgentMeas;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool querySplitSkillMeas;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool queryTrunkGroupMeas;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool queryVdnMeas;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool singleStepConference;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool selectiveListeningHold;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool selectiveListeningRetrieve;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool setBillingRate;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool queryUCID;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool chargeAdviceEvent;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool reserved1;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool reserved2;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTQueryDeviceInfoConfEvent_t
    {
        public ATTExtensionClass_t extensionClass;
        public ATTExtensionClass_t associatedClass;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string associatedDevice;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTSetAdviceOfCharge_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool featureFlag;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTSetAdviceOfChargeConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV6NetworkReachedEvent_t
    {
        public ATTProgressLocation_t progressLocation;
        public ATTProgressDescription_t progressDescription;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkGroup;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTSetAgentState_t
    {
        public ATTWorkMode_t workMode;
        public int reasonCode;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool enablePending;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTSetAgentStateConfEvent_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool isPending;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQueryAgentStateConfEvent_t
    {
        public ATTWorkMode_t workMode;
        public ATTTalkState_t talkState;
        public int reasonCode;
        public ATTWorkMode_t pendingWorkMode;
        public int pendingReasonCode;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTUserToUserInfo_Data
    {
        public ushort length;
        [MarshalAsAttribute(UnmanagedType.ByValTStr,SizeConst=129)]
        public string value;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTUserToUserInfo_t
    {
        public ATTUUIProtocolType_t type;
        public ATTUserToUserInfo_Data data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV6RouteRequestEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkGroup;
        public ATTLookaheadInfo_t lookaheadInfo;
        public ATTUserEnteredCode_t userEnteredCode;
        public ATTUserToUserInfo_t userInfo;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
        public ATTCallOriginatorInfo_t callOriginatorInfo;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool flexibleBilling;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV6OriginalCallInfo_t
    {
        public ATTReasonForCallInfo_t reason;
        public ExtendedDeviceID_t callingDevice;
        public ExtendedDeviceID_t calledDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkGroup;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
        public ATTLookaheadInfo_t lookaheadInfo;
        public ATTUserEnteredCode_t userEnteredCode;
        public ATTUserToUserInfo_t userInfo;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
        public ATTCallOriginatorInfo_t callOriginatorInfo;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool flexibleBilling;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTTrunkInfo_t
    {
        public ConnectionID_t connection;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkGroup;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTTrunkList_t
    {
        public ushort count;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.Struct)]
        public ATTTrunkInfo_t[] trunks;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV6TransferredEvent_t
    {
        public ATTV6OriginalCallInfo_t originalCallInfo;
        public ExtendedDeviceID_t distributingDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
        public ATTTrunkList_t trunkList;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV6ConferencedEvent_t
    {
        public ATTV6OriginalCallInfo_t originalCallInfo;
        public ExtendedDeviceID_t distributingDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
        public ATTTrunkList_t trunkList;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTClearConnection_t
    {
        public ATTDropResource_t dropResource;
        public ATTUserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTConsultationCall_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string destRoute;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool priorityCalling;
        public ATTUserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTMakeCall_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string destRoute;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool priorityCalling;
        public ATTUserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTDirectAgentCall_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string split;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool priorityCalling;
        public ATTUserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTMakePredictiveCall_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool priorityCalling;
        public short maxRings;
        public ATTAnswerTreat_t answerTreat;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string destRoute;
        public ATTUserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTSupervisorAssistCall_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string split;
        public ATTUserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTReconnectCall_t
    {
        public ATTDropResource_t dropResource;
        public ATTUserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTV6ConnectionClearedEvent_t
    {
        public ATTUserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV6RouteSelect_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string callingDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string directAgentCallSplit;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool priorityCalling;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string destRoute;
        public ATTUserCollectCode_t collectCode;
        public ATTUserProvidedCode_t userProvidedCode;
        public ATTUserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV6DeliveredEvent_t
    {
        public ATTDeliveredType_t deliveredType;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkGroup;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string split;
        public ATTLookaheadInfo_t lookaheadInfo;
        public ATTUserEnteredCode_t userEnteredCode;
        public ATTUserToUserInfo_t userInfo;
        public ATTReasonCode_t reason;
        public ATTV6OriginalCallInfo_t originalCallInfo;
        public ExtendedDeviceID_t distributingDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
        public ATTCallOriginatorInfo_t callOriginatorInfo;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool flexibleBilling;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTV6EstablishedEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkGroup;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string split;
        public ATTLookaheadInfo_t lookaheadInfo;
        public ATTUserEnteredCode_t userEnteredCode;
        public ATTUserToUserInfo_t userInfo;
        public ATTReasonCode_t reason;
        public ATTV6OriginalCallInfo_t originalCallInfo;
        public ExtendedDeviceID_t distributingDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
        public ATTCallOriginatorInfo_t callOriginatorInfo;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool flexibleBilling;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTOriginatedEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string logicalAgent;
        public ATTUserToUserInfo_t userInfo;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Anonymous_61704943_801c_42d6_8135_28fae545d706
    {
        public ushort length;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string value;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct Reserved_t
    {
        public Anonymous_61704943_801c_42d6_8135_28fae545d706 data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Anonymous_48eed1af_da4c_48ac_8bde_7a38185256c8
    {
        public ushort length;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string value;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct Reserved2_t
    {
        public Anonymous_48eed1af_da4c_48ac_8bde_7a38185256c8 data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Anonymous_5d4dd665_21de_4058_8e0d_a08bbbf8f20a
    {
        public ushort length;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string value;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct Reserved3_t
    {
        public Anonymous_5d4dd665_21de_4058_8e0d_a08bbbf8f20a data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct Reserved4_t
    {
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct Reserved5_t
    {
        public int data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DeviceHistoryEntry_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string olddeviceID;
        public CSTAEventCause_t cause;
        public ConnectionID_t oldconnectionID;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]//,Pack=2
    public class DeviceHistory_t
    {
        public  uint count;
        private readonly IntPtr point;
        public DeviceHistoryEntry_t[] list { get { return NativeMethods.GetArrayStruct<DeviceHistoryEntry_t>(point,count).ToArray(); } }
/*
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("count", count, typeof(uint));
        }
        public DeviceHistory_t(SerializationInfo info, StreamingContext context)
        {
            count = (uint)info.GetValue("count", typeof(uint));

            // Reset the property value using the GetValue method.
            //myProperty_value = (string)info.GetValue("props", typeof(string));
        }*/
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTOriginalCallInfo_t
    {
        public ATTReasonForCallInfo_t reason;       //4
        public ExtendedDeviceID_t callingDevice;    //72
        public ExtendedDeviceID_t calledDevice;     //72
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]   //64
        public string trunkGroup;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]   //64
        public string trunkMember;
        public ATTLookaheadInfo_t lookaheadInfo;                        //208
        public ATTUserEnteredCode_t  userEnteredCode;                   //100
        public ATTUserToUserInfo_t   userInfo;                          //136
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;                 
        public ATTCallOriginatorInfo_t callOriginatorInfo;      //8
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool flexibleBilling;                     //1
        public DeviceHistory_t deviceHistory;           //8
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTQueryDeviceNameConfEvent_t
    {
        public ATTDeviceType_t deviceType;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string device;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string name;
        public ATTUnicodeDeviceID uname;
    }
    public enum ATTRedirectType_t
    {
        vdn = 0,
        network = 1,
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTRouteSelect_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string callingDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string directAgentCallSplit;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool priorityCalling;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string destRoute;
        public ATTUserCollectCode_t collectCode;
        public ATTUserProvidedCode_t userProvidedCode;
        public ATTUserToUserInfo_t userInfo;
        public ATTRedirectType_t redirectType;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTGetAPICapsConfEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 65)]
        public string switchVersion;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool sendDTMFTone;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool enteredDigitsEvent;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool queryDeviceName;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool queryAgentMeas;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool querySplitSkillMeas;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool queryTrunkGroupMeas;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool queryVdnMeas;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool singleStepConference;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool selectiveListeningHold;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool selectiveListeningRetrieve;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool setBillingRate;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool queryUCID;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool chargeAdviceEvent;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool reserved1;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool reserved2;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool devicehistoryCount;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string adminSoftwareVersion;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string softwareVersion;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string offerType;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string serverType;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTDeliveredEvent_t
    {
        public ATTDeliveredType_t    deliveredType;                         
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]       
        public string trunkGroup;   
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]       
        public string trunkMember;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]       
        public string split;
        public ATTLookaheadInfo_t    lookaheadInfo;                         
        public ATTUserEnteredCode_t userEnteredCode;                        //504
        public ATTUserToUserInfo_t   userInfo;                              //136
        public ATTReasonCode_t   reason;                                    //4
        public ATTOriginalCallInfo_t originalCallInfo;                      //804 //644
        public ExtendedDeviceID_t distributingDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
        public ATTCallOriginatorInfo_t callOriginatorInfo;
        [MarshalAs(UnmanagedType.I1)]
        public bool flexibleBilling;
        public DeviceHistory_t deviceHistory;
        public ExtendedDeviceID_t distributingVDN;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTEstablishedEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkGroup;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string split;
        public ATTLookaheadInfo_t lookaheadInfo;
        public ATTUserEnteredCode_t userEnteredCode;
        public ATTUserToUserInfo_t userInfo;
        public ATTReasonCode_t reason;
        public ATTOriginalCallInfo_t originalCallInfo;
        public ExtendedDeviceID_t distributingDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
        public ATTCallOriginatorInfo_t callOriginatorInfo;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool flexibleBilling;
        public DeviceHistory_t deviceHistory;
        public ExtendedDeviceID_t distributingVDN;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTQueuedEvent_t
    {
        public DeviceHistory_t deviceHistory;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTRouteRequestEvent_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkGroup;
        public ATTLookaheadInfo_t lookaheadInfo;
        public ATTUserEnteredCode_t userEnteredCode;
        public ATTUserToUserInfo_t userInfo;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
        public ATTCallOriginatorInfo_t callOriginatorInfo;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool flexibleBilling;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
        public DeviceHistory_t deviceHistory;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTTransferredEvent_t
    {
        public ATTOriginalCallInfo_t originalCallInfo;
        public ExtendedDeviceID_t distributingDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
        public ATTTrunkList_t trunkList;
        public DeviceHistory_t deviceHistory;
        public ExtendedDeviceID_t distributingVDN;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTConferencedEvent_t
    {
        public ATTOriginalCallInfo_t originalCallInfo;
        public ExtendedDeviceID_t distributingDevice;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string ucid;
        public ATTTrunkList_t trunkList;
        public DeviceHistory_t deviceHistory;
        public ExtendedDeviceID_t distributingVDN;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTConnectionClearedEvent_t
    {
        public ATTUserToUserInfo_t userInfo;
        public DeviceHistory_t deviceHistory;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTDivertedEvent_t
    {
        public DeviceHistory_t deviceHistory;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTNetworkReachedEvent_t
    {
        public ATTProgressLocation_t progressLocation;
        public ATTProgressDescription_t progressDescription;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkGroup;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string trunkMember;
        public DeviceHistory_t deviceHistory;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTFailedEvent_t
    {
        public DeviceHistory_t deviceHistory;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential)]
    public struct ATTSnapshotCallConfEvent_t
    {
        public DeviceHistory_t deviceHistory;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ATTPrivateData_t
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string vendor;
        public ushort length;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 10240)]
        public string data;
    }
    [Serializable,StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct UserEnteredCode_t
    {
        public ushort size;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool type;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool timeout;
        [MarshalAs(UnmanagedType.I1)] 
 		 public bool indicator;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 25)]
        public string data;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string collectVDN;
    }
    public enum eventTypeCSTA : ushort
    {
        CSTA_ALTERNATE_CALL = 1,
        CSTA_ALTERNATE_CALL_CONF = 2,
        CSTA_ANSWER_CALL = 3,
        CSTA_ANSWER_CALL_CONF = 4,
        CSTA_CALL_COMPLETION = 5,
        CSTA_CALL_COMPLETION_CONF = 6,
        CSTA_CLEAR_CALL = 7,
        CSTA_CLEAR_CALL_CONF = 8,
        CSTA_CLEAR_CONNECTION = 9,
        CSTA_CLEAR_CONNECTION_CONF = 10,
        CSTA_CONFERENCE_CALL = 11,
        CSTA_CONFERENCE_CALL_CONF = 12,
        CSTA_CONSULTATION_CALL = 13,
        CSTA_CONSULTATION_CALL_CONF = 14,
        CSTA_DEFLECT_CALL = 15,
        CSTA_DEFLECT_CALL_CONF = 16,
        CSTA_PICKUP_CALL = 17,
        CSTA_PICKUP_CALL_CONF = 18,
        CSTA_GROUP_PICKUP_CALL = 19,
        CSTA_GROUP_PICKUP_CALL_CONF = 20,
        CSTA_HOLD_CALL = 21,
        CSTA_HOLD_CALL_CONF = 22,
        CSTA_MAKE_CALL = 23,
        CSTA_MAKE_CALL_CONF = 24,
        CSTA_MAKE_PREDICTIVE_CALL = 25,
        CSTA_MAKE_PREDICTIVE_CALL_CONF = 26,
        CSTA_QUERY_MWI = 27,
        CSTA_QUERY_MWI_CONF = 28,
        CSTA_QUERY_DND = 29,
        CSTA_QUERY_DND_CONF = 30,
        CSTA_QUERY_FWD = 31,
        CSTA_QUERY_FWD_CONF = 32,
        CSTA_QUERY_AGENT_STATE = 33,
        CSTA_QUERY_AGENT_STATE_CONF = 34,
        CSTA_QUERY_LAST_NUMBER = 35,
        CSTA_QUERY_LAST_NUMBER_CONF = 36,
        CSTA_QUERY_DEVICE_INFO = 37,
        CSTA_QUERY_DEVICE_INFO_CONF = 38,
        CSTA_RECONNECT_CALL = 39,
        CSTA_RECONNECT_CALL_CONF = 40,
        CSTA_RETRIEVE_CALL = 41,
        CSTA_RETRIEVE_CALL_CONF = 42,
        CSTA_SET_MWI = 43,
        CSTA_SET_MWI_CONF = 44,
        CSTA_SET_DND = 45,
        CSTA_SET_DND_CONF = 46,
        CSTA_SET_FWD = 47,
        CSTA_SET_FWD_CONF = 48,
        CSTA_SET_AGENT_STATE = 49,
        CSTA_SET_AGENT_STATE_CONF = 50,
        CSTA_TRANSFER_CALL = 51,
        CSTA_TRANSFER_CALL_CONF = 52,
        CSTA_UNIVERSAL_FAILURE_CONF = 53,
        CSTA_CALL_CLEARED = 54,
        CSTA_CONFERENCED = 55,
        CSTA_CONNECTION_CLEARED = 56,
        CSTA_DELIVERED = 57,
        CSTA_DIVERTED = 58,
        CSTA_ESTABLISHED = 59,
        CSTA_FAILED = 60,
        CSTA_HELD = 61,
        CSTA_NETWORK_REACHED = 62,
        CSTA_ORIGINATED = 63,
        CSTA_QUEUED = 64,
        CSTA_RETRIEVED = 65,
        CSTA_SERVICE_INITIATED = 66,
        CSTA_TRANSFERRED = 67,
        CSTA_CALL_INFORMATION = 68,
        CSTA_DO_NOT_DISTURB = 69,
        CSTA_FORWARDING = 70,
        CSTA_MESSAGE_WAITING = 71,
        CSTA_LOGGED_ON = 72,
        CSTA_LOGGED_OFF = 73,
        CSTA_NOT_READY = 74,
        CSTA_READY = 75,
        CSTA_WORK_NOT_READY = 76,
        CSTA_WORK_READY = 77,
        CSTA_ROUTE_REGISTER_REQ = 78,
        CSTA_ROUTE_REGISTER_REQ_CONF = 79,
        CSTA_ROUTE_REGISTER_CANCEL = 80,
        CSTA_ROUTE_REGISTER_CANCEL_CONF = 81,
        CSTA_ROUTE_REGISTER_ABORT = 82,
        CSTA_ROUTE_REQUEST = 83,
        CSTA_ROUTE_SELECT_REQUEST = 84,
        CSTA_RE_ROUTE_REQUEST = 85,
        CSTA_ROUTE_USED = 86,
        CSTA_ROUTE_END = 87,
        CSTA_ROUTE_END_REQUEST = 88,
        CSTA_ESCAPE_SVC = 89,
        CSTA_ESCAPE_SVC_CONF = 90,
        CSTA_ESCAPE_SVC_REQ = 91,
        CSTA_ESCAPE_SVC_REQ_CONF = 92,
        CSTA_PRIVATE = 93,
        CSTA_PRIVATE_STATUS = 94,
        CSTA_SEND_PRIVATE = 95,
        CSTA_BACK_IN_SERVICE = 96,
        CSTA_OUT_OF_SERVICE = 97,
        CSTA_REQ_SYS_STAT = 98,
        CSTA_SYS_STAT_REQ_CONF = 99,
        CSTA_SYS_STAT_START = 100,
        CSTA_SYS_STAT_START_CONF = 101,
        CSTA_SYS_STAT_STOP = 102,
        CSTA_SYS_STAT_STOP_CONF = 103,
        CSTA_CHANGE_SYS_STAT_FILTER = 104,
        CSTA_CHANGE_SYS_STAT_FILTER_CONF = 105,
        CSTA_SYS_STAT = 106,
        CSTA_SYS_STAT_ENDED = 107,
        CSTA_SYS_STAT_REQ = 108,
        CSTA_REQ_SYS_STAT_CONF = 109,
        CSTA_SYS_STAT_EVENT_SEND = 110,
        CSTA_MONITOR_DEVICE = 111,
        CSTA_MONITOR_CALL = 112,
        CSTA_MONITOR_CALLS_VIA_DEVICE = 113,
        CSTA_MONITOR_CONF = 114,
        CSTA_CHANGE_MONITOR_FILTER = 115,
        CSTA_CHANGE_MONITOR_FILTER_CONF = 116,
        CSTA_MONITOR_STOP = 117,
        CSTA_MONITOR_STOP_CONF = 118,
        CSTA_MONITOR_ENDED = 119,
        CSTA_SNAPSHOT_CALL = 120,
        CSTA_SNAPSHOT_CALL_CONF = 121,
        CSTA_SNAPSHOT_DEVICE = 122,
        CSTA_SNAPSHOT_DEVICE_CONF = 123,
        CSTA_GETAPI_CAPS = 124,
        CSTA_GETAPI_CAPS_CONF = 125,
        CSTA_GET_DEVICE_LIST = 126,
        CSTA_GET_DEVICE_LIST_CONF = 127,
        CSTA_QUERY_CALL_MONITOR = 128,
        CSTA_QUERY_CALL_MONITOR_CONF = 129,
        CSTA_ROUTE_REQUEST_EXT = 130,
        CSTA_ROUTE_USED_EXT = 131,
        CSTA_ROUTE_SELECT_INV_REQUEST = 132,
        CSTA_ROUTE_END_INV_REQUEST = 133,
    }
    // ReSharper enable InconsistentNaming
}
