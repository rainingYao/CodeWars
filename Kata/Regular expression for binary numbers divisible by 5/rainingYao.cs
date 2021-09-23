namespace CodeWars2.Kata.Regular_expression_for_binary_numbers_divisible_by_5.rainingYao
{
    using NUnit.Framework;
    using System;
    using System.Text.RegularExpressions;

    [TestFixture]
    public class TestFixture
    {
        [Test, Description("Example Tests")]
        [TestCase("", ExpectedResult = false)]
        [TestCase("101", ExpectedResult = true)]
        [TestCase("1010", ExpectedResult = true)]
        [TestCase("10100", ExpectedResult = true)]
        [TestCase("1111110111111100", ExpectedResult = true)]
        [TestCase("10110101", ExpectedResult = false)]
        [TestCase("1110001", ExpectedResult = false)]
        [TestCase("‭00010101‬", ExpectedResult = false)]
        [TestCase("‭0011110000100000‬", ExpectedResult = false)]
        [TestCase("‭0101110000010101‬", ExpectedResult = false)]
        [TestCase("100101110010000", ExpectedResult = false)]
        [TestCase("1010101110100000", ExpectedResult = false)]
        [TestCase("1000000011010001", ExpectedResult = false)]
        [TestCase("101001000", ExpectedResult = false)]
        [TestCase("1011001100001", ExpectedResult = false)]
        public bool ExampleTests(string text)
        {
            return Regex.IsMatch(text, Kata.DivisibleByFive);
        }
    }

    public class Kata
    {
        public const string DivisibleByFive = "^0|(101(0)*)$"; // partial solution
    }
}
