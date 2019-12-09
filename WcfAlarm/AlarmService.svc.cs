using AlarmEntityFramework;
using Models;
using System.Collections.Generic;


namespace WcfAlarm
{
    
    public class AlarmService : IAlarmService
    {

        public void AddAlarm(Alarm alarm)
        {
            AlarmEntWrapper.AddAlarm(alarm);
        }

        public void AddUser(User user)
        {
            AlarmEntWrapper.AddUser(user);
        }

        public void DeleteAlarm(Alarm alarm)
        {
            AlarmEntWrapper.DeleteAlarm(alarm);
        }



        public IEnumerable<Alarm> GetAlarms(User user)
        {
            return AlarmEntWrapper.GetAlarms(user.Guid);
        }

        public User GetUser(string login)
        {
            return AlarmEntWrapper.UserByLogin(login);
        }

        public bool UserExistsInDB(User user)
        {
            return AlarmEntWrapper.UserExistsInDB(user);
        }
    }
}
