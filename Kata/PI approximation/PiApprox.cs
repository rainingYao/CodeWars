namespace PIApproximation
{
    using System;
    using NUnit.Framework;
    using System.Collections;

    [TestFixture]
    public class PiApproxTests
    {
        [Test]
        public void Test1()
        {
            ArrayList r = PiApprox.iterPi(0.1);
            ArrayList c = new ArrayList { 10, 3.0418396189 };
            Assert.AreEqual(c, r);
        }
        [Test]
        public void Test2()
        {
            ArrayList r = PiApprox.iterPi(0.01);
            ArrayList c = new ArrayList { 100, 3.1315929036 };
            Assert.AreEqual(c, r);
        }
        [Test]
        public void Test3()
        {
            ArrayList r = PiApprox.iterPi(0.001);
            ArrayList c = new ArrayList { 1000, 3.1405926538 };
            Assert.AreEqual(c, r);
        }
        [Test]
        public void Test4()
        {
            ArrayList r = PiApprox.iterPi(0.0001);
            ArrayList c = new ArrayList { 10000, 3.1414926536 };
            Assert.AreEqual(c, r);
        }
        [Test]
        public void Test5()
        {
            ArrayList r = PiApprox.iterPi(0.005);
            ArrayList c = new ArrayList { 200, 3.1365926848 };
            Assert.AreEqual(c, r);
        }
        [Test]
        public void Test6()
        {
            ArrayList r = PiApprox.iterPi(0.0000001);
            ArrayList c = new ArrayList { 10000001, 3.1415927536 };
            Assert.AreEqual(c, r);
        }
        [Test]
        public void Test7()
        {
            ArrayList r = PiApprox.iterPi(0.000005);
            ArrayList c = new ArrayList { 200001, 3.1415976536 };
            Assert.AreEqual(c, r);
        }
        [Test]
        public void Test8()
        {
            ArrayList r = PiApprox.iterPi(0.5);
            ArrayList c = new ArrayList { 2, 2.6666666667 };
            Assert.AreEqual(c, r);
        }

    }

    public class PiApprox
    {
        public static ArrayList iterPi(double epsilon)
        {
            int i = 1;
            double pi4 = 1;
            while (Math.Abs(pi4 * 4 - Math.PI) > epsilon)
                pi4 += ((++i % 2) * 2 - 1d) / (2 * i - 1);
            return new ArrayList { i, Math.Round(pi4 * 4, 10) };
        }
    }
}
