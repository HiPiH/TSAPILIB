using System;

namespace TSAPILIB2
{
    public class EventArg<T1>
    {
        public T1 Result = default(T1);
        public EventArg() { }
        public EventArg(object a1) { Result = (T1)a1; }
        public EventArg(T1 a1) { Result = a1; }
        public void Set(T1 data)
        {
            Result = data;
        }
    }

    public class UniversalFailureEventArg : EventArgs
    {
        public ACSUniversalFailure_t Error { get; set; }
        public PrivateData_t Pd { get; set; }
        public uint InvokeID { get; set; }
    }

    public class UniversalFailureSys : EventArgs
    {
        public ACSUniversalFailure_t Error { get; set; }
        public eventTypeACS EventType { get; set; }
    }

    public class AgentStateEventArgs : EventArgs
    {
        public ATTQueryAgentStateConfEvent_t  Mode { get; set; }
    }
}