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
            for (int i = 0; i < 5; i++)
            {
                CheeseNibbler newGame = new CheeseNibbler();
                newGame.PlayGame();
                Console.ReadKey();
            }
        }
    }
    // The point represents a single cell of the Grid. It's responsible for holding the status of the point.
    class Point
    {
        // Enumerations
        public enum PointStatus 
        { 
            Empty, 
            Mouse, 
            Cheese 
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
    // The core of the game
    // The Grid owns the Points, the mouse, and the cheese
    class CheeseNibbler
    {
        // Properties
        // Multidimensional array of points, the Grid itself
        public Point[,] Grid { get; set; }
        // Represents location of the mouse 
        public Point Mouse { get; set; }
        // Represents location of the cheese
        public Point Cheese { get; set; }
        // Holds what round is taking place
        public int Round { get; set; }
        // Constructor
        public CheeseNibbler()
        {
            // Initialize the Grid
            Grid = new Point[10, 10];
            // Fill each cell of the the Grid with a Point
            for (int y = 0; y < this.Grid.GetLength(1); y++)
            {
                for (int x = 0; x < this.Grid.GetLength(0); x++)
                {
                    Grid[x, y] = new Point(x, y);
                }
            }
            // Random initalization
            Random rng = new Random();
            // Initialize Mouse and randomly put it on the Grid
            // Temporary coordinates for Mouse
            int mouseX = rng.Next(10);
            int mouseY = rng.Next(10);
            // Place on Grid
            Mouse = new Point(mouseX, mouseY);
            Grid[mouseX, mouseY] = Mouse;
            Mouse.Status = Point.PointStatus.Mouse;
            // Temporary coordinates for Cheese
            int cheeseX = rng.Next(10);
            int cheeseY = rng.Next(10);
            // Make sure that Cheese doesn't have the same spot as the Mouse
            while (mouseX == cheeseX && mouseY == cheeseY)
            {
                cheeseX = rng.Next(10);
                cheeseY = rng.Next(10);
            }
            // Place on Grid
            Cheese = new Point(cheeseX, cheeseY);
            Grid[cheeseX, cheeseY] = Cheese;
            Cheese.Status = Point.PointStatus.Cheese;
        }
        // METHODS
        public void DrawGrid()
        {
            Console.Clear();
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
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
                        default:
                            break;
                    }
                }
                Console.WriteLine();
            }
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
                        return (Mouse.X - 1 >= 0);

                case ConsoleKey.RightArrow:
                        return (Mouse.X + 1 <= 9);

                case ConsoleKey.UpArrow:
                        return (Mouse.Y - 1 >= 0);

                case ConsoleKey.DownArrow:
                        return (Mouse.Y + 1 <= 9);
            }
            return false;
        }
        // Logic of moving the mouse. Returns a boolean of true if the cheese was found
        public bool MoveMouse(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.DownArrow:
                    // If the new position has the Cheese, return true
                    if (Mouse.X == Cheese.X && Mouse.Y + 1 == Cheese.Y)
                        return true;
                    // If doesn't have cheese
                    // Set the original Mouse position status to empty
                    Grid[Mouse.X, Mouse.Y].Status = Point.PointStatus.Empty;
                    // Set the Mouse property to new Mouse position
                    Mouse = Grid[Mouse.X, Mouse.Y + 1];
                    // Set the new Mouse position status to Mouse
                    Grid[Mouse.X, Mouse.Y].Status = Point.PointStatus.Mouse;
                    break;

                case ConsoleKey.UpArrow:
                    if (Mouse.X == Cheese.X && Mouse.Y - 1 == Cheese.Y)
                        return true;
                    Grid[Mouse.X, Mouse.Y].Status = Point.PointStatus.Empty;
                    Mouse = Grid[Mouse.X, Mouse.Y - 1];
                    Grid[Mouse.X, Mouse.Y].Status = Point.PointStatus.Mouse;
                    break;

                case ConsoleKey.LeftArrow:
                    if (Mouse.X - 1 == Cheese.X && Mouse.Y == Cheese.Y)
                        return true;
                    Grid[Mouse.X, Mouse.Y].Status = Point.PointStatus.Empty;
                    Mouse = Grid[Mouse.X - 1, Mouse.Y];
                    Grid[Mouse.X, Mouse.Y].Status = Point.PointStatus.Mouse;
                    break;

                case ConsoleKey.RightArrow:
                    if (Mouse.X + 1 == Cheese.X && Mouse.Y == Cheese.Y)
                        return true;
                    Grid[Mouse.X, Mouse.Y].Status = Point.PointStatus.Empty;
                    Mouse = Grid[Mouse.X + 1, Mouse.Y];
                    Grid[Mouse.X, Mouse.Y].Status = Point.PointStatus.Mouse;
                    break;

                default:
                    break;
            }
            return false;
        }
        // Handles the logic for playing the Game
        public void PlayGame()
        {
            bool ifCheeseHasBeenFound = false;
            while (!ifCheeseHasBeenFound)
            {
                this.DrawGrid();
                ifCheeseHasBeenFound = MoveMouse(GetUserMove());
                this.Round++;
            }

            Console.WriteLine("You ate cheese in {0} rounds", this.Round);
        }
    }
}
