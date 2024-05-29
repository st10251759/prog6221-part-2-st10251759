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
Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/ErrorHandling_App
Date of Access: 27 March 2024  
=============Code Attribution====================
*/
namespace ST10251759_PROG6221_POE_Part_2
{//namespace begin

    internal class Program
    {//program begin
        static void Main(string[] args)
        {//main begin

            //Inital display to welcome the user to the application
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("============================================");
            Console.WriteLine("     Welcome to the Recipe Management App    ");
            Console.WriteLine("============================================");
            Console.ResetColor();

            //instationation of the object reciepe - so that it may be called in the main class
            Recipe recipe = new Recipe();
            //call the method in reciepe class that prompts the user to enter the reciepes name and details
            recipe.EnterRecipeDetails();
            //call the method to display the details of the reciepe entered
            recipe.DisplayRecipe();

            //flag variable that will add validation to continue to prompt the user for the menu option until user selects exit by entering the integer 4
            bool exit = false;
            while (!exit)
            {//while begin
                //display options for user to select
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Scale Recipe");
                Console.WriteLine("2. Reset Recipe");
                Console.WriteLine("3. Clear");
                Console.WriteLine("4. Exit");
                Console.WriteLine("--------------------------------------------\n");

                //variable to capture users choice after the prompt - call method that will validate wether input is in correct format (integer was entered)
                int choice = GetIntegerInput("Enter your choice: ");
                //switch case to cycle through the options and call relevent methods based on user choice
                switch (choice)
                {//switch begin
                    case 1:
                        //call the method to scale the ingredients of the recipes
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("============================================");
                        Console.WriteLine("          Scaling Recipe          ");
                        Console.WriteLine("============================================");
                        Console.ResetColor();

                        recipe.ScaleRecipe();
                        recipe.DisplayRecipe();
                        break;
                    case 2:
                        //call the method to reset the values of the reciepe to the original values
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("============================================");
                        Console.WriteLine("          Resetting Recipe          ");
                        Console.WriteLine("============================================");
                        Console.ResetColor();

                        recipe.ResetRecipe();
                        recipe.DisplayRecipe();
                        break;
                    case 3:
                        //call the method to clear the reciepe entered and reprompt user to enter antoehr recipe
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("============================================");
                        Console.WriteLine("          Clearing Recipe          ");
                        Console.WriteLine("============================================");
                        Console.ResetColor();

                        recipe.ClearRecipe();
                        recipe.DisplayRecipe();
                        break;
                    case 4:
                        //exit the program
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("========================================================");
                        Console.WriteLine("Exiting App!! Thank You for using Recipe Management App");
                        Console.WriteLine("=======================================================");
                        Console.ResetColor();
                        exit = true;
                        break;
                    default:
                        //Valition if user entered an invalid number not between the range of 1 - 4
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid option. Please try again.");
                        Console.ResetColor();

                        break;
                }//switch end
            }//while end
        }//main end

        //Integer method to recieve a value that is entered by user and goes through validation to make sure the value entered is an integer and inform user if invalid input is entered
        private static int GetIntegerInput(string prompt)
        {//GetIntegerInput begin
            //run while loop to continue propmt user for a valid number if they persist to enter incorrect format
            while (true)
            {//while begin
                try
                {//try begin
                    Console.Write(prompt);
                    return int.Parse(Console.ReadLine());
                }//try end 
                catch (FormatException)
                {//catch begin
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter an integer.");
                    Console.ResetColor();
                }//catch end
            }//while end
        }//GetIntegerInput end
    }//program end
}//namespace end
