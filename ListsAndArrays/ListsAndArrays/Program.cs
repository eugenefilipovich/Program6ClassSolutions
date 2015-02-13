using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListsAndArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Fixed length array
            string[] foodArray = new string[5];
            foodArray[0] = "quinoa";
            foodArray[1] = "grapes";
            Console.WriteLine(foodArray[0]);

            // Multidimensional array
            int[,] twoD = new int[5,5];
            twoD[1, 1] = 7;
            Console.WriteLine(twoD[1,1]);

            // Lists
            List<string> teams = new List<string>();
            teams.Add("Broncos");
            teams.Add("Tigers");
            teams.Add("Eagles");

            // Sorting
            teams.Sort();
            Console.WriteLine("After sort");

            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine(teams[i]);
            }

            // Inserted and pushed everything down
            teams.Insert(0,"49ers");
            Console.WriteLine(teams[0]);

            // Resorting after inserting
            Console.WriteLine("Resorted");
            teams.Sort();

            for (int i = 0; i < teams.Count; i++)
            {
                Console.WriteLine(teams[i]);
            }

            // Finding in the list (if contains then true), case sensitive
            if (teams.Contains("Broncos"))
            {
                Console.WriteLine("Has Broncos");
            }

            // Where is it in the list
            Console.WriteLine(teams.IndexOf("Tigers"));

            // Array to a list
            List<string> foodList = foodArray.ToList();

            // Delete from list
            teams.Remove("Eagles");
            teams.RemoveAt(0);


            // Keep the console open
            Console.ReadKey();
        }
    }
}
