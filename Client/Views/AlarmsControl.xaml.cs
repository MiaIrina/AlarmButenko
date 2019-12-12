using Client.Tools.Navigation;
using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Controls;


namespace Client.Views
{
    /// <summary>
    /// Логика взаимодействия для AlarmsControl.xaml
    /// </summary>
    public partial class AlarmsControl : UserControl,INavigatable
    {
        public AlarmsControl()
        {
            InitializeComponent();
            DataContext = new AlarmsViewModel();
        }
    }
}
