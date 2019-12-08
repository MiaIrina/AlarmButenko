using Client.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {



               /*case ViewType.Main:
                    ViewsDictionary.Add(viewType, new MainMenuControl());
                    break;*/
                case ViewType.SignUp:
                    ViewsDictionary.Add(viewType, new SignUpControl());
                    break;
                case ViewType.SignIn:
                    ViewsDictionary.Add(viewType, new LoginControl());
                    break;
                case ViewType.Alarms:
                    ViewsDictionary.Add(viewType, new LoginControl());
                    break;
                case ViewType.CreateAlarm:
                    ViewsDictionary.Add(viewType, new LoginControl());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }

        
    }
}
