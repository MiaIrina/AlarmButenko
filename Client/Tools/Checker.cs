using Client.Tools.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Client.Tools
{
    internal static class Checker
    {

        public static void CheckEmail(string email)
        {
            try
            {
                 Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                throw new WrongMailException(email);
            }
        }

        public static void CheckName(string name)
        {
            try
            {
               
           Regex.IsMatch(name,
                    @" ^[a - zA - Z] + (([',. -][a-zA-Z ])?[a-zA-Z]*)*$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                throw new WrongNameException(name);
            }

        }
        public static void CheckSurname(string surname)
        {
            try
            {

                Regex.IsMatch(surname,
                          @" ^[a - zA - Z] + (([',. -][a-zA-Z ])?[a-zA-Z]*)*$",
                          RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                throw new WrongSurnameException(surname);
            }

        }
        public static void CheckLogin(string login)
        {
            try
            {

                 Regex.IsMatch(login,
                          @"^(?=.*[A-Za-z0-9]$)[A-Za-z][A-Za-z\d.-]{0,19}$",
                          RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                throw new WrongLoginException(login);
            }

        }
    }
}
