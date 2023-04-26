using System.Runtime.Serialization;

namespace eTrade.Business.CrossCuttingConcern.Exceptions
{
    public class UserRegisterFailedException : Exception
    {
        public UserRegisterFailedException() : base("Error")
        {

        }

        public UserRegisterFailedException(string? message) : base(message)
        {
        }

        public UserRegisterFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UserRegisterFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
