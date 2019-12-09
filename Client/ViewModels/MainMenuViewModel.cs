using Client.Tools;
using Client.Tools.Managers;
using Client.Tools.Navigation;
using System;


namespace Client.ViewModels
{
    class MainMenuViewModelBaseViewModel
    {

        #region
        private RelayCommand<object> _exitCommand;
        private RelayCommand<object> _signUpCommand;
        private RelayCommand<object> _signInCommand;

        #endregion
        public RelayCommand<Object> ExitCommand
        {
            get
            {
                return _exitCommand ?? (_exitCommand = new RelayCommand<object>(o => Environment.Exit(0)));
            }
        }
        public RelayCommand<Object> AddUserCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.SignUp)));
            }
        }
        public RelayCommand<Object> UsersListCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.SignIn)));
            }
        }
    }
}
