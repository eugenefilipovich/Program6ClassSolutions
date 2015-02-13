using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            DoStrudentExamples();
            // ShowCourseConstructors();
            Console.ReadKey();
        }

        static void DoStrudentExamples()
        {
            Student student1 = new Student("John McClary", StudentRank.Freshmen);
            student1.CourseList.Add(new Course("Pro Development", "B"));
            student1.CourseList.Add(new Course("Programming", "D"));
            student1.CourseList.Add(new Course("Hockey History", "A"));
            student1.CourseList.Add(new Course("Being John", "C"));

            student1.PrintStudentInfo();

            Student student2 = new Student("Nicole W",  StudentRank.Junior);
            student2.CourseList.Add(new Course("Pro Development", "A"));
            student2.CourseList.Add(new Course("Programming", "A"));
            student2.CourseList.Add(new Course("Hockey History", "A"));
            student2.CourseList.Add(new Course("Being John", "A"));

            student2.PrintStudentInfo();
        }
        static void ShowCourseConstructors()
        {
            Course course1 = new Course();
            Course course2 = new Course("Biology");
            Course course3 = new Course("Math 101", "A");

            course1.PrintCourseInfo();
            course2.PrintCourseInfo();
            course3.PrintCourseInfo();

            course2.LetterGrade = "B";

        }

        // New funcion here
    }

    // New classes is going here
    public class Course
    {
        // STEP 1. Define properties

        // Creating properties
        // Step 1. Create the hide-behind variable
        private string _name;
        // Step 2. Create the property layer that sits on the top of that variable. It controls the interaction with the variable
        public string Name
        {
            get
            {
                // Getter: whenever the property is on the right side of an equation, this code is run
                // eg myString = myObject.Name
                return _name.ToUpper();
            }
            set
            {
                // Setter: whenever the property is on the left side of an equation, this code is run
          // eg myObject.Name = "Nickelback"
                _name = value;
            }
        }

        private string _letterGrade;
        public string LetterGrade
        {
            get { return _letterGrade; }
            set { _letterGrade = value; }
        }

        // For the GPA, we are going to do a READ-ONLY property

        public double GradePoints
        {
            get
            {
            switch (this.LetterGrade){
                case "A":
                    return 4.0;
                case "B":
                    return 3.0;
                case "C":
                    return 2.0;
                case "D":
                    return 1.0;
                default:
                    return 0.0;
            }
        }
        }
        // Creating a new class: 
        // STEP 2: Define constructor(s)
        // Parameterless constructor, default constructor
        public Course()
        {
            this.Name = "Undefined";
            this.LetterGrade = "I";
        }
        // Parameterfull constructor, usually used more
        public Course(string name)
        {
            this.Name = name;
            this.LetterGrade = "I";
        }
        // 
        public Course(string name, string letterGrade)
        {
            this.Name = name;
            this.LetterGrade = letterGrade;
        }

        // Creating a new class: 
        // STEP 3: Define its methods (actions)

        public void PrintCourseInfo()
        {
            Console.WriteLine("{0, 15} {1, 2} {2, 3}", this.Name, this.LetterGrade, this.GradePoints);
        }
    }

    //Defining an enumeration (ENUM)

    public enum StudentRank
    {
        Freshmen,
        Sophmore,
        Junior,
        Senior
    }

    public class Student
    {
        // STEP 1: Define the properties
        private string _name;

        public string Name
        {
            get { return _name; } // Console.Write(myObj.Name);
            set { _name = value; } // myObj = "Patrick Yee";
        }

        private List<Course> _courseList;

        public List<Course> CourseList
        {
            get { return _courseList; }
            set { _courseList = value; }
        }

        public double GPA
        {
            get
            {
                // Total grade points divided by the # of classes
                return this.CourseList.Average(x => x.GradePoints);
            }
        }

        private StudentRank _studentRank;
        public StudentRank StudentRank
        {
            get { return _studentRank; }
            set {_studentRank = value;}
        }
        // Other properties might include: age, studentID, DOB, major

        // STEP 2: Constructors
        public Student(string name, StudentRank rank)
        {
            this.Name = name;
            this.CourseList = new List<Course>(); // Make sure to initialiaze any lists
            this.StudentRank = rank;
        }

        // STEP 3: Methods
        public void PrintStudentInfo()
        {
            Console.WriteLine("Name: {0}", this.Name);
            foreach (Course course in this.CourseList)
            {
                course.PrintCourseInfo();
            }
            Console.WriteLine("GPA: {0}", this.GPA);

            // lambda
            // this.CourseList.ForEach(x => x.PrintCourseInfo())


        }
    }
}
