using System;
using System.Collections.Generic;
using CountriesWiki.ViewModel;
using Xamarin.Forms;

namespace CountriesWiki.View
{
    public partial class CountryDetailPage : ContentPage
    {
        public CountryDetailPage(CountryDetailsViewModel bindingContext)
        {
            InitializeComponent();
            this.BindingContext = bindingContext;
        }
    }
}
