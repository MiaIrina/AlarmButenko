using Client.Tools.Navigation;
using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;


namespace Client.Views
{
    /// <summary>
    /// Логика взаимодействия для MainMenuControl.xaml
    /// </summary>
    public partial class MainMenuControl : UserControl,INavigatable
    {
        public MainMenuControl()
        {
            DataContext = new MainMenuViewModel();
           InitializeComponent();
        }
    }
}
