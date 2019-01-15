namespace StepInPrimes
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;

    [TestFixture]
    public static class StepInPrimesTests
    {
        [Test]
        public static void test0()
        {
            Assert.AreEqual(new int[] { 101, 103 }, StepInPrimes.Step(2, 100, 110));
            Assert.AreEqual(new int[] { 103, 107 }, StepInPrimes.Step(4, 100, 110));
            Assert.AreEqual(new int[] { 101, 107 }, StepInPrimes.Step(6, 100, 110));
            Assert.AreEqual(new int[] { 359, 367 }, StepInPrimes.Step(8, 300, 400));
            Assert.AreEqual(new int[] { 307, 317 }, StepInPrimes.Step(10, 300, 400));
        }

        private static Random rnd = new Random();

        [Test]
        public static void test1()
        {
            Assert.AreEqual(new int[] { 101, 103 }, StepInPrimes.Step(2, 100, 110));
            Assert.AreEqual(new int[] { 103, 107 }, StepInPrimes.Step(4, 100, 110));
            Assert.AreEqual(new int[] { 101, 107 }, StepInPrimes.Step(6, 100, 110));
            Assert.AreEqual(new int[] { 359, 367 }, StepInPrimes.Step(8, 300, 400));
            Assert.AreEqual(new int[] { 307, 317 }, StepInPrimes.Step(10, 300, 400));

            Assert.AreEqual(new int[] { 30109, 30113 }, StepInPrimes.Step(4, 30000, 100000));
            Assert.AreEqual(new int[] { 30091, 30097 }, StepInPrimes.Step(6, 30000, 100000));
            Assert.AreEqual(new int[] { 30089, 30097 }, StepInPrimes.Step(8, 30000, 100000));
            Assert.AreEqual(null, StepInPrimes.Step(11, 30000, 100000));
            Assert.AreEqual(new int[] { 10000139, 10000141 }, StepInPrimes.Step(2, 10000000, 11000000));

            Assert.AreEqual(new int[] { 1321, 1373 }, StepInPrimes.Step(52, 1300, 150000));
            Assert.AreEqual(new int[] { 4909, 4919 }, StepInPrimes.Step(10, 4900, 5000));
            Assert.AreEqual(new int[] { 4903, 4933 }, StepInPrimes.Step(30, 4900, 5000));
            Assert.AreEqual(new int[] { 4931, 4933 }, StepInPrimes.Step(2, 4900, 5000));
            Assert.AreEqual(new int[] { 104087, 104089 }, StepInPrimes.Step(2, 104000, 105000));

            Assert.AreEqual(null, StepInPrimes.Step(2, 4900, 4919));
            Assert.AreEqual(null, StepInPrimes.Step(7, 4900, 4919));
            Assert.AreEqual(new int[] { 30133, 30137 }, StepInPrimes.Step(4, 30115, 100000));
            Assert.AreEqual(new int[] { 30319, 30323 }, StepInPrimes.Step(4, 30140, 100000));
            Assert.AreEqual(new int[] { 30109, 30113 }, StepInPrimes.Step(4, 30000, 30325));

        }
        //-----------------------
        private static Boolean PrimeSol(long n)
        {
            if (n == 2) return true;
            else if ((n < 2) || (n % 2 == 0)) return false;
            else
            {
                for (long i = 3; i <= Math.Sqrt(n); ++i)
                {
                    if (n % i == 0) return false;
                }
                return true;
            }
        }
        public static long[] StepSol(int g, long m, long n)
        {
            long[] res = new long[2];
            long i = m;
            while (i <= n - g)
            {
                if (PrimeSol(i) && PrimeSol(i + g))
                {
                    res[0] = i;
                    res[1] = i + g;
                    return res;
                }
                i++;
            }
            return null;
        }
        //-----------------------
        [Test]
        public static void RandomTest()
        {
            Console.WriteLine("Random Tests");
            for (int i = 0; i < 50; i++)
            {
                long n = 0;
                if (rnd.Next(0, 99) % 5 == 0)
                    n = (long)rnd.Next(1000, 2000);
                else n = (long)rnd.Next(100000, 1000000);
                Assert.AreEqual(StepSol(2, n, n + 1000), StepInPrimes.Step(2, n, n + 1000));
                Assert.AreEqual(StepSol(4, n, n + 1000), StepInPrimes.Step(4, n, n + 1000));
                Assert.AreEqual(StepSol(6, n, n + 1000), StepInPrimes.Step(6, n, n + 1000));
                Assert.AreEqual(StepSol(8, n, n + 1000), StepInPrimes.Step(8, n, n + 1000));
                Assert.AreEqual(StepSol(10, n, n + 100), StepInPrimes.Step(10, n, n + 100));
            }
        }
    }

    ///// .net 4.7
    //[TestFixture]
    //class YieldTest
    //{
    //    private static IEnumerable<TestCaseData> testCases
    //    {
    //        get
    //        {
    //            yield return new TestCaseData(2, 100, 110).Returns(new[] { 101L, 103L });
    //            yield return new TestCaseData(4, 100, 110).Returns(new[] { 103L, 107L });
    //            yield return new TestCaseData(6, 100, 110).Returns(new[] { 101L, 107L });
    //            yield return new TestCaseData(8, 300, 400).Returns(new[] { 359L, 367L });
    //            yield return new TestCaseData(10, 300, 400).Returns(new[] { 307L, 317L });
    //        }
    //    }

    //    [Test, TestCaseSource("testCases")]
    //    public long[] YieldTests(int g, long m, long n) => StepInPrimes.MyAnswer(g, m, n);

    //    [Test, TestCaseSource("testCases")]
    //    public long[] OneBestAnswer(int g, long m, long n) => StepInPrimes.OneBestAnswer(g, m, n);
    //}

    //可以隔着质数的解
    class StepInPrimes
    {
        public static long[] Step(int g, long m, long n)
        {
            return OneBestAnswer(g, m, n);
            //return MyAnswer(g, m, n);
        }

        public static long[] MyAnswer(int g, long m, long n)
        {
            if (m % 2 == 0) m++;
            while (m <= n)
            {
                if (IsPrime(m))
                {
                    long t = m + g;
                    if (t <= n && IsPrime(t))
                        return new[] { m, t };
                }
                m += 2;
            }
            return null;
        }

        public static bool IsPrime(long p)
        {
            for (long i = 3; i <= Math.Sqrt(p); i += 2)
            {
                if (p % i == 0) return false;
            }
            return p % 2 != 0;
        }

        public static long[] OneBestAnswer(int g, long m, long n)
        {
            var s = new bool[n + 1];
            for (long i = 2; i < s.Length; i++)
            {
                if (!s[i])
                {
                    if (i - g >= m && !s[i - g]) return new[] { i - g, i };
                    for (long j = i * i; j < s.Length; j += i)
                        s[j] = true;
                }
            }
            return null;
        }
    }

    ///// .net 4.7
    ///// 测试是否为质数 不是主要测试
    //[TestFixture]
    //class IsPrimeTest
    //{
    //    private static IEnumerable<TestCaseData> testCases
    //    {
    //        get
    //        {
    //            yield return new TestCaseData(361L).Returns(false);
    //            yield return new TestCaseData(30148L).Returns(false);
    //        }
    //    }

    //    [Test, TestCaseSource("testCases")]
    //    public bool Test(long p) => StepInPrimes.IsPrime(p);
    //}
}
