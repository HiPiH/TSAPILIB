using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSAPILIB2
{
    public class DeviceExeption : Exception
    {
        public String device;
        public DeviceExeption(String device,String error)
            :base (String.Format("Device {0}. Error: '{1}'" ,device,error))
        {
            this.device = device;
        }
    }

    public class Device
    {
        protected TSAPI tsapi;
        protected String device;
        protected CSTAQueryDeviceInfoConfEvent_t device_info;
        protected ATTQueryDeviceInfoConfEvent_t device_associated_info;

        public DeviceType_t type{get{ return this.device_info.deviceType;}}
        public DeviceClass_t classe{get{ return this.device_info.deviceClass;}}
        public ATTExtensionClass_t associatedClass{get{ return this.device_associated_info.associatedClass;}}
        public String associatedDevice{get{ return this.device_associated_info.associatedDevice;}}

        public Device(TSAPI tsapi, String device)
        {
            this.tsapi = tsapi;
            this.device = device;
            resultQueryDeviceInfo inf = new resultQueryDeviceInfo(this.initDevice);
            this.tsapi.getQueryDeviceInfoAsync(this.device, this.initDevice);
            this.tsapi.getQueryDeviceInfoAsync(this.device, this.initDevice);
        }

        protected void initDevice(QueryDeviceInfoEventArg arg)
        {
            Console.WriteLine(arg.error);
            if (arg.error == CSTAUniversalFailure_t.allOK)
            {
                this.device_info = arg.arg;
                this.device_associated_info = arg.att_arg;
            }else{
                throw new DeviceExeption(this.device,"initDevice "+arg.error);
            }
        }

        public String getDeviceId()
        {
            return this.device;
        }

    }
}
