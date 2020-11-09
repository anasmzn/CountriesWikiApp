using System;
using System.Collections.Generic;
using CountriesWiki.Extensions;
using CountriesWiki.Localization;
using CountriesWiki.ViewModel;
using Xamarin.Forms;

namespace CountriesWiki.View
{
    public partial class CountriesListPage : ContentPage
    {
        public CountriesListPage(CountiresListViewModel bindingContext)
        {
            InitializeComponent();
            Title = AppResources.strCountries;
            this.BindingContext = bindingContext;
            bindingContext.NavigatedToAsync<object>().FireAndForgetSafeAsync();
        }
    }
}
