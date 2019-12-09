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
        private int _hour;
        [DataMember]
        private int _minutes;
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
        public int Hour
        {

            get => _hour;
            set => _hour = value;
        }
        public int Minutes
        {

            get => _minutes;
            set => _minutes = value;
        }

        public User User
        {
            get { return _user; }
            private set { _user = value; }
        }

        public Alarm(int hour, int minutes, User user) : this()
        {
            _guid = Guid.NewGuid();
            _hour = hour;
            _minutes = minutes;
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
