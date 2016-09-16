using System;

namespace TSAPILIB2
{
    public class MonitorEventCollection : IDisposable
    {
        private readonly uint _monitorCrossRefId;
        private readonly ConnectionID_t _deviceId;
        private readonly bool _isCallMonitor;
        public bool IsCallMonitor
        {
            get { return _isCallMonitor; }
        }
        public MonitorEventCollection(uint monitorCrossRefId,String deviceId)
        {
            _monitorCrossRefId = monitorCrossRefId;
            _deviceId = new ConnectionID_t { deviceID = deviceId };
        }
        public MonitorEventCollection(uint monitorCrossRefId, ConnectionID_t deviceId)
        {
            _monitorCrossRefId = monitorCrossRefId;
            _deviceId = deviceId;
            _isCallMonitor = true;
        }

        public ConnectionID_t GetTargertMonitror()
        {
            return _deviceId;
        }
        public uint GetTargertMonitrorId()
        {
            return _monitorCrossRefId;
        }

        public delegate void CallCleared(object sender, CstaAttEventArgs<CSTACallClearedEvent_t, ATTCallClearedEvent_t> e,uint monId);
        public delegate void Conferenced(object sender, CstaAttEventArgs<CSTAConferencedEvent_t, ATTConferencedEvent_t> e, uint monId);
        public delegate void ConnectionCleared(object sender, CstaEventArgs<CSTAConnectionClearedEvent_t> e, uint monId);
        public delegate void Delivered(object sender, CstaAttEventArgs<CSTADeliveredEvent_t, ATTDeliveredEvent_t> e, uint monId);
        public delegate void Diverted(object sender, CstaAttEventArgs<CSTADivertedEvent_t, ATTDivertedEvent_t> e, uint monId);
        public delegate void Established(object sender, CstaAttEventArgs<CSTAEstablishedEvent_t, ATTEstablishedEvent_t> e, uint monId);
        public delegate void Failed(object sender, CstaAttEventArgs<CSTAFailedEvent_t, ATTFailedEvent_t> e, uint monId);
        public delegate void Held(object sender, CstaEventArgs<CSTAHeldEvent_t> e, uint monId);
        public delegate void NetworkReached(object sender, CstaAttEventArgs<CSTANetworkReachedEvent_t, ATTNetworkReachedEvent_t> e, uint monId);
        public delegate void Originated(object sender, CstaAttEventArgs<CSTAOriginatedEvent_t, ATTOriginatedEvent_t> e, uint monId);
        public delegate void Queued(object sender, CstaAttEventArgs<CSTAQueuedEvent_t, ATTQueuedEvent_t> e, uint monId);
        public delegate void Retrieved(object sender, CstaEventArgs<CSTARetrievedEvent_t> e, uint monId);
        public delegate void ServiceInitiated(object sender, CstaAttEventArgs<CSTAServiceInitiatedEvent_t, ATTServiceInitiatedEvent_t> e, uint monId);
        public delegate void Transferred(object sender, CstaAttEventArgs<CSTATransferredEvent_t, ATTTransferredEvent_t> e, uint monId);
        public delegate void CallInformation(object sender, CstaEventArgs<CSTACallInformationEvent_t> e, uint monId);
        public delegate void DoNotDisturb(object sender, CstaEventArgs<CSTADoNotDisturbEvent_t> e, uint monId);
        public delegate void Forwarding(object sender, CstaEventArgs<CSTAForwardingEvent_t> e, uint monId);
        public delegate void MessageWaiting(object sender, CstaEventArgs<CSTAMessageWaitingEvent_t> e, uint monId);
        public delegate void BackInService(object sender, CstaEventArgs<CSTABackInServiceEvent_t> e, uint monId);
        public delegate void OutOfService(object sender, CstaEventArgs<CSTAOutOfServiceEvent_t> e, uint monId);
        public delegate void PrivateStatus(object sender, CstaEventArgs<CSTAPrivateStatusEvent_t> e, uint monId);
        public delegate void MonitorEnded(object sender, CstaEventArgs<CSTAMonitorEndedEvent_t> e, uint monId);
        public delegate void LogOn(object sender, CstaEventArgs<CSTALoggedOnEvent_t> e, uint monId);
        public delegate void LogOff(object sender, CstaEventArgs<CSTALoggedOffEvent_t> e, uint monId);

        public event CallCleared OnCallCleared;
        public event Conferenced OnConferenced;
        public event ConnectionCleared OnConnectionCleared;
        public event Delivered OnDelivered;
        public event Diverted OnDiverted;
        public event Established OnEstablished;
        public event Failed OnFailed;
        public event Held OnHeld;
        public event NetworkReached OnNetworkReached;
        public event Originated OnOriginated;
        public event Queued OnQueued;
        public event Retrieved OnRetrieved;
        public event ServiceInitiated OnServiceInitiated;
        public event Transferred OnTransferred;
        public event CallInformation OnCallInformation;
        public event DoNotDisturb OnDoNotDisturb;
        public event Forwarding OnForwarding;
        public event MessageWaiting OnMessageWaiting;
        public event BackInService OnBackInService;
        public event OutOfService OnOutOfService;
        public event PrivateStatus OnPrivateStatus;
        public event MonitorEnded OnMonitorEnded;
        public event LogOn OnLogOn;
        public event LogOff OnLogOff;

