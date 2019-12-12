using Client.Tools;
using Client.Tools.Managers;
using Client.Tools.Navigation;
using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
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
        private RelayCommand<object> _deleteCommand;
        private RelayCommand<object> _addAlarmCommand;
        private Alarm _selectedAlarm;
        private bool _isAlarmSelected;

        private static Thread _workingThread;
        private static CancellationToken _token;
        private static CancellationTokenSource _tokenSource;
        #endregion

        public static void StartWorkingThread()
        {
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            _workingThread = new Thread(StartWorkingThreadProcess);
            _workingThread.Start();
            StationManager.CloseThreads += StopWorkingThread;
        }
        private  static void StartWorkingThreadProcess()
        {
            while (!_token.IsCancellationRequested)
            {
                if (_token.IsCancellationRequested)
                    break;
                List<Alarm> alarms = AlarmClient.Sample.GetAlarms(StationManager.Current).ToList();
                foreach (var alarm in alarms)
                {
                    if (alarm.BeginTime.ToShortTimeString() == DateTime.Now.ToShortTimeString()&&alarm.BeginTime!=alarm.EndTime)
                    {
                        if (Application.Current.Dispatcher != null)
                        {
                            Application.Current.Dispatcher.Invoke(new Action(() =>
                            {
                                _tokenSource.Cancel();
                                _workingThread.Abort();
                                AlarmClient.Sample.EndAlarm(alarm, alarm.BeginTime);
                                NavigationManager.Instance.Navigate(ViewType.AlarmMessage);
                                MessageViewModel.StartWorkingThread();                   
                            }));
                        }
                    }
                    if (_token.IsCancellationRequested)
                        break;
                }

                AlarmClient.Sample.UpdateAlarms();
            }
        }

        internal static void StopWorkingThread()
        {
            _tokenSource.Cancel();
        }

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
        public RelayCommand<Object> DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new RelayCommand<object>(DeleteAlarm));
            }
        }

        private void DeleteAlarm(object obj)
        {
            AlarmClient.Sample.DeleteAlarm(SelectedAlarm);
            Alarms.Remove(SelectedAlarm);

        }

        public Alarm SelectedAlarm
        {
            get
            {
                return _selectedAlarm;
            }
            set
            {
                _selectedAlarm = value;
                if (_selectedAlarm != null)
                    IsAlarmSelected = true;
                else
                {
                    IsAlarmSelected = false;
                }
                OnPropertyChanged();
            }
        }
        public bool IsAlarmSelected
        {
            get
            {
                return _isAlarmSelected;
            }
            private set
            {
                _isAlarmSelected = value;
                OnPropertyChanged();
            }
        }
        private async void AddNewAlarm(object obj)
        {
                LoaderManager.Instance.ShowLoader();
            bool result =await Task.Run(() =>
            {
                
                try
                {
                    findthePossibleAlarm();
                    
                   
                    
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
                NavigationManager.Instance.Navigate(ViewType.CreateAlarm);
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
            AlarmClient.Sample.UpdateAlarms();
            StartWorkingThread();
           Alarms = new ObservableCollection<Alarm>(AlarmClient.Sample.GetAlarms(StationManager.Current));
          
            
        }
    }
}
