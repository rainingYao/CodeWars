namespace PrimesInNumbers
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class PrimeDecompTests
    {
        [Test]
        public void Test1()
        {
            int lst = 7775460;
            Assert.AreEqual("(2**2)(3**3)(5)(7)(11**2)(17)", PrimeDecomp.factors(lst));
        }
        [Test]
        public void Test2()
        {
            int lst = 7919;
            Assert.AreEqual("(7919)", PrimeDecomp.factors(lst));
        }
        [Test]
        public void Test3()
        {
            int lst = 17 * 17 * 93 * 677;
            Assert.AreEqual("(3)(17**2)(31)(677)", PrimeDecomp.factors(lst));
        }
        [Test]
        public void Test4()
        {
            int lst = 933555431;
            Assert.AreEqual("(7537)(123863)", PrimeDecomp.factors(lst));
        }
        [Test]
        public void Test5()
        {
            int lst = 342217392;
            Assert.AreEqual("(2**4)(3)(11)(43)(15073)", PrimeDecomp.factors(lst));
        }
        [Test]
        public void Test6()
        {
            int lst = 123456789;
            Assert.AreEqual("(3**2)(3607)(3803)", PrimeDecomp.factors(lst));
        }
        [Test]
        public void Test7()
        {
            int lst = 987654321;
            Assert.AreEqual("(3**2)(17**2)(379721)", PrimeDecomp.factors(lst));
        }
    }

    public class PrimeDecomp
    {
        public static String factors(int lst)
        {
            string ans = "";
            for (int i = 2; lst > 1 && i <= lst; i++)
            {
                int j = 0;
                while (lst % i == 0)
                {
                    lst /= i;
                    j++;
                }
                if (j == 1) ans += $"({i})";
                else if (j > 1) ans += $"({i}**{j})";
            }
            return ans;
        }
    }
}