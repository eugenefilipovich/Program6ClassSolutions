using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            //Employee JohnMcClary = new Employee("John", "McClary", "Known Liar");
            //JohnMcClary.Talk();

            //Janitor jeff = new Janitor("jeff", "macco");
            //jeff.Sweep();
            //jeff.Clean();
            //jeff.Talk();

            Musician dustin = new Musician("dustin", "kraft", "piano");
            dustin.Talk();
            dustin.Jam();

            Bird bird = new Bird();
            // To create a list
            List<ISing> listOfThingsThatSing = new List<ISing>();
            listOfThingsThatSing.Add(dustin);
            listOfThingsThatSing.Add(bird);
            foreach (ISing somethingThatSings in listOfThingsThatSing)
            {
                somethingThatSings.Sing();
            }
            Console.ReadKey();
        }
    }

    #region "Class stuff"
    // Abstract class, cannot be instantiated
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person(string fname, string lname)
        {
            this.FirstName = fname; 
            this.LastName = lname;
        }

        public void Walk()
        {
            Console.WriteLine("whistling sounds");
        }
        // Need virtual because we are overriding the behavior of this child class
        public virtual void Talk()
        {
            Console.WriteLine("Hey whats up?");
        }
    }
    // Employee inherits Person class
    public class Employee : Person
    {
        public string JobTitle { get; set; }

        public Employee(string fname, string lname, string jobtitle) : base(fname, lname)
        {
            this.JobTitle = jobtitle;
            this.FirstName = fname;
            this.LastName = lname;
        }

        // methods
        // override is the base class method
        public override void Talk()
        {
            // if we want to include the base class behavior
            base.Talk();
            // Talk about the job
            Console.WriteLine("I'm a {0}. Synergize the paradigms", this.JobTitle);
        }
    }

    public class Janitor : Employee
    {
        public int NumberOfBrooms { get; set; }

        public Janitor(string fname, string lname)
            : base(fname, lname, "Janitor")
        {
            // Nothing goes in the constructor, because the base classes handle it for us
            this.NumberOfBrooms = 3;
        }

        // Methods
        public override void Talk()
        {
            base.Talk();
            Console.WriteLine("I'm a person too");
        }

        public void Sweep()
        {
            Console.WriteLine("Sweep sweep sweep");
        }

        public void Clean()
        {
            Console.WriteLine("Squeky squeky");
        }
    }

    public class Musician : Employee, ISing
    {
        public string Instrument { get; set; }
        public Musician(string fname, string lname, string instrument)
            : base(fname, lname, "Musician")
        {
            this.Instrument = instrument;
        }

        public override void Talk()
        {
            base.Talk();
            Console.WriteLine("I play {0}", this.Instrument);
        }

        public void Jam()
        {
            Console.WriteLine("Jamming on my {0}", this.Instrument);
        }


        public void Sing()
        {
            Console.WriteLine("Oooooooooooo!");
        }
    }
    #endregion

#region "Interfaces"

    interface ISing
    {
        // framework for describing something that sings
        // provides no information on how it sings (does not implement how it sings)
        void Sing();
    }

    class Bird : ISing
    {
        public void Sing()
        {
            Console.WriteLine("Chirp chirp");
        }
    }
 interface ICombustionEngine
    {
        int FuelLevel { get; set; }

        void Refuel(int fuel);

        void Go();

    }

    public class Jet : ICombustionEngine
    {

        public int FuelLevel { get; set; }

        public void Refuel(int fuel)
        {
            this.FuelLevel += fuel;
        }

        public void Go()
        {
            if(FuelLevel > 25)
            {
                Console.WriteLine("vroooooom! breaking sound barriers, yo.");
                this.FuelLevel -= 25;
            }
            else
            {
                Console.WriteLine("Out of gas");
            }
            
        }

        public Jet()
        {
            this.FuelLevel = 20;
        }
    }

    public class Generator : ICombustionEngine
    {
        public int FuelLevel { get; set; }

        public Generator()
        {
            this.FuelLevel = 20;
        }

        public void Refuel(int fuel)
        {
            this.FuelLevel += fuel;
        }

        public void Go()
        {
            if (this.FuelLevel > 10)
            {
                Console.WriteLine("I'm producing 25KW");
                this.FuelLevel -= 10;
            }
            else
            {
                Console.WriteLine("out of gas");
            }
        }
    }

#endregion
}
