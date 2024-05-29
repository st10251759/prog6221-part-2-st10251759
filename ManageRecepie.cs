using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10251759_PROG6221_POE_Part_2
{//namespace begin
    public class ManageRecepie
    {//ManageRecipe Class begin

        List<Recipe> recipes = new List<Recipe>();
        // use of generic collections
        // a list created to store the recipes that are entered by a user

        //this method will create instance of a recipe object and add the recipes to the recipe list
        public void addRecipe()
        {//addRecipe begin 

            //Display Headings in Green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("============================================");
            Console.WriteLine("Enter Recipe Details:");
            Console.WriteLine("============================================");
            Console.ResetColor();

            // GET NAME FROM USER
            string recipeName = GetNonEmptyStringInput("Please enter the name of the recipe you wish to add:");

            // GET NUM INGREDIENTS FREOM USER
            int numIngredients; //variable to hold number of ingredients
            //do while loop to continue prompting user if they enter invalid integer ( zero or less)
            do
            {//do begin
                Console.Write("\nPlease enter the number of ingredients in your recipe:");
                numIngredients = GetIntegerInput();
                if (numIngredients <= 0)
                {//if begin
                    Console.WriteLine("\nPlease enter a valid number (greater than zero).");
                }//if end
            }//do end
            while (numIngredients <= 0); //while condition

            // GET NUM STEPS FREOM USER
            int numSteps; //variable to hold number of steps
            //do while loop to continue prompting user if they enter invalid integer ( zero or less)
            do
            {//do begin
                Console.Write("\nPlease enter the number of steps in your recipe:");
                numSteps = GetIntegerInput();
                if (numSteps <= 0)
                {//if begin
                    Console.WriteLine("\nPlease enter a valid number (greater than zero).");
                }//if end
            }//do end
            while (numSteps <= 0); //while condition

            // CREATE RECIPE OBJECT
            Recipe recipe = new Recipe(recipeName, numIngredients, numSteps);
            recipe.setIngredients(); // get the ingredients in the recipe from the user
            recipe.setSteps();// get the steps for the recipe from the user
            recipe.calculateTotalCalories();// calculate the total number of calories in the recipe

            recipes.Add(recipe); // add the new recipe object to the list of recipe object

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            recipe.DisplayRecipe(); // display the recipe to the user

        }//addRecipe end
 
        private int GetIntegerInput()
        {//GetIntegerInput begin
         //while loop to continue prompting user until value is correct
            while (true)
            {//while begin
             //try catch for validation
                try
                {//try begin
                    return int.Parse(Console.ReadLine());
                }//try end
                catch (FormatException)
                {//catch begin
                 //error message and reprompt user
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter an integer.");
                    Console.ResetColor();
                }//catch end
            }//while end
        }//GetIntegerInput

        //method to validate the factor for scaling entered by user
        private double GetDoubleScalingFactor()
        {//GetDoubleScalingFactor() begin 
         //run while loop to continue loop
            while (true)
            {//while begin
             //try catch for validation
                try
                {//try begin
                    double factor = double.Parse(Console.ReadLine());
                    //if statement to check if user input is within the options
                    if (factor == 0.5 || factor == 2 || factor == 3)
                    {//if equal to one of the 3 options / if is in range begin
                        return factor;
                    }//if equal to one of the 3 options / if is in range end
                    else
                    {//else statement if the factor is not within the 3 options begin
                     //error message and reprompt user
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid scaling factor. Please enter 0.5, 2, or 3.");
                        Console.ResetColor();
                    }//else statement if the factor is not within the 3 options end
                }//try end
                catch (FormatException)
                {//catch begin
                 //error message and reprompt user
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ResetColor();
                }//catch end
            }//while end
        }//GetDoubleScalingFactor() end

        //method to validate double user input
        private double GetDoubleInput()
        {//GetDoubleInput begin
            while (true)
            {//while loop begin
             //try-catch for validation
                try
                {//try begin
                    return double.Parse(Console.ReadLine());
                }//try end
                catch (FormatException)
                {//catch begin
                 //Display error message and reprompt user
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number.");
                    Console.ResetColor();
                }//catch end
            }//while loop end
        }//GetDoubleInput end

        //method to validate string input is not null
        public string GetNonEmptyStringInput(string prompt)
        {//GetNonEmptyStringInput begin
         //create a null variable to enter loop
            string input = "";
            //run while loop to continue prompting user until input is not null
            while (string.IsNullOrEmpty(input))
            {//while begin
             //prompt user for input
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim();

                //if statement to check if the input is still null
                if (string.IsNullOrEmpty(input))
                {//if begin
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input cannot be empty. Please try again.");
                    Console.ResetColor();
                }//if end
            }//while end
            return input;
        }//GetNonEmptyStringInput begin

    }//ManageRecipe Class end

}//namespace end