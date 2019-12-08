using AlarmEntityFramework;
using AlarmProjectButenko.Models;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlarmManagers
{
    class AlarmDBManager
    {

        public static bool UserExistsInDB(string login)
        {
            return AlarmEntWrapper.UserExistsInDB(login);
        }

        public static User GetUserByLogin(string login)
        {
            return AlarmEntWrapper.UserByLogin(login);
        }

        public static void AddUser(User user)
        {
            AlarmEntWrapper.AddUser(user);
        }

        internal static User CheckUser(User user)
        {
            var userInDB = AlarmEntWrapper.UserByGuid(user.Guid);
            if (userInDB!= null && userInDB.CheckPassword(user))
                return userInDB;
            return null;
        }

        public static void DeleteAlarm(Alarm alarm)
        {
            AlarmEntWrapper.DeleteAlarm(alarm);
        }

        public static void AddAlarm(Alarm alarm)
        {
            AlarmEntWrapper.AddAlarm(alarm);
        }
    }
}
