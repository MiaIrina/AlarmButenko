using System;


namespace Client.Tools.Exceptions
{
    internal class WrongMailException : FormatException
    {
        public WrongMailException() : base()
        {

        }
        public WrongMailException(string mail)
            : base($"Wrong format of email {mail}")
        {

        }
    }
}
