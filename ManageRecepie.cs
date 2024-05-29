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