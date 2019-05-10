using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FreshMvvmComplexNav
{
    public class BaseSlideOverPage : SlideOverKit.MenuContainerPage
    {
        public BaseSlideOverPage()
        {
            
        }
    }

    public partial class ContactListPage : BasePage
	{
		public ContactListPage ()
		{
			InitializeComponent ();


		}

        public SlideOverKit.SlideMenuView SlideMenu { get; set; }

        public Action ShowMenuAction { get; set; }

        public Action HideMenuAction { get; set; }
	}
}

