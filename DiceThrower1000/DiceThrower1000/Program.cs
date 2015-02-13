using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceThrower1000
{
    class Program
    {
        /// <summary>
        /// Call
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Calls function
            ThrowDice("3d6 2d10 6d20");
            // Leaves console open
            Console.ReadKey();
        }
        /// <summary>
        /// Body of the game, throws dices, in a 2d4 format, where 2 is number of throws, 4 is a number of dies
        /// </summary>
        /// <param name="diceString">Throw information</param>
                static void ThrowDice(string diceString)
        {
                    // Initiates random number generator
            Random randomNumberGenerator = new Random();
                    // Split input into separate tries(throws)
            string[] splitNumberArray = diceString.Split(' ');
                    // Looping thru out scenarios
            for (int i = 0; i < splitNumberArray.Length; i++)
            {
                // Prints the throw
                Console.WriteLine("Throw: " + splitNumberArray[i]);
                // Splits the throw into separate numbers, where the first is a number of throws, the second is a number of dies 
                string[] oneThrow = splitNumberArray[i].Split('d');
                // Preparation for results printing 
                Console.Write("Results: ");
                // Variable to store average roll info
                float averageRoll = 0;
                // Loops thru the individual throws
                for (int j = 0; j < int.Parse(oneThrow[0]); j++)
                {
                    // Gets a random die roll
                    int randomNumber = randomNumberGenerator.Next(1, int.Parse(oneThrow[1]));
                    // Adds the roll into the average roll counter
                    averageRoll = averageRoll + randomNumber;
                    // Prnts out the individual throw
                    Console.Write(randomNumber + " ");
                }
                // Prints the average
                Console.WriteLine("Average: " + averageRoll/int.Parse(oneThrow[0]));
                // Line in between the throws
                Console.WriteLine();
            }
            
        }
    }
}
