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

Author: Fatima Shaik 
Website: https://github.com/fb-shaik/PROG6221-Group1-2024/tree/main/EnumDemo_App
Date of Access: 09 April 2024 

=============Code Attribution====================
*/
namespace ST10251759_PROG6221_POE_Part_2
{//namespace begin
    public class Ingredient
    {//Ingredient Class Begin
        //attribute variable declaration - with getter and setter methods 
        public string Name { get; set; }
        public double Quantity { get; set; }
        //public string Unit { get; set; }
        public double OriginalQuantity { get; set; }
        public UnitOfMeasurement OriginalUnit { get; set; }
        public UnitOfMeasurement Unit { get; set; } //enum

        public FoodGroup FoodGroup { get; set; } //enum for food group
        public double calories { get; set; }
        public double originalCalories { get; set; }

        public Ingredient()
        {
        }

        //constructor Method with 4 parameters
        public Ingredient(string name, double quantity, UnitOfMeasurement unit, FoodGroup foodGroup, double calories)
        {//constructor begin
            Name = name;
            Quantity = quantity;
            Unit = unit;
            OriginalQuantity = quantity;
            OriginalUnit = unit; //needs to be stroed in an integer
            FoodGroup = foodGroup;
            this.calories = calories;
            originalCalories = calories;
        }//constructor end


        //method to alter the Quatity to return to its orginal state
        public void ResetQuantity()
        {
            Quantity = OriginalQuantity;
        }
        //method to alter the Unit to return to its orginal state
        public void ResetUnit()
        {
            Unit = OriginalUnit;
        }
    }//Ingredient Class end
}//namespace end