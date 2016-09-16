using System;
using System.Runtime.Serialization;

namespace TSAPILIB2
{
    [Serializable]
    public class Exeption : Exception
    {
        public ACSFunctionRet_t Code;
        public Exeption(ACSFunctionRet_t type)
            : base(String.Format("{0}",  type))
        {
        }
        public Exeption(String text, ACSFunctionRet_t type)
            : base(String.Format("{0}:{1}",text,type))
        {
            Code = type;
        }
        // ReSharper disable once RedundantOverridenMember
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
    [Serializable]
    public class CstaExeption : Exception
    {

        public CSTAUniversalFailure_t Code;
        public CstaExeption(CSTAUniversalFailure_t type)
            : base(String.Format("{0}", type))
        {
            Code = type;
        }
        public CstaExeption(String text, CSTAUniversalFailure_t type)
            : base(String.Format("{0}:{1}", text, type))
        {
            Code = type;
        }

        // ReSharper disable once RedundantOverridenMember
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
    [Serializable]
    public class TsapiSystemExeption : Exception
    {
        public TsapiSystemExeption(ACSUniversalFailure_t error)
            : base(error.ToString())
        {
        }
    }
    [Serializable]
    public class ProgrammingExeption : Exception
    {
        public ProgrammingExeption(String text)
            : base(text)
        {
        }
    }
}