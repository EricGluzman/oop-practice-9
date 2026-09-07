using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_practice_9.Exceptions
{
    internal class IsCurrentWorkException : Exception
    {
        public IsCurrentWorkException() { }
        public IsCurrentWorkException(string msg) : base(msg) { }
    }
}
