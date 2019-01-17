namespace LongestConsConsecutive_stringsecutives
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System;
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
    }

    public class LongestConsecutives
    {
        static int i = 1;
        public static String LongestConsec(string[] strarr, int k)
        {
            int idx = 0;
            int maxsum = 0;
            for (int i = 0; i < strarr.Length - k + 1; i++)
            {
                int summ = 0;
                for (int j = 0; j < k; j++)
                {
                    summ += strarr[j].Length;
                }
                if (maxsum < summ)
                {
                    maxsum = summ;
                    idx = i;
                }
            }
            string ans = "";
            for (int j = idx; j < k; j++)
            {
                ans += strarr[j];
            }
            return ans;


            // your code
            if (k < 1)
                return "";

            string strk = "";
            int[] a = new int[strarr.Length + 1];

            //将相邻k个元素求和，结果放在数组a
            foreach (string s in strarr)
            {
                a[i] = s.Length;

                if (i >= k)
                {
                    for (int j = 1; j < k; j++)
                        a[i - 1] += a[i - 1 + j];
                }
                i++;
            }
            i = 0;

            int max = a.Max();
            if (max == 0 || k > max)
                return "";
            else
            {
                for (int j = 1; j < a.Length - k; j++)
                {
                    if (a[j] == max)        //找出最大值下标
                    {
                        for (; i < k; i++)
                            strk += strarr[j + i];
                        return strk;
                    }
                }
                return "";
            }
        }
    }

}

