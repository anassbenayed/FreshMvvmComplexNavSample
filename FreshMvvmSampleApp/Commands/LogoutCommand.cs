using System;
using Xamarin.Forms;

namespace FreshMvvmComplexNav
{
    public class LogoutCommand : Command
    {
        public LogoutCommand() 
            : base(() => {
                MessagingCenter.Send<MasterNavigationMessage> (new MasterNavigationMessage {
                    NavigationType = MasterNaviationType.Logout
                }, MasterNavigationMessage.Message);
            }
            )
        {            
        }
    }
}

