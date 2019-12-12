using Client.Tools;
using Client.Tools.Managers;
using Client.Tools.Navigation;
using System;
using System.Threading;
using System.Windows;

namespace Client.ViewModels
{
    internal class MessageViewModel : BaseViewModel
    {

        private RelayCommand<object> _backCommand;
        private static Thread _workingThread;
        private static CancellationToken _token;
        private static CancellationTokenSource _tokenSource;
        public static void StartWorkingThread()
        {
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            _workingThread = new Thread(StartWorkingThreadProcess);
            _workingThread.Start();
            StationManager.CloseThreads += StopWorkingThread;
        }
        private void ReturnToAlarms(object obj)
        {

            if (Application.Current.Dispatcher != null)
            {
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    _tokenSource.Cancel();
                    _workingThread.Abort();


                    NavigationManager.Instance.Navigate(ViewType.Alarms);
                    AlarmsViewModel.StartWorkingThread();

                }));
            }
        }
        public RelayCommand<Object> BackCommand
        {
            get
            {
                return _backCommand ?? (_backCommand = new RelayCommand<object>(ReturnToAlarms));
            }
        }
        private static void StartWorkingThreadProcess()
        {
            DateTime stop = DateTime.Now.AddMinutes(2);

            while (!_token.IsCancellationRequested && stop > DateTime.Now)
            {
                Thread.Sleep(1000);
            }
 
                   
                        if (Application.Current.Dispatcher != null)
                        {
                            Application.Current.Dispatcher.Invoke(new Action(() =>
                            {
                                _tokenSource.Cancel();
                                _workingThread.Abort();


                                NavigationManager.Instance.Navigate(ViewType.Alarms);
                                AlarmsViewModel.StartWorkingThread();

                            }));
                        }
                    
                    
 }  internal static void StopWorkingThread()
            {
                _tokenSource.Cancel();

            }} }
