using System;
namespace CountriesWiki.Services
{
    public interface ILogService
    {
        void WriteError(Exception ex);
        void Write(string log);
    }
}
