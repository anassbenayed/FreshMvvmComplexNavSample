using System;
using Xamarin.Forms;

namespace FreshMvvmComplexNav
{
    public class TabbedContainer : FreshMvvm.FreshTabbedNavigationContainer
    {
        public TabbedContainer(string navigationName) : base(navigationName)
        {
        }

        protected override Xamarin.Forms.Page CreateContainerPage(Xamarin.Forms.Page page)
        {
            if (page is NavigationPage || page is MasterDetailPage || page is TabbedPage) {
                return page;
            }
            return new BaseNavigationPage (page);
        }            
    }
}

