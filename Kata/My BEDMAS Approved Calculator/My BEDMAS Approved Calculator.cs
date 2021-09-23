namespace My_BEDMAS_Approved_Calculator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    public static class Kata
    {
        static double calculate(double n1, char op, double n2) => op switch
        {
            '+' => n1 + n2,
            '-' => n1 - n2,
            '*' => n1 * n2,
            '/' => n1 / n2,
            '^' => Math.Pow(n1, n2),
            _ => 0
        };

        static double calculate(double n, char op)
        {
            double fact = 1;
            while (n > 1)
            {
                fact *= n;
                n--;
            }
            return fact;
        }

        static string symbols =
            "+-*/^!()";
        static string[] array = new string[] {
            ">><<<<<>",
            ">><<<<<>",
            ">>>><<<>",
            ">>>><<<>",
            ">>>>><<>",
            ">>>>>> >",
            "<<<<<<<=",
            "        " };
        static char Priority(char l, char r)
        {
            return array[symbols.IndexOf(l)][symbols.IndexOf(r)];
        }

        public static double calculate(string s)
        {
            s = $"({s})";
            var numbers = new Stack<double>();
            var operators = new Stack<char>();
            operators.Push('(');
            var i = 1;
            while (i < s.Length)
            {
                switch (s[i])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    case '.':
                        var number = s.Skip(i).TakeWhile(c => char.IsDigit(c) || c == '.');
                        numbers.Push(double.Parse(string.Concat(number)));
                        i += number.Count();
                        break;
                    case '(':
                    case ')':
                    case '*':
                    case '+':
                    case '-':
                    case '/':
                    case '^':
                    case '!':
                        switch (Priority(operators.Peek(), s[i]))
                        {
                            case '<':
                                operators.Push(s[i]);
                                i++;
                                break;
                            case '=':
                                operators.Pop();
                                i++;
                                break;
                            case '>':
                                var op = operators.Pop();
                                if (s[i] == '!')
                                {
                                    var n = numbers.Pop();
                                    numbers.Push(calculate(n, op));
                                }
                                else
                                {
                                    var n2 = numbers.Pop();
                                    var n1 = numbers.Pop();
                                    numbers.Push(calculate(n1, op, n2));
                                }
                                break;
                            case ' ':
                                i++;
                                break;
                        }
                        break;
                    default:
                        i++;
                        break;
                }
            }
            return numbers.Pop();
        }
    }


    [TestFixture]
    public class CalculatorTest
    {
        public bool close(double a, double b)
        {
            if (Math.Abs(a - b) < 0.000000001) return true;
            return false;
        }

        [Test]
        public void PublicTests()
        {
            Assert.AreEqual(true, close(Kata.calculate("1 + 2"), 3));
            Assert.AreEqual(true, close(Kata.calculate("2*2"), 4));
        }


        [TestCase("4 + 2 * ( (226 - (5 * 3) ^ 2) ^ 2 + (10.7 - 7.4) ^ 2 - 6.89)", ExpectedResult = 14)]
        public double HardTests(string formula)
        {
            return Kata.calculate(formula);
        }

        [TestCase("62 + 51/   (51 +  69)", ExpectedResult = 62.425)]
        [TestCase("(97   + 60+  43)  * 43  *97", ExpectedResult = 834200)]
        public double RandomTests(string formula)
        {
            return Kata.calculate(formula);
        }
    }
}
