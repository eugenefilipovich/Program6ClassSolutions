using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Disemvoweler
{
    [TestFixture]
    class Test
    {
        [Test,Timeout(500)]
        public void testExample1()
        {
            Assert.IsNotNullOrEmpty(Program.Disemvoweler("Nickleback is my favorite band. Their songwriting can't be beat!"));
            StringAssert.AreEqualIgnoringCase("NcklbcksmyfvrtbndThrsngwrtngcntbbt", Program.Disemvoweler("Nickleback is my favorite band. Their songwriting can't be beat!"));
        }
        [Test, Timeout(500)]
        public void testExample2()
        {
            Assert.IsNotNullOrEmpty(Program.Disemvoweler("How many bears could bear grylls grill if bear grylls could grill bears?"));
            StringAssert.AreEqualIgnoringCase("Hwmnybrscldbrgryllsgrllfbrgryllscldgrllbrs", Program.Disemvoweler("How many bears could bear grylls grill if bear grylls could grill bears?"));
        }
        [Test, Timeout(500)]
        public void testExample3()
        {
            Assert.IsNotNullOrEmpty(Program.Disemvoweler("I'm a code ninja, baby. I make the functions and I make the calls."));
            StringAssert.AreEqualIgnoringCase("mcdnnjbbymkthfnctnsndmkthclls", Program.Disemvoweler("I'm a code ninja, baby. I make the functions and I make the calls."));
        }
    }
}
