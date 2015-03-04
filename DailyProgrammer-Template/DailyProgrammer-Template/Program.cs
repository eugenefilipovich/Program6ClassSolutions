using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework; //test classes need to have the using statement

///     REDDIT DAILY PROGRAMMER SOLUTION TEMPLATE 
///                             http://www.reddit.com/r/dailyprogrammer
///     Your Name: 
///     Challenge Name: 
///     Challenge #: 
///     Challenge URL: 
///     Brief Description of Challenge:

///
/// 
///
///     What was difficult about this challenge?
///
///     
///
///     What was easier than expected about this challenge?
///
///
///
///     BE SURE TO CREATE AT LEAST TWO TESTS FOR YOUR CODE IN THE TEST CLASS
///     One test for a valid entry, one test for an invalid entry.

namespace DailyProgrammer_Template
{
///     Your Name: Eugene Filipovich
///     Challenge Name: Non-repeating years
///     Challenge #: 101
///     Challenge URL: http://www.reddit.com/r/dailyprogrammer/comments/10l8ay/9272012_challenge_101_easy_nonrepeating_years/
///     Brief Description of Challenge:
///     Write a program to count the number years in an inclusive range of years that have no repeated digits.
///     Compute the longest run of years of repeated digits and the longest run of years of non-repeated digits in that range.
///
/// 
///
///     What was difficult about this challenge?
///     Finding out longest runs.
///
///     
///
///     What was easier than expected about this challenge?
///     Checking whether number has repeated digits or not.
///
///
///
///     BE SURE TO CREATE AT LEAST TWO TESTS FOR YOUR CODE IN THE TEST CLASS
///     One test for a valid entry, one test for an invalid entry.
    public class NonRepeatingYears
    {
        public static int NonRepeatingYearsProgram(int yearToBegin, int yearToEnd)
        {

            // String to hold current year in string format
            string currentYearString;
            // Lists of years with not repeated and repeated digits
            List<int> listOfNonRepeatingYears = new List<int>();
            List<int> listOfRepeatingYears = new List<int>();
            // Loop to look over all years
            for (int i = yearToBegin; i <= yearToEnd; i++)
            {
                currentYearString = i.ToString();
                // If all digits are distinct
                if (currentYearString.Distinct().Count() == 4)
                {
                    listOfNonRepeatingYears.Add(i);
                }
                    // If not distinct
                else
                {
                    listOfRepeatingYears.Add(i);
                } 
            }
            Console.WriteLine("Number of years with distinct digits: " + listOfNonRepeatingYears.Count + ". List of years: ");
            foreach (int element in listOfNonRepeatingYears)
            {
                Console.WriteLine(element);
            }
            // Adds number to the end of list to do looping
            listOfNonRepeatingYears.Add(9999);
            listOfRepeatingYears.Add(9999);
            // Variables for of a longest runs
            List<int> tempList = new List<int>();
            List<int> longestRunList = new List<int>();
            int tempRun = 0;
            int longestRun = 0;
            // Loops through and looks for a longest run
            for (int j = 0; j < listOfNonRepeatingYears.Count - 1; j++)
            {
                if (listOfNonRepeatingYears[j] - listOfNonRepeatingYears[j + 1] == -1)
                {
                    tempList.Add(listOfNonRepeatingYears[j]);
                    tempRun = tempRun + 1;
                }
                    // If current run is the longest
                else if (longestRun < tempRun)
                {
                    longestRunList.Clear();
                    longestRunList.AddRange(tempList);
                    longestRunList.Add(listOfNonRepeatingYears[j]);
                    longestRun = tempRun + 1;
                    tempList.Clear();
                    tempRun = 0;
                }
            }
            Console.WriteLine("The longest run of years with non-repeating digits: " + longestRun + ". List of years: ");
            foreach (int element in longestRunList)
            {
                Console.WriteLine(element);
            }
            // Clear temporary variables before using
            longestRunList.Clear();
            tempList.Clear();
            tempRun = 0;
            longestRun = 0;
            // Loops through and looks for a longest run
            for (int j = 0; j < listOfRepeatingYears.Count - 1; j++)
            {
                if (listOfRepeatingYears[j] - listOfRepeatingYears[j + 1] == -1)
                {
                    tempList.Add(listOfRepeatingYears[j]);
                    tempRun = tempRun + 1;
                }
                // If current run is the longest
                else if (longestRun < tempRun)
                {
                    longestRunList.Clear();
                    longestRunList.AddRange(tempList);
                    longestRunList.Add(listOfRepeatingYears[j]);
                    longestRun = tempRun + 1;
                    tempList.Clear();
                    tempRun = 0;
                }
            }
            Console.WriteLine("The longest run of years with repeating digits: " + longestRun + ". List of years: ");
            foreach (int element in longestRunList)
            {
                Console.WriteLine(element);
            }
            return listOfNonRepeatingYears.Count - 1;
        }
    }
//      Your Name: Eugene Filipovich
///     Challenge Name: Two-Way Morse Code Translator
///     Challenge #: 93
///     Challenge URL: http://www.reddit.com/r/dailyprogrammer/comments/z3a4y/8302012_challenge_93_easy_twoway_morse_code/
///     Brief Description of Challenge:
///     Two-way translator: English to Morse code, Morse code to English.
///     When translating to Morse code, one space should be used to separate morse code letters, and two spaces should be used to separate morse code words. When translating to English, there should only be one space in between words, and no spaces in between letters.
///
/// 
///
///     What was difficult about this challenge?
///     Make right Morse-English translation with spaces between words
///
///     
///
///     What was easier than expected about this challenge?
///     English to Morse translation
///
///
///
///     BE SURE TO CREATE AT LEAST TWO TESTS FOR YOUR CODE IN THE TEST CLASS
///     One test for a valid entry, one test for an invalid entry.
    public class Morse
    {
        public static string MorseCodeTranslator(string inputString)
        {
            // Libraries with elements standing on suited indexes
            string[] abc = {   " ","A", "B", "C", "D", "E", 
                                   "F", "G", "H", "I", "J", 
                                   "K", "L", "M", "N", "O", 
                                   "P", "Q", "R", "S", "T", 
                                   "U", "V", "W", "X", "Y", 
                                   "Z", "?", ":", ",", ".",
                                   "0", "1", "2", "3", "4",
                                   "5", "6", "7", "8", "9"};
            string[] morse = {" ", ".-", "-...", "-.-.", "-..", ".", 
                              "..-.", "--.", "....", "..", ".---", 
                              "-.-", ".-..", "--", "-.", "---", 
                              ".--.", "--.-", ".-.", "...", "-", 
                              "..-", "...-", ".--", "-..-", "-.--", 
                              "--..", "..--..", "---...", "-....-", ".-.-.-",
                              "-----", ".----", "..---", "...--", "....-",
                              ".....", "-....", "--...", "---..","----."};
            string outputString = "";
            // English to Morse translation
            if ("qwertyuiopasdfghjklzxcvbnm".Contains(inputString[0].ToString().ToLower()))
            {
                for (int j = 0; j < inputString.Length; j++)
                {
                    for (int i = 0; i < abc.Length; i++)
                    {
                        if (inputString[j].ToString().ToLower() == abc[i].ToLower())
                        {
                            outputString = outputString + morse[i] + " ";
                        }
                    }
                }
            }
                // Morse to English
            else if (".-".Contains(inputString[0]))
            {
                // Splits by words
                string[] splitWords = inputString.Split(new string[] { "  " }, StringSplitOptions.None);
                // Current word
                for (int k = 0; k < splitWords.Length; k++)
                {
                    // Splits by letters
                    string[] splitLetters = splitWords[k].Split(' ');
                    // Current letter
                    for (int j = 0; j < splitLetters.Length; j++)
                    {
                        for (int i = 0; i < morse.Length; i++)
                        {
                            if (splitLetters[j] == morse[i])
                            {
                                // English output
                                outputString = outputString + abc[i];
                            }
                        }
                    }
                    // Adds space between words
                    outputString = outputString + " ";
                }
            }
                // If input doesn't start from letter or - or .
            else
            {
                Console.WriteLine("Wrong input!");
            }
            return outputString.ToLower();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Call of the first program
            NonRepeatingYears.NonRepeatingYearsProgram(2000, 2015);
            // Call of the second program with different input
            Console.WriteLine("- .-. .- -. ... .- - .-.. .- -. - .. -.-. .. ... -- in English is: " + Morse.MorseCodeTranslator(".... . .-.. .-.. ---  .-- --- .-. .-.. -.."));
            Console.WriteLine("Hello world in Morse code is: " + Morse.MorseCodeTranslator("hello world"));
            Console.ReadKey();

        }

