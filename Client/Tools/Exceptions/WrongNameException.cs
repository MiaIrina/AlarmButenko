using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Tools.Exceptions
{
    internal class WrongNameException : FormatException
    {
        public WrongNameException() : base()
        {

        }
        public WrongNameException(string name)
            : base($"Wrong format of name or surname {name}")
        {

        }
    }
}
