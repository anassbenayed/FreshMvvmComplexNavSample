using System;
using FreshMvvm;
using Xamarin.Forms;

namespace FreshMvvmComplexNav
{
    public class LoginPageModel : FreshBasePageModel
    {
        public LoginPageModel ()
        {
        }

        public Command LoginCommand {
            get {
                return new Command (() => {
                    CoreMethods.SwitchOutRootNavigation (NavigationStacks.MainAppStack);
                });
            }
        }
    }
}

