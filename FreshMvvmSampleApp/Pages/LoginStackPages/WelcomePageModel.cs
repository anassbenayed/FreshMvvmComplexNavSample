using System;
using FreshMvvm;
using Xamarin.Forms;

namespace FreshMvvmComplexNav
{
    public class WelcomePageModel : FreshBasePageModel
    {
        public WelcomePageModel ()
        {
        }

        public Command ContinueCommand 
        {
            get {
                return new Command (() => {
                    CoreMethods.PushPageModel<LoginPageModel> ();
                });
            }
        }
    }
}

