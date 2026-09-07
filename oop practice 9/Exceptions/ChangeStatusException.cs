using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_practice_9.Exceptions
{
    internal class ChangeStatusException : Exception
    {
        public ChangeStatusException() { }
        public ChangeStatusException(string msg) : base(msg) { }
    }
}
