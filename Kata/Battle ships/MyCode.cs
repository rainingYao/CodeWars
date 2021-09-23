namespace BattleShips.MyCode
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    [TestFixture]
    class KataTestClass
    {
        private Random ran = new Random();

        [TestCase]
        public void FinalTest1()
        {
            var kata = new Kata();
            int[,] board = { { 0, 0, 1, 2, 2, 0 }, { 0, 3, 0, 1, 0, 0 }, { 0, 3, 0, 0, 0, 0 }, { 0, 3, 0, 0, 0, 0 } };
            int[,] attacks = { { 3, 4 }, { 4, 3 }, { 4, 4 } };
            var result = Kata.damagedOrSunk(board, attacks);
            Console.WriteLine("Final Test 1 - sunk = 1, damaged = 1, notTouched = 1, points = 0.5");
            Assert.AreEqual(1, result["sunk"]);
            Assert.AreEqual(1, result["damaged"]);
            Assert.AreEqual(1, result["notTouched"]);
            Assert.AreEqual(0.5, result["points"]);
        }

        [TestCase]
        public void FinalTest2()
        {
            var kata = new Kata();
            int[,] board = { { 0, 0, 1 }, { 0, 0, 0 }, { 0, 2, 0 }, { 0, 2, 0 } };
            int[,] attacks = { { 3, 4 }, { 2, 1 }, { 2, 2 } };
            var result = Kata.damagedOrSunk(board, attacks);
            Console.WriteLine("Final Test 2 - sunk = 2, damaged = 0, notTouched = 0, points = 2");
            Assert.AreEqual(2, result["sunk"]);
            Assert.AreEqual(0, result["damaged"]);
            Assert.AreEqual(0, result["notTouched"]);
            Assert.AreEqual(2, result["points"]);
        }

        [TestCase]
        public void FinalTest3()
        {
            var kata = new Kata();
            int[,] board = { { 0, 0, 1 }, { 0, 0, 1 }, { 0, 2, 0 }, { 0, 2, 0 } };
            int[,] attacks = { { 3, 4 }, { 2, 1 }, { 2, 2 } };
            var result = Kata.damagedOrSunk(board, attacks);
            Console.WriteLine("Final Test 3 - sunk = 1, damaged = 1, notTouched = 0, points = 1.5");
            Assert.AreEqual(1, result["sunk"]);
            Assert.AreEqual(1, result["damaged"]);
            Assert.AreEqual(0, result["notTouched"]);
            Assert.AreEqual(1.5, result["points"]);
        }

        [TestCase]
        public void FinalTest4()
        {
            var kata = new Kata();
            int[,] board = { { 1, 1, 1 }, { 0, 0, 0 }, { 0, 2, 0 }, { 0, 2, 0 } };
            int[,] attacks = { { 1, 4 }, { 2, 4 }, { 3, 4 } };
            var result = Kata.damagedOrSunk(board, attacks);
            Console.WriteLine("Final Test 4 - sunk = 1, damaged = 0, notTouched = 1, points = 0");
            Assert.AreEqual(1, result["sunk"]);
            Assert.AreEqual(0, result["damaged"]);
            Assert.AreEqual(1, result["notTouched"]);
            Assert.AreEqual(0, result["points"]);
        }

        [TestCase, Repeat(10)]
        public void RandomTest()
        {
            var kata = new Kata();
            int zxc = ran.Next(5, 8);
            int zyc = ran.Next(5, 8);
            int[,] board = board_maker(zxc, zyc);
            Console.WriteLine("Game Board");
            for (int a = 0; a < board.GetLength(0); a++)
            {
                for (int b = 0; b < board.GetLength(1); b++)
                {
                    Console.Write(board[a, b] + ",");
                }
                Console.WriteLine(Environment.NewLine);
            }

            int[,] attacks = attack_maker(zxc, zyc);
            Console.WriteLine("Attacks");
            for (int a = 0; a < attacks.GetLength(0); a++)
            {
                Console.Write("(" + attacks[a, 0] + ", " + attacks[a, 1] + ") ");
            }
            Console.WriteLine(Environment.NewLine);
            var solution = damagedOrSunkCheck(board, attacks);
            var result = Kata.damagedOrSunk(board, attacks);
            Console.WriteLine("Random Test expected - sunk = " + solution["sunk"] + ", damaged = " + solution["damaged"] + ", notTouched = " + solution["notTouched"] + ", points = " + solution["points"]);
            Console.WriteLine("Random Test actual   - sunk = " + result["sunk"] + ", damaged = " + result["damaged"] + ", notTouched = " + result["notTouched"] + ", points = " + result["points"]);
            Assert.AreEqual(solution["sunk"], result["sunk"]);
            Assert.AreEqual(solution["damaged"], result["damaged"]);
            Assert.AreEqual(solution["notTouched"], result["notTouched"]);
            Assert.AreEqual(solution["points"], result["points"]);
        }

        private int[,] board_maker(int zy, int zx)
        {
            int[,] board = new int[zx, zy];
            for (int za = 0; za < zx; za++)
            {
                for (int zb = 0; zb < zy; zb++)
                {
                    board[za, zb] = 0;
                }
            }
            for (int za = 1; za <= ran.Next(2, 4); za++)
            {
                int zcount = 0;
                int zsize = 10;
                int zdirection = 0;
                int zxc = 0;
                int zyc = 0;
                while (zcount < zsize - 1)
                {
                    zcount = 0;
                    zsize = ran.Next(2, 4);
                    zdirection = ran.Next(1, 3);
                    zxc = ran.Next(0, (zx - 1));
                    zyc = ran.Next(0, (zy - 1));
                    for (int zb = 0; zb <= zsize; zb++)
                    {
                        if (zdirection == 1)
                        {
                            if (zxc + zb < zx - 1) { if (board[zxc + zb, zyc] == 0) { zcount = +1; } }
                        }
                        else
                        {
                            if (zyc + zb < zy - 1) { if (board[zxc, zyc + zb] == 0) { zcount = +1; } }
                        }
                    }
                }
                for (int zb = 0; zb < zsize; zb++)
                {
                    if (zdirection == 1) { board[zxc + zb, zyc] = za; } else { board[zxc, zyc + zb] = za; }
                }
            }
            return board;
        }

        private int[,] attack_maker(int zx, int zy)
        {
            int amount = ran.Next(2, 11);
            int[,] attack = new int[amount, 2];
            for (int zz = 0; zz < amount; zz++)
            {
                bool pos = true;
                int zxc = 0;
                int zyc = 0;
                while (pos)
                {
                    zxc = ran.Next(1, zx);
                    zyc = ran.Next(1, zy);
                    pos = false;
                    for (int check = 0; check < zz; check++)
                    {
                        if (attack[check, 0] == zxc && attack[check, 1] == zyc) { pos = true; }
                    }
                }
                attack[zz, 0] = zxc;
                attack[zz, 1] = zyc;
            }
            return attack;
        }

        private static Dictionary<string, double> damagedOrSunkCheck(int[,] board, int[,] attacks)
        {
            Dictionary<string, double> result = new Dictionary<string, double> { { "sunk", 0 }, { "damaged", 0 }, { "notTouched", 0 }, { "points", 0 } };
            Dictionary<int, int> ships = new Dictionary<int, int> { { 1, 0 }, { 2, 0 }, { 3, 0 } };
            Dictionary<int, int> hits = new Dictionary<int, int> { { 1, 0 }, { 2, 0 }, { 3, 0 } };
            for (int x = 0; x < board.GetLength(0); x++)
            {
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (board[x, y] != 0) { ships[board[x, y]]++; }
                }
            }
            for (int x = 0; x < attacks.GetLength(0); x++)
            {
                int ship = board[board.GetLength(0) - attacks[x, 1], attacks[x, 0] - 1];
                if (ship > 0) { hits[ship]++; }
            }
            for (int x = 1; x <= 3; x++)
            {
                if (ships[x] != 0)
                {
                    ships[x] = ships[x] - hits[x];
                    if (ships[x] == 0)
                    {
                        result["points"]++; result["sunk"]++;
                    }
                    else
                    {
                        if (hits[x] == 0) { result["notTouched"]++; result["points"]--; } else { result["damaged"]++; result["points"] = result["points"] + .5; }
                    }
                }
            }
            return result;
        }
    }

    class Kata
    {
        /// <summary>
        /// 先求每个船的长度作为数组 下标为船号
        /// 再求攻击过船的次数作为数组 下标为船号
        /// 根据次数和长度判断
        /// </summary>
        public static Dictionary<string, double> damagedOrSunk(int[,] board, int[,] attacks)
        {
            int sum = board.Cast<int>().Max();
            int unused = sum - board.Cast<int>().Distinct().Where(n => n > 0).Count();
            int[] a = new int[sum];
            int[] b = new int[sum];
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    if (board[i, j] > 0) a[board[i, j] - 1]++;
            for (int i = 0; i < attacks.GetLength(0); i++)
            {
                int ship = board[board.GetLength(0) - attacks[i, 1], attacks[i, 0] - 1];
                if (ship > 0) b[ship - 1]++;
            }
            int sunk = 0, damaged = 0, notTouched = 0 - unused;
            for (int i = 0; i < sum; i++)
                if (b[i] == 0) notTouched++;
                else if (b[i] == a[i]) sunk++;
                else damaged++;
            return new Dictionary<string, double>()
            { {"sunk", sunk} ,{"damaged", damaged}, {"notTouched", notTouched}, {"points", sunk+damaged*0.5-notTouched} };
        }

        /// <summary>
        /// *= -1
        /// Execution Timed Out (12000 ms)
        /// </summary>
        public static Dictionary<string, double> damagedOrSunk_0(int[,] board, int[,] attacks)
        {
            int sum = board.Cast<int>().Max();
            for (int i = 0; i < attacks.GetLength(0); i++)
                board[attacks.GetLength(0) - attacks[i, 1], attacks[i, 0] - 1] *= -1;
            int injured = board.Cast<int>().Distinct().Count(i => i < 0);
            int survive = board.Cast<int>().Distinct().Count(i => i > 0);
            int sunk = sum - survive;
            int damaged = injured + survive - sum;
            int notTouched = sum - injured;
            return new Dictionary<string, double>()
            { {"sunk", sunk} ,{"damaged", damaged}, {"notTouched", notTouched}, {"points", sunk+damaged*0.5-notTouched} };
        }
    }
}
