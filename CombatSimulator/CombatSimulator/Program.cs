using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Random function initialization
            Random rng = new Random();
            Console.WriteLine("                      Press any key to start the game.");
            // Pressing button to proceed
            Console.ReadKey();
            // Clears console
            Console.Clear();
            Console.WriteLine(@"         
               ███████╗███████╗ █████╗  ██████╗  █████╗ ██╗           
               ██╔════╝██╔════╝██╔══██╗██╔════╝ ██╔══██╗██║           
               ███████╗█████╗  ███████║██║  ███╗███████║██║           
               ╚════██║██╔══╝  ██╔══██║██║   ██║██╔══██║██║           
               ███████║███████╗██║  ██║╚██████╔╝██║  ██║███████╗      
               ╚══════╝╚══════╝╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝      ");
            Console.ReadKey();
            Console.WriteLine(@"                                                                   
                               ██╗   ██╗███████╗                              
                               ██║   ██║██╔════╝                              
                               ██║   ██║███████╗                              
                               ╚██╗ ██╔╝╚════██║                              
                                ╚████╔╝ ███████║                              
                                 ╚═══╝  ╚══════╝                              ");
            Console.ReadKey();
            Console.WriteLine(@" 
           ███████╗███████╗ █████╗  ██████╗ ██╗   ██╗██╗     ██╗     
           ██╔════╝██╔════╝██╔══██╗██╔════╝ ██║   ██║██║     ██║     
           ███████╗█████╗  ███████║██║  ███╗██║   ██║██║     ██║     
           ╚════██║██╔══╝  ██╔══██║██║   ██║██║   ██║██║     ██║     
           ███████║███████╗██║  ██║╚██████╔╝╚██████╔╝███████╗███████╗
           ╚══════╝╚══════╝╚═╝  ╚═╝ ╚═════╝  ╚═════╝ ╚══════╝╚══════╝");
            Console.ReadKey();
            Console.Clear();
            // Variable wich is true when game is in progress, false wneh finished
            bool playing = true;
            // Text to console
            Console.WriteLine("You're Steven Seagal and you're sitting on a bench at the Brooklyn shore eating your hamburger. You feel a light breeze coming from the ocean. Everything is so placid and peaceful. Then, suddenly, a gigantic seagull is trying to steal your fries.");
            Console.WriteLine();
            Console.WriteLine("                              YOU HAVE TO FIGHT!");
            Console.WriteLine();
            Console.WriteLine(@"You can try to brake seagull's knee with 20-35 HP damage, but it works only 70% of the time.
Your humiliating words always wound seagull for 10-15 HP damage.
Drink hot chili sauce to regenerate 10 to 20 HP.

Seagull's only type of attack is a rain of crap.  


                            Press any key to begin.");
            Console.ReadKey();
            Console.Clear();
            // Variable holding players HP
            int playerHP = 100;
            // Holds seagull's HP
            int gullHP = 200;
            // Variable to put results from random function, damage
            int currentHit = 0;
            // Variable to put results from random function, percentage of success
            int currentChance = 0;
            // Main game loop
            while (playing)
            {
                // Game stats
                Console.WriteLine("You have " + playerHP + " HP.");
                Console.WriteLine("Seagull has " + gullHP + " HP.");
                Console.WriteLine(@"Choose your attack:
1. Try to brake seagull's knee or elbow.
2. Say something humiliating about seagull's ancestor.
3. Drink hot chili sauce to regenerate your wounds.");
                // Input from user, what kind of attack he chooses
                string playerChoice = Console.ReadLine();
                Console.Clear();
                // If attack type is 1
                if (playerChoice == "1")
                {
                    // Random chance of success
                    currentChance = rng.Next(1,11);
                    // If successfull
                    if (currentChance > 3)
	                {
                        // Random damage
                        currentHit = rng.Next(20, 36);
                        // HP after damage
                        gullHP = gullHP - currentHit;
                        // Info about last attack
                        Console.WriteLine("Attack on the knee was successful, seagull lost " + currentHit + " HP.");
	                }
                        // If not successful
                    else
                    {
                        Console.WriteLine("You missed. Seagull was too fast.");
                    }
                }
                    // If choice number 2
                else if (playerChoice == "2")
                {
                    // Random damage
                    currentHit = rng.Next(10, 16);
                    // HP after damage
                    gullHP = gullHP - currentHit;
                    // Info about last attack
                    Console.WriteLine("Humiliation caused " + currentHit + " HP damage. Seagull lost it's self-control."); 
                }
                    // If choice number 3
                else if (playerChoice == "3")
                {
                    // Random ampunt of regenerated HP
                    currentHit = rng.Next(10, 21);
                    // HP after healing
                    playerHP = playerHP + currentHit;
                    // Info about last choice
                    Console.WriteLine("Hot chili sauce regenerates " + currentHit + " of your HP."); 
                }
                    // If input was wrong
                else
                {
                    Console.WriteLine("Wrong input. You lost your turn.");
                }
                // Checks if gull is dead
                if (gullHP < 1)
                {
                    Console.WriteLine("You won and you proved that nothing in this world can defeat you. Press any key to exit.");
                    // Stops the game
                    playing = false;
                    Console.ReadKey();
                    // Breaks while loop
                    break;
                }
                // Gull's random chance to attack player
                currentChance = rng.Next(1, 11);
                // If successful
                if (currentChance > 2)
                {
                    // Random damage
                    currentHit = rng.Next(5, 16);
                    // Players HP update
                    playerHP = playerHP - currentHit;
                    // Info about last attack
                    Console.WriteLine("Incoming! Raining crap from a lacerated sky! You lost " + currentHit + " HP.");
                }
                    // Gull lost her chance to attack
                else
                {
                    Console.WriteLine("Seagull couldn't concetrate. You are lucky.");
                }
                // Checks if player is dead
                if (playerHP < 1)
                {
                    Console.WriteLine("You lost the fight and your french fries. Press any key to exit.");
                    // Game ends
                    playing = false;
                    Console.ReadKey();
                }
            }
        }
    }
}
