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

        public void recipeOptions(Recipe recipe)
        {//recipeOptions Method begin 
            int selection = 0;
            // set selection value to 0
            string recipeName = recipe.Name;
            //List<Ingredient> ingredients = new List<Ingredient>(recipe.Ingredients);

            //flag variable that will add validation to continue to prompt the user for the menu option until user selects exit by entering the integer 4
            bool exit = false;
            while (!exit)
            {//while begin
                Console.ForegroundColor = ConsoleColor.Green;
                // change font colour to green
                Console.WriteLine("Please select one of the following options:");
                Console.WriteLine("1.Display recipe\n2.Scale Recipe\n3.Reset Recipe\n4.Clear\n5.Add a recipe\n6.Display all recipes\n7.Back to main menu\n");
                Console.ResetColor();
                Console.Write("\nEnter your choice:");
                selection = int.Parse(Console.ReadLine());
                // get selection number form user

                if (selection < 0 || selection > 7)
                { throw new ArgumentOutOfRangeException("Selection is out of bounds"); }

                Console.ForegroundColor = ConsoleColor.White;
                // change font colour to white

                // create switch case statment to call different methods based on user input selection
                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("============================================");
                        Console.WriteLine("          Display Recipe          ");
                        Console.WriteLine("============================================");
                        Console.ResetColor();

                        recipe.DisplayRecipe();
                        break;
                    case 2:
                        Console.Clear();
                        //call the method to scale the ingredients of the recipes
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("============================================");
                        Console.WriteLine("          Scaling Recipe          ");
                        Console.WriteLine("============================================");
                        Console.ResetColor();

                        recipe.ScaleRecipe();
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        Console.Clear();
                        //call the method to reset the values of the reciepe to the original values
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("============================================");
                        Console.WriteLine("          Resetting Recipe          ");
                        Console.WriteLine("============================================");
                        Console.ResetColor();

                        recipe.ResetRecipe();
                        recipe.DisplayRecipe();
                        break;
                    case 4:
                        Console.Clear();
                        //call the method to clear the reciepe entered and reprompt user to enter antoehr recipe
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("============================================");
                        Console.WriteLine("          Clearing Recipe          ");
                        Console.WriteLine("============================================");
                        Console.ResetColor();

                        DeleteRecipe(recipes, recipe);

                        //recipe.ClearRecipe();
                        exit = true;  //Exit loop after deleting
                        mainOptions();
                        break;
                    case 5:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("============================================");
                        Console.WriteLine("          Adding Recipe          ");
                        Console.WriteLine("============================================");
                        Console.ResetColor();

                        addRecipe();
                        break;

                    case 6:
                        Console.Clear();
                        // call addRecipe method to add a new recipe
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("============================================");
                        Console.WriteLine("          Recipe List          ");
                        Console.WriteLine("============================================");
                        Console.ResetColor();
                        displayAllRecipies();
                        break;
                    case 7:
                        Console.Clear();
                        //exit the program
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("========================================================");
                        Console.WriteLine("Returning back to main menu");
                        Console.WriteLine("=======================================================");
                        Console.ResetColor();
                        mainOptions();
                        exit = true;
                        break;
                    default:
                        //Valition if user entered an invalid number not between the range of 1 - 4
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ResetColor();

                        break;
                }// end switch case
            }//while end
        }//recipeOptions end

        public void mainOptions()
        {
            int selection = 3;

            do
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Please select one of the following options:\n1.Add Recipe\n2.Display All recipes\n3.Exit\n");
                Console.ResetColor();
                Console.Write("\nEnter your choice:");
                selection = int.Parse(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        addRecipe();// allow the user to enter new recipes
                        break;
                    case 2:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Gray;
                        displayAllRecipies();// allow the user to choose from a list of current recipes
                        break;
                }
            }// end do
            while (selection != 3);// exits the application


            if (selection == 3)
            {
                Console.Clear();
                Console.WriteLine("========================================================");
                Console.WriteLine("Exiting App!! Thank You for using Recipe Management App");
                Console.WriteLine("=======================================================");
                Console.ResetColor();
                System.Environment.Exit(0);
            }
        }// end main options method

        public void displayAllRecipies()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("There are no recipes to display.");
                return;
            }

            Recipe temp;

            // two for loops and if statments used to bubble sort the list of recipes
            // allows for recipes to be displayed to the user in alphabetical order
            for (int i = 0; i < recipes.Count(); i++)
            {
                for (int j = 0; j < recipes.Count(); j++)
                {
                    if (string.Compare(recipes[i].Name, recipes[j].Name) < 0)
                    {
                        temp = recipes[i];
                        recipes[i] = recipes[j];
                        recipes[j] = temp;
                    }// end if 
                }// end for j loop
            }// end for i loop

            Console.WriteLine("Please select one of the following recipes\nEnter the recipe number:");

            for (int k = 0; k < recipes.Count(); k++)
            {
                Console.WriteLine($"{k + 1}. {recipes[k].Name}");
            }// end k loop

            Console.WriteLine("0. Return to Main Menu\n");

            Console.Write("\nEnter your choice:");
            int selection = int.Parse(Console.ReadLine());
            if (selection != 0)
            {
                Recipe recipe = recipes[selection - 1];
                recipeOptions(recipe);
            }//end if 
            else if (selection == 0)
            {
                Console.Clear();
                mainOptions();
            }

        }// end display all method

        //Clear recipe method to remove the recipe from the list
        public void DeleteRecipe(List<Recipe> recipes, Recipe recipeToDelete)
        {
            if (recipes.Contains(recipeToDelete))
            {
                recipes.Remove(recipeToDelete);
                Console.WriteLine($"Recipe '{recipeToDelete.Name}' has been deleted.\n");
            }
            else
            {
                Console.WriteLine($"Recipe '{recipeToDelete.Name}' not found.\n");
            }
        }


        // --------------USER INPUT VALIDATING METHODS----------------------------

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