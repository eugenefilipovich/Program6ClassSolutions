using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TextStatsLambda_DigitalRoot
{
    [TestFixture]
    class Test
    {
        static string testString = "Mike's favorite color is blue.";

        [Test]
        public void DigitalRootTest31337()
        {
            Assert.IsTrue(Program.DigitalRoot("31337") == 8, "Digital root for 31337 should be 8");
        }

        [Test]
        public void DigitalRootTest45734()
        {
            Assert.IsTrue(Program.DigitalRoot("45734") == 5, "Digital root for 45734 should be 5");
        }

        [Test]
        public void TextStatsTestNumberOfWords()
        {
            Assert.IsTrue(Program.NumberOfWords(testString) == 5, "Incorrect number of words");
        }

        [Test]
        public void TextStatsTestNumberOfVowels()
        {
            Assert.IsTrue(Program.NumberOfVowels(testString) == 11, "Incorrect number of vowels");
        }

        [Test]
        public void TextStatsTestNumberOfConsonants()
        {
            Assert.IsTrue(Program.NumberOfConsonants(testString) == 13, "Incorrect number of consonants");
        }

        [Test]
        public void TextStatsTestNumberOfSpecialCharacters()
        {
            Assert.IsTrue(Program.NumberOfSpecialCharacters(testString) == 6, "Incorrect number of special characters");
        }
        [Test]
        public void TextStatsTestShortestWord()
        {
            Assert.IsTrue(Program.ShortestWord(testString) == "is" , "Incorrect shortest word");
        }

        [Test]
        public void TextStatsTestLongestWord()
        {
            Assert.IsTrue(Program.LongestWord(testString) == "favorite", "Incorrect longest word");
        }
    }
}
