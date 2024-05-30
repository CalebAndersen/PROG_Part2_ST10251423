using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartTwo
{
    public class Ingredient
    {
        //Declaring variables with getters and setters in order to be accessed and changed from other classes
        public string ingredName { get; set; }
        public double ingredQuant { get; set; }
        public string ingredUnit { get; set; }
        public string ingredSteps { get; set; }
        public double scaledQuant { get; set; }
        public string scaledUnit { get; set; }
        public int Calories { get; set; }
        public int scaledCalories { get; set; }
        public string FoodGroup { get; set; }
        public bool scaling { get; set; }
    }
}
