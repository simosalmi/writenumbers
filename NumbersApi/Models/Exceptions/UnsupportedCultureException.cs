using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NumbersApi.Models.Exceptions
{
    class UnsupportedCultureException : Exception
    {
        public UnsupportedCultureException()
        {

        }

        public UnsupportedCultureException(string message)
            :base(message)
        {

        }

        public UnsupportedCultureException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
