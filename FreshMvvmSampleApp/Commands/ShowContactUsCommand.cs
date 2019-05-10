using System;
using Xamarin.Forms;

namespace FreshMvvmComplexNav
{
    public class ShowContactUsCommand : Command
    {
        public ShowContactUsCommand() 
            : base(() => {
                MessagingCenter.Send<MasterNavigationMessage> (new MasterNavigationMessage {
                    NavigationType = MasterNaviationType.ContactUs
                }, MasterNavigationMessage.Message);
            }
            )
        {            
        }
    }
}

