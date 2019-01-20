namespace IntegerDepth
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void SampleTest1()
        {
            Assert.AreEqual(12, Kata.ComputeDepth(8));
        }

        [Test]
        public void EdgeCase1()
        {
            Assert.AreEqual(10, Kata.ComputeDepth(1));
        }

        [Test]
        public void EdgeCase2()
        {
            Assert.AreEqual(10, Kata.ComputeDepth(7));
        }

        [Test]
        public void EdgeCase3()
        {
            Assert.AreEqual(12, Kata.ComputeDepth(8));
        }

        [Test]
        public void EdgeCase4()
        {
            Assert.AreEqual(8, Kata.ComputeDepth(13));
        }

        [Test]
        public void EdgeCase5()
        {
            Assert.AreEqual(36, Kata.ComputeDepth(25));
        }

        [Test]
        public void EdgeCase6()
        {
            Assert.AreEqual(9, Kata.ComputeDepth(42));
        }

        private static int ComputeDepthPrivately(int n)
        {
            var f = new HashSet<char>();
            var d = 0;

            while (f.Count < 10)
            {
                var value = (n * ++d).ToString();
                foreach (char c in value)
                    if (!f.Contains(c))
                        f.Add(c);
            }

            return d;
        }

        [Test]
        public void RandomTests()
        {
            var random = new Random();
            for (int i = 0; i < 100; i++)
            {
                var e = random.Next(1, 501);
                var expected = ComputeDepthPrivately(e);
                var actual = Kata.ComputeDepth(e);
                Assert.AreEqual(expected, actual);
            }
        }
    }

    public class Kata
    {

        public static int ComputeDepth(int n)
        {
            string all = "0123456789";
            int i = 1;
            for (; all != ""; i++)
                foreach (char c in (n * i).ToString())
                    all = all.Replace(c.ToString(), "");
            return i - 1;
        }

    }
}