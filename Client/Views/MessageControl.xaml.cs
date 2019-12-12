using Client.Tools.Navigation;
using Client.ViewModels;
using System.Windows.Controls;



namespace Client.Views
{
    /// <summary>
    /// Логика взаимодействия для MessageControl.xaml
    /// </summary>
    public partial class MessageControl : UserControl,INavigatable
    {
        public MessageControl()
        {
            InitializeComponent();
            DataContext = new MessageViewModel();
        }
    }
}
