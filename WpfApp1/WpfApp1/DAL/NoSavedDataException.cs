using System;
using System.Runtime.Serialization;

namespace WpfApp1.DAL
{
    [Serializable]
    internal class NoSavedDataException : Exception
    {
        public NoSavedDataException()
        {
        }

        public NoSavedDataException(string message) : base(message)
        {
        }

        public NoSavedDataException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoSavedDataException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}