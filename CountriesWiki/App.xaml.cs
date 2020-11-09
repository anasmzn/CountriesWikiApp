using System;
using CountriesWiki.DataAccess;
using CountriesWiki.Services;
using CountriesWiki.Util;
using CountriesWiki.View;
using CountriesWiki.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CountriesWiki
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            IocUtil.BuildIocContainer();
            var countriesPage = IocUtil.Resolve<CountriesListPage>();
            var detailPage = new NavigationPage(IocUtil.Resolve<CountryDetailPage>());
            if (Device.Idiom == TargetIdiom.Tablet || Device.Idiom == TargetIdiom.Desktop)
            {
                MainPage = new MasterDetailPage()
                {
                    Master = countriesPage,
                    Detail = detailPage,
                };
            }
            else
            {
                MainPage = new NavigationPage(countriesPage);
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
