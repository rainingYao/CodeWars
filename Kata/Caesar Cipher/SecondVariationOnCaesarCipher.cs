namespace CodeWars.Kata.Caesar_Cipher
{
    using System;
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class CaesarCipherTests
    {
        [Test]
        public void LimitTest1()
        {
            string u = "abcdefghijklmn";
            List<string> v = new List<string> { "abbc", "defg", "hijk", "lmno" };
            Assert.AreEqual(u, CaesarTwo.decode(v));
            Assert.AreEqual(u, CaesarTwo.decode(CaesarTwo.encodeStr(u, 1)));
        }

        [Test]
        public void Test1()
        {
            string u = "I should have known that you would have a perfect answer for me!!!";
            Assert.AreEqual(u, CaesarTwo.decode(CaesarTwo.encodeStr(u, 1)));
        }
        [Test]
        public void Test1a()
        {
            string u = "abcdefghjuty12";
            List<string> v = new List<string> { "abbc", "defg", "hikv", "uz12" };
            Assert.AreEqual(v, CaesarTwo.encodeStr(u, 1));
            Assert.AreEqual(u, CaesarTwo.decode(CaesarTwo.encodeStr(u, 1)));
        }
        [Test]
        public void Test2()
        {
            string u = "O CAPTAIN! my Captain! our fearful trip is done;";
            List<string> v = new List<string> { "opP DBQUBJ", "O! nz Dbqu", "bjo! pvs g", "fbsgvm usj", "q jt epof;" };
            Assert.AreEqual(v, CaesarTwo.encodeStr(u, 1));
            Assert.AreEqual(u, CaesarTwo.decode(v));
        }
        [Test]
        public void Test3()
        {
            string u = "For you bouquets and ribbon'd wreaths--for you the shores a-crowding;";
            List<string> v = new List<string> { "fgGps zpv cpvrv", "fut boe sjccpo'", "e xsfbuit--gps ", "zpv uif tipsft ", "b-dspxejoh;" };
            Assert.AreEqual(v, CaesarTwo.encodeStr(u, 1));
            Assert.AreEqual(u, CaesarTwo.decode(v));
        }
        [Test]
        public void Test4()
        {
            string u = "Exult, O shores, and ring, O bells! But I, with mournful tread, Walk the deck my Captain lies, Fallen cold and dead. ";
            List<string> v = new List<string> { "efFyvmu, P tipsft, boe s", "joh, P cfmmt! Cvu J, xju", "i npvsogvm usfbe, Xbml u", "if efdl nz Dbqubjo mjft,", " Gbmmfo dpme boe efbe. " };
            Assert.AreEqual(v, CaesarTwo.encodeStr(u, 1));
            Assert.AreEqual(u, CaesarTwo.decode(v));
        }
        [Test]
        public void Test5()
        {
            string u = "Had I the heavens' embroidered cloths, Enwrought with golden and silver light,";
            List<string> v = new List<string> { "hiIbe J uif ifbw", "fot' fncspjefsfe", " dmpuit, Foxspvh", "iu xjui hpmefo b", "oe tjmwfs mjhiu," };
            Assert.AreEqual(v, CaesarTwo.encodeStr(u, 1));
            Assert.AreEqual(u, CaesarTwo.decode(v));
        }
        [Test]
        public void Test6()
        {
            string u = "The blue and the dim and the dark cloths Of night and light and the half-light,";
            List<string> v = new List<string> { "tuUif cmvf boe ui", "f ejn boe uif ebs", "l dmpuit Pg ojhiu", " boe mjhiu boe ui", "f ibmg-mjhiu," };
            Assert.AreEqual(v, CaesarTwo.encodeStr(u, 1));
            Assert.AreEqual(u, CaesarTwo.decode(v));
        }
        [Test]
        public void Test7()
        {
            string u = "I would spread the cloths under your feet: But I, being poor, have only my dreams;";
            List<string> v = new List<string> { "ijJ xpvme tqsfbe ", "uif dmpuit voefs ", "zpvs gffu: Cvu J,", " cfjoh qpps, ibwf", " pomz nz esfbnt;" };
            Assert.AreEqual(v, CaesarTwo.encodeStr(u, 1));
            Assert.AreEqual(u, CaesarTwo.decode(v));
        }
        [Test]
        public void Test8()
        {
            string u = "I have spread my dreams under your feet; Tread softly because you tread on my dreams. William B Yeats (1865-1939)";
            Assert.AreEqual(u, CaesarTwo.decode(CaesarTwo.encodeStr(u, 25)));
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
            if (p > 4) list.Add(s.Substring(p * 4, s.Length - p * 4));
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
