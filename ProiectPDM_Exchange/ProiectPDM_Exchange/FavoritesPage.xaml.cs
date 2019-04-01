using ProiectPDM_Exchange.Constants;
using ProiectPDM_Exchange.Database;
using ProiectPDM_Exchange.Entities;
using ProiectPDM_Exchange.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProiectPDM_Exchange
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavoritesPage : ContentPage
	{
        private CurrencyDataAccess currencyDataAccess;
        private ExchangeRateService exchangeRateService;

		public FavoritesPage()
		{
			InitializeComponent();
            currencyDataAccess = new CurrencyDataAccess();
            exchangeRateService = new ExchangeRateService();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await LoadFavoriteCurrencies();

            await LoadTotalCurrencies();
        }

        private async Task LoadFavoriteCurrencies()
        {
            var savedCurrencies = currencyDataAccess.GetAllCurrencies();
            Currencies_ListView.ItemsSource = savedCurrencies;
        }

        private async Task LoadTotalCurrencies()
        {
            var exchangeRate = await exchangeRateService.GetTodayRates(ApiStrings.DefaultCurrency);
            List<string> totalCurrencyList = (from rate in exchangeRate.Rates select rate.Name).ToList();
            totalCurrencyList.Add(exchangeRate.Base);

            Favorites_SelectFavorite_Picker.ItemsSource = totalCurrencyList;
        }

        private async void Favorites_AddFavorite_Button_Clicked(object sender, EventArgs e)
        {
            if (Favorites_SelectFavorite_Picker.SelectedItem != null)
            {
                var currency = new Currency();
                currency.Name = Favorites_SelectFavorite_Picker.SelectedItem.ToString();
                currencyDataAccess.InsertCurrency(currency);

                await LoadFavoriteCurrencies();
            }
            
        }

        private async void Favorites_DeleteAllFavorites_Button_Clicked(object sender, EventArgs e)
        {
            currencyDataAccess.DeleteAllCurrencies();
            await LoadFavoriteCurrencies();
        }

        private async void Currencies_ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = (ListView)sender;
            var selectedCurrency = (Currency)listView.SelectedItem;

            MessagingCenter.Send<string, Currency>("MainPage", "FavoriteCurrencySelected", selectedCurrency);
            await Navigation.PopAsync();
        }
    }
}