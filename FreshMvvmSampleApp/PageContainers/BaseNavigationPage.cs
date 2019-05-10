using System;
using Xamarin.Forms;

namespace FreshMvvmComplexNav
{
    public class BaseNavigationPage : NavigationPage
    {
        public BaseNavigationPage (Page page) : base (page)
        {
            BarTextColor = Color.White;
            BarBackgroundColor = Color.FromHex ("#17375E");
            Icon = "MenuFilled.png";
        }
    }
}

