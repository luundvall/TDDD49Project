using System;
using System.Runtime.Serialization;

namespace WpfApp1.BLL
{
    [Serializable]
    internal class NoFileFoundException : Exception
    {
        public NoFileFoundException()
        {
        }

        public NoFileFoundException(string message) : base(message)
        {
        }

        public NoFileFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoFileFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}