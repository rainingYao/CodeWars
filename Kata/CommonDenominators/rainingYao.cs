namespace CodeWars.Kata.CommonDenominators.rainingYao
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;

    [TestFixture]
    public class FractsTests
    {

        [Test]
        public void Test1()
        {

            long[,] lst = new long[,] { { 1, 2 }, { 1, 3 }, { 1, 4 } };
            Assert.AreEqual("(6,12)(4,12)(3,12)", Fracts.convertFrac(lst));

            lst = new long[,] { { 69, 130 }, { 87, 1310 }, { 3, 4 } };
            Assert.AreEqual("(18078,34060)(2262,34060)(25545,34060)", Fracts.convertFrac(lst));

            lst = new long[,] { };
            Assert.AreEqual("", Fracts.convertFrac(lst));

            lst = new long[,] { { 77, 130 }, { 84, 131 }, { 3, 4 } };
            Assert.AreEqual("(20174,34060)(21840,34060)(25545,34060)", Fracts.convertFrac(lst));

            lst = new long[,] { { 6, 13 }, { 187, 1310 }, { 31, 41 } };
            Assert.AreEqual("(322260,698230)(99671,698230)(527930,698230)", Fracts.convertFrac(lst));

            lst = new long[,] { { 8, 15 }, { 7, 111 }, { 4, 25 } };
            Assert.AreEqual("(1480,2775)(175,2775)(444,2775)", Fracts.convertFrac(lst));

            lst = new long[,] { { 1, 100 }, { 3, 1000 }, { 1, 2500 }, { 1, 20000 } };
            Assert.AreEqual("(200,20000)(60,20000)(8,20000)(1,20000)", Fracts.convertFrac(lst));

            lst = new long[,] { { 1, 1 }, { 3, 1 }, { 4, 1 }, { 5, 1 } };
            Assert.AreEqual("(1,1)(3,1)(4,1)(5,1)", Fracts.convertFrac(lst));

        }
    }

    public class Fracts
    {
        public static string convertFrac(long[,] lst)
        {
            ////最大公约数,乘积,最小公倍数
            //long gcd, product, lcm;
            //gcd = product = lcm = lst[0, 1];
            ////全部约分
            //for (int i = 0; i < lst.GetLength(0); i++)
            //{
            //    gcd = GCD(lst[i, 0], lst[i, 1]);
            //    lst[i, 0] /= gcd;
            //    lst[i, 1] /= gcd;
            //}
            ////求最大公约数
            //for (int i = 0; i < lst.GetLength(0) - 1; i++)
            //{
            //    gcd = GCD(gcd, lst[i + 1, 1]);
            //}
            ////求最小公倍数
            //for (int i = 0; i < lst.GetLength(0) - 1; i++)
            //{
            //    product *= lst[i + 1, 1];
            //    lcm *= lst[i + 1, 1]/gcd;
            //    double assert = lst[i + 1, 1] / gcd;
            //}

            long gcd = 0;
            int length = lst.GetLength(0);
            for (int i = 0; i < length - 1; i++)
            {
                gcd = GCD(lst[i, 1], lst[length - 1, 1]);
                long a = lst[i, 1] / gcd;
                long b = lst[length - 1, 1] / gcd;
                lst[length - 1, 0] *= a;
                lst[length - 1, 1] *= a;
                lst[i, 0] *= b;
                lst[i, 1] *= b;
            }
            for (int i = 0; i < length - 1; i++)
            {
                if (lst[i, 1] == lst[length - 1, 1]) continue;
                gcd = GCD(lst[i, 1], lst[length - 1, 1]);
                long b = lst[length - 1, 1] / gcd;
                lst[i, 0] *= b;
                lst[i, 1] *= b;
            }
            //拼接答案
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lst.GetLength(0); i++)
            {
                sb.Append("(").Append(lst[i, 0]).Append(",").Append(lst[i, 1]).Append(")");
            }
            return sb.ToString();
        }

        //求最大公约数
        public static long GCD(long a, long b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

        //求最小公倍数
        public static long LCM(long a, long b)
        {
            return a * b / GCD(b, a % b);
        }
    }
}
