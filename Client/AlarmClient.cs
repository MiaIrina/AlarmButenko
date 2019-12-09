

using Client.Tools.Exceptions;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class AlarmClient
    {
        private static AlarmClient _client;
        private static readonly object Locker = new object();

        internal static AlarmClient Client
        {
            get
            {
                if (_client == null)
                    lock (Locker)
                {
                    return _client ?? (_client = new AlarmClient());
                }
                    return _client;
                
            }
        }

        private static AlarmServiceClient ClientOfAlarm { get; set; }

        private AlarmClient()
        {
            ClientOfAlarm = new ServiceClient();
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
