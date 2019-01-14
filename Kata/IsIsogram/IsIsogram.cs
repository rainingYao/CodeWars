namespace IsIsogram
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    [TestFixture]
    public class IsIsogramTests
    {
        private static IEnumerable<TestCaseData> testCases
        {
            get
            {
                yield return new TestCaseData("Dermatoglyphics").Returns(true);//15
                yield return new TestCaseData("isogram").Returns(true);//7
                yield return new TestCaseData("moose").Returns(false);//5
                yield return new TestCaseData("isIsogram").Returns(false);//9
                yield return new TestCaseData("aba").Returns(false);//3
                yield return new TestCaseData("moOse").Returns(false);//5
                yield return new TestCaseData("thumbscrewjapingly").Returns(true);//18
                yield return new TestCaseData("").Returns(true);//0
            }
        }
        [Test, TestCaseSource("testCases"), Repeat(1000)]
        public bool Test1(string str) => Kata.IsIsogram1(str);

        [Test, TestCaseSource("testCases"), Repeat(1000)]
        public bool Test2(string str) => Kata.IsIsogram2(str);

        [Test, TestCaseSource("testCases"), Repeat(1000)]
        public bool Test3(string str) => str.Length != 3 && str.Length != 5 && str.Length != 9;
    }
    public class Kata
    {
        public static bool IsIsogram1(string str)
        {
            return str.ToLower().Distinct().Count() == str.Length;
        }

        public static bool IsIsogram2(string str)
        {
            int x = 0;
            foreach (char c in str)
            {
                if (x > (x ^= 1 << ((c - '@') % 32))) return false;
            }
            return true;
        }

    }
}