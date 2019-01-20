namespace DuplicateEncoder
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class KataTests
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("(((", Kata.DuplicateEncode("din"));
            Assert.AreEqual("()()()", Kata.DuplicateEncode("recede"));
            Assert.AreEqual(")())())", Kata.DuplicateEncode("Success"), "should ignore case");
            Assert.AreEqual("))((", Kata.DuplicateEncode("(( @"));
            Assert.AreEqual("()(((())())", Kata.DuplicateEncode("CodeWarrior"));
            Assert.AreEqual(")()))()))))()(", Kata.DuplicateEncode("Supralapsarian"), "should ignore case");
            Assert.AreEqual("))))))", Kata.DuplicateEncode("iiiiii"), "duplicate-only-string");
        }

        [Test]
        public void ParenthesesTests()
        {
            Assert.AreEqual("))((", Kata.DuplicateEncode("(( @"));
            Assert.AreEqual(")))))(", Kata.DuplicateEncode(" ( ( )"));
        }

        [Test]
        public void RandomTests()
        {
            var rand = new Random();

            Func<string, string> myDuplicateEncode = delegate (string word)
            {
                Dictionary<char, int> dict = new Dictionary<char, int>();
                for (int i = 0; i < word.Length; i++)
                {
                    if (!dict.ContainsKey(char.ToLower(word[i])))
                    {
                        dict.Add(char.ToLower(word[i]), 0);
                    }
                    dict[char.ToLower(word[i])]++;
                }
                string result = "";

                for (var i = 0; i < word.Length; i++)
                {
                    if (dict[char.ToLower(word[i])] == 1)
                    {
                        result += "(";
                    }
                    else
                    {
                        result += ")";
                    }
                }

                return result;
            };

            for (int r = 0; r < 10; r++)
            {
                var length = rand.Next(10, 21);
                var chars = "abcdeFGHIJklmnOPQRSTuvwxyz() @!";
                var word = string.Concat(Enumerable.Range(0, length).Select(a => chars[rand.Next(0, chars.Length)]));

                Assert.AreEqual(myDuplicateEncode(word), Kata.DuplicateEncode(word));
            }
        }
    }


    public class Kata
    {
        public static string DuplicateEncode(string word)
        {
            //Use (word = word.ToLower()) to ignore case!
            //Then use word.Count(c => c == w) to count every char,
            //and if count > 1 concat ')' else '('.
            return string.Concat((word = word.ToLower()).Select(w => word.Count(c => c == w) > 1 ? ')' : '('));
        }
    }
}