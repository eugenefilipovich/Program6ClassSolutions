using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiDimensionalArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1D array
            int[] my1DArray = new int[10];
            // How to make a 2D array
            int[,] my2DArray = new int[3, 3];
            // Populate an array
            int counter = 1;
            for (int y = 0; y < 3; y++)
            {
                // For each y (row)
                for (int x = 0; x < 3; x++)
                {
                    // For each x (column)
                    my2DArray[x, y] = counter;
                    counter++;
                }
            }
            // Writing out the grid
            for (int y = 0; y < 3; y++)
            {
                // For each y (row)
                for (int x = 0; x < 3; x++)
                {
                    // write the grid
                    Console.Write("[{0}]", my2DArray[x,y]);
                }
                Console.WriteLine();
            }
            // Create a 2D array of point
            Point[,] pointArray = new Point[10, 10];

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    pointArray[x, y] = new Point(x, y);
                }
            }
            // Using arrows for movement
            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.RightArrow:
                    // do studff for right arrow
                    break;
                case ConsoleKey.LeftArrow:
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }
    }
    /// <summary>
    /// Represents a single point on the grid
    /// </summary>
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
