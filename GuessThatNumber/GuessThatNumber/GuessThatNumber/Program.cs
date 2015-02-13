using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessThatNumber
{
    public class Program
    {
        // This is the number the user needs to guess.  Set its value in your code using a RNG.
        static int NumberToGuess = 0;

        static void Main(string[] args)
        {
            // Random function initialization
            Random rng = new Random();
            // Picking random number
            int randomNumber = rng.Next(1, 101);
            // For test
            SetNumberToGuess(randomNumber);
            // Instructions to user
            Console.WriteLine("You have to guess the number, user! ");
            // Input
            string inputMain = Console.ReadLine();
            // Counter of tries, including wrong invalid input
            int counter = 1;
            // Checks if input string is valid
            while (ValidateInput(inputMain) == false)
            {
                // Instructions to user
                Console.WriteLine("Invalid number, try again");
                // Re-input
                inputMain = Console.ReadLine();
                // Counter of tries +
                counter++;
            }
            // If passed, converts into integer to proceed to the main while loop
            int inputInt = Convert.ToInt32(inputMain);
            // If super lucky
            if (inputInt == NumberToGuess)
            {
               Console.WriteLine("You won! First correct guess you entered was right! Total number of attempts: " + counter); 
            }
            // If number entered by user is not equal to computer's proceed to main while loop
            while (inputInt != NumberToGuess)
            {
                // If not valid re-enter
                if (ValidateInput(inputMain) == false)
                {
                    Console.WriteLine("Number should consist of 0123456789 and be in the range from 1 to 100, silly, try again!");
                    inputMain = Console.ReadLine();
                    counter++;
                }
                    // If guess is higher
                else if (IsGuessTooHigh(Convert.ToInt32(inputMain)))
                {
                    // 3 variations of answers depending on how far are we from the computer's number
                    if (Math.Abs(Convert.ToInt32(inputMain) - NumberToGuess) > 20)
                    {
                        Console.WriteLine("Cold like in Odin's ass. Try lower!");
                        inputMain = Console.ReadLine();
                        counter++;
                    }
                    else if (Math.Abs(Convert.ToInt32(inputMain) - NumberToGuess) > 10)
                    {
                        Console.WriteLine("Warm. Warm enough for diesel engine to start. Try lower!");
                        inputMain = Console.ReadLine();
                        counter++;
                    }
                    else if (Math.Abs(Convert.ToInt32(inputMain) - NumberToGuess) >= 1)
                    {
                        Console.WriteLine("Hot! Be careful now, don't ruin everything. Try lower!");
                        inputMain = Console.ReadLine();
                        counter++;
                    }
                        
                }
                    // If our guess is lower
                else if (IsGuessTooLow(Convert.ToInt32(inputMain)))
                {
                    // 3 variations of answers depending on how far are we from the computer's number
                    if (Math.Abs(Convert.ToInt32(inputMain) - NumberToGuess) > 20)
                    {
                        Console.WriteLine("Feels like in Karelia in the middle of the winter. Try higher!");
                        inputMain = Console.ReadLine();
                        counter++;
                    }
                    else if (Math.Abs(Convert.ToInt32(inputMain) - NumberToGuess) > 10)
                    {
                        Console.WriteLine("Warm. Warm enough for suomi people to swim. Try higher!");
                        inputMain = Console.ReadLine();
                        counter++;
                    }
                    else if (Math.Abs(Convert.ToInt32(inputMain) - NumberToGuess) >= 1)
                    {
                        Console.WriteLine("Hot! Hot! Hot! Try higher!");
                        inputMain = Console.ReadLine();
                        counter++;
                    }
                }
                    // If input = computer's number
                else if (Convert.ToInt32(inputMain) == NumberToGuess)
                {
                    Console.WriteLine("You won! Total number of attempts: " + counter);
                    // Condition to end while loop
                        inputInt = NumberToGuess;
                }
            }
            
            Console.ReadKey();
        }
        
        public static bool ValidateInput(string userInput)
        {
            int validOrNot;
            // Returns boolean, true - if can be converted to integer, false - if can't
            if (Int32.TryParse(userInput, out validOrNot) && Convert.ToInt32(userInput) > 0 && Convert.ToInt32(userInput) < 101)
            {
                 return true;
            }
            //check to make sure that the users input is a valid number between 1 and 100.
            return false;
        }

        public static void SetNumberToGuess(int number)
        {
            NumberToGuess = number;
            //TODO: make this function override your global variable holding the number the user needs to guess.  This is used only for testing methods.
        }

        public static bool IsGuessTooHigh(int userGuess)
        {
            // Our guess greater than computer's number
            if (userGuess > NumberToGuess)
            {
                return true;
            }
            //TODO: return true if the number guessed by the user is too high
            return false;
        }

        public static bool IsGuessTooLow(int userGuess)
        {
            // Our guess less than computer's number
            if (userGuess < NumberToGuess)
            {
                return true;
            }
            //TODO: return true if the number guessed by the user is too low
            return false;
        }
    }
}
