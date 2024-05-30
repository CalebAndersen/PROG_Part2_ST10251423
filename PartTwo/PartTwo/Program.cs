using PartTwo;
using System.Collections.Generic;
using System;
using System.Linq;

namespace PartTwo
{
    public class Program
    {
        static List<Recipe> recipes;
        static bool scaled = false;
        //Delegate to warn the user if total calories exceeds 300
        public delegate void CalorieWarning(int totalCalories);
        public static CalorieWarning calorieWarning = TotalCalories;

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("**************************\nWelcome to Recipe App!\n**************************\n" +
                "Select options on the menu with the corresponding numbers on your keyboard\n" +
                "You can add as many recipes as you want and display them in a list or solely\n" +
                "**************************");
            Console.ForegroundColor = ConsoleColor.White;
            calorieWarning = TotalCalories;
            recipes = new List<Recipe>();
            bool exit = false;

            while (!exit)
            {
                try
                {
                Console.WriteLine("Input your option:\n1: Add a new recipe\n"
                + "2: Display all recipes\n"
                + "3: Choose recipe to display\n"
                + "4: Scale recipe\n"
                + "5: Clear all data\n"
                + "6: Exit program");
                int input = int.Parse(Console.ReadLine()); //Retrieve input from user

                    switch (input)
                    {
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            recPrompt();
                            break; //Ends execution, prevents other cases being run
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Green;
                            displayAll(); //Method is called to output the full recipe
                            break;
                        case 3:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            chooseRecDisplay();
                            break;
                        case 4:
                            Console.ForegroundColor = ConsoleColor.Red;
                            scaleRec();
                            break;
                        case 5:
                            Console.Clear(); //Console is cleared
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Thank you for using recipe app");
                            //mainMenu() is not called as the program has ended
                            break;
                        case 6:
                            Console.Clear();
                            Console.WriteLine("**************************\nThank you for using Recipe App!\n**************************\n");
                            Console.ReadLine();
                            break;
                        default: //Executes when input is invalid
                            Console.Clear();
                            Console.WriteLine("Enter a valid option 1 - 5");
                            Console.WriteLine(); //used to add a blank line
                            break;
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Please enter a valid option");
                }
            }
        }

