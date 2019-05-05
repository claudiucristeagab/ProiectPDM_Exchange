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
	public partial class MenuPage : ContentPage
	{
		public MenuPage ()
		{
			InitializeComponent ();
		}

        private void Menu_ExchangeRate_Button_Clicked(object sender, EventArgs e)
        {
            var mainPage = new MainPage();
            Navigation.PushAsync(mainPage);
        }

        private void Menu_Favorites_Button_Clicked(object sender, EventArgs e)
        {
            var favoritesPage = new FavoritesPage();
            Navigation.PushAsync(favoritesPage);
        }

        private void Menu_About_Button_Clicked(object sender, EventArgs e)
        {
            var aboutPage = new AboutPage();
            Navigation.PushAsync(aboutPage);
        }
    }
}