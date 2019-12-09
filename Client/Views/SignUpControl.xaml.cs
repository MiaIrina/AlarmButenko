using Client.Tools.Navigation;
using Client.ViewModels;
using System.Windows.Controls;


namespace Client.Views
{
    /// <summary>
    /// Логика взаимодействия для SignUpControl.xaml
    /// </summary>
    public partial class SignUpControl : UserControl,INavigatable
    {
        public SignUpControl()
        {
            InitializeComponent();
            DataContext = new SignUpViewModel();
        }
    }
}
