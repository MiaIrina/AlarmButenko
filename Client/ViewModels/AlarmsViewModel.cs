using Client.Tools;
using Client.Tools.Managers;
using Client.Tools.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
  internal class AlarmsViewModel:BaseViewModel
    {
        #region Fields

        private RelayCommand<object> _exitCommand;
        private RelayCommand<object> _backCommand;
        #endregion
        public RelayCommand<Object> ExitCommand
        {
            get
            {
                return _exitCommand ?? (_exitCommand = new RelayCommand<object>(o => Environment.Exit(0)));
            }
        }
        public RelayCommand<Object> BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand<object>(o=>LogOut()));
            }
        }
        private void LogOut()
        {
            NavigationManager.Instance.Navigate(ViewType.Main);
                StationManager.Current = null;
        }
    }
}
