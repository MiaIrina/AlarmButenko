using AlarmEntityFramework;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfAlarm
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
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

        public bool UserExistsInDB(string login)
        {
            return AlarmEntWrapper.UserExistsInDB(login);
        }
    }
}
