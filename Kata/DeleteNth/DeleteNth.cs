namespace DeleteNth
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class DeleteNthTests
    {
        [Test]
        public void TestSimple()
        {
            var expected = new int[] { 20, 37, 21 };

            var actual = Kata.DeleteNth(new int[] { 20, 37, 20, 21 }, 1);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void TestSimple2()
        {
            var expected = new int[] { 1, 1, 3, 3, 7, 2, 2, 2 };

            var actual = Kata.DeleteNth(new int[] { 1, 1, 3, 3, 7, 2, 2, 2, 2 }, 3);

            CollectionAssert.AreEqual(expected, actual);
        }

        const int TESTS = 20;
        const int MOTIVES = 10;

        [Test]
        public void TestRandom()
        {
            List<int[]> tests = new List<int[]>();
            Random rand = new Random();

            for (var x = 0; x < TESTS; x++)
            {
                int[] motives = new int[MOTIVES];

                for (var y = 0; y < MOTIVES; y++)
                {
                    motives[y] = rand.Next(3) + 1;
                }

                tests.Add(motives);
            }

            foreach (var test in tests)
            {
                int max = rand.Next(3) + 1;
                var expected = Solve(test, max);
                var actual = Kata.DeleteNth(test, max);

                Console.WriteLine(
                  String.Format("([{0}], {1}) \n-  Expected: {2} Actual: {3}",
                    String.Join(",", test),
                    max,
                    String.Join(",", expected),
                    String.Join(",", actual)));

                CollectionAssert.AreEqual(expected, actual);
            }
        }

        private static int[] Solve(int[] arr, int x)
        {
            var cache = new System.Collections.Generic.Dictionary<int, int>();

            return arr.Where(n =>
            {
                int count = cache.ContainsKey(n) ? cache[n] : 0;
                cache[n] = count + 1;
                return cache[n] <= x;
            }).ToArray();
        }
    }

    class Kata
    {
        public static int[] DeleteNth(int[] arr, int x)
        {
            return arr.Where((t, i) => arr.Take(i + 1).Count(s => s == t) <= x).ToArray();
        }
    }
}
