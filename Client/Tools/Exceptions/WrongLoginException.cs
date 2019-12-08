using System;


namespace Client.Tools.Exceptions
{
    internal class WrongLoginException : FormatException
    {
        public WrongLoginException() : base()
        {

        }
        public WrongLoginException(string login)
            : base($"Wrong format of login {login}")
        {

        }
    }
}
