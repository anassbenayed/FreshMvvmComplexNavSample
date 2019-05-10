using System;
using Xamarin.Forms;
using System.ComponentModel;

namespace FreshMvvmComplexNav
{
    public class BasePage : SlideOverKit.MenuContainerPage
    {
        public BasePage ()
        {
            this.ToolbarItems.Add (new ToolbarItem {
                Command = new Command (() => {
                    ShowMenuAction?.Invoke ();
                }),
                Text = "SlideMenu",
                Priority = 0
            });

            this.SlideMenu = new SlideDownMenuView ();

            MessagingCenter.Subscribe<ToggleSlideMenuNavigation> (this, ToggleSlideMenuNavigation.Message, (o) => {
                HideMenuAction?.Invoke ();
            });
        }

        protected override void OnAppearing ()
        {
            base.OnAppearing ();
        }
    }
}

