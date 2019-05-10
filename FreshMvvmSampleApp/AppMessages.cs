using System;
namespace FreshMvvmComplexNav
{
    public enum MasterNaviationType { QuoteList, ContactList, Quote, Logout, ContactUs }

    public class MasterNavigationMessage
    {
        public MasterNaviationType NavigationType { get; set; }
        public object NavigationData { get; set; }
        public const string Message = "MasterNavigationMessage";
    }

    public class ToggleSlideMenuNavigation
    {
        public const string Message = "OpenSlideMenuNavigation";
    }
}



