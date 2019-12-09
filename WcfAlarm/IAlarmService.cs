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

    [ServiceContract]
    public interface IAlarmService
    {
        [OperationContract]
        bool UserExistsInDB(User user);
        [OperationContract]
        void AddUser(User user);
        [OperationContract]
        void AddAlarm(Alarm alarm);
        [OperationContract]
        void DeleteAlarm(Alarm alarm);
        [OperationContract]
        User GetUser(string login);

        [OperationContract]
        IEnumerable<Alarm> GetAlarms(User user);

    }
}
