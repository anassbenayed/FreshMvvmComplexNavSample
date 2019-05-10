using System;
using Xamarin.Forms;

namespace FreshMvvmComplexNav
{
    public class ContactUsPageModel : FreshMvvm.FreshBasePageModel
    {
        public ContactUsPageModel ()
        {
        }

        public Command CloseCommand {
            get {
                return new Command (() => {
                    CoreMethods.PopModalNavigationService();
                });
            }
        }
    }
}
