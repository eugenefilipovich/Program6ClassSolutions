using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupPicker
{
    class Program
    {
        static Random randomNumberGenerator = new Random(); 
        /// <summary>
        /// Randomly assingns students to groups
        /// </summary>
        /// <param name="args">Number of student per group</param>
        static void Main(string[] args)
        {
            PickGroup(4);
            Console.ReadKey();
        }

        static void PickGroup(int groupSize)
        {
            // Main list of names
            List<string> studentList = new List<string>() {"Linda", "Eugene", "Patrick", "Sergio", "Nate", "Michael", "Andrii", "Nicole", "Juli", "Andrew", "Brandon S", "Brandon E", "Maria", "Daniel", "Mike", "Laura", "Tim" };
            // List of names in the group
            List<string> currentGroupList = new List<string>();
            // Group count
            int groupNumber = 1;
            // Counter used to store original number of students
            int counter = studentList.Count;
            for (int i = 0; i < counter; i++)
            {
                // Picks random name from the list
                int currentStudent = randomNumberGenerator.Next(0, studentList.Count);
                // Adds randomly picked name to the group
                currentGroupList.Add(studentList[currentStudent]);
                // Removes the name that was assingned to the group
                studentList.RemoveAt(currentStudent);
                // Prints out the group if size of the group is reached or no more students in the initial list
                if ((currentGroupList.Count == groupSize) || (studentList.Count == 0))
                {
                    Console.WriteLine("\n Group " + groupNumber + "\n");
                    for (int j = 0; j < currentGroupList.Count; j++)
                    {
                        Console.WriteLine(currentGroupList[j]);
                    }
                    // Erases group of students that was printed out
                    currentGroupList.Clear();
                    // Going to the next group
                    groupNumber++;
                }
            }
        }
    }
}
