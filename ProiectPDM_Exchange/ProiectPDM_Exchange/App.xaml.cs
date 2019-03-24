using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ProiectPDM_Exchange
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var mainPage = new MainPage();
            var navigationPage = new NavigationPage(mainPage);
            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
