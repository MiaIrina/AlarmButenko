using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Tools.Exceptions
{
    internal class WrongSurnameException : FormatException
    {
        public WrongSurnameException() : base()
        {

        }
        public WrongSurnameException(string name)
            : base($"Wrong format of surname {name}")
        {

        }
    }
}
