
namespace Domain.Exceptions
{
    public class BadRequestEntityException : BaseException
    {
        public BadRequestEntityException(string message) : base(message)
        {
        }

        public BadRequestEntityException(List<string> messages) : base(messages)
        {
        }

        public BadRequestEntityException() : base("Request not valid.")
        {

        }
    }
}
