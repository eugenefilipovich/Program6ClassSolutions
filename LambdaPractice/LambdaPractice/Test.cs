using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LambdaPractice
{
    [TestFixture]
    class Test
    {

        static List<string> TestList = new List<string>() { "kayak", "baseballs", "volleyball" };

        [Test]
        public void Shortest()
        {
            Assert.IsTrue(Program.ShortestName(TestList) == "kayak", "Not returning the shortest word.");
        }
        [Test]
        public void Longest()
        {
            Assert.IsTrue(Program.LongestName(TestList) == "volleyball", "Not returning the longest word.");
        }

        [Test]
        public void SecondLongest()
        {
            Assert.IsTrue(Program.SecondLongestName(TestList) == "baseballs", "Not returning the second longest word.");
        }

        [Test]
        public void ThirdShortest()
        {
            Assert.IsTrue(Program.ThirdShortestName(TestList) == "volleyball", "Not returning the 3rd shortest word");
        }

        [Test]
        public void BallProducts()
        {
            Assert.IsTrue(Program.BallProducts(TestList).Count == 2, "Not returning the correct number of ball products");
        }

        [Test]
        public void EndsInS()
        {
            Assert.IsTrue(Program.EndInS(TestList).Count == 1, "Not returning the correct number of items that end with the letter s");
        }
    }
}
