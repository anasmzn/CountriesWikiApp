using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CountriesWiki.Services
{
    public class ApiService : IApiService
    {
        private HttpClient _httpClient;
        private ILogService _logService;

        public ApiService(ILogService logService)
        {
            _httpClient = new HttpClient();
            _logService = logService;
        }

        public Task<TResult> Delete<TRequest, TResult>(string url, TRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<TResult> Get<TResult>(string url, bool throwException)
        {
            TResult tobeReturned = default;
            try
            {
                var responseMessage = await _httpClient.GetAsync(url);
                if (responseMessage != null && responseMessage.IsSuccessStatusCode)
                {
                    var content = await responseMessage.Content.ReadAsStringAsync();
                    Debug.WriteLine(content);
                    return JsonConvert.DeserializeObject<TResult>(content);
                }
                responseMessage?.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                _logService.WriteError(ex);
                if (throwException)
                    throw;
            }
            return tobeReturned;
        }

        public Task<TResult> Post<TRequest, TResult>(string url, TRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<TResult> Put<TRequest, TResult>(string url, TRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
