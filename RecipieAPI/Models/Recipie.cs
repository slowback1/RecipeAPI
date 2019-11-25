using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipieAPI.Models
{
    public class Recipie
    {
        public int RecipieID;
        public string RecipieName;
        public string RecipieDescription;
        public int TimesCooked;
        public string RecipieIngredients;
        public string RecipieDirections;
        public Recipie(
            int id = -1,
            string name = "",
            string description = "",
            int timesCooked = -1,
            string ingredients = "",
            string directions = "")
        {
                if(id != 0)
            {
                RecipieID = id;
            }
            RecipieName = name;
            RecipieDescription = description;
            TimesCooked = timesCooked;
            RecipieIngredients = ingredients;
            RecipieDirections = directions;
        }
    }
}
