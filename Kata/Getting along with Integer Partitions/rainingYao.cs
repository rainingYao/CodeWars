namespace CodeWars2.Kata.Getting_along_with_Integer_Partitions.rainingYao
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class IntPartTests
    {

        [Test]
        public void Test1()
        {
            Console.WriteLine("****** Basic Tests Small Numbers");
            Assert.AreEqual("Range: 1 Average: 1.50 Median: 1.50", IntPart.Part(2));
            Assert.AreEqual("Range: 2 Average: 2.00 Median: 2.00", IntPart.Part(3));
            Assert.AreEqual("Range: 3 Average: 2.50 Median: 2.50", IntPart.Part(4));
            Assert.AreEqual("Range: 5 Average: 3.50 Median: 3.50", IntPart.Part(5));
            Assert.AreEqual("Range: 8 Average: 4.75 Median: 4.50", IntPart.Part(6));
            Assert.AreEqual("Range: 11 Average: 6.09 Median: 6.00", IntPart.Part(7));
            Assert.AreEqual("Range: 17 Average: 8.29 Median: 7.50", IntPart.Part(8));
            Assert.AreEqual("Range: 26 Average: 11.17 Median: 9.50", IntPart.Part(9));
            Assert.AreEqual("Range: 35 Average: 15.00 Median: 14.00", IntPart.Part(10));
        }
        [Test]
        public void Test2()
        {
            Console.WriteLine("****** Basic Tests Bigger Numbers");
            Assert.AreEqual("Range: 53 Average: 19.69 Median: 16.00", IntPart.Part(11));
            Assert.AreEqual("Range: 80 Average: 27.08 Median: 22.50", IntPart.Part(12));
            Assert.AreEqual("Range: 107 Average: 35.07 Median: 27.00", IntPart.Part(13));
            Assert.AreEqual("Range: 161 Average: 47.33 Median: 35.00", IntPart.Part(14));
            Assert.AreEqual("Range: 242 Average: 63.91 Median: 45.00", IntPart.Part(15));
            Assert.AreEqual("Range: 323 Average: 84.44 Median: 56.00", IntPart.Part(16));
            Assert.AreEqual("Range: 485 Average: 112.66 Median: 73.50", IntPart.Part(17));
            Assert.AreEqual("Range: 728 Average: 151.44 Median: 96.00", IntPart.Part(18));
            Assert.AreEqual("Range: 971 Average: 199.34 Median: 118.50", IntPart.Part(19));
            Assert.AreEqual("Range: 1457 Average: 268.11 Median: 152.00", IntPart.Part(20));
        }
        [Test]
        public void Test3()
        {
            Console.WriteLine("****** Basic Tests Still Bigger Numbers");
            Assert.AreEqual("Range: 13121 Average: 1500.90 Median: 625.00", IntPart.Part(26));
            Assert.AreEqual("Range: 19682 Average: 2009.29 Median: 775.00", IntPart.Part(27));
            Assert.AreEqual("Range: 26243 Average: 2669.98 Median: 980.00", IntPart.Part(28));
            Assert.AreEqual("Range: 39365 Average: 3558.37 Median: 1224.50", IntPart.Part(29));
            Assert.AreEqual("Range: 59048 Average: 4764.89 Median: 1538.00", IntPart.Part(30));
            Assert.AreEqual("Range: 78731 Average: 6326.47 Median: 1920.00", IntPart.Part(31));
            Assert.AreEqual("Range: 86093441 Average: 1552316.81 Median: 120960.00", IntPart.Part(50));
        }

        public static void RandomTests1()
        {
            Console.WriteLine("****** Series 1");
            Assert.AreEqual("Range: 2186 Average: 358.10 Median: 197.00", IntPart.Part(21));
            Assert.AreEqual("Range: 4373 Average: 633.44 Median: 315.00", IntPart.Part(23));
            Assert.AreEqual("Range: 177146 Average: 11292.63 Median: 3024.00", IntPart.Part(33));
            Assert.AreEqual("Range: 354293 Average: 20088.78 Median: 4704.00", IntPart.Part(35));
            Assert.AreEqual("Range: 708587 Average: 35745.98 Median: 7371.00", IntPart.Part(37));
            Assert.AreEqual("Range: 1594322 Average: 63823.27 Median: 11475.00", IntPart.Part(39));
            Assert.AreEqual("Range: 6377291 Average: 202904.65 Median: 27262.50", IntPart.Part(43));
            Assert.AreEqual("Range: 19131875 Average: 484712.39 Median: 51975.00", IntPart.Part(46));
            Assert.AreEqual("Range: 28697813 Average: 648367.27 Median: 64260.00", IntPart.Part(47));
            Assert.AreEqual("Range: 43046720 Average: 867970.08 Median: 79830.00", IntPart.Part(48));
        }
        public static void RandomTests2()
        {
            Console.WriteLine("****** Series 2");
            Assert.AreEqual("Range: 2186 Average: 358.10 Median: 197.00", IntPart.Part(21));
            Assert.AreEqual("Range: 6560 Average: 846.79 Median: 390.00", IntPart.Part(24));
            Assert.AreEqual("Range: 8747 Average: 1126.14 Median: 500.00", IntPart.Part(25));
            Assert.AreEqual("Range: 236195 Average: 15031.03 Median: 3761.50", IntPart.Part(34));
            Assert.AreEqual("Range: 1062881 Average: 47763.72 Median: 9152.00", IntPart.Part(38));
            Assert.AreEqual("Range: 3188645 Average: 113720.82 Median: 17745.00", IntPart.Part(41));
            Assert.AreEqual("Range: 4782968 Average: 152184.15 Median: 21888.00", IntPart.Part(42));
            Assert.AreEqual("Range: 19131875 Average: 484712.39 Median: 51975.00", IntPart.Part(46));
            Assert.AreEqual("Range: 28697813 Average: 648367.27 Median: 64260.00", IntPart.Part(47));
            Assert.AreEqual("Range: 57395627 Average: 1159398.98 Median: 98227.50", IntPart.Part(49));
        }
        public static void RandomTests3()
        {
            Console.WriteLine("****** Series 3");
            Assert.AreEqual("Range: 2915 Average: 475.46 Median: 245.00", IntPart.Part(22));
            Assert.AreEqual("Range: 6560 Average: 846.79 Median: 390.00", IntPart.Part(24));
            Assert.AreEqual("Range: 118097 Average: 8457.17 Median: 2420.00", IntPart.Part(32));
            Assert.AreEqual("Range: 236195 Average: 15031.03 Median: 3761.50", IntPart.Part(34));
            Assert.AreEqual("Range: 531440 Average: 26832.81 Median: 5865.00", IntPart.Part(36));
            Assert.AreEqual("Range: 2125763 Average: 85158.49 Median: 14250.00", IntPart.Part(40));
            Assert.AreEqual("Range: 4782968 Average: 152184.15 Median: 21888.00", IntPart.Part(42));
            Assert.AreEqual("Range: 9565937 Average: 271332.21 Median: 33796.00", IntPart.Part(44));
            Assert.AreEqual("Range: 14348906 Average: 363114.82 Median: 41947.50", IntPart.Part(45));
            Assert.AreEqual("Range: 57395627 Average: 1159398.98 Median: 98227.50", IntPart.Part(49));
        }

        [Test]
        public static void Test4()
        {
            Console.WriteLine("\n Random Tests ****************");
            Random rnd = new Random();
            int n = rnd.Next(1, 4);
            if (n == 1) RandomTests1();
            else if (n == 2) RandomTests2();
            else RandomTests3();
        }

        [Test]
        public void MyTest1()
        {
            Assert.AreEqual("Range: 53 Average: 19.69 Median: 16.00", IntPart.Part(11));
        }

    }

    //// 超时
    //public class IntPart
    //{
    //    public static string Part(long n)
    //    {
    //        set.Clear();
    //        List<long> list = new List<long>();
    //        list.Add(n);
    //        dis(list);
    //        set.Add(n);
    //        list = set.ToList();
    //        int count = list.Count;

    //        double range = list[count - 1] - list[0];
    //        double average = list.Average();
    //        double median = 0;
    //        if (count % 2 == 0)
    //        {
    //            median = (list[count / 2 - 1] + list[count / 2]) / 2.0;
    //        }
    //        else
    //        {
    //            median = list[count / 2];
    //        }
    //        return $"Range: {range} Average: {average.ToString("N")} Median: {median.ToString("N")}";
    //    }

    //    static SortedSet<long> set = new SortedSet<long>();

    //    public static void dis(List<long> list)
    //    {
    //        foreach (long x in list)
    //        {
    //            if (x > 1)
    //            {
    //                for (int y = 1; y < x; y++)
    //                {
    //                    List<long> list2 = new List<long>(list);
    //                    list2.Remove(x);
    //                    list2.Add(y);
    //                    list2.Add(x - y);
    //                    list2.Sort();
    //                    long s = 1;
    //                    foreach (long z in list2)
    //                    {
    //                        s *= z;
    //                    }
    //                    set.Add(s);
    //                    dis(list2);
    //                }
    //            }
    //        }
    //    }
    //}

    // 未完成
    //public class IntPart
    //{
    //    public static string Part(long n)
    //    {
    //        long[] arr = new long[n];
    //        arr.Initialize();
    //        arr[0] = n;
    //        SortedSet<long> set = new SortedSet<long>() { n };

    //        des(ref set, in n, ref arr, 0);

    //        List<long> list = set.ToList();
    //        int count = list.Count;
    //        double range = list[count - 1] - list[0];
    //        double average = list.Average();
    //        double median = 0;
    //        if (count % 2 == 0)
    //        {
    //            median = (list[count / 2 - 1] + list[count / 2]) / 2.0;
    //        }
    //        else
    //        {
    //            median = list[count / 2];
    //        }
    //        return $"Range: {range} Average: {average.ToString("N")} Median: {median.ToString("N")}";
    //    }

    //    public static void des(ref SortedSet<long> set, in long n, ref long[] arr, int lv)
    //    {
    //        while (true)
    //        {
    //            for (int i = lv; i < n; i++)
    //            {
    //                if (arr[i] <= 1)
    //                {
    //                    arr[i - 1] -= 1;
    //                    arr[i] += 1;
    //                    if (arr[i] <= arr[i - 1]) break;
    //                }
    //            }

    //            //计算乘积
    //            long p = 1;
    //            for (int i = 0; i < n; i++)
    //            {
    //                if (arr[i] == 0) break;
    //                p *= arr[i];
    //            }
    //            set.Add(p);
    //            if (p == 1) break;
    //        }
    //    }
    //}

    // 改良了网络搜索到的加数分解的组合算法
    public class IntPart
    {
        public static string Part(long n)
        {
            List<long> list = new List<long>();
            SortedSet<long> set = new SortedSet<long>();
            des(ref set, n, ref list, 1);

            List<long> li = set.ToList();
            int count = li.Count;
            double range = li[count - 1] - li[0];
            double average = li.Average();
            double median = count % 2 == 0 ?
                (li[count / 2 - 1] + li[count / 2]) / 2.0 :
                li[count / 2];
            return $"Range: {range} Average: {average:0.00} Median: {median:0.00}";
        }

        public static void des(ref SortedSet<long> set, long n, ref List<long> list, int lv)
        {
            for (int i = lv; i <= n / 2; i++)
            {
                list.Add(i);
                des(ref set, n - i, ref list, i);
                list.RemoveAt(list.Count - 1);
            }
            set.Add(list.Aggregate(n, (a, b) => a * b));
        }
    }
}