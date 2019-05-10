using Xamarin.Forms;
using FreshMvvm;
using System.Diagnostics.Contracts;

namespace FreshMvvmComplexNav
{
    public class MainMenuPageModel : FreshBasePageModel
    {
        public MainMenuPageModel ()
        {
            ShowQuotes = new ShowQuoteListCommand();

            ShowContacts = new ShowContactsCommand();

            JumpToQuote = new JumpToQuoteCommand();

            ShowContactUs = new ShowContactUsCommand();

            Logout = new LogoutCommand();
        }

        public Command ShowQuotes { get; set; }

        public Command ShowContacts { get; set; }

        public Command JumpToQuote { get; set; }

        public Command ShowContactUs { get; set; }

        public Command Logout { get; set; }       
    }
}

