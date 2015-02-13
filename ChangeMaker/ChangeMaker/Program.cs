using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMaker
{
    class Program
    {
        static void Main(string[] args)
        {
            // Calling the function with $4.19.  
            // Notice that when using the decimal format you must end numbers with an 'm'
            ChangeAmount(4.19m);
            ChangeAmount(3.18m);
            ChangeAmount(0.99m);
            ChangeAmount(12.93m);
            // Leaves console open
            Console.ReadKey();
        }

        public static Change ChangeAmount(decimal amount) 
        {
            // This is our object that will hold the data of how many coins of each type to return
            Change amountAsChange = new Change();
            // Saving amount to show to console
            decimal amountToShow = amount;
            // Loops for each nominal
            // Checking if there is enough amount to take one more coin of current nominal
            // Yes - taking one more, No - going to next nominal
            while (amount >= .25m)
            {
                // Number of coins increased
                amountAsChange.Quarters++;
                // Amount decreased by amount of coin taken
                amount = amount - .25m;
            }
            while (amount >= .1m)
            {
                amountAsChange.Dimes++;
                amount = amount - .1m;
            }
            while (amount >= .05m)
            {
                amountAsChange.Nickles++;
                amount = amount - .05m;
            }
            while (amount >= 0.01m)
            {
                amountAsChange.Pennies++;
                amount = amount - .01m;
            }
            // Console output
            Console.WriteLine("Amount: " + amountToShow);
            Console.WriteLine("Quarters: " + amountAsChange.Quarters);
            Console.WriteLine("Dimes: " + amountAsChange.Dimes);
            Console.WriteLine("Nickles: " + amountAsChange.Nickles);
            Console.WriteLine("Pennies: " + amountAsChange.Pennies);

            // Return our Change Object
            return amountAsChange;
        }

        /// <summary>
        /// Example using the Change class to store data
        /// </summary>
        public static Change Example(decimal amount)
        {
            // Creating a new object of our class Change
            Change amountAsChange = new Change();

            // Increasing the number of quarters
            amountAsChange.Quarters++;
            amountAsChange.Quarters += 1;
            amountAsChange.Quarters = amountAsChange.Quarters + 1;

            // Outputting to the console
            Console.WriteLine("Quarters: " + amountAsChange.Quarters);

            // Returning the object
            return amountAsChange;
        }

    }

    public class Change
    {
        /// <summary>
        /// This is property to hold the number of Quarters to be returned as change
        /// </summary>
        public int Quarters { get; set; }

        /// <summary>
        /// This is property to hold the number of Dimes to be returned as change
        /// </summary>
        public int Dimes { get; set; }

        /// <summary>
        /// This is property to hold the number of Nickles to be returned as change
        /// </summary>
        public int Nickles { get; set; }

        /// <summary>
        /// This is property to hold the number of Pennies to be returned as change
        /// </summary>public int Nickles { get; set; }
        public int Pennies { get; set; }

        /// <summary>
        /// This is a constructor, it initializes a new instance of the class (called an object).  This sets it's default values.
        /// </summary>
        public Change()
        {
            this.Quarters = 0;
            this.Dimes = 0;
            this.Nickles = 0;
            this.Pennies = 0;
        }
    }
}
