using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Student Number: ST10251759
 Full Name: Cameron Chetty
 Course: PROG6221
 Assessment: POE Part 1
 Github Link: https://github.com/VCDN-2024/prog6221-part-1-st10251759
 */

/*
=============Code Attribution====================
Author: Geeks for Geeks
Website: https://www.geeksforgeeks.org/console-class-in-c-sharp/
Date of Access: 06 April 2024

Author: Fatima Shaik 
Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/Class_Objects_App
Date of Access: 23 March 2024      

Author: Fatima Shaik 
Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/Array_Demo_App
Date of Access: 23 March 2024  

Author: Fatima Shaik 
Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/ErrorHandling_App
Date of Access: 27 March 2024  

Author: Fatima Shaik 
Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/EnumDemo_App
Date of Access: 09 April 2024 
=============Code Attribution====================
*/
namespace ST10251759_PROG6221_POE_Part_2
{//namespace begin
    public class Recipe
    {//Reciepe Class Begin
        //Attribute - variable declaration
        public string Name { get; set; }
        //public Ingredient[] Ingredients { get; set; }
        public double[] OriginalQuantities { get; set; }

        public double[] OriginalCalories { get; set; }
        public UnitOfMeasurement[] OriginalUnits { get; set; }
        //public Step[] Steps { get; set; }

        //New variables for part 2
        private string message; // used for unit testing

        private List<Ingredient> ingredients = new List<Ingredient>();
        // use of generic collections
        // list create to store ingredient objects

        private List<string> steps = new List<string>();
        // use of generic collections
        // string list created to store each step in recipe

        private double totalCalories;
        // private double variable created to store the total number of calories in a recipe

        private int numIngredients;

        private int numSteps;

        // CONSTRUCTOR METHOD
        public Recipe(string name, int numIngredients, int numSteps)
        {
            Name = name;
            this.numIngredients = numIngredients;
            this.numSteps = numSteps;
        }// end constructor

        //Method to prompt user to enter details for reciepe 
        public void EnterRecipeDetails()
        {//EnterRecipeDetails begin

            //Display Headings in Green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("============================================");
            Console.WriteLine("Enter Recipe Details:");
            Console.WriteLine("============================================");
            Console.ResetColor();

            //Prompt user to enter the name of the recipe by calling the get string input method
            Name = GetNonEmptyStringInput("Name: ");

            Console.WriteLine("");

            //Prompt user to enter the number of ingredients in your recipe
            //numIngredients will be used a loop controller
            Console.Write("Number of ingredients: ");
            int numIngredients = GetIntegerInput();

            Console.WriteLine("");

            //create and store ingreients in an array using the numIngredients as the size of the array
            Ingredients = new Ingredient[numIngredients];

            //Create an array to hold the current ingredients and unit of measurement
            OriginalQuantities = new double[numIngredients];
            OriginalUnits = new UnitOfMeasurement[numIngredients];

            //run for loop to store all ingredients details. Will continue prompting user unit all ingeredients are entered 
            for (int i = 0; i < numIngredients; i++)
            {//for loop begin
                //instantiate the creation of the object for every ingredient
                Ingredients[i] = new Ingredient();

                // Prompt user for each Ingredients name and store in a variable by calling the get string input method
                Ingredients[i].Name = GetNonEmptyStringInput($"Ingredient {i + 1} name: ");

                Console.WriteLine("");

                // Prompt user for the quantity of the ingredient and store in variable
                Console.Write($"Quantity of {Ingredients[i].Name}: ");
                Ingredients[i].Quantity = GetDoubleInput();
                OriginalQuantities[i] = Ingredients[i].Quantity; //store a copy of the quantity in another array used for reseting

                Console.WriteLine("");

                //Prompt user for the unit of measurement for each ingredient
                //Call GetUnitOfMeasurement method to do error checking and range checking
                Ingredients[i].Unit = GetUnitOfMeasurement($"Unit of measurement for {Ingredients[i].Name}: ");
                OriginalUnits[i] = Ingredients[i].Unit; //store a copy of unit of measurement to use for reseting

                Console.WriteLine("");
            }//for loop end

            //Prompt user for the number of steps to use a loop controller
            Console.Write("Number of steps: ");
            //Call GetIntegerInput method to do error checking and validation - to ensure user enters a number
            int numSteps = GetIntegerInput();

            //Instanitate step class of the size based on userinput for number of steps
            Steps = new Step[numSteps];

            //run a for loop to enter the steps decriptions
            for (int i = 0; i < numSteps; i++)
            {//for loop begin
                //create new instance for Step class each time loop exercutes
                Steps[i] = new Step();

                //Prompt user for each steps description and sore in variable in step class by calling the get string input method
                Steps[i].Description = GetNonEmptyStringInput($"Step {i + 1} description: ");
            }//for loop end
        } // EnterRecipeDetails end

        //Method to display the reciep in a neat format
        public void DisplayRecipe()
        {//DisplayRecipe begin
            //Display the Recipe Name in Yellow
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"============================================");
            Console.WriteLine($"{Name.ToUpper()}");
            Console.WriteLine($"============================================");
            Console.ResetColor();

