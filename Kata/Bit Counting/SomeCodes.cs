namespace BitCounting.AllTestsForSomeCodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using MyCode;

    [TestFixture]
    public class BitCounting
    {
        private static IEnumerable<TestCaseData> testCases
        {
            get
            {
                yield return new TestCaseData(0).Returns(0);
                yield return new TestCaseData(4).Returns(1);
                yield return new TestCaseData(7).Returns(3);
                yield return new TestCaseData(9).Returns(2);
                yield return new TestCaseData(10).Returns(2);
                yield return new TestCaseData(26).Returns(3);
                yield return new TestCaseData(77231418).Returns(14);
                yield return new TestCaseData(12525589).Returns(11);
                yield return new TestCaseData(3811).Returns(8);
                yield return new TestCaseData(392902058).Returns(17);
                yield return new TestCaseData(1044).Returns(3);
                yield return new TestCaseData(10030245).Returns(10);
                yield return new TestCaseData(183337941).Returns(16);
                yield return new TestCaseData(20478766).Returns(14);
                yield return new TestCaseData(103021).Returns(9);
                yield return new TestCaseData(287).Returns(6);
                yield return new TestCaseData(115370965).Returns(15);
                yield return new TestCaseData(31).Returns(5);
                yield return new TestCaseData(417862).Returns(7);
                yield return new TestCaseData(626031).Returns(12);
                yield return new TestCaseData(89).Returns(4);
                yield return new TestCaseData(674259).Returns(10);
            }
        }

        [Test, TestCaseSource("testCases")]
        public int Test1(int n) => Convert.ToString(n, 2).Count(x => x == '1');

        [Test, TestCaseSource("testCases")]
        public int Test2(int n)
        {
            long v = (n & 0x55555555) + ((n & 0xaaaaaaaa) >> 1);
            v = (v & 0x33333333) + ((v & 0xcccccccc) >> 2);
            v = (v & 0x0f0f0f0f) + ((v & 0xf0f0f0f0) >> 4);
            return (int)v % 255;
        }

        [Test, TestCaseSource("testCases")]
        public int Test3(int i)
        {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
        }

        int[] bits = { 0, 1, 1, 2, 1, 2, 2, 3, 1, 2, 2, 3, 2, 3, 3, 4 };
        [Test, TestCaseSource("testCases")]
        public int Test4(int x)
                => bits[(x >> 0) & 0xf] + bits[(x >> 16) & 0xf] +
                   bits[(x >> 4) & 0xf] + bits[(x >> 20) & 0xf] +
                   bits[(x >> 8) & 0xf] + bits[(x >> 24) & 0xf] +
                   bits[(x >> 12) & 0xf] + bits[(x >> 28) & 0xf];

        [Test, TestCaseSource("testCases")]
        public int Test5(int n) => new System.Collections.BitArray(new[] { n }).Cast<bool>().Count(i => i);


    }
}





















