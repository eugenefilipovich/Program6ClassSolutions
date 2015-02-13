using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DebuggingPractice
{
    [TestFixture]
    class Test
    {
        [Test]
        public void testCountTs()
        {
            Assert.AreEqual(16, Program.CountTs("The thirty-three thieves thought that they thrilled the throne throughout Thursday."));
        }
        [Test]
        public void testPalindrome()
        {
            Assert.That(Program.IsPalindrome("racecar"));
        }
        [Test]
        public void testISBN1()
        {
            Assert.That(Program.IsValidISBN("0-7475-3269-9"));
        }
        [Test]
        public void testISBN2()
        {
            Assert.That(Program.IsValidISBN("0-4515-2493-4"));
        }
        [Test]
        public void testISBN3()
        {
            Assert.That(Program.IsValidISBN("0-1420-0283-6"));
        }
        [Test]
        public void testISBN4()
        {
            Assert.That(Program.IsValidISBN("0-9116-5006-7"));
        }
        [Test]
        public void testPanagram1()
        {
            Assert.That(Program.IsPanagram("The quick brown fox jumps over the lazy dog."));
        }
        [Test]
        public void testPanagram2()
        {
            Assert.That(Program.IsPanagram("Fat hag dwarves quickly zap jinx mobs"));
        }
        [Test]
        public void testPanagram3()
        {
            Assert.That(Program.IsPanagram("Pack my box with five dozen liquor jugs."));
        }
    }
}
