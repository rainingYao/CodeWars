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
    }

    public class CaesarTwo
    {
        public static List<string> encodeStr(string s, int shift)
        {
            string ans = string.Concat(s[0], encode(s[0], shift)).ToLower();
            ans += string.Concat(s.Select(c => encode(c, shift)));

            List<string> list = new List<string>();
            int p = (int)Math.Ceiling(s.Length / 5d);
            //list.Add(string.Concat(ans.Take(p)));
            //list.Add(string.Concat(ans.Skip(p).Take(p)));
            //list.Add(string.Concat(ans.Skip(p * 2).Take(p)));
            //list.Add(string.Concat(ans.Skip(p * 3).Take(p)));
            //list.Add(string.Concat(ans.Skip(p * 4).Take(p)));
            list.Add(ans.Substring(0, p));
            list.Add(ans.Substring(p, p));
            list.Add(ans.Substring(p * 2, p));
            list.Add(ans.Substring(p * 3, p));
            list.Add(ans.Substring(p * 4, ans.Length - p * 4));
            return list;
        }

        static string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string lower = "abcdefghijklmnopqrstuvwxyz";

        static char encode(char c, int shift)
        {
            char ans = c;
            if (Char.IsUpper(c)) ans = upper[(upper.IndexOf(c) + shift) % 26];
            if (Char.IsLower(c)) ans = lower[(lower.IndexOf(c) + shift) % 26];
            return ans;
        }

        //static char encode(char c, int shift)
        //{
        //    char ans = c;
        //    if (c == 'Z' || c == 'z') ans -= (char)25;
        //    if (Char.IsLetter(c)) ans += (char)shift;
        //    return ans;
        //}

        public static string decode(List<string> s)
        {
            string ans = string.Concat(s);
            int shift = ans[0] - ans[1];
            string a = ans.Substring(2);
            ans = string.Concat(a.Select(c => encode(c, shift)));
            return ans;
        }
    }

}
