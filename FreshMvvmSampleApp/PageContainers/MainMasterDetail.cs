using System;
using Xamarin.Forms;
using FreshMvvm;
using System.Linq;
using System.Threading.Tasks;

namespace FreshMvvmComplexNav
{
    public class MainMasterDetail : FreshMvvm.FreshMasterDetailNavigationContainer
    {
        enum TabTypes { ContactList, QuoteList };

        ContactListPageModel _contactListPageModel;
        ContactListPage _contactlistPage;
        BaseNavigationPage _contactListPageNav;
        QuoteListPageModel _quoteListPageModel;

        //From this MasterDetail we needed a coremethods instance, so we use the first child page from the tabs
        IPageModelCoreMethods GetCoreMethods ()
        {
            return _contactListPageModel.CoreMethods;
        }

        TabbedContainer _tabContainer;

        public MainMasterDetail () : base (NavigationStacks.MainAppStack)
        {
            this.Title = "Sample";
            MessagingCenter.Subscribe<MasterNavigationMessage> (this, MasterNavigationMessage.Message, HandleMasterNavigation);
        }

        protected override Page CreateContainerPage (Page page)
        {
            if (page is NavigationPage || page is MasterDetailPage || page is TabbedPage) {
                return page;
            }
            return new BaseNavigationPage (page);
        }

        protected override void CreateMenuPage (string menuPageTitle, string menuIcon = null)
        {
            var menuPage = FreshPageModelResolver.ResolvePageModel<MainMenuPageModel> ();
            menuPage.Icon = "MenuFilled.png";
            menuPage.Title = "Menu";
            Master = menuPage;

            _tabContainer = new TabbedContainer ("InnerTabbedContainer");
            _contactListPageNav = _tabContainer.AddTab<ContactListPageModel> ("Contact List", "contacts.png") as BaseNavigationPage;
            _contactlistPage = _contactListPageNav.CurrentPage as ContactListPage;
            _contactListPageModel = _contactlistPage.BindingContext as ContactListPageModel;

            var quoteListPageNav = _tabContainer.AddTab<QuoteListPageModel> ("Quote List", "document.png") as BaseNavigationPage;
            _quoteListPageModel = quoteListPageNav.CurrentPage.BindingContext as QuoteListPageModel;

            Detail = _tabContainer;
        }

        void HandleMasterNavigation (MasterNavigationMessage masterNavigation)
        {
            switch (masterNavigation.NavigationType) {
            case MasterNaviationType.ContactList:
                OpenContactList.Execute (null);
                break;
            case MasterNaviationType.QuoteList:
                OpenQuoteList.Execute (null);
                break;
            case MasterNaviationType.Logout:
                LogoutCommand.Execute (null);
                break;
            case MasterNaviationType.Quote:
                QuoteCommand.Execute (masterNavigation.NavigationData);
                break;
            case MasterNaviationType.ContactUs:
                ContactUsCommand.Execute (null);
                break;
            }
        }

        public Command OpenContactList {
            get {
                return new Command ((obj) => {

                    Device.BeginInvokeOnMainThread (() => {

                        _tabContainer.CurrentPage = _tabContainer.Children [(int)TabTypes.ContactList];
                        Detail = _tabContainer;

                    });

                    IsPresented = false;

                });
            }
        }

        public Command OpenQuoteList {
            get {
                return new Command ((obj) => {

                    Device.BeginInvokeOnMainThread (() => {

                        _tabContainer.CurrentPage = _tabContainer.Children [(int)TabTypes.QuoteList];
                        Detail = _tabContainer;

                    });

                    IsPresented = false;
                });
            }
        }

        public Command QuoteCommand {
            get {
                return new Command ((obj) => {

                    Device.BeginInvokeOnMainThread (() => {

                        _tabContainer.CurrentPage = _tabContainer.Children [(int)TabTypes.QuoteList];
                        _quoteListPageModel.CoreMethods.PopToRoot(false);
                        _quoteListPageModel.CoreMethods.PushPageModel<QuotePageModel>(obj);
                        Detail = _tabContainer;

                    });

                    IsPresented = false;

                });
            }
        }

        public Command ContactUsCommand {
            get {
                return new Command ((obj) => {
                    
                    var contactUsPage = FreshPageModelResolver.ResolvePageModel<ContactUsPageModel> (null);
                    var container = new FreshNavigationContainer (contactUsPage, Guid.NewGuid ().ToString ());

                    Device.BeginInvokeOnMainThread (async () => {
                        await GetCoreMethods().PushNewNavigationServiceModal (container, contactUsPage.GetModel ());
                    });

                    IsPresented = false;

                });
            }
        }

        public Command LogoutCommand {
            get {
                return new Command ((obj) => {
                    IsPresented = false;

                    GetCoreMethods ().SwitchOutRootNavigation (NavigationStacks.LoginNavigationStack);
                });
            }
        }
    }
}

