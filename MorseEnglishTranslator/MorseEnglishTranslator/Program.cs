using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseEnglishTranslator
{

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
            Console.WriteLine("This is ENGLISH-MORSE, MORSE-ENGLISH translator.");
            Console.WriteLine("English input: use space in between each word.                                  Morse code input: use space in between letters, to spaces in between words.");
            Console.WriteLine("Enter something to translate:");
            // Input
            string userInput = Console.ReadLine();
            // Console clearing
            Console.Clear();
            Console.WriteLine("Translation: "+ Morse.MorseCodeTranslator(userInput));
            Console.WriteLine("Press any key to close the program");
            Console.ReadKey();
        }
    }
}
