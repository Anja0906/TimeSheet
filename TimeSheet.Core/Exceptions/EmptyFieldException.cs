using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Core.Exceptions
{
    public class EmptyFieldException : Exception
    {
        public EmptyFieldException() { }
        public EmptyFieldException(string message) : base(message) { }
    }
}
