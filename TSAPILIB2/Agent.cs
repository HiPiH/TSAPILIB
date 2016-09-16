using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSAPILIB2
{

    public class AgentExeption : Exception
    {
        public String device;
        public String agent;
        public AgentExeption(String device,String agent, String error)
            :base (String.Format("Agent {0}. Device {1}. Error: '{2}'" ,agent,device,error))
        {
            this.device = device;
            this.agent = agent;
        }
    }
    public class AgentDeviceNoSation : AgentExeption
    {
        public AgentDeviceNoSation(String device, String agent)
            : base(device, agent, "Device is not station.")
        {

        }
        
    }
    public class AgentDeviceinUse : AgentExeption
    {
        public ATTExtensionClass_t obj_used_class;
        public String obj_used;
        public AgentDeviceinUse(String device, String agent, ATTExtensionClass_t obj_used_class, String obj_used)
            : base(device, agent, String.Format("Device in use for '{0}:{1}'.", obj_used_class,obj_used))
        {
            this.obj_used_class = obj_used_class;
            this.obj_used = obj_used;
        }

    }
   

    public class Agent
    {
        public struct StatusAgent
        {
            public StausAgentItem cstate;
            public StausAgentItem lstate;
            public DateTime update;
            public StatusAgent(bool init)
            {
                this.cstate = new StausAgentItem() { status = ATTWorkMode_t.wmNone, code = 0 };
                this.lstate = new StausAgentItem() { status = ATTWorkMode_t.wmNone, code = 0 };
                this.update = DateTime.Now;
            }
            public void Set(ATTWorkMode_t mode, int code)
            {
                this.update = DateTime.Now;
                this.lstate = this.cstate;
                this.cstate = new StausAgentItem() { status = mode, code = code };
            }
            public struct StausAgentItem
            {
                public ATTWorkMode_t status;
                public int code;
            }
        }
        protected TSAPI tsapi;
        protected String agent;
        protected String password;
        protected Device device;
        protected StatusAgent status = new StatusAgent(true);

        public Agent(TSAPI tsapi,String agent, String password,Device device)
        {
            this.tsapi = tsapi;
            this.device = device;
            this.agent = agent;
            this.password = password;
            this.checkDevice();
        }

        protected void setExpetion(String function, String error)
        {
            throw new AgentExeption(this.agent, this.device.getDeviceId(), function + ":" + error);
        }

        public void checkDevice()
        {
            if (this.device.type != DeviceType_t.dtStation)
            {
                throw new AgentDeviceNoSation(this.agent, this.device.getDeviceId());
            }
            if (
                !(
                    this.device.associatedClass == ATTExtensionClass_t.ecOther
                    ||
                    (
                        this.device.associatedClass == ATTExtensionClass_t.ecLogicalAgent
                        && 
                        this.device.associatedDevice == this.agent
                    )
               )
            )
            {
                throw new AgentDeviceinUse(this.agent, this.device.getDeviceId(), this.device.associatedClass, this.device.associatedDevice);
            }
        }

        public Device getDevice()
        {
            return this.device;
        }

        protected void setStatus(ATTWorkMode_t mode, int code)
        {
            this.status.Set(mode, code);
        }


        protected void changeStatusAgent(AgentMode_t type,ATTWorkMode_t mode,int code)
        {
            this.tsapi.setAgentStateAsync(this.device.getDeviceId(), this.agent, "", this.password, type, mode, code,
            new resultDefault(delegate(eventArg arg)
            {
                if (arg.error == CSTAUniversalFailure_t.allOK)
                {
                    this.setStatus(mode, code);
                }
            }));         
        }

        public String getAgentId()
        {
            return this.agent;
        }

        public void Login()
        {
            if (this.status.cstate.status == ATTWorkMode_t.wmNone)
            {
                this.changeStatusAgent(AgentMode_t.amLogIn, ATTWorkMode_t.wmAuxWork, 0);
            }
        }

        public void Logout()
        {
            if (this.status.cstate.status != ATTWorkMode_t.wmNone)
            {
                this.changeStatusAgent(AgentMode_t.amLogOut, ATTWorkMode_t.wmNone, 0);
            }
        }

        public void Manual()
        {
            if (this.status.cstate.status == ATTWorkMode_t.wmManualIn && this.status.cstate.status != ATTWorkMode_t.wmNone)
            {
                this.changeStatusAgent(AgentMode_t.amReady, ATTWorkMode_t.wmManualIn, 0);
            }
        }

        public void AuxWrok(int code)
        {
            if (this.status.cstate.status == ATTWorkMode_t.wmAuxWork  && this.status.cstate.status != ATTWorkMode_t.wmNone)
            {
                this.changeStatusAgent(AgentMode_t.amNotReady, ATTWorkMode_t.wmAuxWork, code);
            }
        }

        public void AftrCall(int code)
        {
            if (this.status.cstate.status == ATTWorkMode_t.wmAftcalWk && this.status.cstate.status != ATTWorkMode_t.wmNone)
            {
                this.changeStatusAgent(AgentMode_t.amWorkNotReady, ATTWorkMode_t.wmAftcalWk, 0);
            }
        }

    }
}
