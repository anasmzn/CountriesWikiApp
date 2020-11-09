using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CountriesWiki.DataAccess;
using CountriesWiki.Model;
using CountriesWiki.Services;
using CountriesWiki.Util;
using CountriesWiki.View;
using Xamarin.Forms;

namespace CountriesWiki.ViewModel
{
    public class CountiresListViewModel : BasePageViewModel
    {
        private ObservableCollection<Country> countries;
        private Country selectedItem;

        public ObservableCollection<Country> Countries { get => countries; set => SetProperty(ref countries, value); }

        public Country SelectedItem { get => selectedItem; set => SetProperty(ref selectedItem, value); }

        private readonly ICountriesDataAccess _dataAccess;

        public CountiresListViewModel(ILogService logService, INavigationService navigationService, ICountriesDataAccess dataAccess) : base(logService, navigationService)
        {
            _dataAccess = dataAccess;
            this.PropertyChanged += async (s, e) => await CountiresListViewModel_PropertyChangedAsync(e);
        }

        public override async Task NavigatedToAsync<T>(T parameters = default)
        {
            try
            {
                IsBusy = true;
                var response = await _dataAccess.GetAllCountries();
                if (response != null && response.Any())
                {
                    Countries = new ObservableCollection<Country>(response);
                    if (Device.Idiom != TargetIdiom.Phone)
                    {
                        await NavigationService.PushAsync(IocUtil.Resolve<CountryDetailPage>(), Countries[0].Alpha3Code);
                    }
                }
            }
            catch (Exception ex)
            {
                LogService.WriteError(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task CountiresListViewModel_PropertyChangedAsync(System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(SelectedItem)))
            {
                if (SelectedItem == null)
                    return;
                await OnCountrySelectedAsync();
                SelectedItem = null;
            }
        }

        private async Task OnCountrySelectedAsync()
        {
            var detailPage = IocUtil.Resolve<CountryDetailPage>();
            await NavigationService.PushAsync(detailPage, SelectedItem.Alpha3Code);
        }
    }
}
