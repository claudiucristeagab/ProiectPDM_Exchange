using ProiectPDM_Exchange.Database;
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

		public FavoritesPage()
		{
			InitializeComponent();
            currencyDataAccess = new CurrencyDataAccess();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var list = currencyDataAccess.GetAllCurrencies();

            Currencies_ListView.ItemsSource = list;
        }
    }
}