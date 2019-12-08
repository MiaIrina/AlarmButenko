using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Tools.Navigation
{
    internal enum ViewType
    {
        SignUp,
        Main,
        SignIn,
        Alarms,
        CreateAlarm
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
       
    }
}
