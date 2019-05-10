using System;
using Xamarin.Forms;

namespace FreshMvvmComplexNav
{
    public class ShowContactsCommand : Command
    {
        public ShowContactsCommand() 
            : base(() => {
                    MessagingCenter.Send<MasterNavigationMessage> (new MasterNavigationMessage {
                        NavigationType = MasterNaviationType.ContactList
                    }, MasterNavigationMessage.Message);
                }
            )
        {            
        }
    }
}

