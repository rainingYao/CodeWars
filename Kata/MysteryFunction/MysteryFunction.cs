namespace MysteryFunction.rainingYao.First
{
    using System;
    using NUnit.Framework;

    public class MysteryFunction
    {
        class T
        {
            int N;
            public T(int N)
            {
                this.N = N;
            }
            public long this[long n]
            {
                get
                {
                    if (N <= 1) return n;
                    else
                    {
                        long total = (int)Math.Pow(2, N);
                        long half = total / 2;
                        if (n < half)
                        {
                            return new T(N - 1)[n];
                        }
                        else
                        {
                            return new T(N - 1)[total - n - 1] + half;
                        }
                    }
                }
            }
        }

        class S
        {
            int N;
            public S(int N)
            {
                this.N = N;
            }
            public long this[long n]
            {
                get
                {
                    if (N <= 1) return n;
                    else
                    {
                        long total = (int)Math.Pow(2, N);
                        long half = total / 2;
                        int len = (int)Math.Log(n - half, 2) + 1;
                        return total - new S(len)[n - half] - 1;
                    }
                }
            }
        }

        public static long Mystery(long n)
        {
            int N = (int)Math.Log(n, 2) + 1;
            return new T(N)[n];
        }

        public static long MysteryInv(long n)
        {
            int N = (int)Math.Log(n, 2) + 1;
            return new S(N)[n];
        }

        public static string NameOfMystery()
        {
            return "kiku";
        }
    }

    public class MysteryFunctionTest
    {
        [Test]
        public void MysteryTest()
        {
            Assert.AreEqual(5, MysteryFunction.Mystery(6), "mystery(6) ");
            Assert.AreEqual(13, MysteryFunction.Mystery(9), "mystery(9) ");
            Assert.AreEqual(26, MysteryFunction.Mystery(19), "mystery(19) ");
        }

        [Test]
        public void MysteryInvTest()
        {
            Assert.AreEqual(6, MysteryFunction.MysteryInv(5), "mysteryInv(5)");
            Assert.AreEqual(9, MysteryFunction.MysteryInv(13), "mysteryInv(13)");
            Assert.AreEqual(19, MysteryFunction.MysteryInv(26), "mysteryInv(26)");
        }
    }
}

namespace MysteryFunction.rainingYao.Second
{
    using System;
    using NUnit.Framework;

    public class MysteryFunction
    {
        public static long Mystery(long n)
        {
            if (n <= 1) return n;
            int N = (int)Math.Log(n, 2);
            long half = (long)Math.Pow(2, N);
            return half + Mystery(half + half - n - 1);
        }

        public static long MysteryInv(long n)
        {
            if (n <= 1) return n;
            int N = (int)Math.Log(n, 2);
            long half = (long)Math.Pow(2, N);
            int len = (int)Math.Log(n - half, 2) + 1;
            return half + half - MysteryInv(n - half) - 1;
        }

        public static string NameOfMystery()
        {
            return "gray code";
        }
    }

    public class MysteryFunctionTest
    {
        [Test]
        public void MysteryTest()
        {
            Assert.AreEqual(5, MysteryFunction.Mystery(6), "mystery(6) ");
            Assert.AreEqual(13, MysteryFunction.Mystery(9), "mystery(9) ");
            Assert.AreEqual(26, MysteryFunction.Mystery(19), "mystery(19) ");
            int x = 10;
            Assert.AreEqual((int)Math.Pow(2, x), MysteryFunction.Mystery((int)Math.Pow(2, x + 1) - 1), string.Format("mystery({0}) ", (int)Math.Pow(2, x + 1) - 1));
            Assert.AreEqual(41058636170415, MysteryFunction.Mystery(63337240397621), "mystery(63337240397621) ");
        }

        [Test]
        public void MysteryInvTest()
        {
            Assert.AreEqual(6, MysteryFunction.MysteryInv(5), "mysteryInv(5)");
            Assert.AreEqual(9, MysteryFunction.MysteryInv(13), "mysteryInv(13)");
            Assert.AreEqual(19, MysteryFunction.MysteryInv(26), "mysteryInv(26)");
            int x = 10;
            Assert.AreEqual((int)Math.Pow(2, x + 1) - 1, MysteryFunction.MysteryInv((int)Math.Pow(2, x)), string.Format("mysteryInv({0}) ", (int)Math.Pow(2, x)));
            Assert.AreEqual(50320920207254, MysteryFunction.MysteryInv(65036019806301), "mysteryInv(65036019806301)");
        }

        [Test]
        public void RandomSmallNumbersTest()
        {
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                long n = r.Next(1000);
                Assert.AreEqual(n ^ (n >> 1), MysteryFunction.Mystery(n), $"mystery({n})");
            }
        }

