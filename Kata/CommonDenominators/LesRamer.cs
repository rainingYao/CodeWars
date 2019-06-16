namespace CommonDenominators.LesRamer
{
    using System;
    using System.Linq;
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
            var indices = Enumerable.Range(0, lst.GetLength(0));
            var d = indices.Aggregate(1L, (a, i) => a * lst[i, 1] / gcd(a, lst[i, 1]));
            return string.Concat(indices.Select(i => $"({d * lst[i, 0] / lst[i, 1]},{d})"));
        }

        private static long gcd(long a, long b) => b == 0 ? a : gcd(b, a % b);
    }
}
