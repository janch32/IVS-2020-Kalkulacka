using System;
using System.Runtime.Serialization;

namespace MathLib.Exceptions
{
    /// <summary>
    /// Generic Exception for parse errors.
    /// Mainly for malformed input expression strings
    /// </summary>
    [Serializable]
    public class ParseException : Exception
    {
        public ParseException()
        {
        }

        public ParseException(string message) : base(message)
        {
        }

        public ParseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ParseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
