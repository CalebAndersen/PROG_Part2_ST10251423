using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartTwo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace CalorieTest
{
    [TestClass]
    public class TotalCalorieTest
    {
        [TestMethod]
        public void TestCalculateTotalCalories()
        {
            //Creating a Recipe object
            var rec = new Recipe();
            rec.Name = "Milk Tart";
            rec.Ingredients.Add(new Ingredient
            {
                ingredName = "Sugar",
                ingredQuant = 2,
                ingredUnit = "teaspoons",
                Calories = 250,
                FoodGroup = "Sweets and Snacks"
            });
            rec.Ingredients.Add(new Ingredient
            {
                ingredName = "Milk",
                ingredQuant = 1,
                ingredUnit = "cup",
                Calories = 100,
                FoodGroup = "Dairy"
            });
            rec.Steps.Add(new Step
            {
                Description = "This is a step"
            });

            int totalCalories = Program.CalculateTotalCalories(rec);
            Assert.AreEqual(350, totalCalories);
        }
        //Testing to see if the warning is thrown when calories exceed 300
        [TestMethod]
        public void TestTotalCaloriesWarning()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Program.TotalCalories(350);

            // Assert
            var result = stringWriter.ToString().Trim();
            Assert.IsTrue(result.Contains("Warning: The total calories exceed 300"));
        }
        //Testing to see if the warning is not thrown when calories are under 300
        [TestMethod]
        public void TestTotalCaloriesNoWarning()
        {
            int totalCalories = 200;
            bool warning = false;

            Program.calorieWarning += (calories) => warning = true;
            Program.TotalCalories(totalCalories);

            Assert.IsFalse(warning);
        }
    }
}
