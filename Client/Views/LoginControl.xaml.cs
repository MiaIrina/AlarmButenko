using Client.Tools.Navigation;
using Client.ViewModels;
using System;

using System.Windows.Controls;


namespace Client.Views
{
    /// <summary>
    /// Логика взаимодействия для LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl,INavigatable
    {
        public LoginControl()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
    }
}
