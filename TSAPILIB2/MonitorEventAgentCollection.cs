using System;
using System.Threading;

namespace TSAPILIB2
{
    public class MonitorEventAgentCollection:  IDisposable
    {

        private ATTQueryAgentStateConfEvent_t _mode;
        private AgentState_t _sate;
        private Timer _timer;
        private bool _start = true;
        public delegate void Login(object sender, AgentStateEventArgs e,uint monitorId);
        public delegate void Logout(object sender, AgentStateEventArgs e, uint monitorId);
        public delegate void Ready(object sender, AgentStateEventArgs e, uint monitorId);
        public delegate void NotRead(object sender, AgentStateEventArgs e, uint monitorId);
        public delegate void AftCall(object sender, AgentStateEventArgs e, uint monitorId);

        public event MonitorEventAgentCollection.Login OnLogin;
        public event Logout OnLogout;
        public event Ready OnReady;
        public event NotRead OnNotReady;
        public event AftCall OnAftCall;

        private readonly Tsapi _tsapi;
        private readonly string _agentId;
        private readonly uint _monitorId;

        private enum Timeouts
        {
            Login = 1000,
            Logout = 5000
        }
        public string GetAgentName()
        {
            return _agentId;
        }
        public MonitorEventAgentCollection(Tsapi ts, string agentId, int count)
        {
            _tsapi = ts;
            _agentId = agentId;
            _monitorId = (uint)count + 1000000; // попытка уйти от пересечения с монитрингом девайсов
            _timer = new Timer(TimerCallBack, this, (long)Timeouts.Login,(long) Timeouts.Login);
        }
        ~MonitorEventAgentCollection()
        {
            Dispose(false);
        }
        private void TimerCallBack(object sender)
        {
            _tsapi.GetQueryAgentState(_agentId);
        }

        public void Invoke(CSTAQueryAgentStateConfEvent_t csta, ATTQueryAgentStateConfEvent_t att)
        {
            if (_start)
            {
                _mode = att;
                _sate = csta.agentState;
                if (csta.agentState == AgentState_t.agNull)
                {
                    LogoutInvoke();
                }
                else
                {

                    LoginInvoke();
                    switch (_mode.workMode)
                    {
                        case ATTWorkMode_t.wmManualIn:ReadyInvoke(); break;
                        case ATTWorkMode_t.wmAuxWork:NotReadyInvoke(); break;
                        case ATTWorkMode_t.wmAftcalWk:AftCallInvoke(); break;
                    }
                }              
                _start = false;
            }
            else
            {
                if (_sate != csta.agentState ||_mode.workMode != att.workMode ||_mode.reasonCode != att.reasonCode ||_mode.talkState != att.talkState)
                {
                    if (csta.agentState == AgentState_t.agNull &&_sate != AgentState_t.agNull)
                    {
                        LogoutInvoke();
                    }
                    if (csta.agentState != AgentState_t.agNull &&_sate == AgentState_t.agNull)
                    {
                        LoginInvoke();
                    }
                    _mode = att;
                    _sate = csta.agentState;
                    switch (_mode.workMode)
                    {
                        case ATTWorkMode_t.wmAutoIn:
                        case ATTWorkMode_t.wmManualIn:ReadyInvoke(); break;
                        case ATTWorkMode_t.wmAuxWork:NotReadyInvoke(); break;
                        case ATTWorkMode_t.wmAftcalWk:AftCallInvoke(); break;
                    }
                }
            }

            _timer.Change((long)Timeouts.Login, (long)Timeouts.Login);
        }

         void LoginInvoke()
        {
           
            _timer.Change((long)Timeouts.Login, (long)Timeouts.Login);
             OnLogin?.Invoke(this, new AgentStateEventArgs { Mode = _mode }, _monitorId);
        }

         void LogoutInvoke()
        {
            _timer.Change((long)Timeouts.Logout, (long)Timeouts.Logout);
             OnLogout?.Invoke(this, new AgentStateEventArgs { Mode = _mode }, _monitorId);
        }

         void ReadyInvoke()
         {
             OnReady?.Invoke(this, new AgentStateEventArgs { Mode = _mode }, _monitorId);
         }

        void NotReadyInvoke()
        {
            OnNotReady?.Invoke(this, new AgentStateEventArgs { Mode = _mode }, _monitorId);
        }

        void AftCallInvoke()
        {
            OnAftCall?.Invoke(this, new AgentStateEventArgs { Mode = _mode }, _monitorId);
        }

        public void Dispose()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Disposed) return;
            if (disposing)
            {


            }
            if (_timer != null)
            {
                _timer.Dispose();
                _timer = null;
            }
            OnAftCall = null;
            OnLogin = null;
            OnLogout = null;
            OnNotReady = null;
            OnReady = null;
        }

        public bool Disposed { get; set; }

        public uint MonitorId => _monitorId;
    }
}