using System;
namespace CountriesWiki
{
    public static class Config
    {
        private static string _baseUrl;

        public static string BaseUrl
        {
            get
            {
                if (_baseUrl == null)
                {
                    _baseUrl = "https://restcountries.eu/rest/v2/"; //Set base Url from some kind of CPS service instead. I am hardcoding just for demonstration purpose
                }
                return _baseUrl;
            }
            internal set => _baseUrl = value;
        }

        public const string GetAllCountries = "all";

        public const string GetCountryByAlpha3Code = "alpha/{0}";//alpha3Code - {0}
    }
}