            //Display Ingredient heading in green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Ingredients");
            Console.ResetColor();

            //for each loop to access each element in the ingredient class
            foreach (Ingredient ingredient in Ingredients)
            {//for each begin
                //display the ingredient details
                Console.WriteLine($"- {ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }//for each end

            //Display the Step heading in blue
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Steps");
            Console.ResetColor();

            //for each loop to get the user input for steps
            for (int i = 0; i < Steps.Length; i++)
            {//for loop begin
             // DisplayRecipe all the steps
                Console.WriteLine($"Step {i + 1}: {Steps[i].Description}");
            }//for loop end
            Console.WriteLine("\n-----------------------------------------------------------");
        }//DisplayRecipe end

        //Method to scale the reciepe ingreidents to make large quantiies 
        public void ScaleRecipe()
        {//ScaleRecipe begin

            //Display Scaling Heading in Yellow
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nScaling Options");
            Console.ResetColor();

            //Display options to keep user inbounds
            Console.WriteLine("0.5 - Decrease recipe size by half");
            Console.WriteLine("2   - Double recipe size");
            Console.WriteLine("3   - Triple recipe size");

            //Prompt user for the scaling factor
            Console.Write("Enter scaling factor (0.5, 2, or 3): ");
            //Call method to validate the user input
            double factor = GetDoubleScalingFactor();

            //foreach to alter each value of the array ingredients
            foreach (Ingredient ingredient in Ingredients)
            {//for each begin
                //the scaled value equals the ingredients quantity multiplied by the factor
                double scaledQuantity = ingredient.Quantity * factor;

                //The switch statement is used to select one of many code blocks to be executed based on the value of a given expression.
                switch (ingredient.Unit)
                {//switch begin
                    //run through enum options
                    case UnitOfMeasurement.SMALL: ingredient.Quantity *= factor; break;
                    case UnitOfMeasurement.MEDIUM: ingredient.Quantity *= factor; break;
                    case UnitOfMeasurement.LARGE: ingredient.Quantity *= factor; break;
                    case UnitOfMeasurement.EXTRALARGE: ingredient.Quantity *= factor; break;
                    case UnitOfMeasurement.CUP:
                    case UnitOfMeasurement.CUPS:
                        ConvertCups(ingredient, scaledQuantity); //call method to covert cups back into tablespoons
                        break;
                    case UnitOfMeasurement.TABLESPOON:
                    case UnitOfMeasurement.TABLESPOONS:
                        ConvertTablespoons(ingredient, scaledQuantity); //call method that either converts the unit to cups or teaspoons
                        break;
                    case UnitOfMeasurement.TEASPOON:
                    case UnitOfMeasurement.TEASPOONS:
                        ConvertTeaspoons(ingredient, scaledQuantity); //call method toconvert the unit into tablespoons
                        break;
                    default:
                        //Don't need to add validation here because i have catered in another method to ensure user selects correct unit or measurement
                        break;
                }//switch end
            }//for each end

            //Display successful message in green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nRecipe scaled by a factor of {factor} successfully!\n");
            Console.ResetColor();
        }//ScaleRecipe end

        //Method to get unit of measurement from enum
        private UnitOfMeasurement GetUnitOfMeasurement(string prompt)
        {//GetUnitOfMeasurement begin
            //while loop to continuelly prompting user
            while (true)
            {//while loop begin
                Console.Write(prompt);
                string input = Console.ReadLine().ToUpper();

                //check if the user input is a valid option in enum
                if (Enum.TryParse<UnitOfMeasurement>(input, out UnitOfMeasurement unit))
                {//if valid begin
                    return unit;
                }//if valid end
                else //if not valid option
                {//else begin
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid unit of measurement. Valid options are:");
                    Console.ResetColor();
                    //Display the Options
                    foreach (UnitOfMeasurement option in Enum.GetValues(typeof(UnitOfMeasurement)))
                    {
                        Console.WriteLine(option.ToString());
                    }
                }//else end
            }//while loop end
        }//GetUnitOfMeasurement end

        //method to convert to cup as unit of measurement
        public void ConvertCups(Ingredient ingredient, double newQuantity)
        {//ConvertCups begin
         //convert to tablespoon quantity

            //if quantity is less than one, unit must be converted into tablespoons
            if (newQuantity < 1)
            {
                //1 cup = 16 tablespoons
                double tablespoons = newQuantity * 16;
                ingredient.Quantity = tablespoons;
                ingredient.Unit = UnitOfMeasurement.TABLESPOONS;
            }
            else if (newQuantity == 1) //if quantity is one unit is cup
            {
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitOfMeasurement.CUP;
            }
            else //if unit is more han 1 uni is cups
            {
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitOfMeasurement.CUPS;
            }
        }//ConvertCups end

        //method to convert to tablesoons as unit of measurement
        public void ConvertTablespoons(Ingredient ingredient, double newQuantity)
        {//ConvertTablespoons begin
            //16 tablespoons equals 1 cup
            //3 teaspoons equals 1 tablespoon
            if (newQuantity >= 16)
            {//if greater than or equal to 16 begin
                //if quantity is 16 unit is 1 cup
                if (newQuantity == 16)
                {//if equal to 16 begin
                    ingredient.Quantity = 1;
                    ingredient.Unit = UnitOfMeasurement.CUP;
                }//if equal to 16 end
                else
                {//else if quantity is greater than 16 convert to an amount of cups begin
                    //take the newQuantity and divide by 16 to get the number of cups
                    double cups = newQuantity / 16;
                    ingredient.Quantity = cups;
                    ingredient.Unit = UnitOfMeasurement.CUPS;
                }//else if quantity is greater than 16 convert to an amount of cups end
            }//if greater than or equal to 16 end
            else if (newQuantity < 1)
            {//else if quanity is less than one convert to teaspoons begin
                //1 tablespoon is equal to 3 teaspoons
                double teaspoons = newQuantity * 3;
                ingredient.Quantity = teaspoons;
                ingredient.Unit = UnitOfMeasurement.TEASPOONS;
            }//else if quanity is less than one convert to teaspoons end
            else
            {//else if quantity is not less than 1 or greater than or equal to 16 begin
                if (newQuantity == 1)
                {//if quantity is equal to 1 the unit is 1 tablespoon end
                    ingredient.Quantity = 1;
                    ingredient.Unit = UnitOfMeasurement.TABLESPOON;
                }//if quantity is equal to 1 the unit is 1 tablespoon end
                else
                {//else if the unit is between 1 and 16 unit will remain tablespoons begin
                    ingredient.Quantity = newQuantity;
                    ingredient.Unit = UnitOfMeasurement.TABLESPOONS;
                }
            }//else if quantity is not less than 1 or greater than or equal to 16 end
        }//ConvertTablespoons end

        //Method to convert the number of teaspoons into tablespoons
        public void ConvertTeaspoons(Ingredient ingredient, double newQuantity)
        {//ConvertTeaspoons begin
            if (newQuantity >= 3)
            {//if the quantity is greater than or equal to 3 the unit must be converted to tablespoons (begin)
                //3 teaspoons equals 1 tablespoons
                if (newQuantity == 3)
                {//if quantity equals 3 the unit is 1 tablespoon begin
                    ingredient.Quantity = 1;
                    ingredient.Unit = UnitOfMeasurement.TABLESPOON;
                }//if quantity equals 3 the unit is 1 tablespoon end
                else
                {//else if the quanity is greater than 3 the unit must be divided into 3 and converted into tablespoons begin
                    double tablespoons = newQuantity / 3;

                    ingredient.Quantity = tablespoons;
                    ingredient.Unit = UnitOfMeasurement.TABLESPOONS;

                }//else if the quanity is greater than 3 the unit must be divided into 3 and converted into tablespoons end
            }//if the quantity is greater than or equal to 3 the unit must be converted to tablespoons (end)
            else if (newQuantity <= 1)
            { //else if the quanity is less than or equal to 1 the unit must reamain teaspoon begin
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitOfMeasurement.TEASPOON;
            } //else if the quanity is less than or equal to 1 the unit must reamain teaspoon end
            else
            { //else if the quanity is more than 1 and less than 3 the unit must be teaspoons begin
                ingredient.Quantity = newQuantity;
                ingredient.Unit = UnitOfMeasurement.TEASPOONS;
            }//else if the quanity is more than 1 and less than 3 the unit must be teaspoons end
        }//ConvertTeaspoons end

        //Method to reset the reciepes ingredient quanties to orginal values
        public void ResetRecipe()
        {//ResetRecipe begin

            //run for loop to access all elements of array
            for (int i = 0; i < Ingredients.Length; i++)
            {//for loop begin
                Ingredients[i].Quantity = OriginalQuantities[i];
                Ingredients[i].Unit = OriginalUnits[i];
            }//for loop end

            //Display succesful message in green
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nRecipe has been reset to its orgin state successfully!\n");
            Console.ResetColor();
        }//ResetRecipe end

        //method to clear recipe details and reprompt user to enter a new recipe
        public void ClearRecipe()
        {//ClearRecipe begin

            //Prompt user to confirm if they want to delete reply either yes or no
            Console.WriteLine("Are you sure you want to clear the recipe? (yes/no)");
            string response = Console.ReadLine().ToLower();

            //if statement to either to either clear the recipe data and add new recipe or to cancel operation 
            if (response == "yes")
            {//if the user selects yes to clear recipe begin
                Console.WriteLine("Clearing the recipe...");
                //Clear the contents of the array
                Ingredients = null;
                Steps = null;
                //Display success message in green
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nRecipe has been cleared successfully!\n");
                Console.ResetColor();

                //Call method to reprompt user to enter a new recipe details
                EnterRecipeDetails();

            }//if the user selects yes to clear recipe end
            else
            {//else if the user cancels the operation by selection no or anything that is not yes begin
                Console.WriteLine("Clear operation canceled.");
            }//else if the user cancels the operation by selection no or anything that is not yes begin
        }//ClearRecipe end

        //method to validate the intger entered as user input
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
        }//GetNonEmptyStringInput end

    }//Reciepe Class Begin
}//namespace end