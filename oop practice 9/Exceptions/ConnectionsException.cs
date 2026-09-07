using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_practice_9.Exceptions
{
    internal class ConnectionsException : Exception
    {
        public ConnectionsException() { }
        public ConnectionsException(string msg) : base(msg) { }
    }
}