        public void Invoke(CstaUnsolicitedEvent data, eventTypeCSTA eventType, ATTEvent_t attData, uint monitorCrossRefId)
        {
          
            
            switch (eventType)
            {
                case eventTypeCSTA.CSTA_CALL_CLEARED: if (OnCallCleared != null) OnCallCleared(this, new CstaAttEventArgs<CSTACallClearedEvent_t, ATTCallClearedEvent_t>(data.callCleared, attData.callClearedEvent), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_CONFERENCED: if (OnConferenced != null) OnConferenced(this, new CstaAttEventArgs<CSTAConferencedEvent_t, ATTConferencedEvent_t>(data.conferenced, attData.conferencedEvent), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_CONNECTION_CLEARED: if (OnConnectionCleared != null) OnConnectionCleared(this, new CstaEventArgs<CSTAConnectionClearedEvent_t>(data.connectionCleared), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_DELIVERED: if (OnDelivered != null) OnDelivered(this, new CstaAttEventArgs<CSTADeliveredEvent_t, ATTDeliveredEvent_t>(data.delivered, attData.deliveredEvent), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_DIVERTED: if (OnDiverted != null) OnDiverted(this, new CstaAttEventArgs<CSTADivertedEvent_t, ATTDivertedEvent_t>(data.diverted, attData.divertedEvent), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_ESTABLISHED: if (OnEstablished != null) OnEstablished(this, new CstaAttEventArgs<CSTAEstablishedEvent_t, ATTEstablishedEvent_t>(data.established, attData.establishedEvent), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_FAILED: if (OnFailed != null) OnFailed(this, new CstaAttEventArgs<CSTAFailedEvent_t, ATTFailedEvent_t>(data.failed, attData.failedEvent), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_HELD: if (OnHeld != null) OnHeld(this, new CstaEventArgs<CSTAHeldEvent_t>(data.held), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_NETWORK_REACHED: if (OnNetworkReached != null) OnNetworkReached(this, new CstaAttEventArgs<CSTANetworkReachedEvent_t, ATTNetworkReachedEvent_t>(data.networkReached, attData.networkReachedEvent), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_ORIGINATED: if (OnOriginated != null) OnOriginated(this, new CstaAttEventArgs<CSTAOriginatedEvent_t, ATTOriginatedEvent_t>(data.originated, attData.originatedEvent), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_QUEUED: if (OnQueued != null) OnQueued(this, new CstaAttEventArgs<CSTAQueuedEvent_t, ATTQueuedEvent_t>(data.queued, attData.queuedEvent), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_RETRIEVED: if (OnRetrieved != null) OnRetrieved(this, new CstaEventArgs<CSTARetrievedEvent_t>(data.retrieved), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_SERVICE_INITIATED: if (OnServiceInitiated != null) OnServiceInitiated(this, new CstaAttEventArgs<CSTAServiceInitiatedEvent_t, ATTServiceInitiatedEvent_t>(data.serviceInitiated, attData.serviceInitiated), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_TRANSFERRED: if (OnTransferred != null) OnTransferred(this, new CstaAttEventArgs<CSTATransferredEvent_t, ATTTransferredEvent_t>(data.transferred, attData.transferredEvent), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_CALL_INFORMATION: if (OnCallInformation != null) OnCallInformation(this, new CstaEventArgs<CSTACallInformationEvent_t>(data.callInformation), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_DO_NOT_DISTURB: if (OnDoNotDisturb != null) OnDoNotDisturb(this, new CstaEventArgs<CSTADoNotDisturbEvent_t>(data.doNotDisturb), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_FORWARDING: if (OnForwarding != null) OnForwarding(this, new CstaEventArgs<CSTAForwardingEvent_t>(data.forwarding), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_MESSAGE_WAITING: if (OnMessageWaiting != null) OnMessageWaiting(this, new CstaEventArgs<CSTAMessageWaitingEvent_t>(data.messageWaiting), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_BACK_IN_SERVICE: if (OnBackInService != null) OnBackInService(this, new CstaEventArgs<CSTABackInServiceEvent_t>(data.backInService), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_OUT_OF_SERVICE: if (OnOutOfService != null) OnOutOfService(this, new CstaEventArgs<CSTAOutOfServiceEvent_t>(data.outOfService), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_PRIVATE_STATUS: if (OnPrivateStatus != null) OnPrivateStatus(this, new CstaEventArgs<CSTAPrivateStatusEvent_t>(data.privateStatus), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_MONITOR_ENDED: MonitorEndedInvoke(data.monitorEnded, monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_LOGGED_ON: if (OnPrivateStatus != null) OnLogOn(this, new CstaEventArgs<CSTALoggedOnEvent_t>(data.loggedOn), monitorCrossRefId); break;
                case eventTypeCSTA.CSTA_LOGGED_OFF: if (OnPrivateStatus != null) OnLogOff(this, new CstaEventArgs<CSTALoggedOffEvent_t>(data.loggedOff), monitorCrossRefId); break;

            }
        }
        public void MonitorEndedInvoke(CSTAMonitorEndedEvent_t data, uint monId)
        {

            if (OnMonitorEnded != null) OnMonitorEnded(this, new CstaEventArgs<CSTAMonitorEndedEvent_t>(data), monId);
        }

        protected virtual void Dispose(bool disposing)
        {

            if (disposing )
            {
                OnCallCleared = null;
                OnConferenced = null;
                OnConnectionCleared = null;
                OnDelivered = null;
                OnDiverted = null;
                OnEstablished = null;
                OnFailed = null;
                OnHeld = null;
                OnNetworkReached = null;
                OnOriginated = null;
                OnQueued = null;
                OnRetrieved = null;
                OnServiceInitiated = null;
                OnTransferred = null;
                OnCallInformation = null;
                OnDoNotDisturb = null;
                OnForwarding = null;
                OnMessageWaiting = null;
                OnLogOn = null;
                OnLogOff = null;
            }
            
            
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}