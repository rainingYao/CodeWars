namespace ConsecutiveStrings
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using NUnit.Framework;

    [TestFixture]
    public static class LongestConsecutivesTests
    {
        private static void testing(string actual, string expected)
        {
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public static void test1()
        {
            Console.WriteLine("Basic Tests");
            testing(LongestConsecutives.LongestConsec(new String[] { "zone", "abigail", "theta", "form", "libe", "zas", "theta", "abigail" }, 2), "abigailtheta");
            testing(LongestConsecutives.LongestConsec(new String[] { "ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh" }, 1), "oocccffuucccjjjkkkjyyyeehh");
            testing(LongestConsecutives.LongestConsec(new String[] { }, 3), "");
            testing(LongestConsecutives.LongestConsec(new String[] { "itvayloxrp", "wkppqsztdkmvcuwvereiupccauycnjutlv", "vweqilsfytihvrzlaodfixoyxvyuyvgpck" }, 2), "wkppqsztdkmvcuwvereiupccauycnjutlvvweqilsfytihvrzlaodfixoyxvyuyvgpck");
            testing(LongestConsecutives.LongestConsec(new String[] { "wlwsasphmxx", "owiaxujylentrklctozmymu", "wpgozvxxiu" }, 2), "wlwsasphmxxowiaxujylentrklctozmymu");
            testing(LongestConsecutives.LongestConsec(new String[] { "zone", "abigail", "theta", "form", "libe", "zas" }, -2), "");
            testing(LongestConsecutives.LongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 3), "ixoyx3452zzzzzzzzzzzz");
            testing(LongestConsecutives.LongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 15), "");
            testing(LongestConsecutives.LongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 0), "");
        }

        //-----------------------        
        private static String LongestConsecSol(string[] strarr, int k)
        {
            int n = strarr.Length;
            if ((n == 0) || (k > n) || (k <= 0)) return "";
            int[] arr = strarr.Select(w => w.Length).ToArray();
            int sm = 0;
            for (int i = 0; i < k; i++) sm += arr[i];
            int mx_sm = sm, mx_nd = k - 1;
            for (int u = k; u < n; u++)
            {
                sm = sm + arr[u] - arr[u - k];
                if (sm > mx_sm)
                {
                    mx_sm = sm; mx_nd = u;
                }
            }
            int start = mx_nd - k + 1;
            string[] sl = new List<string>(strarr).GetRange(start, k).ToArray();
            return String.Join("", sl);
        }
        private static string[] DoEx(int k)
        {
            int j = 0;
            string[] a1 = new string[k];
            while (j < k)
            {
                string res = "";
                int n = -1;
                for (int i = 0; i < rnd.Next(3, 10); i++)
                {
                    n = rnd.Next(97, 122);
                    for (int u = 0; u < rnd.Next(1, 3); u++)
                        res += (char)n;
                }
                a1[j] = res;
                j++;
            }
            return a1;
        }
        //-----------------------
        private static Random rnd = new Random();
        [Test]
        public static void RandomTest1()
        {
            Console.WriteLine("200 Random Tests");
            for (int i = 0; i < 200; i++)
            {
                String[] s1 = DoEx(rnd.Next(100, 200));
                int n = rnd.Next(1, s1.Length + 2);
                testing(LongestConsecutives.LongestConsec(s1, n), LongestConsecSol(s1, n));
            }
        }
        [Test]
        public static void BestCodeRandomTest()
        {
            Console.WriteLine("200 Random Tests");
            for (int i = 0; i < 200; i++)
            {
                String[] s1 = DoEx(rnd.Next(100, 200));
                int n = rnd.Next(1, s1.Length + 2);
                testing(LongestConsecutives.BestCode(s1, n), LongestConsecSol(s1, n));
            }
        }
    }
    public class LongestConsecutives
    {
        public static String LongestConsec(string[] strarr, int k)
        {
            string longest = "";
            if (strarr.Length < k) return longest;
            for (int i = 0; i < strarr.Length - k + 1; i++)
            {
                string temp = "";
                for (int g = i; g < i + k; g++) temp += strarr[g];
                if (temp.Length > longest.Length) longest = temp;
            }
            return longest;
        }
        public static string BestCode(string[] s, int k)
        {
            return s.Length == 0 || s.Length < k || k <= 0 ? ""
                 : Enumerable.Range(0, s.Length - k + 1)
                             .Select(x => string.Join("", s.Skip(x).Take(k)))
                             .OrderByDescending(x => x.Length)
                             .First();
        }
    }
}
