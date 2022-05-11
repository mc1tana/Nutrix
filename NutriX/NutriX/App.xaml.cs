using NutriX.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutriX
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new AcceuilPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
