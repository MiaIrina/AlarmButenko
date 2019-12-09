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
    class LoginViewModel:BaseViewModel,ILoaderOwner
    {
        #region Fields

        private RelayCommand<object> _exitCommand;
        private RelayCommand<object> _backCommand;
        private RelayCommand<object> _loginCommand;
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;
 
        private string _login;
        private string _password;
        #endregion
        #region Properties

        
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

        public RelayCommand<Object> LoginCommand
        {
            get
            {
                return _loginCommand ?? (_loginCommand =
                           new RelayCommand<object>(LoginAction, IsPossibleToLogin));
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



        private bool IsPossibleToLogin(object obj)
        {
            return  !string.IsNullOrWhiteSpace(Login)
                && !string.IsNullOrWhiteSpace(Password) ;
        }

        private void BackCommandAction(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.Main);
        }

        private async void LoginAction(object obj)
        {
            User usertoCheck = null;
            LoaderManager.Instance.ShowLoader();
            bool result = await Task.Run(() =>
            {
                try
                {
                   
                    Checker.CheckLogin(Login);
                    usertoCheck = AlarmClient.Client.UserByLogin(Login);
                    usertoCheck = usertoCheck ?? throw new Exception($"The user with login {Login} doesn`t exist !");
                  
                if (!usertoCheck.CheckPassword(Password))
                {
                    throw new Exception("Wrong password!");
                        
                }
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
               
                    StationManager.Current = usertoCheck;
                    MessageBox.Show($"Welcome back {usertoCheck.Name} {usertoCheck.Surname}!");
                    NavigationManager.Instance.Navigate(ViewType.Alarms);



            }
            return;


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

