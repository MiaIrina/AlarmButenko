using Client.Tools.Managers;
using Client.Tools.Navigation;
using Client.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,IContentOwner
    {

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            Initialize();
        }

        private void Initialize()
        {

            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.Main);
        }

        
    }
}
