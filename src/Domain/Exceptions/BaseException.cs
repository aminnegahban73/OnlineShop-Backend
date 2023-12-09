namespace Domain.Exceptions
{
    public class BaseException : Exception
    {
        public List<string> Messages { get; set; }
        
        public BaseException(string message) : base(message)
        {
        }

        public BaseException(List<string> messages) : base(null)
        {
            Messages = messages;
        }
    }
}
