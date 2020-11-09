using System;
using System.Threading.Tasks;
using CountriesWiki.Model;

namespace CountriesWiki.DataAccess
{
    public interface ICountriesDataAccess
    {
        Task<Country[]> GetAllCountries();

        Task<Country> GetCountry(string alpha3code);
    }
}
