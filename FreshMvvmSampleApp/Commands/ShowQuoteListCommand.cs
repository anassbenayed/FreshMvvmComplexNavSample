using System;
using Xamarin.Forms;

namespace FreshMvvmComplexNav
{
    public class ShowQuoteListCommand : Command
    {
        public ShowQuoteListCommand() 
            : base(() => {
                MessagingCenter.Send<MasterNavigationMessage> (new MasterNavigationMessage {
                    NavigationType = MasterNaviationType.QuoteList
                }, MasterNavigationMessage.Message);
            }
            )
        {            
        }
    }
}

