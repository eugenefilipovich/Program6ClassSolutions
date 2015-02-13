using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipMania
{
    class Program
    {
        static void Main(string[] args)
        {
            FlipCoins(10000);
            FlipForHeads(10000);
            Console.ReadKey();
        }
        /// <summary>
        /// Flips a coin numberOfFlips times and displays how many heads and tails were flipped
        /// </summary>
        /// <param name="numberOfFlips">Flips made</param>
        static void FlipCoins(int numberOfFlips)
        {
            if (numberOfFlips > 0)
            {
                int numberOfHeads = 0;
                int numberOfTails = 0;
                for (int i = 0; i < numberOfFlips; i++)
                {
                    int ourFlip = randomNumberGenerator.Next(0, 2);
                    if (ourFlip == 0)
                    {
                        numberOfHeads++;
                    }
                    else
                    {
                        numberOfTails++;
                    }
                }
                Console.WriteLine("We flipped a coin " + numberOfFlips + " times");
                Console.WriteLine("Number of Heads " + numberOfHeads);
                Console.WriteLine("Number of Tails " + numberOfTails);
            }
           
        }
        /// <summary>
        /// Flips coin until numberOfHeadsFlipped heads were found and displays how many times it took to flip that amount of heads
        /// </summary>
        /// <param name="numberOfHeads"> Number of heads needed to succeed</param>
        static void FlipForHeads(int numberOfHeads)
        {
            if (numberOfHeads > 0)
            {
                int numberOfHeadsFlipped = 0;
                int totalFlips = 0;
                while (numberOfHeadsFlipped < numberOfHeads)
                {
                    int ourFlipSecond = randomNumberGenerator.Next(0, 2);
                    if (ourFlipSecond == 0)
                    {
                        numberOfHeadsFlipped++;
                    }
                    totalFlips++;
                }
                Console.WriteLine("We are flipping a coin until we find " + numberOfHeads + " heads");
                Console.WriteLine("It took " + totalFlips + " to find " + numberOfHeads + " heads");
            }
        }
        static Random randomNumberGenerator = new Random();
    }
}
