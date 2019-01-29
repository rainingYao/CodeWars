namespace SumByFactors
{
    using System;
    using System.Linq;
    using NUnit.Framework;
    using System.Text;

    [TestFixture]
    public class SumOfDividedTests
    {

        [Test]
        public void Test1()
        {
            int[] lst = new int[] { -29804, -4209, -28265, -72769, -31744 };
            Assert.AreEqual("(2 -61548)(3 -4209)(5 -28265)(23 -4209)(31 -31744)(53 -72769)(61 -4209)(1373 -72769)(5653 -28265)(7451 -29804)", SumOfDivided.sumOfDivided(lst));
        }
    }

    public class SumOfDivided
    {
        public static string sumOfDivided(int[] lst)
        {
            StringBuilder ans = new StringBuilder();//The Answer.
            int[] cpy = lst.Select(x => Math.Abs(x)).ToArray();//Copy array for calculating all factors.
            bool fac = false;//Mark when i is a factor.
            long sum = 0;//Record sum.
            for (int j = 0; j < lst.Length; j++)
            {
                if (cpy[j] % 2 == 0)
                {
                    fac = true;
                    sum += lst[j];
                    while (cpy[j] % 2 == 0) cpy[j] /= 2;//Divide all i(factor)
                }
            }
            if (fac) ans.Append("(" + 2 + " " + sum + ")");
            for (int i = 3; cpy.Count(x => x > 1) > 0; i += 2)//Divide all factors until only 1 is left.
            {
                fac = false;
                sum = 0;
                for (int j = 0; j < lst.Length; j++)
                {
                    if (cpy[j] % i == 0)
                    {
                        fac = true;
                        sum += lst[j];
                        while (cpy[j] % i == 0) cpy[j] /= i;//Divide all i(factor)
                    }
                }
                if (fac) ans.Append("(" + i + " " + sum + ")");
            }
            return ans.ToString();
        }

        /// <summary>
        /// 辗转相除法求gcd
        /// [Sum by Factors]暂未用到
        /// </summary>
        public static int gcd(int a, int b)
        {
            return b == 0 ? a : gcd(b, a % b);
        }
    }
}