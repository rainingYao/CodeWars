namespace MysteryFunction.rainingYao
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
                        int total = (int)Math.Pow(2, N);
                        int half = total / 2;
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
                        int total = (int)Math.Pow(2, N);
                        int half = total / 2;
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
