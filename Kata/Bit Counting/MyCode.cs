﻿namespace BitCounting.MyCode
{
    using System;

    public class Kata
    {
        public static int CountBits(int n)
        {
            int count = 0;
            while (n > 0)
            {
                if (n % 2 == 1) count++;
                n /= 2;
            }
            return count;
        }
    }
}
namespace BitCounting.AllTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using MyCode;

    [TestFixture]
    public class BitCounting
    {
        [Test]
        public void CountBits()
        {
            Assert.AreEqual(0, Kata.CountBits(0));
            Assert.AreEqual(1, Kata.CountBits(4));
            Assert.AreEqual(3, Kata.CountBits(7));
            Assert.AreEqual(2, Kata.CountBits(9));
            Assert.AreEqual(2, Kata.CountBits(10));
            Assert.AreEqual(3, Kata.CountBits(26));
            Assert.AreEqual(14, Kata.CountBits(77231418));
            Assert.AreEqual(11, Kata.CountBits(12525589));
            Assert.AreEqual(8, Kata.CountBits(3811));
            Assert.AreEqual(17, Kata.CountBits(392902058));
            Assert.AreEqual(3, Kata.CountBits(1044));
            Assert.AreEqual(10, Kata.CountBits(10030245));
            Assert.AreEqual(16, Kata.CountBits(183337941));
            Assert.AreEqual(14, Kata.CountBits(20478766));
            Assert.AreEqual(9, Kata.CountBits(103021));
            Assert.AreEqual(6, Kata.CountBits(287));
            Assert.AreEqual(15, Kata.CountBits(115370965));
            Assert.AreEqual(5, Kata.CountBits(31));
            Assert.AreEqual(7, Kata.CountBits(417862));
            Assert.AreEqual(12, Kata.CountBits(626031));
            Assert.AreEqual(4, Kata.CountBits(89));
            Assert.AreEqual(10, Kata.CountBits(674259));
        }
    }
}
