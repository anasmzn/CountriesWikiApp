using System;
using System.Linq;
using System.Threading.Tasks;
using CountriesWiki.DataAccess;
using CountriesWiki.Localization;
using CountriesWiki.Model;
using CountriesWiki.Services;

namespace CountriesWiki.ViewModel
{
    public class CountryDetailsViewModel : BasePageViewModel
    {
        private Country country;
        private string countryDetails;
        private readonly ICountriesDataAccess _dataAccess;

        public Country Country { get => country; set => SetProperty(ref country, value); }

        public string CountryDetails { get => countryDetails; set => SetProperty(ref countryDetails, value); }

        public CountryDetailsViewModel(ILogService logService, INavigationService navigationService, ICountriesDataAccess dataAccess) : base(logService, navigationService)
        {
            _dataAccess = dataAccess;
        }

        public override async Task NavigatedToAsync<T>(T parameters)
        {
            try
            {
                if (parameters is string alpha3code)
                {
                    IsBusy = true;
                    Country = await _dataAccess.GetCountry(alpha3code);
                    if (Country != null)
                    {
                        string language = string.Empty;
                        Country.Languages.ForEach(x => language += x.Name + "| ");
                        CountryDetails = string.Format(AppResources.strCountryDetails, Country.Name, Country.Capital, Country.Region, Country.Population, language.Trim());
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
    }
}
