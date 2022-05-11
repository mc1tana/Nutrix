using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutriX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcceuilPage : ContentPage
    {
        public AcceuilPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            string c = CodeProd.Text;
            Console.WriteLine(c);
            Navigation.PushAsync(new ResultPage(c));
        }

        private void Scan(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ScanPage());
        }
    }
}