using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextStatsLambda_DigitalRoot
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call of DigitalRoot
            Console.WriteLine("Digital root of 31337: " + DigitalRoot("31337"));
            Console.WriteLine("Digital root of 45734: " + DigitalRoot("45734"));
            // Call of TextStats
            TextStats("Mike's favorite color is blue.");
            Console.ReadKey();
        }

        static void TextStats(string inputString)
        {
            // Calling of all special functions
            Console.WriteLine("1. Number of characters: " + inputString.Count());
            Console.WriteLine("2. Number of words: " + NumberOfWords(inputString));
            Console.WriteLine("3. Number of vowels: " + NumberOfVowels(inputString));
            Console.WriteLine("4. Number of consonants: " + NumberOfConsonants(inputString));
            Console.WriteLine("5. Number of special characters: " + NumberOfSpecialCharacters(inputString));
            Console.WriteLine("6. Longest word: " + LongestWord(inputString));
            Console.WriteLine("7. Shortest word: " + ShortestWord(inputString));
        }

        public static int DigitalRoot(string rootThisNumber)
        {
            // Keeps temporary and final result
            int result = 0;
            // Looping until we have one digit left
            while (rootThisNumber.Length > 1)
            {
                // Clears result before next for loop
                result = 0;
                // result = rootThisNumber.Sum( x => Int.Parse(x.ToString()));
                // Adds all digits to the sum
                for (int i = 0; i < rootThisNumber.Length; i++)
                {
                    result = result + Int32.Parse(rootThisNumber[i].ToString());
                }
                // Changes string to a previous sum of digits
                rootThisNumber = result.ToString();
            }
            // Returns integer
            return result;
        }

        public static int NumberOfWords(string inputString)
        {
            // Counts number of words (words are separated by space)
            return inputString.Split(' ').Count();
        }

        public static int NumberOfVowels(string inputString)
        {
            // Checks if aeiou contains current character
            return inputString.Count(x => "aeiou".Contains(x.ToString().ToLower()));
        }

        public static int NumberOfConsonants(string inputString)
        {
            // Checks if qwrtypsdfghjklzxcvbnm contains current character
            return inputString.Count(x => "qwrtypsdfghjklzxcvbnm".Contains(x.ToString().ToLower()));
        }

        public static int NumberOfSpecialCharacters(string inputString)
        {
            // .,?;'!@#$%^&*() and spaces are considered special characters
            return inputString.Count(x => " .,?;'!@#$%^&*()".Contains(x.ToString()));
        }

        public static string LongestWord(string inputString)
        {
            return inputString.Split(' ').OrderByDescending(x => x.Length).First();
        }

        public static string ShortestWord(string inputString)
        {
            return inputString.Split(' ').OrderByDescending(x => x.Length).Last(); ;
        }
    }
}
