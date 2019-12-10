using Client.Tools;
using Client.Tools.Managers;
using Client.Tools.Navigation;
using Models;
using System;
using System.Collections.ObjectModel;


namespace Client.ViewModels
{
  internal class AlarmsViewModel:BaseViewModel
    {
        #region Fields
        private ObservableCollection <Alarm> _alarms;
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

        public ObservableCollection<Alarm> Alarms {
            get
            {
                return _alarms;
            }
            private set
            {
                _alarms = value;
                OnPropertyChanged();
            }
        }

        private void LogOut()
        {
            NavigationManager.Instance.Navigate(ViewType.Main);
                StationManager.Current = null;
        }
        public AlarmsViewModel()
        {
            Alarms = new ObservableCollection<Alarm>(AlarmClient.Sample.GetAlarms(StationManager.Current));
        }
    }
}
