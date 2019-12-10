using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private DateTime _beginTime;
        [DataMember]
        private DateTime _endTime;
        [DataMember]
        private User _user;
        [DataMember]
        private int _hour;
        [DataMember]
        private int _minutes;

        public Guid Guid
        {
            get => _guid;
            set => _guid = value;
        }
    

        public Guid UserGuid
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
        public int Hour
        {

            get =>_hour;
          
             set=>   _hour = value;
            
        }
        public int Minutes
        {
            get => _minutes;
          
            set=>    _minutes = value;
            
        }
        public ObservableCollection<int> Hours { get; private set; }
        public ObservableCollection<int> Minut { get; private set; }

        public virtual User AlarmUser
        {
            get { return _user; }
             set { _user = value; }
        }
        private DateTime CountDate(int hour, int minutes)
        {
            DateTime today = DateTime.Now;
            DateTime res = new DateTime(today.Year,today.Month,today.Day,hour,minutes,0);
            if (today.Hour > hour||(today.Hour == hour && today.Minute>minutes))
            {
                res=res.AddDays(1);
            }
            return res;

        }
        public Alarm(int hour, int minutes) : this()
        {
            _guid = Guid.NewGuid();
            _beginTime = CountDate(hour,minutes);
            _endTime=_beginTime.AddMinutes(2);
            _hour= hour;
            _minutes = minutes;
          
           
        }
        public void deleteDBValues()
        {
            _user = null;
        }
        private Alarm()
        {
            Hours = new ObservableCollection<int>(Enumerable.Range(0, 24));
            Minut = new ObservableCollection<int>(Enumerable.Range(0, 60));
        }
    }
}
