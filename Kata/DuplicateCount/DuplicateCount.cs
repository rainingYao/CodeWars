using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class DuplicateCount
{
    [Test]
    public void DuplicateCountTests()
    {
        Assert.AreEqual(0, Kata.DuplicateCount(""));
        Assert.AreEqual(0, Kata.DuplicateCount("abcde"));
        Assert.AreEqual(2, Kata.DuplicateCount("aabbcde"));
        Assert.AreEqual(2, Kata.DuplicateCount("aabBcde"), "should ignore case");
        Assert.AreEqual(1, Kata.DuplicateCount("Indivisibility"));
        Assert.AreEqual(2, Kata.DuplicateCount("Indivisibilities"), "characters may not be adjacent");
    }

    public static int Solution(string str)
    {
        str = String.Join("", str.ToLower().OrderBy(c => c));
        return Regex.Matches(str, @"(.)\1+").Count;
    }

    [Test]

    public void KataTests()
    {
        Assert.AreEqual(0, Kata.DuplicateCount(""));
        Assert.AreEqual(0, Kata.DuplicateCount("abcde"));
        Assert.AreEqual(2, Kata.DuplicateCount("aabbcde"));
        Assert.AreEqual(2, Kata.DuplicateCount("aabBcde"), "should ignore case");
        Assert.AreEqual(1, Kata.DuplicateCount("Indivisibility"));
        Assert.AreEqual(2, Kata.DuplicateCount("Indivisibilities"), "characters may not be adjacent");
    }

    [Test]
    public void RandomTests()
    {
        var random = new Random();
        string randomStr;
        for (int i = 0; i < 10; i++)
        {
            randomStr =
              String.Join("", Enumerable.Range(0, 20).Select((o, x) => (char)random.Next('a', 'z') + (char)random.Next('A', 'Z')));

            Assert.AreEqual(Solution(randomStr), Kata.DuplicateCount(randomStr));
        }
    }

    private static IEnumerable<TestCaseData> testCases
    {
        get
        {
            yield return new TestCaseData("").Returns(0);
            yield return new TestCaseData("abcde").Returns(0);
            yield return new TestCaseData("aabbcde").Returns(2);
            yield return new TestCaseData("aabBcde").Returns(2);
            yield return new TestCaseData("Indivisibility").Returns(1);
            yield return new TestCaseData("Indivisibilities").Returns(2);

            var random = new Random();
            string randomStr;
            for (int i = 0; i < 100; i++)
            {
                randomStr =
                  String.Join("", Enumerable.Range(0, 20).Select((o, x) => (char)random.Next('a', 'z') + (char)random.Next('A', 'Z')));

                yield return new TestCaseData(randomStr).Returns(Solution(randomStr));
            }
        }
    }

    [Test, TestCaseSource("testCases")]
    public int LinqCodeTests(string str) => Kata.DuplicateCount(str);

    [Test, TestCaseSource("testCases")]
    public int WhileCodeTests(string str) => Kata.WhileCode(str);

    [Test, TestCaseSource("testCases")]
    public int RegexCodeTests(string str) => Kata.RegexCode(str);

    [Test, TestCaseSource("testCases")]
    public int TestsA(string str) => Kata.A(str);

    [Test, TestCaseSource("testCases")]
    public int TestsB(string str) => Kata.B(str);

    [Test, TestCaseSource("testCases")]
    public int TestsC(string str) => Kata.C(str);

}

public class Kata
{
    /// Linq
    public static int DuplicateCount(string str)
    {
        return (from c in str.ToLower()
                group c by c
                into g
                where g.Count() > 1
                select 1).Sum();
    }

    /// While
    public static int WhileCode(string str)
    {
        int sum = 0;
        str = str.ToLower();
        while (str.Length > 0)
        {
            if (str.Length - (str = str.Replace(str[0].ToString(), "")).Length > 1) sum++;
        }
        return sum;
    }

    /// Regular Expresstion
    public static int RegexCode(string str)
    {
        str = String.Join("", str.ToLower().OrderBy(c => c));
        return Regex.Matches(str, @"(.)\1+").Count;
    }

    ///A clever solution
    public static int A(string str)
    {
        return str.ToUpper().GroupBy(s => s).Count(g => g.Count() > 1);
    }

    ///Other solution
    public static int B(string str)
    {
        return "1234567890abcdefghijklmnopqrstuvwxyz".Count(c => str.Length > str.ToLower().Replace(c.ToString(), "").Length + 1);
    }

    ///Other solution
    public static int C(string str)
    {
        str = str.ToLower();
        return str.Distinct().Count(c => str.Count(d => c == d) > 1);
    }

}