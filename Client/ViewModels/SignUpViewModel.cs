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

        private RelayCommand<object> _backCommand;
        private RelayCommand<object> _signUpCommand;
        private Visibility _loaderVisibility = Visibility.Hidden;
        private bool _isControlEnabled = true;

        #endregion
        #region Properties


        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

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
                    NavigationManager.Instance.Navigate(ViewType.Alarms);
                }
                else MessageBox.Show("This user is already exists!");
                
              
            } return;
           
            
        }

       

    }
}
