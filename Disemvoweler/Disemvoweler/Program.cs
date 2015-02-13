using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disemvoweler
{
    class Program
    {
        static void Main(string[] args)
        {
            // Function call
            Disemvoweler("Nickelback is my favorite band. Their songwriting can't be beat");
            Disemvoweler("How many bears could bear grylls grill if bear grylls could grill bears?");
            Disemvoweler("I'm a code ninja, baby. I make the functions and I make the calls");
            // Keep the console open
            Console.ReadKey();
        }
        public static string Disemvoweler(string input)
        {
            // Creating string for output of disemvoweled input string
            string outputString = string.Empty;
            // String for vowels removed
            string outputStringOfVowels = string.Empty;
            // Creating input string to lower case
            string inputLower = input.ToLower();
            // Loop searching for vowels to remove
            for (int i = 0; i < input.Length; i++)
            {
                // Checking if chararacter is not eligible to stay in the string
                if (inputLower[i] == 'a' || inputLower[i] == 'e' || inputLower[i] == 'i' || inputLower[i] == 'o' || inputLower[i] == 'u' || inputLower[i] == ' ' || inputLower[i] == '!' || inputLower[i] == '?' || inputLower[i] == '.' || inputLower[i] == '\'' || inputLower[i] == ',')
                {
                    // Checking if it's a vowel
                    if (inputLower[i] == 'a' || inputLower[i] == 'e' || inputLower[i] == 'i' || inputLower[i] == 'o' || inputLower[i] == 'u')
                    {
                        // Yes, save it to vowels removed string
                        outputStringOfVowels = outputStringOfVowels + inputLower[i];
                    }
                }
                else
                {
                    // Eligible to stay characters go to output string
                    outputString = outputString + inputLower[i];
                }
            }
            // Write out the various string results
            Console.WriteLine("Original: " + input );
            Console.WriteLine("Disemvoweled: " + outputString);
            Console.WriteLine("Vowels Removed: " + outputStringOfVowels); 
            // Return the Disemvoweled string as well for testing
            return outputString;
        }
    }
}
