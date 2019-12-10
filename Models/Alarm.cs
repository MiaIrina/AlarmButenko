using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Alarm
    {
        [DataMember]
        private Guid _guid;
        [DataMember]
        private Guid _userGuid;
        [DataMember]
        private User _alarmUser;
        [DataMember]
        private DateTime _beginTime;
        [DataMember]
        private DateTime _endTime;
        [DataMember]
        private User _user;
        public Guid Guid
        {
            get => _guid;
            set => _guid = value;
        }
        public virtual User AlarmUser
        {
            get => _alarmUser;
            set => _alarmUser = value;
        }

        public Guid OwnerGuid
        {
            get => _userGuid;
            set => _userGuid = value;
        }
        public DateTime BeginTime
        {

            get => _beginTime;
            set => _beginTime = value;
        }
        public DateTime EndTime
        {

            get => _endTime;
            set => _endTime = value;
        }

        public User User
        {
            get { return _user; }
            private set { _user = value; }
        }
        private DateTime CountDate(int hour, int minutes)
        {
            DateTime today = DateTime.Now;
            DateTime res = new DateTime(today.Year,today.Month,today.Day,hour,minutes,0);
            if (today.Hour > hour||(today.Hour == hour && today.Minute>minutes))
            {
                res.AddDays(1);
            }
            return res;

        }
        public Alarm(int hour, int minutes, User user) : this()
        {
            _guid = Guid.NewGuid();
            _beginTime = CountDate(hour,minutes);
            _endTime=_beginTime.AddMinutes(2);
            _user = user;
            _userGuid = user.Guid;
            User.Alarms.Add(this);
        }
        public void deleteDBValues()
        {
            _user = null;
        }
        private Alarm()
        {
        }
    }
}
