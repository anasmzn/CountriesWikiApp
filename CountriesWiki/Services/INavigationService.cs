using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CountriesWiki.Services
{
    public interface INavigationService
    {
        Task PushAsync<T, K>(T page, K data = default) where T : Page;

        Task PopAsync();
    }
}
