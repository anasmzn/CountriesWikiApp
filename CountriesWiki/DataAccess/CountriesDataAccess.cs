using System;
using System.Threading.Tasks;
using CountriesWiki.Model;
using CountriesWiki.Services;

namespace CountriesWiki.DataAccess
{
    public class CountriesDataAccess : ICountriesDataAccess
    {
        private readonly IApiService _apiService;

        public CountriesDataAccess(IApiService apiService)
        {
            _apiService = apiService;
        }

        public Task<Country[]> GetAllCountries()
        {
            var url = Config.BaseUrl + Config.GetAllCountries;
            return _apiService.Get<Country[]>(url);
        }

        public Task<Country> GetCountry(string alpha3code)
        {
            var url = Config.BaseUrl + string.Format(Config.GetCountryByAlpha3Code, alpha3code);
            return _apiService.Get<Country>(url);
        }
    }
}
