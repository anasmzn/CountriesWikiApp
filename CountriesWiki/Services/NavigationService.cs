using System;
using System.Threading.Tasks;
using CountriesWiki.ViewModel;
using Xamarin.Forms;

namespace CountriesWiki.Services
{
    public class NavigationService : INavigationService
    {
        public async Task PopAsync()
        {
            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                await navigationPage.PopAsync();
            }
            else if (Application.Current.MainPage is MasterDetailPage masterDetailPage && masterDetailPage.Detail is NavigationPage detailNavigationPage)
            {
                if (detailNavigationPage.Navigation.NavigationStack.Count > 1)
                    await detailNavigationPage.Navigation.PopToRootAsync(false);
            }
        }

        public async Task PushAsync<T, K>(T page, K data) where T : Page
        {
            if (Application.Current.MainPage is NavigationPage navigationPage)
            {
                await navigationPage.PushAsync(page, true);
                if (page.BindingContext is BasePageViewModel basePageViewModel)
                {
                    await basePageViewModel.NavigatedToAsync<K>(data);
                }
            }
            else if (Application.Current.MainPage is MasterDetailPage masterDetailPage && masterDetailPage.Detail is NavigationPage detailNavigationPage)
            {
                NavigationPage.SetHasNavigationBar(page, false);
                detailNavigationPage.Navigation.InsertPageBefore(page, detailNavigationPage.Navigation.NavigationStack[0]);
                await detailNavigationPage.Navigation.PopToRootAsync(false);
                if (page.BindingContext is BasePageViewModel basePageViewModel)
                {
                    masterDetailPage.IsPresented = false;
                    await basePageViewModel.NavigatedToAsync<K>(data);
                }
            }
        }
    }
}