        //Method used by the delegate for displaying a warning if calories exceed 300
        public static void TotalCalories(int totalCalories)
        {
            if (totalCalories > 300)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning: The total calories exceed 300" +
                    "\nCalorie Ranges Per Serving:" +
                    "\n•Low: Under 50 calories" +
                    "\n•Moderate: 50 - 150 calories" +
                    "\n•High: 150 - 300 calories" +
                    "\n•Very High: Over 300\n");
            }
            else
            {
                Console.WriteLine("Calorie Ranges Per Serving:" +
                    "\n•Low: Under 50 calories" +
                    "\n•Moderate: 50 - 150 calories" +
                    "\n•High: 150 - 300 calories" +
                    "\n•Very High: Over 300\n");
            }
        }

        //Method to calculate the total number of calories
        public static int CalculateTotalCalories(Recipe rec)
        {
            int totalCalories = 0;

            foreach (var ingredient in rec.Ingredients)
            {
                if (ingredient.scaling)
                {
                    totalCalories = rec.Ingredients.Sum(ingred => ingred.scaledCalories);
                }
                else
                {
                    totalCalories = rec.Ingredients.Sum(ingred => ingred.Calories);
                }
            }

            Console.WriteLine($"Total Calories: {totalCalories}");

            if (totalCalories <= 300)
            {
                Console.WriteLine("Total calories are under 300, this a low-calorie recipe");
            }
            return totalCalories;
        }

        //Method for collecting details about a recipe
        public static void recPrompt()
        {
            Recipe rec = new Recipe();
            Console.Clear();
            Console.WriteLine("What is the recipe's name?");
            rec.Name = Console.ReadLine();
            Console.WriteLine("How many ingredients are in the recipe?");
            int ingredNum = 0;
            //Check input is valid before continuing
            bool temp = false;
            while (temp == false)
            {
                try
                {
                    ingredNum = int.Parse(Console.ReadLine());
                    if (ingredNum <= 0)
                    {
                        Console.WriteLine("Enter a valid value");
                    }
                    else
                    {
                        temp = true;
                    }
                }
                //Throws when something other than an integer is entered
                catch (Exception)
                {

                    Console.WriteLine("Enter a valid option");
                }
            }

            //Saving the data
            for (int i = 0; i < ingredNum; i++)
            {
                Console.WriteLine("Enter the name of the ingredient {0} ", i + 1);
                string name = Console.ReadLine();
                Console.WriteLine("Enter the quantity of the ingredient {0} ", i + 1);
                double ingredQuant = 0;

                temp = false;
                while (temp == false)
                {
                    //Exception handling to ensure its a valid option
                    try
                    {
                        ingredQuant = Double.Parse(Console.ReadLine());
                        temp = true;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Enter a valid option: ");
                    }
                }

                Console.WriteLine("Select the unit of measurement:\n1: Cup\n"
                    + "2: g\n"
                    + "3: mg\n"
                    + "4: L\n"
                    + "5: ml\n"
                    + "6: Tablespoon\n"
                    + "7: Teaspoon");
                int input = int.Parse(Console.ReadLine());
                string unit = "";

                temp = false; //Boolean to end the while loop
                while (temp == false)
                {
                    try
                    {
                        //Assigns unit according to what the user chose
                        switch (input)
                        {
                            case 1:
                                unit = "cup";
                                temp = true;
                                break;
                            case 2:
                                unit = "g";
                                temp = true;
                                break;
                            case 3:
                                unit = "mg";
                                temp = true;
                                break;
                            case 4:
                                unit = "L";
                                temp = true;
                                break;
                            case 5:
                                unit = "ml";
                                temp = true;
                                break;
                            case 6:
                                unit = "tablespoon";
                                temp = true;
                                break;
                            case 7:
                                unit = "teaspoon";
                                temp = true;
                                break;
                            default: //Executes when input is invalid and keeps the loop running until a valid input is entered
                                Console.WriteLine("Enter a valid option");
                                input = int.Parse(Console.ReadLine());
                                break;
                        }
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Enter a valid option");
                        input = int.Parse(Console.ReadLine());
                    }
                }



                //Adds an "s" to the unit to make it plural if the quantity is more than one
                if (ingredQuant > 1 && (unit == "teaspoon" || unit == "tablespoon" || unit == "cup"))
                {
                    unit = unit + "s";
                }

                Console.WriteLine("Calorie Ranges Per Serving:\n•Low: Under 50 calories" +
                    "\n•Moderate: 50 - 150 calories" +
                    "\n•High: 150-300" +
                    "\n•Very High: Over 300");
                Console.WriteLine($"Enter the amount of calories of the ingredient {i + 1}");
                int calories = 0;
                temp = false;
                while (temp == false)
                {
                    try
                    {
                        calories = int.Parse(Console.ReadLine());
                        if (calories <= 0)
                        {
                            Console.WriteLine("Enter a valid number of calories");
                        }
                        else
                        {
                            temp = true;
                        }
                    }
                    //Throws when something other than an integer is entered
                    catch (Exception)
                    {

                        Console.WriteLine("Enter a valid option");
                    }
                }

                //Recording the food group the ingredient belongs to
                Console.WriteLine($"Select the food group ingredient {i + 1} belongs to:\n"
                    + "1: Vegetables\n"
                    + "2: Fruit\n"
                    + "3: Grains\n"
                    + "4: Dairy\n"
                    + "5: Protein\n"
                    + "6: Sweets and Snacks\n"
                    + "7: Oils\n"
                    + "8: Other");

                int option = int.Parse(Console.ReadLine());
                string foodGroup = "";

                temp = false; //Boolean to end the while loop
                while (temp == false)
                {
                    try
                    {
                        //Assigns unit according to what the user chose
                        switch (option)
                        {
                            case 1:
                                foodGroup = "Vegetables (nutrient-rich foods)";
                                temp = true;
                                break;
                            case 2:
                                foodGroup = "Fruit (colorful and sweet foods)";
                                temp = true;
                                break;
                            case 3:
                                foodGroup = "Grains (staple foods)";
                                temp = true;
                                break;
                            case 4:
                                foodGroup = "Dairy (dairy and milk products)";
                                temp = true;
                                break;
                            case 5:
                                foodGroup = "Protein (meat, fish, etc)";
                                temp = true;
                                break;
                            case 6:
                                foodGroup = "Sweets and Snacks (High sugar foods)";
                                temp = true;
                                break;
                            case 7:
                                foodGroup = "Oils (Fats)";
                                temp = true;
                                break;
                            case 8:
                                foodGroup = "Other (Miscellaneous foods)";
                                temp = true;
                                break;
                            default: //Executes when input is invalid and keeps the loop running until a valid input is entered
                                Console.WriteLine("Enter a valid option");
                                option = int.Parse(Console.ReadLine());
                                break;
                        }
                    }
                    catch (Exception)
                    {

                        Console.WriteLine("Enter a valid option");
                        option = int.Parse(Console.ReadLine());
                    }
                }

                rec.Ingredients.Add(new Ingredient
                {
                    ingredName = name,
                    ingredQuant = ingredQuant,
                    ingredUnit = unit,
                    scaledQuant = ingredQuant,
                    scaledUnit = unit,
                    Calories = calories,
                    FoodGroup = foodGroup
                });
            }

            //Recording the steps for the recipe
            Console.WriteLine("How many steps are in the recipe?");
            temp = false;
            int stepsNum = 0;
            while (temp == false)
            {
                try
                {
                    stepsNum = int.Parse(Console.ReadLine());
                    if (stepsNum <= 0) //There must be at least one step, not 0 or below
                    {
                        Console.WriteLine("Enter a valid value");
                    }
                    else
                    {
                        temp = true;
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Enter a valid option");
                }
            }

            //Save the steps
            for (int i = 0; i < stepsNum; i++)
            {
                Console.WriteLine($"Enter the description of step number { i + 1}");
                string stepDesc = Console.ReadLine();
                temp = false;

                rec.Steps.Add(new Step
                {
                    Description = stepDesc
                });
            }
            recipes.Add(rec);
            Console.Clear();
            Console.WriteLine("Recipe successfully added");
            int totalCalories = CalculateTotalCalories(rec);
            calorieWarning(totalCalories);
        }

        //Displays all recipes by name in alphabetical order
        public static void displayAll()
        {
            Console.WriteLine("List of Recipes:\n");
            List<string> recNames = recipes.Select(r => r.Name).OrderBy(name => name).ToList(); //Displays only the name of the recipe
            
            recNames.Sort(); //Sorts in alphabetical order
            foreach (var name in recNames)
            {
                Console.WriteLine(name);
            }
        }

        //Method to allow the user for input for what recipe they want to display
        public static void chooseRecDisplay()
        {
            Console.WriteLine("Choose a recipe to display:");
            displayAll(); //calls the displayAll() method
            Console.WriteLine("Enter the recipe's name:");
            string recName = Console.ReadLine();

            Recipe rec = recipes.FirstOrDefault(r => r.Name == recName);

            if (rec != null)
            {
                display(rec);
            }
            else
            {
                Console.WriteLine("Rec not found");
            }
        }
        //Method to display a recipe
        public static void display(Recipe rec)
        {
            Console.Clear();

            double scale = 0;

            foreach (var ingredient in rec.Ingredients)
            {
                if (ingredient.scaling == true)
                {
                    scale = ingredient.scaledQuant / ingredient.ingredQuant;
                }
                else
                {
                    scale = 0;
                }
            }
            if(scale == 0)
            {
                Console.WriteLine($"Recipe name: {rec.Name}");
            }
            else
            {
                Console.WriteLine($"Recipe name: {rec.Name} - scaled by {scale}");
            }

            Console.WriteLine("Ingredients:");
            foreach (var ingredient in rec.Ingredients)
            {
                if (ingredient.scaling)
                {
                    Console.WriteLine($"{ingredient.scaledQuant} {ingredient.scaledUnit} of {ingredient.ingredName}");
                    Console.WriteLine($"Calories: {ingredient.scaledCalories}");
                }
                else
                {
                    Console.WriteLine($"{ingredient.ingredQuant} {ingredient.ingredUnit} of {ingredient.ingredName}");
                    Console.WriteLine($"Calories: {ingredient.Calories}");
                }
                Console.WriteLine($"Food group: {ingredient.FoodGroup}");
            }

            Console.WriteLine("Steps:");
            foreach (var step in rec.Steps)
            {
                Console.WriteLine(step.Description);
            }

            int totalCalories = CalculateTotalCalories(rec);

            if (totalCalories > 300)
            {
                calorieWarning(totalCalories);
            }
        }
        //Method that allows the user to choose and scale a recipe
        public static void scaleRec()
        {
            Console.WriteLine("Choose a recipe to scale:");
            displayAll();
            Console.WriteLine("Enter the recipe's name:");
            string recName = Console.ReadLine();
            Recipe rec = recipes.FirstOrDefault(r => r.Name == recName);

            Console.WriteLine("What would you like to scale the recipe by?"
                + "\n1: Half (0.5)"
                + "\n2: Double (2)"
                + "\n3: Triple (3)"
                + "\n4: Reset to original quantities");
            double scaleFactor = int.Parse(Console.ReadLine());

            switch(scaleFactor)
            {
                case 1:
                    scaleFactor = 0.5;
                    break;
                case 2:
                    scaleFactor = 2;
                    break;
                case 3:
                    scaleFactor = 3;
                    break;
                case 4:
                    scaleFactor = 0;
                    break;
                default:
                    Console.WriteLine("Please enter a valid option:");
                    scaleFactor = int.Parse(Console.ReadLine());
                    break;
            }

            foreach (var ingredient in rec.Ingredients)
            {
                try
                {
                    //Changes values back to default ingredient values
                    if(scaleFactor == 0)
                    {
                        ingredient.scaling = false;
                        ingredient.scaledQuant = ingredient.ingredQuant;
                        ingredient.scaledCalories = ingredient.Calories;
                        ingredient.scaledUnit = ingredient.ingredUnit;
                    }
                    else
                    {
                        ingredient.scaling = true;
                    }

                    ingredient.scaledQuant = (int)(ingredient.ingredQuant * scaleFactor);
                    ingredient.scaledCalories = (int)(ingredient.Calories * scaleFactor);

                    //Scaling the unit if needed
                    switch (ingredient.ingredUnit)
                    {
                        case "mg":
                            if (ingredient.scaledQuant >= 1000) //1000mg is equal to 1g
                            {
                                ingredient.scaledQuant = ingredient.scaledQuant / 1000; //Converts to grams by dividing by 1000
                                ingredient.scaledUnit = "g";
                            }
                            else //If unit is not large enough to be converted, it will remain the same
                            {
                                ingredient.scaledUnit = "mg";
                            }
                            break;
                        case "ml":
                            if (ingredient.scaledQuant >= 1000)
                            {
                                ingredient.scaledQuant = ingredient.scaledQuant / 1000;
                                ingredient.scaledUnit = "L";
                            }
                            else
                            {
                                ingredient.scaledUnit = "ml";
                            }
                            break;
                        case "teaspoon":
                        case "teaspoons": //Similar case labels have the same if else statement
                            if (ingredient.scaledQuant >= 3) //There are 3 teaspoons in a tablespoon
                            {
                                ingredient.scaledQuant = ingredient.scaledQuant / 3;
                                ingredient.scaledUnit = "tablespoon";
                            }
                            else
                            {
                                ingredient.scaledUnit = "teaspoon";
                            }
                            break;
                        case "tablespoon":
                        case "tablespoons":
                            if (ingredient.scaledQuant >= 16) //There are 16 tablespoons in 1 cup
                            {
                                ingredient.scaledQuant = ingredient.scaledQuant / 16;
                                ingredient.scaledUnit = "cup";
                            }
                            else
                            {
                                ingredient.scaledUnit = "tablespoon";
                            }
                            break;
                        default:
                            ingredient.scaledUnit = ingredient.ingredUnit;
                            break;
                    }

                    if (ingredient.scaledQuant > 1 && (ingredient.ingredUnit == "teaspoon" || ingredient.ingredUnit == "tablespoon" || ingredient.ingredUnit == "cup"))
                    {
                        ingredient.scaledUnit = ingredient.scaledUnit + "s";
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Enter a valid option");
                }
            }
        }
    }
}