using System;
using System.Runtime.Serialization;

namespace SzakdogaBeleptetes
{
    [Serializable]
    internal class AbKivetel : Exception
    {
        public AbKivetel()
        {
        }

        public AbKivetel(string message) : base(message)
        {
        }

        public AbKivetel(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AbKivetel(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}