using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {

        static void Main(string[] args)
        {
            // Prints out letter by letter
            OldTimeyTextPrint("By typing your name you are starting this game full of VIOLENCE, BLOOD and GORE.", 10);
            // Reading users name
            string userName = Console.ReadLine();
            // Console clearing
            Console.Clear();
            // Prints out letter by letter
            OldTimeyTextPrint(userName + ", you will be guessing letters of the word until you can guess the word or all of the letters. Press any key to continue.", 10);
            // Pressing button to proceed
            Console.ReadKey();
            // Creating list of words
            List<string> listOfWords = new List<string>() { "apple", "cherry", "olive", "plum", "orange", "tomato", "banana", "potato", "lettuce", "garlic" };
            // Random initialization
            Random rng = new Random();
            // Condition for game
            bool playing = true;
            // Declaring of word we randomly choose
            string wordToGuess = string.Empty;
            // Declaring of list of letters succesfully tried 
            string guessLetters = string.Empty;
            // Declaring of a string caring the current input
            string guessLetterNow = string.Empty;
            // Choosing the word to guess
            wordToGuess = listOfWords[rng.Next(0, listOfWords.Count)].ToUpper();
            // Variable holding amount of guesses left
            int guessesLeft = wordToGuess.Length;
            // Game loop
            while (playing)
            {
                Console.Clear();
                // Printing out current game stats
                Console.WriteLine("Guess that word, " + userName);
                Console.WriteLine(DisplayMaskedWord(wordToGuess, guessLetters).ToUpper());
                Console.WriteLine("Letters guessed: " + guessLetters.ToUpper());
                Console.WriteLine("Guesses left: " + guessesLeft);
                // Condition to let player make input (without it we have one more input even after game is over)
                if (guessesLeft != 0 && wordToGuess != DisplayMaskedWord(wordToGuess, guessLetters).ToUpper().Replace(" ", ""))
                {
                    // Users guess
                    guessLetterNow = Console.ReadLine().ToUpper();
                }
                // Main if with various conditions
                if (guessLetterNow.Length > 1 && guessLetterNow == wordToGuess)
                {
                    // Call the function with graphic
                    WinByWord();
                    // Prints out letter by letter
                    OldTimeyTextPrint("Guessed the whole word, Emperor. The word was: " + wordToGuess.ToUpper(), 10);
                    // Game is over
                    playing = false;
                } 
                else if (wordToGuess ==  DisplayMaskedWord(wordToGuess, guessLetters).ToUpper().Replace(" ", ""))
                {
                    // Call the function with graphic
                    WinByLetters();
                    // Prints out letter by letter
                    OldTimeyTextPrint("Letter by letter? Biomass! The word was: " + wordToGuess.ToUpper(), 10);
                    // Game is over
                    playing = false;
                }
                else if (guessesLeft == 0)
                {
                    // Call the function with graphic
                    Lost();
                    // Prints out letter by letter
                    OldTimeyTextPrint("Terminated. The word was: " + wordToGuess.ToUpper(), 10);
                    // Game is over
                    playing = false;
                }
                else if (guessLetterNow.Length == 1 && wordToGuess.Contains(guessLetterNow) && !guessLetters.Contains(guessLetterNow))
                {
                    // Game continues with letter guessed
                    guessLetters = guessLetters + guessLetterNow;
                }
                else
                {
                    // Decrementing of lives left
                    guessesLeft--;
                }
            }
            // Press to close
            Console.ReadKey();
        }
        /// <summary>
        /// Returns string for output
        /// </summary>
        /// <param name="wordToGuess">Word picked by computer</param>
        /// <param name="guessLetters">Letters list entered by user</param>
        /// <returns></returns>
        static string DisplayMaskedWord(string wordToGuess, string guessLetters)
        {
            // Empty string
            string outputString = string.Empty;
            // Loop going through the letters list to check if current symbol from word to guess is there
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                // Positive
                if (guessLetters.Contains(wordToGuess[i]))
                {
                    // Add it to output string
                    outputString = outputString + wordToGuess[i] + " ";
                }
                    // Negative
                else
	            {
                    // Add a _ symbol to hide letters
                    outputString = outputString + "_" + " ";
            	}
            }
            return outputString;
        }
        /// <summary>
        /// Prints out like an old printer
        /// </summary>
        /// <param name="inputText">Text to output</param>
        /// <param name="pauseDuration">Pause between symbols</param>
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

        // 3 functions with graphic for different game results
        static void Lost()
        {
            Console.WriteLine(@"
     O          
    /|\
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"
     O             <
    /|\            
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"    
     O            <-
    /|\           
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O           <--
    /|\          
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"   
     O          <---
    /|\         
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"   
     O         <---<
    /|\        
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"    
     O        <---<
    /|\       
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O       <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O      <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O     <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O    <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O   <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O  <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O<---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
    O<---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
    <---<
   O/|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
   <---<
    /|\      
___O/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
  <---<
    /|\      
__O_/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
 <---<
    /|\      
_O__/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
<---<
    /|\      
_O__/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
---<
    /|\      
_O__/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
--<
    /|\      
_O__/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
-<   
    /|\      
_O__/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
<   
    /|\      
_O__/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
   
    /|\      
_O__/ \_____________");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
        }
        static void WinByWord()
        {
            Console.WriteLine(@"
     O          
    /|\
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"
     O             <
    /|\            
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"    
     O            <-
    /|\           
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O           <--
    /|\          
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"   
     O          <---
    /|\         
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"   
     O         <---<
    /|\        
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"    
     O        <---<
    /|\       
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O       <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O      <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O     <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O    <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O   <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O/ <---<
    /|      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O/<---<
    /|      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O/>--->
    /|      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O/ >--->
    /|      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O/  >--->
    /|      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O/   >--->
    /|      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O/    >--->
    /|      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O/     >--->
    /|      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O/      >--->
    /|      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O/       >--->
    /|      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O/        >--->
    /|      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O          >---
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O           >--
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O            >-
    /|\     
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O             >
    /|\     
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O            
    /|\     
____/ \_____________");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
        }
        static void WinByLetters()
        {
            Console.WriteLine(@"
     O          
    /|\
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"
     O             <
    /|\            
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"    
     O            <-
    /|\           
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O           <--
    /|\          
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"   
     O          <---
    /|\         
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"   
     O         <---<
    /|\        
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"    
     O        <---<
    /|\       
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O       <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O      <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O     <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O    <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O   <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O  <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O<---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(20);
            Console.Clear();
            Console.WriteLine(@"     
     O <---<
    /|\      
____/ \_____________");
            System.Threading.Thread.Sleep(30);
            Console.Clear();
            Console.WriteLine(@"     
     O
    /|\ <---<     
____/ \_____________");
            System.Threading.Thread.Sleep(30);
            Console.Clear();
            Console.WriteLine(@"     
     O
    /|\      
____/ \_ <---<______");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
        }
    }
}
