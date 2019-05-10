using System;
using Xamarin.Forms;
using System.Collections.Generic;
using FreshMvvm;

namespace FreshMvvmComplexNav
{
    public class App : Application
    {
        public App ()
        {
            FreshIOC.Container.Register<IDatabaseService, DatabaseService> ();

            var welcomePage = FreshPageModelResolver.ResolvePageModel<WelcomePageModel> ();
            var loginStack = new FreshNavigationContainer (welcomePage, NavigationStacks.LoginNavigationStack);

            var mainMasterDetail = new MainMasterDetail ();
            mainMasterDetail.Init ("Menu");

            MainPage = loginStack;
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}

