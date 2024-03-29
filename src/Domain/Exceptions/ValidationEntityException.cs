﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ValidationEntityException : BaseException
    {
        public ValidationEntityException(string message) : base(message)
        {
        }

        public ValidationEntityException(List<string> messages) : base(messages)
        {
        }

        public ValidationEntityException() : base("An Error ocurred. Please try later.")
        {
            
        }
    }
}
