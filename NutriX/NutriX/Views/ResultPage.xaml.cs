
using Newtonsoft.Json;
using NutriX.Models;
using Org.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NutriX.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
       

        public ResultPage(string CodeProd)
        {
            InitializeComponent();
            List<string> levelNut=new List<string>();
            string url = "https://world.openfoodfacts.org/api/v0/product/20954666";

            string ProdRec = "";

            var uri = new UriBuilder(url).Uri;
            var client = new WebClient();
            ServicePointManager.ServerCertificateValidationCallback = new
                RemoteCertificateValidationCallback
                (
                   delegate { return true; }
                );

            using (var webclient = new WebClient())
            {

                try
                {

                    ProdRec = webclient.DownloadString(url);


                }
                catch (Exception ex)
                {
                    //   Device.BeginInvokeOnMainThread(() =>
                    //   {


                    DisplayAlert("Erreur", "une erreur réseau s'est produite " + ex.Message, "OK");



                    //      });

                    return;

                }



            }







            ProductTest prod = JsonConvert.DeserializeObject<ProductTest>(ProdRec);

            
            Code.Text = prod.Code.ToString();
            origine.Text = prod.Product.Countries;
            NScore.Text = prod.Product.Ecoscore_score;
            NGrade.Text = prod.Product.Ecoscore_grade;
            Ingredient.Text = prod.Product.Ingredients_text_fr;
            img.Source = "Nutri" + prod.Product.Ecoscore_grade + ".png";
            LevelFat.Text = prod.Product.Nutrient_levels.Fat;
            LevelColorFat(prod.Product.Nutrient_levels.Fat);
            LevelColorSugars(prod.Product.Nutrient_levels.Sugars);
           LevelColorSalt(prod.Product.Nutrient_levels.Salt);
            Console.WriteLine(prod.Product.Nutrient_levels.Salt);
            
            
            levelNut.Add(prod.Product.Nutrient_levels.Fat);
            levelNut.Add(prod.Product.Nutrient_levels.Sugars);
            levelNut.Add(prod.Product.Nutrient_levels.Salt);

            
        }

        public void LevelColorFat(string chaine)
        {
            if (chaine == "low")
            {
                FatColor.BackgroundColor = Color.Green;
            }
            else if (chaine == "moderate")
            {
                
                FatColor.BackgroundColor = Color.Orange;

            }
            else if (chaine == "high")
            {
                FatColor.BackgroundColor = Color.Red;

            }

        }
        public void LevelColorSugars(string chaine)
        {
            if (chaine == "low")
            {
                SugarsColor.BackgroundColor = Color.Green;
            }
            else if (chaine == "moderate")
            {
                SugarsColor.BackgroundColor = Color.Orange;

            }
            else if (chaine == "high")
            {
                SugarsColor.BackgroundColor = Color.Red;

            }

        }
        public void LevelColorSalt(string chaine)
        {
            if (chaine == "low")
            {
                SaltColor.BackgroundColor = Color.Green;
            }
            else if (chaine == "moderate")
            {
                SaltColor.BackgroundColor = Color.Orange;

            }
            else if (chaine == "high")
            {
                SaltColor.BackgroundColor = Color.Red;

            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}