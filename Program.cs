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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("============================================");
            Console.WriteLine("     Welcome to the Recipe Management App    ");
            Console.WriteLine("============================================");
            Console.ResetColor();

            //instationation of the object reciepe - so that it may be called in the main class
            ManageRecepie manageRecepie = new ManageRecepie();
            manageRecepie.addRecipe();// user must add a recipe before displaying options to display all recipies or add recipe
            manageRecepie.mainOptions();// displays options to user - to view current recipes or to add a recipe
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