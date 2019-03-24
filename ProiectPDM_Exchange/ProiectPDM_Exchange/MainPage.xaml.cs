using Newtonsoft.Json;
using ProiectPDM_Exchange.Constants;
using ProiectPDM_Exchange.Entities;
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

        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            var currencyName = string.Empty;

            if (currentCurrency == null)
            {
                currencyName = ApiStrings.DefaultCurrency;
            }
            else
            {
                currencyName = currentCurrency.Name;
            }

            HttpClient httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(ApiStrings.Latest + currencyName);
            var exchangeRate = JsonConvert.DeserializeObject<ExchangeRate>(json);

            BindingContext = exchangeRate;
            ExchangeRate_ListView.ItemsSource = exchangeRate.Rates;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var favoritesPage = new FavoritesPage();
            Navigation.PushAsync(favoritesPage);
        }
    }
}
