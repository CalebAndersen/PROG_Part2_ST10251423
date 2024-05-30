using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTwo
{
    public class Recipe
    {
        public string Name { get; set; } //Name of recipe
        public List<Ingredient> Ingredients { get; set; } //Creating Ingredient object to store ingredients for the recipe
        public List<Step> Steps { get; set; } //Creating Steps object to store steps for the recipe
        //Assigning the Steps and Ingredients to the recipe
        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<Step>();
        }
    }
}
