



using Client.ServiceAlarm;
using Models;

using System.Collections.Generic;

namespace Client
{
    internal class AlarmClient
    {
        private static AlarmClient _sample;
        private static readonly object Locker = new object();

        internal static AlarmClient Sample
        {
            get
            {
                if (_sample!= null)
                    return _sample;

                lock (Locker)
                {
                    return _sample ?? (_sample = new AlarmClient());
                }
                
            }
        }

        private static AlarmServiceClient ClientOfAlarm  { get; set; }

        private AlarmClient()
        {
            ClientOfAlarm = new AlarmServiceClient();
        }
      internal void CloseCon()
        {
            ClientOfAlarm.Close();
        }
        internal void AddUser(User user)
        {
            ClientOfAlarm.AddUser(user);
        }
        internal bool UserExistsInDB(User user)
        {
            return ClientOfAlarm.UserExistsInDB(user);
        }

        internal void AddAlarm(Alarm alarm)
        {
            ClientOfAlarm.AddAlarm(alarm);
        }
        internal void DeleteAlarm(Alarm alarm)
        {
            ClientOfAlarm.DeleteAlarm(alarm);
        }
        internal IEnumerable<Alarm> GetAlarms (User user)
        {
            return ClientOfAlarm.GetAlarms(user);
        }

        internal User UserByLogin(string login)
        {
            return ClientOfAlarm.GetUser(login);
        }


      



    }
}
