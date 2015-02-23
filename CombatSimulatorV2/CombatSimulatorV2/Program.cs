using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatSimulatorV2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Call of the game
            Game game = new Game();
            game.PlayGame();
            Console.ReadKey();
        }
    }
    class Actor
    {
        // Properties
        public string Name { get; set; }
        public int HP { get; set; }
        public bool IsAlive 
        {
            get
            {
                if (this.HP > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public Random RNG = new Random();
        // Constructor
        public Actor(string name, int startHealthPoins)
        {
            this.HP = startHealthPoins;
            this.Name = name;
            this.RNG = new Random();
        }
        // Attack method, for override
        public virtual void DoAttack(Actor actor)
        {
        }
    }
    // Enemy class inherits Actor class
    class Enemy : Actor
    {
        // Constructor passes to Actor class
        public Enemy(string name, int startHealthPoins)
            : base(name, startHealthPoins)
        {
        }
        // Attack method overrides Actor's method
        public override void DoAttack(Actor actor)
        {
            // Damage
            int currentHit = 0;
            // Chance to cause damage
            int currentChance = RNG.Next(1, 11);
            // If in 80%
            if (currentChance > 2)
            {
                currentHit = RNG.Next(5, 16);
                actor.HP -= currentHit;
                Console.WriteLine("The {0} damages you with {1} HP.", this.Name, currentHit);
            }
                // If in 20%
            else
            {
                Console.WriteLine("{0} couldn't concetrate. You are lucky.", this.Name);
            }
        }
    }
    // Player class inherits Actor class
    class Player : Actor
    {
        // Enum for type of attack
        enum AttackType
        {
            Knee = 1,
            Humilate = 2,
            Heal = 3
        }
        // Constructor passes to Actor
        public Player(string name, int startHealthPoins)
            : base(name, startHealthPoins)
        {
        }
        // Attack method overrides Actor's
        public override void DoAttack(Actor actor)
        {
            // Variation of attack type
            switch (ChooseAttack())
            {
                case AttackType.Knee:
                    // Random chance of success
                    int currentChance = RNG.Next(1, 11);
                    // If successfull
                    if (currentChance > 3)
                    {
                        // Random damage
                        int currentHit = RNG.Next(20, 36);
                        // HP after damage
                        actor.HP -= currentHit;
                        // Info about last attack
                        Console.WriteLine("Attack on the knee was successful, enemy lost " + currentHit + " HP.");
                    }
                    else
                    {
                        Console.WriteLine("You missed. Enemy was too fast.");
                    }
                    break;

                case AttackType.Humilate:
                    // Random damage
                    int currentHitSecond = RNG.Next(10, 16);
                    // HP after damage
                    actor.HP -= currentHitSecond;
                    // Info about last attack
                    Console.WriteLine("Humiliation caused " + currentHitSecond + " HP damage.");
                    break;
                case AttackType.Heal:
                    // Random ampunt of regenerated HP
                    int currentHitThird = RNG.Next(10, 21);
                    // HP after healing
                    this.HP += currentHitThird;
                    // Info about last choice
                    Console.WriteLine("Hot chili sauce regenerates " + currentHitThird + " of your HP.");
                    break;
                    // If wrong number
                default:
                    Console.WriteLine("Wrong input. Try again.");
                    break;
            }
        }
        // Reads from console and converts to int to use as enum
        private AttackType ChooseAttack()
        {
            int num1;
            bool res = int.TryParse(Console.ReadLine(), out num1);
            if (res == false)
            {
            }
            else 
            {
            }
            return (AttackType)num1;
        }
    }
    // Game class
    class Game
    {
        // Properties
        public Player Player {get; set;}
        public Enemy Enemy { get; set; }
        // Constructors sets names and health points for player and enemy
        public Game()
        {
            this.Player = new Player("Seagal", 100);
            this.Enemy = new Enemy("Seagull", 200);
        }
        // Info bar
        public void DisplayCombatInfo()
        {
            Console.WriteLine("##############################Current Health Stats##############################\n");
            Console.WriteLine("                               " + Player.Name + " has " + Player.HP + " HP.\n");
            Console.WriteLine("                              " + Enemy.Name + " has " + Enemy.HP + " HP.");
            Console.WriteLine("\n\n1. Try to brake enemy's knee." +
   "\n2. Say something humiliating about enemy's ancestor." +
   "\n3. Drink hot chili sauce to regenerate your wounds.\n");
        }
        // Start of the game and while loop to repeat until game ends
        public void PlayGame()
        {
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
            // Looping until player or enemy are dead
            while (this.Player.IsAlive && this.Enemy.IsAlive)
            {
                Console.Clear();
                DisplayCombatInfo();
                this.Player.DoAttack(this.Enemy);
                this.Enemy.DoAttack(this.Player);
                System.Threading.Thread.Sleep(1000);
            }
            // Player won
            if (Player.IsAlive)
            {
                Console.WriteLine("You won.");

            }
            // No, enemy wins
            else
            {
                Console.WriteLine("You lost.");
            }
        }
    }
}
