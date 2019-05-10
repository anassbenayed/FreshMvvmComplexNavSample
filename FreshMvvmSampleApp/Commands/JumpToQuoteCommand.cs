using System;
using Xamarin.Forms;

namespace FreshMvvmComplexNav
{
    public class JumpToQuoteCommand : Command
    {
        public JumpToQuoteCommand() 
            : base(() => {
                MessagingCenter.Send<MasterNavigationMessage> (new MasterNavigationMessage {
                    NavigationType = MasterNaviationType.Quote,
                    NavigationData = 1
                }, MasterNavigationMessage.Message);
            }
            )
        {            
        }
    }
}

