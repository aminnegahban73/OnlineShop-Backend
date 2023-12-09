using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class NotFoundEntityException : BaseException 
    {
        public NotFoundEntityException(string message) : base(message)
        {
        }

        public NotFoundEntityException(List<string> messages) : base(messages)
        {
        }

        public NotFoundEntityException() : base("No information found!")
        {
        }
    }
}