        [Test]
        public void RandomInvSmallNumbersTest()
        {
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                long n = r.Next(1000);
                Assert.AreEqual(MysteryInv(n), MysteryFunction.MysteryInv(n), $"mysteryInv({n})");
            }
        }

        [Test]
        public void RandomBigNumbersTest()
        {
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                long n = (long)(r.NextDouble() * 999999999999999L);
                Assert.AreEqual(n ^ (n >> 1), MysteryFunction.Mystery(n), $"mystery({n})");
            }
        }

        [Test]
        public void RandomInvBigNumbersTest()
        {
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                long n = (long)(r.NextDouble() * 999999999999999L);
                Assert.AreEqual(MysteryInv(n), MysteryFunction.MysteryInv(n), $"mysteryInv({n})");
            }
        }

        [Test]
        public void FunctionNameTest()
        {
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                long n = r.Next(1000);
                Assert.AreEqual((n ^ (n >> 1)), MysteryFunction.Mystery(n), "No,no,no! Find the function before you can see it in the tests ;)");
            }
            Assert.AreEqual("gray code", MysteryFunction.NameOfMystery().ToLower());
        }

        private static long MysteryInv(long n)
        {
            long mask;
            for (mask = n >> 1; mask != 0; mask >>= 1)
                n ^= mask;
            return n;
        }
    }
}

namespace MysteryFunction.rainingYao.GrayCode
{
    using System;
    using NUnit.Framework;

    public class MysteryFunction
    {
        public static long Mystery(long n)
        {
            return n ^ (n >> 1);
        }

        public static long MysteryInv(long n)
        {
            if (n <= 1) return n;
            int N = (int)Math.Log(n, 2);
            long half = (long)Math.Pow(2, N);
            int len = (int)Math.Log(n - half, 2) + 1;
            return half + half - MysteryInv(n - half) - 1;
        }

        public static string NameOfMystery()
        {
            return "gray code";
        }
    }

    public class MysteryFunctionTest
    {
        [Test]
        public void MysteryTest()
        {
            Assert.AreEqual(5, MysteryFunction.Mystery(6), "mystery(6) ");
            Assert.AreEqual(13, MysteryFunction.Mystery(9), "mystery(9) ");
            Assert.AreEqual(26, MysteryFunction.Mystery(19), "mystery(19) ");
            int x = 10;
            Assert.AreEqual((int)Math.Pow(2, x), MysteryFunction.Mystery((int)Math.Pow(2, x + 1) - 1), string.Format("mystery({0}) ", (int)Math.Pow(2, x + 1) - 1));
            Assert.AreEqual(41058636170415, MysteryFunction.Mystery(63337240397621), "mystery(63337240397621) ");
        }

        [Test]
        public void MysteryInvTest()
        {
            Assert.AreEqual(6, MysteryFunction.MysteryInv(5), "mysteryInv(5)");
            Assert.AreEqual(9, MysteryFunction.MysteryInv(13), "mysteryInv(13)");
            Assert.AreEqual(19, MysteryFunction.MysteryInv(26), "mysteryInv(26)");
            int x = 10;
            Assert.AreEqual((int)Math.Pow(2, x + 1) - 1, MysteryFunction.MysteryInv((int)Math.Pow(2, x)), string.Format("mysteryInv({0}) ", (int)Math.Pow(2, x)));
            Assert.AreEqual(50320920207254, MysteryFunction.MysteryInv(65036019806301), "mysteryInv(65036019806301)");
        }

        [Test]
        public void RandomSmallNumbersTest()
        {
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                long n = r.Next(1000);
                Assert.AreEqual(n ^ (n >> 1), MysteryFunction.Mystery(n), $"mystery({n})");
            }
        }

        [Test]
        public void RandomInvSmallNumbersTest()
        {
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                long n = r.Next(1000);
                Assert.AreEqual(MysteryInv(n), MysteryFunction.MysteryInv(n), $"mysteryInv({n})");
            }
        }

        [Test]
        public void RandomBigNumbersTest()
        {
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                long n = (long)(r.NextDouble() * 999999999999999L);
                Assert.AreEqual(n ^ (n >> 1), MysteryFunction.Mystery(n), $"mystery({n})");
            }
        }

        [Test]
        public void RandomInvBigNumbersTest()
        {
            Random r = new Random();
            for (int i = 0; i < 20; i++)
            {
                long n = (long)(r.NextDouble() * 999999999999999L);
                Assert.AreEqual(MysteryInv(n), MysteryFunction.MysteryInv(n), $"mysteryInv({n})");
            }
        }

        [Test]
        public void FunctionNameTest()
        {
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                long n = r.Next(1000);
                Assert.AreEqual((n ^ (n >> 1)), MysteryFunction.Mystery(n), "No,no,no! Find the function before you can see it in the tests ;)");
            }
            Assert.AreEqual("gray code", MysteryFunction.NameOfMystery().ToLower());
        }

        private static long MysteryInv(long n)
        {
            long mask;
            for (mask = n >> 1; mask != 0; mask >>= 1)
                n ^= mask;
            return n;
        }
    }
}
