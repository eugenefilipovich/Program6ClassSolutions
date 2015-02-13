using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoopingThroughStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            // Function call for the vowel counter
            string testString = "The lazy dog jumps";
            Console.WriteLine("We found {0} vowels in {1}", VowelCounter3000(testString), testString);

            Console.WriteLine("The average length of the word is {0:f4}, in {1}", AverageWordLengthFinder8000(testString), testString);

            // Another way to calculate the average using lambdas
            // Console.WriteLine(testString.Split(' ').Average(x => x.Length));
            // Another way to count the number of vowels using lambdas
            // testString.Count(x => "aeiou".Contains(x.ToString().ToLower()));

            // Old timey printer
            OldTimeyTextPrint(testString, 500);
            OldTimeyTextPrint(testString, 50);
            OldTimeyTextPrint(testString, 5);

            Console.ReadKey();
        }
        /// <summary>
        /// Count the number of vowels in a string
        /// </summary>
        /// <param name="inputText">The string to analyze</param>
        /// <returns>The number of vowels found</returns>
        static int VowelCounter3000(string inputText)
        {
            // Counter of vowels
            int numberOfVowelsFound = 0;

            // We need a loop going through all indexes to compare each letter
            for (int i = 0; i < inputText.Length; i++)
            {
                // Pulling out individual letter and converting it to lower case
                char letter = char.ToLower(inputText[i]);

                // Is it a vowel? 
                if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
                {
                    // Yes, counting
                    numberOfVowelsFound = numberOfVowelsFound + 1;
                }
            }
            //Number of vowels found
            return numberOfVowelsFound;
        }
        /// <summary>
        /// Finds the average length of a word in the string
        /// </summary>
        /// <param name="inputText">Sentence</param>
        /// <returns>Average length of a word </returns>
        static double AverageWordLengthFinder8000(string inputText)
        {
            // Counters to hold our values to calculate an average, need to use doubles
            double totalNumberOfCharacters = 0;
            double totalNumberOfWords = 0;

            // We need to split a string into words
            string[] wordArray = inputText.Split(' ');

            // Loop over each word in the array
            for (int i = 0; i < wordArray.Length; i++)
            {
                // Get the current word
                string currentWord = wordArray[i];

                // Lets process the word
                totalNumberOfWords++;

                totalNumberOfCharacters = totalNumberOfCharacters + currentWord.Length;

                // Return our results
                // Average = total/number of words

            }
            return totalNumberOfCharacters / totalNumberOfWords;
        }

        /// <summary>
        /// Prints text to the screen like an 80s Apple II
        /// </summary>
        /// <param name="inputText">Text to print</param>
        /// <param name="pauseDuration">Pause duration</param>
        static void OldTimeyTextPrint(string inputText, int pauseDuration)
        {
        // Loop over each character
            for (int i = 0; i < inputText.Length; i++)
            {
        // Get the letter
        char letter = inputText[i];

        // Print the letter to the screen
        Console.Write(letter);

        // Pause
                System.Threading.Thread.Sleep(pauseDuration);
            }
        // After the text is complete write a line break
            Console.WriteLine();
        }
    }
}


