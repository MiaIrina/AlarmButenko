using Client.Tools;
using Client.Tools.Managers;
using Client.Tools.Navigation;
using Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Client.ViewModels
{
   internal class AddAlarmViewModel:BaseViewModel
    {
        private RelayCommand<object> _exitCommand;
        private RelayCommand<object> _backCommand;
        private RelayCommand<object> _addAlarmCommand;
        private IEnumerable<int> _possibleMinutes;
        private IEnumerable<int> _possibleHours;
        public int _indexH;

        public int _indexM;
        private int _selectedHour;
        private int _selectedMinute;
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
                return _backCommand ?? (_backCommand = new RelayCommand<object>(o => LogOut()));
            }
        }
        public RelayCommand<Object> AddAlarmCommand
        {
            get
            {
                return _addAlarmCommand ?? (_addAlarmCommand = new RelayCommand<object>(AddNewAlarm,(o=>CanExecuteCommand())));
            }
        }

        private void AddNewAlarm(object obj)
        {
            Alarm toAdd = new Alarm(SelectedHour, SelectedMinute)
            {
                UserGuid = StationManager.Current.Guid
            };
            AlarmClient.Sample.AddAlarm(toAdd);
            NavigationManager.Instance.Navigate(ViewType.Alarms);

        }

        private void LogOut()
        {
            NavigationManager.Instance.Navigate(ViewType.Main);
            StationManager.Current = null;
        }
        public IEnumerable<int> PossibleHours
        {

            get
            {
                return _possibleHours;
            }
            private set
            {
                _possibleHours = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<int> PossibleMinutes
        {

            get
            {
                return _possibleMinutes;
            }
            private set
            {
                _possibleMinutes = value;
                OnPropertyChanged();
            }
        }


        private bool CanExecuteCommand() => IndexM!=-1 && IndexH != -1
                ;
        public int IndexH
        {
            get { return _indexH; }

            set
            {
                _indexH = value;
                OnPropertyChanged();
            }
        }
        public int IndexM
        {
            get { return _indexM; }

            set
            {
                _indexM = value;
                OnPropertyChanged();
            }
        }
        public int SelectedHour {

            get => _selectedHour;
            set
            {
                _selectedHour = value;
              PossibleMinutes=  Enumerable.Range(0, 60).ToList().Where(h => Alarms.Find(k => k.Hour == _selectedHour && h == k.Minutes) == null);
                OnPropertyChanged();
            }
            
                
                }
        public List<Alarm> Alarms
        {

            get;private set;
        }

        public int SelectedMinute
        {

            get => _selectedMinute;
            set
            {
              
                _selectedMinute = value;
              
                PossibleHours = Enumerable.Range(0, 24).ToList().Where(h => Alarms.Find(k => k.Hour == h && _selectedMinute == k.Minutes) == null);
             OnPropertyChanged(); }

        }
        public AddAlarmViewModel()
        {
            Alarms = new List<Alarm>(AlarmClient.Sample.GetAlarms(StationManager.Current));
            PossibleHours = Enumerable.Range(0, 24).ToList();
            PossibleMinutes = Enumerable.Range(0, 60).ToList();
            IndexH = -1;
            IndexM = -1;
        }

    }
}
