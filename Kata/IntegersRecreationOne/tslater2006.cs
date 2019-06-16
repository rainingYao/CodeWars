namespace IntegersRecreationOne.tslater2006
{
    using System;
    using System.Linq;
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
            Assert.AreEqual("[[1, 1], [42, 2500], [246, 84100], [287, 84100], [728, 722500], [1434, 2856100], [1673, 2856100], [1880, 4884100], [4264, 24304900], [6237, 45024100], [9799, 96079204], [9855, 113635600], [18330, 488410000], [21352, 607622500], [21385, 488410000], [24856, 825412900], [36531, 1514610724], [39990, 2313610000], [46655, 2313610000], [57270, 4747210000], [66815, 4747210000], [92664, 13011964900]]", SumSquaredDivisors.listSquared(1, 100000));
        }
    }

    public class SumSquaredDivisors
    {
        public static string listSquared(long m, long n)
        {
            return "[" + string.Join(", ", Enumerable.Range((int)m, (int)(n - m)).Where(x => Math.Sqrt(Enumerable.Range(1, (int)Math.Sqrt(x)).Where(p => (((double)x / p) % 1) == 0).Select(p => new[] { p * p, (x / p) * (x / p) }).Sum(p => p[0] == p[1] ? p[0] : p.Sum())) % 1 == 0).Select(z => z).Zip(Enumerable.Range((int)m, (int)(n - m)).Select(x => Enumerable.Range(1, (int)Math.Sqrt(x)).Where(p => (((double)x / p) % 1) == 0).Select(p => new[] { p * p, (x / p) * (x / p) }).Sum(p => p[0] == p[1] ? p[0] : p.Sum())).Where(p => Math.Sqrt(p) % 1 == 0), (a, b) => new[] { a, b }).Select(p => "[" + p[0] + ", " + p[1] + "]").ToArray()) + "]";
        }
    }
}
