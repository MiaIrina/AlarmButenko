using Client.Tools;
using Client.Tools.Managers;
using Client.Tools.Navigation;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
    internal class SignUpViewModel: BaseViewModel, ILoaderOwner
    {
        #region Fields

        private RelayCommand<object> _exitCommand;
        private RelayCommand<object> _backCommand;
        private RelayCommand<object> _signUpCommand;
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;
        private string _name;
        private string _email;
        private string _surname;
        private string _login;
        private string _password;
        #endregion
        #region Properties

        public String Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public String Surname
        {
            get
            {
                return _surname;
            }
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }
        public String Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        public String Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<Object> BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand =
                           new RelayCommand<object>(BackCommandAction));
            }
        }

        public RelayCommand<Object> SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand =
                           new RelayCommand<object>(SignUpAction, IsPossibleToSignUp));
            }
        }

        public Visibility LoaderVisibility
        {
            get { return _loaderVisibility; }
            set
            {
                _loaderVisibility = value;
                OnPropertyChanged();
            }
        }
        public bool IsControlEnabled
        {
            get { return _isControlEnabled; }
            set
            {
                _isControlEnabled = value;
                OnPropertyChanged();
            }
        }


        #endregion

        

        private bool IsPossibleToSignUp(object obj)
        {
            return    !string.IsNullOrWhiteSpace(Name)&& !string.IsNullOrWhiteSpace(Surname)&&!string.IsNullOrWhiteSpace(Login)
                && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Email);
        }

        private void BackCommandAction(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.Main);
        }

        private async void SignUpAction(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            bool result = await Task.Run(() =>
            {
                try {
                Checker.CheckName(Name);
                Checker.CheckSurname(Surname);
                Checker.CheckLogin(Login);
                Checker.CheckEmail(Email);
                //!!!
                 }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }

                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
            {   
                var usertoAdd = new User(Name, Surname, Login, Email, Password);
                if (!AlarmClient.Client.UserExistsInDB(usertoAdd))
                {
                    AlarmClient.Client.AddUser(usertoAdd);
                    StationManager.Current = usertoAdd;
                    MessageBox.Show($"Welcome {Name} !");
                    NavigationManager.Instance.Navigate(ViewType.Alarms);
                    
                }
                else MessageBox.Show("This user is already exists!");
                
              
            } return;
           
            
        }

        public RelayCommand<Object> ExitCommand
        {
            get
            {
                return _exitCommand ?? (_exitCommand = new RelayCommand<object>(o => Environment.Exit(0)));
            }
        }

        }
}
