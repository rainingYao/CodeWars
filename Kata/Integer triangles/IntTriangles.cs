namespace IntegerTriangles
{
    using System;
    using NUnit.Framework;
    using static System.Linq.Enumerable;
    using static System.Math;

    [TestFixture]
    public static class IntTrianglesTests
    {
        private static void testing(int actual, int expected)
        {
            Assert.AreEqual(expected, actual);
        }
        public static void tests(int[] list1, int[] results)
        {
            for (int i = 0; i < list1.Length; i++)
                testing(IntTriangles.GiveTriang(list1[i]), results[i]);
            return;
        }
        [Test]
        public static void test1()
        {
            Console.WriteLine("Basic Tests");
            int[] list1 = new int[] { 5, 15, 30, 50, 80, 90, 100, 150, 180, 190, 1000, 2000, 10000 };
            int[] results = new int[] { 0, 1, 3, 5, 11, 13, 14, 25, 32, 35, 290, 672, 4416 };
            tests(list1, results);
        }
        [Test]
        public static void test2()
        {
            Console.WriteLine("Intermediate tests");
            int[] list1 = new int[] { 350, 480, 520, 805, 960, 1200, 1400, 1500, 1800, 2000 };
            int[] results = new int[] { 79, 119, 129, 222, 279, 366, 441, 476, 595, 672 };
            tests(list1, results);
        }
        [Test]
        public static void test3()
        {
            Console.WriteLine("Bigger tests");
            int[] list1 = new int[] { 2500, 2800, 2950, 3206, 3420 };
            int[] results = new int[] { 878, 1005, 1068, 1179, 1272 };
            tests(list1, results);
        }
        //-----------------------
        private static Random rnd = new Random();
        public static int GiveTriangSol(int per)
        {
            int cnt = 0; int a = 3;
            while (a < per)
            {
                if (2 * a > per) break;
                int b = a;
                while (b < per)
                {
                    if (a + 2 * b > per) break;
                    double c = Math.Sqrt(a * a + a * b + b * b);
                    if ((c % 1 == 0) && (a + b + c <= per))
                        cnt++;
                    b++;
                }
                a++;
            }
            return cnt;
        }
        //-----------------------
        public static void wTests()
        {
            for (int i = 0; i < 10; i++)
            {
                int n = rnd.Next(100, 8000);
                testing(IntTriangles.GiveTriang(n), GiveTriangSol(n));
            }
        }
        [Test]
        public static void RandomTests()
        {
            Console.WriteLine("Random Tests ******* GiveTriang");
            wTests();
        }
        [Test]
        public static void LinqTest()
        {
            Assert.AreEqual(4416, IntTriangles.LinqGiveTriang(10000));
        }
    }

    public class IntTriangles
    {
        public static int GiveTriang(int per)
        {
            int sum = 0;
            for (int a = 1; a < per * 0.3; a++)
            {
                for (int b = a + 1; a + b < per * 0.6; b++)
                {
                    int s = a * a + a * b + b * b;
                    int c = (int)Math.Sqrt(s);
                    if (s == c * c && a + b + c <= per)
                        sum++;
                }
            }
            return sum;
        }

        public static int LinqGiveTriang(int p)
            => Range(3, p / 3).SelectMany(a => Range(a + 1, p).Select(b => p - a - b - Sqrt(a * a + b * b + a * b)).TakeWhile(x => x >= 0)).Count(x => x % 1 == 0);
    }
}
