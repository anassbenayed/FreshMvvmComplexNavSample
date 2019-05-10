using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SlideOverKit;

namespace FreshMvvmComplexNav
{
    public partial class SlideDownMenuView : SlideMenuView
    {
        public SlideDownMenuView()
        {
            InitializeComponent();

            // You must set HeightRequest in this case
            this.HeightRequest = 300;
            // You must set IsFullScreen in this case, 
            // otherwise you need to set WidthRequest, 
            // just like the QuickInnerMenu sample
            this.IsFullScreen = true;
            this.MenuOrientations = MenuOrientation.TopToBottom;

            // You must set BackgroundColor, 
            // and you cannot put another layout with background color cover the whole View
            // otherwise, it cannot be dragged on Android
            this.BackgroundColor = Color.White;
            this.BackgroundViewColor = Color.Transparent;
        
            mainGrid.BindingContext = this;

            ShowQuotes = CloseMenuFirst(new ShowQuoteListCommand());

            ShowContacts = CloseMenuFirst(new ShowContactsCommand());

            JumpToQuote = CloseMenuFirst(new JumpToQuoteCommand());

            ShowContactUs = CloseMenuFirst(new ShowContactUsCommand());

            Logout = CloseMenuFirst(new LogoutCommand());

        }

        Command CloseMenuFirst(Command cmd)
        {
            return new Command(() =>
                {
                    MessagingCenter.Send<ToggleSlideMenuNavigation>(new ToggleSlideMenuNavigation
                        {                        
                        }, ToggleSlideMenuNavigation.Message);
                    cmd.Execute(null);
                });
        }

        public Command ShowQuotes { get; set; }

        public Command ShowContacts { get; set; }

        public Command JumpToQuote { get; set; }

        public Command ShowContactUs { get; set; }

        public Command Logout { get; set; }       
    }
}

