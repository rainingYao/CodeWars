namespace BreakCamelCase
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    [TestFixture]
    public class Sample_Tests
    {
        private static IEnumerable<TestCaseData> testCases
        {
            get
            {
                yield return new TestCaseData("camelCasing").Returns("camel Casing");
                yield return new TestCaseData("camelCasingTest").Returns("camel Casing Test");
                //首字母大写时或应去除首空格
                //yield return new TestCaseData("CamelCasingTest").Returns("Camel Casing Test");
            }
        }
        
        [Test, TestCaseSource("testCases")]
        public string Test(string str) => Kata.BreakCamelCase(str);

        ///Regex 本题可以不用Trim() 用的是$&
        [Test, TestCaseSource("testCases")]
        public string RegexAnd(string str) => Regex.Replace(str, "[A-Z]", " $&").Trim();

        ///Regex 本题可以不用Trim() 用的是$0
        [Test, TestCaseSource("testCases")]
        public string RegexZero(string str) => Regex.Replace(str, "[A-Z]", " $0").Trim();

        ///Regex 本题可以不用Trim() 用的是$1
        [Test, TestCaseSource("testCases")]
        public string RegexOne(string str) => new Regex("([A-Z])").Replace(str, " $1");
    }

    [TestFixture]
    public class Random_Tests
    {
        private static Random rnd = new Random();

        private static string solution(string str) => new Regex("([A-Z])").Replace(str, " $1");

        [Test, Description("Random Tests")]
        public void RandomTests()
        {
            const int Tests = 100;

            for (int i = 0; i < Tests; ++i)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append((char)rnd.Next(97, 123));
                int length = rnd.Next(10, 200);

                for (int j = 0; j < length; ++j)
                {
                    char c = (char)rnd.Next(97, 123);
                    if (rnd.Next(0, 5) == 0)
                    {
                        c = Char.ToUpper(c);
                    }
                    sb.Append(c);
                }

                string str = sb.ToString();

                string expected = solution(str);
                string actual = Kata.BreakCamelCase(str);

                Assert.AreEqual(expected, actual);
            }
        }
    }

    public class Kata
    {
        /// Linq
        public static string BreakCamelCase(string str)
        {
            return string.Concat(str.Select(c => ('Z' >= c && c >= 'A' ? " " : "") + c));
        }
    }
}
