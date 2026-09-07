using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace oop_practice_9.Exceptions
{
    internal class LikeException : Exception
    {
        public LikeException() { }
        public LikeException(string msg) : base(msg) { }
    }
}
