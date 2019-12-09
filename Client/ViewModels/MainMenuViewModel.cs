using Client.Tools;
using Client.Tools.Managers;
using Client.Tools.Navigation;
using System;


namespace Client.ViewModels
{
    class MainMenuViewModel:BaseViewModel
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
        public RelayCommand<Object> SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.SignUp)));
            }
        }
        public RelayCommand<Object> SignInCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand = new RelayCommand<object>(o => NavigationManager.Instance.Navigate(ViewType.SignIn)));
            }
        }
    }
}
