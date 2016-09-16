using System;
using System.Linq;
using System.Runtime.Serialization;

namespace TSAPILIB2
{
    
    public delegate void ResultDefault<T1, T2>(EventArg<T1, T2> arg);
    public delegate void ResultDefault<T1>(EventArg<T1> arg);
    public delegate void ResultDefault(NullTsapiReturn arg);

    public class ResultTsapi<T1,T2>
    {
        public T1 Csta;
        public T2 Att;
        public ResultTsapi(T1 a1,T2 a2)
        {
            Csta = a1;
           Att = a2;
        }
    }
  
 
    public class EventArg<T1,T2> 
    {
        public T1 Csta ;
        public T2 Att;
        public EventArg() { }
        public EventArg(object a1, object a2) {
            Csta = (T1)a1;
            Att = (T2)a2; 
        }
        public EventArg(T1 a1, T2 a2) { Csta = a1; Att = a2; }
        public void Set(T1 data,T2 attData)
        {
           Csta = data;
           Att = attData;
        }
    
    }

    public class NullTsapiReturn
    {
        public int Case = 0;
    }



    public struct SnapshotDeviceEventReturn 
    {
        public CSTASnapshotDeviceConfEvent_t Csta;
        public ATTSnapshotDeviceConfEvent_t Att;
        public SnapshotDeviceEventReturn(CstaConfirmationEvent a1, ATTEvent_t a2)
        {
           Csta = a1.snapshotDevice;
           Att = a2.snapshotDevice;
       
        }
    }
    [DataContract]
    public struct QueryDeviceInfoReturn
    {
        [DataMember]
        public CSTAQueryDeviceInfoConfEvent_t Csta;
        [DataMember]
        public ATTQueryDeviceInfoConfEvent_t Att;
        public QueryDeviceInfoReturn(CstaConfirmationEvent a1, ATTEvent_t a2)
        {
           Csta = a1.queryDeviceInfo;
           Att = a2.queryDeviceInfo;
        }
    }
    public struct ConferenceCallEventReturn
    {
        [DataMember]
        public CSTAConferenceCallConfEvent_t Csta;
        [DataMember]
        public ATTConferenceCallConfEvent_t Att;
        public ConferenceCallEventReturn(CstaConfirmationEvent a1, ATTEvent_t a2)
        {
           Csta = a1.conferenceCall;
           Att = a2.conferenceCall;
        }
    }
    public struct MakeCallEventReturn
    {
        [DataMember]
        public CSTAMakeCallConfEvent_t Csta;
        [DataMember]
        public ATTMakeCallConfEvent_t Att;
        public MakeCallEventReturn(CstaConfirmationEvent a1, ATTEvent_t a2)
        {
           Csta = a1.makeCall;
           Att = a2.makeCall;
        }
    }
    public struct ConsultationCallEventReturn 
    {
        [DataMember]
        public CSTAConsultationCallConfEvent_t Csta;
        [DataMember]
        public ATTConsultationCallConfEvent_t Att;
        public ConsultationCallEventReturn(CstaConfirmationEvent a1, ATTEvent_t a2)
        {
           Csta = a1.consultationCall;
           Att = a2.consultationCall;
        }
    }
    public struct MakePredictiveCallEventReturn
    {
        [DataMember]
        public CSTAMakePredictiveCallConfEvent_t Csta;
        [DataMember]
        public ATTMakePredictiveCallConfEvent_t Att;
        public MakePredictiveCallEventReturn(CstaConfirmationEvent a1, ATTEvent_t a2)
        {
           Csta = a1.makePredictiveCall;
           Att = a2.makePredictiveCall;
        }
    }

    public struct TransferCallEventReturn
    {
     /*   [DataMember]
        public CSTATransferCallConfEvent_t Csta;
        [DataMember]
        public ATTTransferCallConfEvent_t Att;*/

