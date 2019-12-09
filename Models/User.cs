using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract(IsReference = true)]
    public class User : IDBModel
    {
        #region Fields
        [DataMember]
        private Guid _guid;
        [DataMember]
        private string _name;
        [DataMember]
        private string _surname;
        [DataMember]
        private string _login;

        [DataMember]
        private string _email;
        [DataMember]
        private string _password;
        [DataMember]
        private DateTime _lastLoginDate;
        [DataMember]
        private List<Alarm> _alarms;
        #endregion
        #region Properties
        public Guid Guid
        {
            get
            {
                return _guid;
            }
            private set
            {
                _guid = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                _name = value;
            }
        }
        public string Login
        {
            get
            {
                return _login;
            }
            private set
            {
                _login = value;
            }
        }
        public string Surname
        {
            get
            {
                return _surname;
            }
            private set
            {
                _surname = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            private set => _email = value;
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set { _password = value; }
        }
        public DateTime LastLoginDate
        {
            get
            {
                return _lastLoginDate;
            }
            set
            {
                _lastLoginDate = value;
            }
        }

        public List<Alarm> Alarms
        {
            get => _alarms;
            set => _alarms = value;
        }
        #endregion

        #region Constructor

        public User(string name, string surname, string login, string email, string password) : this()
        {
            _guid = Guid.NewGuid();
            _name = name;
            _surname = surname;
            _email = email;
            _login = login;
            _lastLoginDate = DateTime.Now;
            _password = EncryptPassword(password);
        }

        private User()
        {
            _alarms = new List<Alarm>();
        }
        #endregion

        private string EncryptPassword(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] arr = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(arr);
        }


        internal bool CheckPassword(string password)
        {
            try
            {
                string pass = EncryptPassword(password);
                return _password == pass;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CheckPassword(User user)
        {
            try
            {
                return _password == user._password;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
