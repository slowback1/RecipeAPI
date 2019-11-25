using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RecipieAPI.Models
{
    public class UpRecipie
    {
        public string RecipieName { get; set; } = "";
        public string RecipieDescription { get; set; } = "";
        public int TimesCooked { get; set; } = 0;
        public string RecipieIngredients { get; set; } = "";
        public string RecipieDirections { get; set; } = "";

    }
}