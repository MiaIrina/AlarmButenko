using Client.Tools;
using Client.Tools.Managers;
using Client.Tools.Navigation;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Client.ViewModels
{
  internal class AlarmsViewModel:BaseViewModel
    {
        #region Fields
    
       
        private ObservableCollection <Alarm> _alarms;
        private RelayCommand<object> _exitCommand;
        private RelayCommand<object> _backCommand;
        private RelayCommand<object> _addAlarmCommand;
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
        public RelayCommand<Object> AddAlarmCommand
        {
            get
            {
                return _addAlarmCommand ?? (_addAlarmCommand = new RelayCommand<object>(AddNewAlarm));
            }
        }

        private async void AddNewAlarm(object obj)
        {
                LoaderManager.Instance.ShowLoader();
            bool result =await Task.Run(() =>
            {
                Alarm toAdd;
                try
                {
                    toAdd = findthePossibleAlarm();
                    toAdd.UserGuid = StationManager.Current.Guid;
                    AlarmClient.Sample.AddAlarm(toAdd);
                   
                    
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                Alarms = new ObservableCollection<Alarm>(AlarmClient.Sample.GetAlarms(StationManager.Current));
                MessageBox.Show("New alarm is added");
            }
            return;
            }
        private Alarm findthePossibleAlarm()
        {
            List<Alarm> temp = Alarms.ToList();
           
            int tHour;
            int tMinute;
            for (tHour = 0; tHour < 24; tHour++)
            {
                for (tMinute = 0; tMinute < 60; tMinute++)
                {
                    if(temp.Find(u=>(u.Hour==tHour) && (u.Minutes == tMinute)) == null)
                    {
                        return new Alarm(tHour, tMinute);
                    }
                }
            }
            throw new Exception("No possible alarms to add!");

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
           _alarms = new ObservableCollection<Alarm>(AlarmClient.Sample.GetAlarms(StationManager.Current));
            
        }
    }
}
