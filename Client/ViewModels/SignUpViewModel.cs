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

                Checker.CheckName(Name);

          
                if (Password.Length < 6)
                {
                    MessageBox.Show("Password must be at list 6 characters long");
                    return false;
                }
                //var user = new User(Name, Surname, Email, Login, Password);
                //if (!ServiceClient.Instance.AddUser(user))
                //{
                //    MessageBox.Show("New user mast have unique login and email.");
                //    return false;
                //}
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (!signedUp)
                return;
            var user = new User(Name, Surname, Email, Login, Password);
            ServiceClient.Instance.AddUser(user);
            UserManager.CurrentUser = user;
            NavigationManager.Instance.Navigate(ViewType.ShowRequests);
        }

       

    }
}