        public TransferCallEventReturn(CstaConfirmationEvent a1, ATTEvent_t a2)
        {
          // Csta = a1.transferCall;
           //Att = a2.transferCall;
        }
    }
    public struct QueryMsgWaitingEventReturn
    {
        [DataMember]
        public CSTAQueryMwiConfEvent_t Csta;
        [DataMember]
        public ATTQueryMwiConfEvent_t Att;
        public QueryMsgWaitingEventReturn(CstaConfirmationEvent a1, ATTEvent_t a2)
        {
           Csta = a1.queryMwi;
           Att = a2.queryMwi;
        }
    }
    public struct QueryAgentStateEventReturn
    {
        [DataMember]
        public CSTAQueryAgentStateConfEvent_t Csta;
        [DataMember]
        public ATTQueryAgentStateConfEvent_t Att;
        public QueryAgentStateEventReturn(CstaConfirmationEvent a1, ATTEvent_t a2)  {
           Csta = a1.queryAgentState;
           Att = a2.queryAgentState;
        }
    }
    public struct QueryLastNumberEventReturn
    {
        [DataMember]
         public CSTAQueryLastNumberConfEvent_t Csta;
         public QueryLastNumberEventReturn(CstaConfirmationEvent a1)
        {
           Csta = a1.queryLastNumber;
        }
    }

    public struct ChangeMonitorFilterEventReturn
    {
        [DataMember]
         public CSTAChangeMonitorFilterConfEvent_t Csta;
         public ChangeMonitorFilterEventReturn(CstaConfirmationEvent a1)
        {
           Csta = a1.changeMonitorFilter;
        }
    }

    public struct SnapshotCallEventReturn
    {
        [DataMember]
        public CSTASnapshotCallConfEvent_t Csta;
        [DataMember]
        public ATTSnapshotCallConfEvent_t Att;
        public SnapshotCallEventReturn(CstaConfirmationEvent a1, ATTEvent_t a2)  {
           Csta = a1.snapshotCall;
           Att = a2.snapshotCallConf;
        }
    }
    public struct QueryCallMonitorEventReturn
    {
        [DataMember]
       public CSTAQueryCallMonitorConfEvent_t Csta;
         public QueryCallMonitorEventReturn(CstaConfirmationEvent a1)
        {
           Csta = a1.queryCallMonitor;
        }
    }
    public struct GetDeviceListEventReturn
    {
        [DataMember]
        public CSTAGetDeviceListConfEvent_t Csta;
         public GetDeviceListEventReturn(CstaConfirmationEvent a1)
        {
           Csta = a1.getDeviceList;
        }
    }
    public struct ApiCapsEventReturn
    {
        [DataMember]
        public CSTAGetAPICapsConfEvent_t Csta;
        [DataMember]
        public ATTGetAPICapsConfEvent_t Att;
        public ApiCapsEventReturn(CstaConfirmationEvent a1, ATTEvent_t a2)  {
           Csta = a1.getAPICaps;
           Att = a2.getAPICaps;
        }
    }
    public struct QueryAcdSplitEventReturn
    {
        [DataMember]
       public ATTQueryAcdSplitConfEvent_t Att;
       public QueryAcdSplitEventReturn( ATTEvent_t a1)
        {
           Att = a1.queryAcdSplit;
        }

        public override string ToString()
        {
            return Att.agentsLoggedIn + ":" + Att.availableAgents;
        }
    }

    public struct QueryAgentLoginEventReturn
    {
        [DataMember]
        public ATTQueryAgentLoginConfEvent_t Att;
        public QueryAgentLoginEventReturn(ATTEvent_t a1)
        {
            Att = a1.queryAgentLogin;
        }
    }



    public struct QueryStationStatusEventReturn
    {
        [DataMember]
      public ATTQueryStationStatusConfEvent_t Att;
         public QueryStationStatusEventReturn(ATTEvent_t a1)
        {
           Att = a1.queryStationStatus;
        }
    }
    public struct QueryUcidEventReturn
    {
        [DataMember]
         public ATTQueryUcidConfEvent_t Att;
         public QueryUcidEventReturn( ATTEvent_t a1)
        {
           Att = a1.queryUCID;
        }
    }
    public struct SetupMonitorEventReturn
    {
        [DataMember]
        public CSTAMonitorConfEvent_t Csta;
        [DataMember]
        public ATTMonitorConfEvent_t Att;
        public SetupMonitorEventReturn(CstaConfirmationEvent a1, ATTEvent_t a2)
        {
           Csta = a1.monitorStart;
           Att = a2.monitorStart;
        }
    }


    public class CstaEventArgs<TCsta> : EventArgs
    {
        public CstaEventArgs(TCsta csta)
        {
            
            Csta = csta;
        }

        public TCsta Csta { get; private set; }

    }
    public class CstaAttEventArgs<TCsta, TAtt> : CstaEventArgs<TCsta>
    {
        public CstaAttEventArgs(TCsta csta, TAtt att):base(csta)
        {
            Att = att;
        }

        public TAtt Att { get; private  set; }
    }
}