        /// <summary>
        /// Simple function to illustrate how to use tests
        /// </summary>
        /// <param name="inputInteger"></param>
        /// <returns></returns>
        public static int MyTestFunction(int inputInteger)
        {
            return inputInteger;
        }
    }


#region " TEST CLASS "

    //We need to use a Data Annotation [ ] to declare that this class is a Test class
    [TestFixture]
    class Test
    {
        // Test for 1st program
        [Test]
        public void NonRepeatingYearsProgramValidTest()
        {
            int result = NonRepeatingYears.NonRepeatingYearsProgram(2000, 2015);
            Assert.IsTrue(result == 3, "Wrong output");
        }

        [Test]
        public void NonRepeatingYearsProgramInvalidTest()
        {
            int result = NonRepeatingYears.NonRepeatingYearsProgram(2000, 2015);
            Assert.IsFalse(result == 4);
        }

        [Test]
        public void MorseCodeTranslatorValidTest()
        {
            string result = Morse.MorseCodeTranslator("-- --- .-. ... .  -.-. --- -.. .");
            Assert.IsTrue(result == "morse code ", "Wrong output");
        }
        [Test]
        public void MorseCodeTranslatorInvalidTest()
        {
            string result = Morse.MorseCodeTranslator("-- --- .-. ... .  -.-. --- -.. .");
            Assert.IsFalse(result == "morsecode", "Wrong output");
        }

        //Test classes are declared with a return type of void.  Test classes also need a data annotation to mark them as a Test function
        [Test]
        public void MyValidTest()
        {
            //inside of the test, we can declare any variables that we'll need to test.  Typically, we will reference a function in your main program to test.
            int result = Program.MyTestFunction(15);  // this function should return 15 if it is working correctly
            //now we test for the result.
            Assert.IsTrue(result == 15, "This is the message that displays if it does not pass");
            // The format is:
            // Assert.IsTrue(some boolean condition, "failure message");
        }

        [Test]
        public void MyInvalidTest()
        {
            int result = Program.MyTestFunction(15);
            Assert.IsFalse(result == 14);
        }
    }
#endregion
}
