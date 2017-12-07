using System;
using System.Runtime.Serialization;

namespace WpfApp1
{
    [Serializable]
    internal class InvalidClickException : Exception
    {
        public InvalidClickException()
        {
        }

        public InvalidClickException(string message) : base(message)
        {
        }

        public InvalidClickException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidClickException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}