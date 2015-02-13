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
            // Notice that when using the decimal format you must end numbers with an 'm'
            ChangeAmount(4.19m);
            ChangeAmount(3.18m);
            ChangeAmount(0.99m);
            ChangeAmount(12.93m);
            ChangeAmount(437.03m);
            ChangeAmount(120.93m);
            // Leaves console open
            Console.ReadKey();
        }

        public static Change ChangeAmount(decimal amount) 
        {
            // This is our object that will hold the data of how many coins(bills) of each type to return
            Change amountAsChange = new Change();
            // Saving amount to show to console
            decimal amountToShow = amount;
            // Loops for each nominal
            // Checking if there is enough amount to take one more coin(bill) of current nominal
            // Yes - taking one more, No - going to next nominal
            while (amount >= 100m)
            {
                // Number of coins(bills) increased
                amountAsChange.Hundreds++;
                // Amount decreased by amount of coin taken
                amount = amount - 100m;
            }
            while (amount >= 50m)
            {
                amountAsChange.Fiftys++;
                amount = amount - 50m;
            }
            while (amount >= 20m)
            {
                amountAsChange.Twenties++;
                amount = amount - 20m;
            }
            while (amount >= 10m)
            {
                amountAsChange.Tens++;
                amount = amount - 10m;
            }
            while (amount >= 5m)
            {
                amountAsChange.Fives++;
                amount = amount - 5m;
            }
            while (amount >= 1m)
            {
                amountAsChange.OneDollars++;
                amount = amount - 1m;
            }
            while (amount >= .25m)
            {
                amountAsChange.Quarters++;
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
            while (amount > 0)
            {
                amountAsChange.Pennies++;
                amount = amount - .01m;
            }
            // Console output
            Console.WriteLine("Amount: " + amountToShow);
            Console.WriteLine("100s: " + amountAsChange.Hundreds);
            Console.WriteLine("50s: " + amountAsChange.Fiftys);
            Console.WriteLine("20s: " + amountAsChange.Twenties);
            Console.WriteLine("10s: " + amountAsChange.Tens);
            Console.WriteLine("5s: " + amountAsChange.Fives);
            Console.WriteLine("1s: " + amountAsChange.OneDollars);
            Console.WriteLine("Quarters: " + amountAsChange.Quarters);
            Console.WriteLine("Dimes: " + amountAsChange.Dimes);
            Console.WriteLine("Nickles: " + amountAsChange.Nickles);
            Console.WriteLine("Pennies: " + amountAsChange.Pennies);

            // Return our Change Object
            return amountAsChange;
        }
    }

    public class Change
    {
        /// <summary>
        /// This is property to hold the number of Hundred dollar bills to be returned as change
        /// </summary>
        public int Hundreds { get; set; }
        /// <summary>
        /// This is property to hold the number of $50 bills to be returned as change
        /// </summary>
        public int Fiftys { get; set; }
        /// <summary>
        /// This is property to hold the number of $20 bills to be returned as change
        /// </summary>
        public int Twenties { get; set; }
        /// <summary>
        /// This is property to hold the number of $10 bills to be returned as change
        /// </summary>
        public int Tens { get; set; }
        /// <summary>
        /// This is property to hold the number of $5 bills to be returned as change
        /// </summary>
        public int Fives { get; set; }
        /// <summary>
        /// This is property to hold the number of $1 bills to be returned as change
        /// </summary>
        public int OneDollars { get; set; }
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
            this.Hundreds = 0;
            this.Fiftys = 0;
            this.Twenties = 0;
            this.Tens = 0;
            this.Fives = 0;
            this.OneDollars = 0;
            this.Quarters = 0;
            this.Dimes = 0;
            this.Nickles = 0;
            this.Pennies = 0;

        }
    }
}
