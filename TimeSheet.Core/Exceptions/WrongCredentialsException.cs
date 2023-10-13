﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheet.Core.Exceptions
{
    public class WrongCredentialsException : Exception
    {
        public WrongCredentialsException() { }
        public WrongCredentialsException(string message) : base(message) { }
    }
}
