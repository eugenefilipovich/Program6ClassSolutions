using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheeseNibbler
{
    class Program
    {
        static void Main(string[] args)
        {
                CheeseNibbler newGame = new CheeseNibbler();
                newGame.PlayGame();
        }
    }
    // The point represents a single cell of the Grid. It's responsible for holding the status of the point.
    public class Point
    {
        // Enumerations
        public enum PointStatus
        {
            Empty,
            Mouse,
            Cheese,
            Cat,
            CatAndCheese
        }
        // Properties
        // X coordinate value
        public int X { get; set; }
        // Y coordinate value
        public int Y { get; set; }
        // Does the cell contains the mouse? Is it the cheese?
        public PointStatus Status { get; set; }
        // Constructor
        // Sets the coordinates of the cell, and set the status to empty
        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Status = PointStatus.Empty;
        }
    }
    // Main hero. Responsible for holding the status of the Mouse
    public class Mouse
    {
        // Properties
        public Point Position { get; set; }
        public int Energy { get; set; }
        public bool HasBeenPouncedOn { get; set; }
        // Constructor
        public Mouse()
        {
            // Whether or not cat has got the Mouse
            HasBeenPouncedOn = false;
            // Set amount of energy
            this.Energy = 50;
        }
    }
    public class Cat
    {
        // Properties
        public Point Position { get; set; }
        // Constructor
        public Cat() { }
    }
    // The core of the game
    // The Grid owns the Points, the mouse, and the cheese
    public class CheeseNibbler
    {
        // Properties
        // Multidimensional array of points, the Grid itself
        public Point[,] Grid { get; set; }
        // Represents location of the mouse 
        public Mouse Mouse { get; set; }
        // Represents location of the cheese
        public Point Cheese { get; set; }
        // Holds how many cheeses the mouse consumed
        public int CheeseCount { get; set; }
        // List of cats
        public List<Cat> Cats { get; set; }
        // Constructor
        public CheeseNibbler()
        {
            // Initialize the Grid
            this.Grid = new Point[10, 10];
            // Fill each cell of the the Grid with a Point
            for (int y = 0; y < this.Grid.GetLength(1); y++)
            {
                for (int x = 0; x < this.Grid.GetLength(0); x++)
                {
                    Grid[x, y] = new Point(x, y);
                }
            }
            // Random initialization
            Random rng = new Random();
            // Mouse initialization
            this.Mouse = new Mouse();
            // Initialize Mouse and randomly put it on the Grid
            // Place on Grid
            this.Mouse.Position = Grid[rng.Next(0, 10), rng.Next(0, 10)];
            // Change status
            this.Mouse.Position.Status = Point.PointStatus.Mouse;
            // Place a cheese
            PlaceCheese();
            this.Cats = new List<Cat>();
        }
        public void PlaceCheese()
        {
            // Random initalization
            Random rng = new Random();
            do
            {
                // Get a Point to check
                this.Cheese = Grid[rng.Next(0, 10), rng.Next(0, 10)];
                // condition to be met, must be an Empty point to place the cheese
            } while (this.Cheese.Status != Point.PointStatus.Empty);
            // Set reference to cheese
            this.Cheese.Status = Point.PointStatus.Cheese;
        }
        public void DrawGrid()
        {
            Console.Clear();
            for (int y = 0; y < this.Grid.GetLength(1); y++)
            {
                for (int x = 0; x < this.Grid.GetLength(0); x++)
                {
                    // Get the point from the Grid
                    switch (Grid[x, y].Status)
                    {
                        case Point.PointStatus.Empty:
                            Console.Write("[ ]");
                            break;
                        case Point.PointStatus.Mouse:
                            Console.Write("[M]");
                            break;
                        case Point.PointStatus.Cheese:
                            Console.Write("[C]");
                            break;
                        case Point.PointStatus.Cat:
                            Console.Write("[@]");
                            break;
                        case Point.PointStatus.CatAndCheese:
                            Console.Write("[@]");
                            break;
                        default:
                            Console.Write("[ ]");
                            break;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("You have {0} energy points", this.Mouse.Energy);
            Console.WriteLine("You ate {0} pieces of cheese", this.CheeseCount);
            Console.WriteLine();
        }
        public ConsoleKey GetUserMove()
        {
            while (true)
            {
                // Key pressed by user
                // By putting true you don't have actual key appeared in the console (default is false, shows to the console)
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                // Validating input from user
                if (userInput.Key == ConsoleKey.LeftArrow ||
                userInput.Key == ConsoleKey.RightArrow ||
                userInput.Key == ConsoleKey.UpArrow ||
                userInput.Key == ConsoleKey.DownArrow)
                {
                    // If right key was pressed check if move is valid
                    if (ValidMove(userInput.Key))
                    {
                        return userInput.Key;
                    }
                    else
                    {
                        Console.WriteLine("Move is not valid");
                    }
                }
                else
                {
                    Console.WriteLine("You must use arrow keys to move");
                }
            }
        }
        // Handles the logic of determining a valid move
        public bool ValidMove(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.LeftArrow:
                    return (Mouse.Position.X > 0);

                case ConsoleKey.RightArrow:
                    return (Mouse.Position.X < this.Grid.GetLength(0) - 1);

                case ConsoleKey.UpArrow:
                    return (Mouse.Position.Y > 0);

                case ConsoleKey.DownArrow:
                    return (Mouse.Position.Y < this.Grid.GetLength(0) - 1);
            }
            return false;
        }
        // Logic of moving the mouse. Returns a boolean of true if the cheese was found
        public bool MoveMouse(ConsoleKey input)
        {
            int tempMouseX = Mouse.Position.X;
            int tempMouseY = Mouse.Position.Y;
            // Current coordinates
                // Coordinates after move
                switch (input)
                {
                    case ConsoleKey.LeftArrow:
                        tempMouseX--;
                        break;
                    case ConsoleKey.RightArrow:
                        tempMouseX++;
                        break;
                    case ConsoleKey.UpArrow:
                        tempMouseY--;
                        break;
                    case ConsoleKey.DownArrow:
                        tempMouseY++;
                        break;
                    default:
                        return false;
            }
            // Get the Point of the new position from Grid
            Point afterMovePosition = this.Grid[tempMouseX, tempMouseY];
            // If the new position has the Cheese
            if (afterMovePosition.Status == Point.PointStatus.Cheese)
            {
                // Add one to Cheese count
                CheeseCount++;
                // Set the new Cheese to find
                PlaceCheese();
                // If CheeseCount is divisible by 2, add Cat
                if (CheeseCount % 2 == 0)
                {
                    AddCat();
                }
                // Status changes from Mouse to Empty
                this.Mouse.Position.Status = Point.PointStatus.Empty;
                // Move Mouse to new position
                this.Mouse.Position = afterMovePosition;
                // From Cheese to Mouse
                this.Mouse.Position.Status = Point.PointStatus.Mouse;
                // After cheese was found
                Mouse.Energy += 10;
                return true;
            }
                // If new position has cat
            else if (afterMovePosition.Status == Point.PointStatus.Cat || afterMovePosition.Status == Point.PointStatus.CatAndCheese)
            {
                // Status changes from Mouse to Empty
                this.Mouse.Position.Status = Point.PointStatus.Empty;
                // Mouse goes to new position
                this.Mouse.Position = afterMovePosition;
                // From cheese to cat
                this.Mouse.Position.Status = Point.PointStatus.Cat;
                // Mouse killed
                this.Mouse.HasBeenPouncedOn = true;
                return false;
            }
                // Empty new position
            else
            {
                this.Mouse.Position.Status = Point.PointStatus.Empty;
                this.Mouse.Position = afterMovePosition;
                this.Mouse.Position.Status = Point.PointStatus.Mouse;
                Mouse.Energy--;
                return false;
            }
        }
        // Handles the logic for Creating a new cat
        public void AddCat()
        {
            Cat newCat = new Cat();
            PlaceCat(newCat);
            this.Cats.Add(newCat);
        }
        // Handles the logic of placing Cat
        public void PlaceCat(Cat cat)
        {
            Random rng = new Random();
            do
            {
                // Get a Point to check
                cat.Position = Grid[rng.Next(0, 10), rng.Next(0, 10)];
                // condition to be met, must be an Empty point to place the Cat
            } while (cat.Position.Status != Point.PointStatus.Empty);
            // Set reference to Cat
            cat.Position.Status = Point.PointStatus.Cat;
        }
        public void MoveCat(Cat cat)
        {
            Random rng = new Random();
            // If in 80%
            if (rng.Next(10) > 1)
            {
                int xDif = this.Mouse.Position.X - cat.Position.X;
                int yDif = this.Mouse.Position.Y - cat.Position.Y;
                bool tryLeft = xDif < 0;
                bool tryRight = xDif > 0;
                bool tryUp = yDif < 0;
                bool tryDown = yDif > 0;
                Point targetPosition = cat.Position;
                bool validMove = false;

                while (!validMove && (tryLeft || tryRight || tryUp || tryDown))
                {
                    int catStartingX = cat.Position.X;
                    int catStartingY = cat.Position.Y;
                    if (tryLeft)
                    {
                        targetPosition = Grid[--catStartingX, catStartingY];
                        tryLeft = false;
                    }
                    else if (tryRight)
                    {
                        targetPosition = Grid[++catStartingX, catStartingY];
                        tryRight = false;
                    }
                    else if (tryUp)
                    {
                        targetPosition = Grid[catStartingX, --catStartingY];
                        tryUp = false;
                    }
                    else if (tryDown)
                    {
                        targetPosition = Grid[catStartingX, ++catStartingY];
                        tryDown = false;
                    }
                    validMove = isValidCatMove(targetPosition);
                }
                // If cat goes out frrom cheese
                if (cat.Position.Status == Point.PointStatus.CatAndCheese)
                {
                    cat.Position.Status = Point.PointStatus.Cheese;
                }
                else
                {
                    cat.Position.Status = Point.PointStatus.Empty;
                }
                // Target position has mouse
                if (targetPosition.Status == Point.PointStatus.Mouse)
                {
                    Mouse.HasBeenPouncedOn = true;
                    targetPosition.Status = Point.PointStatus.Cat;
                }
                // Target position has cheese
                else if (targetPosition.Status == Point.PointStatus.Cheese)
                {
                    targetPosition.Status = Point.PointStatus.CatAndCheese;
                }
                else
                {
                    targetPosition.Status = Point.PointStatus.Cat;
                }
                cat.Position = targetPosition;  
            }
        }
        public bool isValidCatMove(Point targetPosition)
        {
            // Can go to position with cheese, mouse or empty, but not other cat
            return targetPosition.Status == Point.PointStatus.Empty || targetPosition.Status == Point.PointStatus.Mouse || targetPosition.Status == Point.PointStatus.Cheese;
        }
        // Handles the logic for playing the Game
        public void PlayGame()
        {
            while (Mouse.Energy > 0)
            {
                DrawGrid();
                MoveMouse(GetUserMove());
                foreach (Cat cat in Cats)
                {
                    MoveCat(cat);
                }
                if (this.Mouse.HasBeenPouncedOn == true)
                {
                    this.Mouse.Energy = 0;
                }
            }
            DrawGrid();
            Console.WriteLine("You lost!");
            Console.WriteLine("Press Enter to start new game or any other key to close");
            ConsoleKeyInfo userAnswer = Console.ReadKey(true);
            if (userAnswer.Key == ConsoleKey.Enter)
            {
                PlayAgain();
            }
            else 
            {
                Console.WriteLine("Leaving the game. Bye!");
                System.Threading.Thread.Sleep(1000);
            }
        }
        public void PlayAgain()
        {
            // Resetting everything
            this.Mouse.HasBeenPouncedOn = false;
            this.Mouse.Energy = 50;
            this.CheeseCount = 0;
            this.Mouse.Position.Status = Point.PointStatus.Empty;
            this.Cheese.Status = Point.PointStatus.Empty;
            Cats.Clear();
            foreach (Cat cat in this.Cats)
            {
                cat.Position.Status = Point.PointStatus.Empty;
            }
            Random rng = new Random();
            // Place mouse and cheese
            this.Mouse.Position = this.Grid[rng.Next(10), rng.Next(10)];
            this.Mouse.Position.Status = Point.PointStatus.Mouse;
            this.PlaceCheese();
            this.PlayGame();
        }
    }
}
