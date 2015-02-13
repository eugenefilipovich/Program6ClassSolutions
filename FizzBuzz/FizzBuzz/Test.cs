using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace FizzBuzz
{
    [TestFixture]
    class Test
    {
        [Test, Timeout(500)]
        public void testFizzBuzz1()
        {
            StringAssert.AreEqualIgnoringCase("1", Program.FizzBuzz(1));
        }
        [Test, Timeout(500)]
        public void testFizzBuzz7()
        {
            StringAssert.AreEqualIgnoringCase("7", Program.FizzBuzz(7));
        }
        [Ignore]
        [Test, Timeout(500)]
        public void testFizzBuzzNegative()
        {
            StringAssert.AreEqualIgnoringCase("", Program.FizzBuzz(-1));
        }
        [Test, Timeout(500)]
        public void testFizzBuzz3()
        {
            StringAssert.AreEqualIgnoringCase("Buzz", Program.FizzBuzz(3));
        }
        [Test, Timeout(500)]
        public void testFizzBuzz5()
        {
            StringAssert.AreEqualIgnoringCase("Fizz", Program.FizzBuzz(5));
        }
        [Test, Timeout(500)]
        public void testFizzBuzz3And5()
        {
            StringAssert.AreEqualIgnoringCase("FizzBuzz", Program.FizzBuzz(15));
        }
    }
}
