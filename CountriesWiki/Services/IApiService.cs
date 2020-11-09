using System;
using System.Threading.Tasks;

namespace CountriesWiki.Services
{
    public interface IApiService
    {
        Task<TResult> Get<TResult>(string url, bool throwException = false);

        Task<TResult> Post<TRequest, TResult>(string url, TRequest request);

        Task<TResult> Put<TRequest, TResult>(string url, TRequest request);

        Task<TResult> Delete<TRequest, TResult>(string url, TRequest request);
    }
}
