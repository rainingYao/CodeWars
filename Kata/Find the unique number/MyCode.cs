namespace FindTheUniqueNumber
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class SolutionTest
    {
        [TestCase(new[] { 0, 0, 1, 0 }, ExpectedResult = 1)]
        [TestCase(new[] { 1, 2, 2, 2 }, ExpectedResult = 1)]
        [TestCase(new[] { -2, 2, 2, 2 }, ExpectedResult = -2)]
        [TestCase(new[] { -3, -3, 0, -3 }, ExpectedResult = 0)]
        [TestCase(new[] { 11, 11, 14, 11, 11 }, ExpectedResult = 14)]
        public int BaseTest(IEnumerable<int> numbers)
        {
            return Kata.GetUnique(numbers);
        }

        [Test]
        public void RandomTest()
        {
            for (var i = 10000; i < 10020; i++)
            {
                var arr = Gen(i);
                Assert.AreEqual(InnerSolution(arr), Kata.GetUnique(arr));
            }
        }

        private IEnumerable<int> Gen(int max)
        {
            var number = new Random().Next(max);
            var count = new Random().Next(3, 20);
            var unique = new Random().Next(max);

            while (unique == number)
            {
                unique = new Random().Next(max);
            }

            var list = new List<int>();
            for (var i = 0; i < count; i++)
            {
                list.Add(number);
            }

            list[new Random().Next(count - 1)] = unique;

            return list;
        }

        private int InnerSolution(IEnumerable<int> numbers)
        {
            var tmp = numbers.OrderBy(n => n).ToList();
            return tmp[0] == tmp[1] ? tmp[tmp.Count - 1] : tmp[0];
        }
    }

    public class Kata
    {
        public static int GetUnique(IEnumerable<int> numbers)
        {
            return numbers.First(n => numbers.Count(c => c == n) == 1);
        }
    }
}
