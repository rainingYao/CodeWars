using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CountSmileys
{
    using NUnit.Framework;
    using System;
    using System.Text.RegularExpressions;

    [TestFixture]
    public class CountSmileys
    {
        [Test]
        public void BasicTest()
        {
            Assert.AreEqual(4, Kata.CountSmileys(new string[] { ":D", ":~)", ";~D", ":)" }));
            Assert.AreEqual(2, Kata.CountSmileys(new string[] { ":)", ":(", ":D", ":O", ":;" }));
            Assert.AreEqual(1, Kata.CountSmileys(new string[] { ";]", ":[", ";*", ":$", ";-D" }));
            Assert.AreEqual(0, Kata.CountSmileys(new string[] { ";", ")", ";*", ":$", "8-D" }));
        }

        [Test, Repeat(1000)]
        public void ContainsTest()
        {
            Assert.AreEqual(4, Kata.ContainsCountSmileys(new string[] { ":D", ":~)", ";~D", ":)" }));
            Assert.AreEqual(2, Kata.ContainsCountSmileys(new string[] { ":)", ":(", ":D", ":O", ":;" }));
            Assert.AreEqual(1, Kata.ContainsCountSmileys(new string[] { ";]", ":[", ";*", ":$", ";-D" }));
            Assert.AreEqual(0, Kata.ContainsCountSmileys(new string[] { ";", ")", ";*", ":$", "8-D" }));
        }

        [Test]
        public void RandomTests()
        {
            Random rand = new Random();
            var eyes = new string[4] { ";", ":", "8", "" };
            var noses = new string[4] { "-", "~", " ", "" };
            var mouths = new string[4] { ")", "D", "(", "P" };
            Func<string[], string> sample = (x) => x[rand.Next(x.Length)];

            for (int i = 0; i < 50; i++)
            {
                string[] smileys = new string[rand.Next(1, 10)];
                for (int r = 0; r < smileys.Length; r++)
                {
                    smileys[r] = sample(eyes) + sample(noses) + sample(mouths);
                }
                var expected = MyCode(smileys);
                var actual = Kata.CountSmileys(smileys);
                Assert.AreEqual(expected, actual);
                //Console.WriteLine($"total: {actual}:  {string.Join("  ", smileys)} ");
            }
        }

        private int MyCode(string[] smileys) { return Regex.Matches(string.Join(" ", smileys), @"[:;][-~]?[)D]").Count; }
    }
    public static class Kata
    {
        public static int CountSmileys(string[] smileys)
        {
            //return smileys.Count(s => Regex.IsMatch(s, "[:|;][-|~]?[D|\\)]"));
            return smileys.Count(s => Regex.IsMatch(s, "[:;][-~]?[D)]"));
        }

        public static int ContainsCountSmileys(string[] smileys)
        {
            return smileys.Count(s => " :D :) ;D ;) :-D :-) ;-D ;-) :~D :~) ;~D ;~) ".Contains(" " + s + " "));
        }
    }
}
