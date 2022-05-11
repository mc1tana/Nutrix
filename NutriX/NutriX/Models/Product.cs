using System;
using System.Collections.Generic;
using System.Text;

namespace NutriX.Models
{
    public class Product
    {
        public string Countries { get; set; }
        public string Ecoscore_score { get; set; }
        public string Ecoscore_grade { get; set; }
        public string Ingredients_text_fr { get; set; }
        public Nutrient_levels Nutrient_levels { get; set; }

        

    }
}
