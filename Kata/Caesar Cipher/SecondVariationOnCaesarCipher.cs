namespace CodeWars.Kata.Caesar_Cipher//https://www.codewars.com/kata/second-variation-on-caesar-cipher/train/csharp
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class CaesarCipherTests
    {
        [Test]
        public void Test1()
        {
            string u = "I should have known that you would have a perfect answer for me!!!";
            Assert.AreEqual(u, CaesarTwo.decode(CaesarTwo.encodeStr(u, 1)));
        }
        [Test]
        public void Test2()
        {
            string u = "O CAPTAIN! my Captain! our fearful trip is done;";
            List<string> v = new List<string> { "opP DBQUBJ", "O! nz Dbqu", "bjo! pvs g", "fbsgvm usj", "q jt epof;" };
            Assert.AreEqual(u, CaesarTwo.decode(v));
        }

        [Test]
        public void LimitTest1()
        {
            string u = "ab";
            List<string> v = new List<string> { "abbc", "defg", "hikv", "uz12"};
            Assert.AreEqual(u, CaesarTwo.decode(v));
            Assert.AreEqual(u, CaesarTwo.decode(CaesarTwo.encodeStr(u, 1)));
        }

    }

    public class CaesarTwo
    {
        public static List<string> encodeStr(string s, int shift)
        {
            string ans = string.Concat(s[0], encode(s[0], shift)).ToLower();
            ans += string.Concat(s.Select(c => encode(c, shift)));
            return assign(ans);
        }

        static char encode(char c, int shift)
        {
            if (Char.IsUpper(c)) return (char)('A' + (c - 'A' + shift) % 26);
            if (Char.IsLower(c)) return (char)('a' + (c - 'a' + shift) % 26);
            return c;
        }

        static List<string> assign(string s)
        {
            List<string> list = new List<string>();
            int p = (int)Math.Ceiling(s.Length / 5d);
            //list.Add(string.Concat(ans.Take(p)));
            //list.Add(string.Concat(ans.Skip(p).Take(p)));
            //list.Add(string.Concat(ans.Skip(p * 2).Take(p)));
            //list.Add(string.Concat(ans.Skip(p * 3).Take(p)));
            //list.Add(string.Concat(ans.Skip(p * 4).Take(p)));
            list.Add(s.Substring(0, p));
            list.Add(s.Substring(p, p));
            list.Add(s.Substring(p * 2, p));
            list.Add(s.Substring(p * 3, p));
            if (p > 1) list.Add(s.Substring(p * 4, s.Length - p * 4));
            return list;
        }

        public static string decode(List<string> s)
        {
            string ans = string.Concat(s);
            int shift = ans[0] - ans[1];
            return string.Concat(ans.Substring(2).Select(c => encode(c, shift)));
        }
    }

}
