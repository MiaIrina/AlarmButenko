﻿using Client.Tools.Navigation;
using Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.Views
{
    /// <summary>
    /// Логика взаимодействия для AddAlarmControl.xaml
    /// </summary>
    public partial class AddAlarmControl : UserControl,INavigatable
    {
        public AddAlarmControl()
        {
            InitializeComponent();
            DataContext = new AddAlarmViewModel();
        }
    }
}
