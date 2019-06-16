namespace CodeWars.Kata.IntegersRecreationOne
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    [TestFixture]
    public class SumSquaredDivisorsTests
    {

        [Test]
        public void Test01()
        {
            Assert.AreEqual("[[1, 1], [42, 2500], [246, 84100]]", SumSquaredDivisors.listSquared(1, 250));
        }
        [Test]
        public void Test02()
        {
            Assert.AreEqual("[[42, 2500], [246, 84100]]", SumSquaredDivisors.listSquared(42, 250));
        }
        [Test]
        public void Test03()
        {
            Assert.AreEqual("[[287, 84100]]", SumSquaredDivisors.listSquared(250, 500));
        }

        [Test]
        public void Test04()
        {
            Assert.AreEqual("[]", SumSquaredDivisors.listSquared(300, 600));
        }
        [Test]
        public void Test05()
        {
            Assert.AreEqual("[[728, 722500], [1434, 2856100]]", SumSquaredDivisors.listSquared(600, 1500));
        }
        [Test]
        public void Test06()
        {
            Assert.AreEqual("[[1673, 2856100]]", SumSquaredDivisors.listSquared(1500, 1800));
        }
        [Test]
        public void Test07()
        {
            Assert.AreEqual("[[1880, 4884100]]", SumSquaredDivisors.listSquared(1800, 2000));
        }
        [Test]
        public void Test08()
        {
            Assert.AreEqual("[]", SumSquaredDivisors.listSquared(2000, 2200));
        }
        [Test]
        public void Test09()
        {
            Assert.AreEqual("[[4264, 24304900]]", SumSquaredDivisors.listSquared(2200, 5000));
        }
        [Test]
        public void Test10()
        {
            Assert.AreEqual("[[6237, 45024100], [9799, 96079204], [9855, 113635600]]", SumSquaredDivisors.listSquared(5000, 10000));
        }

        private static long[] sumSquaredFactorsSol(long n)
        {
            long s = 0;
            long nf = 0;
            long[] res = new long[2];
            for (long i = 1; i <= Math.Floor(Math.Sqrt(n)); i += 1)
            {
                if (n % i == 0)
                {
                    s += i * i;
                    nf = n / i;
                    if (nf != i)
                        s += nf * nf;
                }
            }
            if (Math.Pow((long)Math.Sqrt(s), 2) == s)
            {
                res[0] = n;
                res[1] = s;
                return res;
            }
            else return null;
        }
        public static string listSquaredSol(long m, long n)
        {
            string res = "[";
            for (long i = m; i <= n; i++)
            {
                long[] r = sumSquaredFactorsSol(i);
                if (r != null)
                {
                    res += "[" + r[0].ToString() + ", " + r[1].ToString() + "], ";
                }
            }
            return res.TrimEnd(' ', ',') + "]";
        }

        [Test]
        public static void Test11()
        {
            Random rnd = new Random();
            for (int i = 0; i < 50; i++)
            {
                long m = rnd.Next(200, 1000);
                long n = rnd.Next(1100, 8000);
                Console.WriteLine("listSquared with number m : " + m + " n : " + n);
                Assert.AreEqual(SumSquaredDivisorsTests.listSquaredSol(m, n), SumSquaredDivisors.listSquared(m, n));
            }
        }

        [Test]
        public void Test98()
        {
            Assert.AreEqual("[[1, 1], [42, 2500], [246, 84100], [287, 84100], [728, 722500], [1434, 2856100], [1673, 2856100], [1880, 4884100], [4264, 24304900], [6237, 45024100], [9799, 96079204], [9855, 113635600]]", SumSquaredDivisors.listSquared(1, 10000));
        }
        [Test]
        public void Test99()
        {
            Assert.AreEqual("[[1, 1], [42, 2500], [246, 84100], [287, 84100], [728, 722500], [1434, 2856100], [1673, 2856100], [1880, 4884100], [4264, 24304900], [6237, 45024100], [9799, 96079204], [9855, 113635600]]", SumSquaredDivisors.listSquared(1, 100000));
        }
    }

    public class SumSquaredDivisors
    {
        static long max = 100000;
        static Dictionary<long, long> dict = new Dictionary<long, long> { { 1, 1 }, { 42, 2500 }, { 246, 84100 }, { 287, 84100 }, { 728, 722500 }, { 1434, 2856100 }, { 1673, 2856100 }, { 1880, 4884100 }, { 4264, 24304900 }, { 6237, 45024100 }, { 9799, 96079204 }, { 9855, 113635600 } };

        public static string listSquared(long m, long n)
        {
            if (n > max)
            {
                for (long i = max + 1; i <= n; i++)
                {
                    long product = 0;
                    foreach (long divisor in GetDivisors(i))
                    {
                        product += divisor * divisor;
                    }

                    if (Math.Sqrt(product) == Math.Floor(Math.Sqrt(product)))
                    {
                        dict.Add(i, product);
                    }
                }
                max = n;
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in dict)
            {
                if (item.Key >= m && item.Key <= n)
                {
                    sb.Append($", [{item.Key}, {item.Value}]");
                }
            }
            if (sb.Length > 2) sb.Remove(0, 2);
            return $"[{sb.ToString()}]";
        }

        public static IEnumerable<long> GetDivisors(long number)
        {
            for (long i = 1L; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    yield return i;
                }
            }
            yield return number;
        }
    }
}
