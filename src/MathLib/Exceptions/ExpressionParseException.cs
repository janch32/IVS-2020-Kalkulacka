using System;
using System.Runtime.Serialization;

namespace MathLib.Exceptions
{
    [Serializable]
    public class ExpressionParseException : Exception
    {
        public ExpressionParseException()
        {
        }

        public ExpressionParseException(string message) : base(message)
        {
        }

        public ExpressionParseException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExpressionParseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
