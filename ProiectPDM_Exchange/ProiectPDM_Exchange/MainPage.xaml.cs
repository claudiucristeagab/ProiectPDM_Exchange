using Newtonsoft.Json;
using ProiectPDM_Exchange.Constants;
using ProiectPDM_Exchange.Entities;
using ProiectPDM_Exchange.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProiectPDM_Exchange
{
    public partial class MainPage : ContentPage
    {
        private Currency currentCurrency;

        private readonly ExchangeRateService exchangeRateService;

        public MainPage()
        {
            InitializeComponent();
            currentCurrency = new Currency();
            exchangeRateService = new ExchangeRateService();

            MessagingCenter.Subscribe<string, Currency>("MainPage", "FavoriteCurrencySelected", async (sender, arg) => {
                currentCurrency = arg;
                var datePicker = Main_DatePicker.Date;
                await GetRateForDate(datePicker.Date);
            });
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var datePicker = Main_DatePicker.Date;
            await GetRateForDate(datePicker.Date);
        }

        private async Task GetTodayRates()
        {
            var currencyName = string.Empty;

            if (string.IsNullOrEmpty(currentCurrency.Name))
            {
                currencyName = ApiStrings.DefaultCurrency;
            }
            else
            {
                currencyName = currentCurrency.Name;
            }

            var exchangeRate = await exchangeRateService.GetTodayRates(currencyName);
            BindingContext = exchangeRate;
            ExchangeRate_ListView.ItemsSource = exchangeRate.Rates;
        }

        private async Task GetRateForDate(DateTime dateTime)
        {
            var currencyName = string.Empty;

            if (string.IsNullOrEmpty(currentCurrency.Name))
            {
                currencyName = ApiStrings.DefaultCurrency;
            }
            else
            {
                currencyName = currentCurrency.Name;
            }
            var exchangeRate = await exchangeRateService.GetRatesForDate(currencyName, dateTime);
            BindingContext = exchangeRate;
            ExchangeRate_ListView.ItemsSource = exchangeRate.Rates;
        }

        private void Main_About_Button_Clicked(object sender, EventArgs e)
        {
            var aboutPage = new AboutPage();
            Navigation.PushAsync(aboutPage);
        }

        private async void Main_DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            var datePicker = (DatePicker)sender;
            await GetRateForDate(datePicker.Date);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var favoritesPage = new FavoritesPage();
            Navigation.PushAsync(favoritesPage);
        }
    }
}
