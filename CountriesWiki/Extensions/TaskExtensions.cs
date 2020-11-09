using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CountriesWiki.Extensions
{
    public static class TaskExtensions
    {
        public static void FireAndForgetSafeAsync(this Task task)
        {
            task.ContinueWith((t) =>
            {
                Debug.WriteLine(t.Exception);
            }, TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}
