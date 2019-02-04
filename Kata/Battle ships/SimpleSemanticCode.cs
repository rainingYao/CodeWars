namespace BattleShips.SimpleSemanticCode
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

        [TestCase]
        [TestCase]
        [TestCase]
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
            Console.WriteLine("Random Test - sunk = " + solution["sunk"] + ", damaged = " + solution["damaged"] + ", notTouched = " + solution["notTouched"] + ", points = " + solution["points"]);
            Assert.AreEqual(solution["sunk"], result["sunk"]);
            Assert.AreEqual(solution["damaged"], result["damaged"]);
            Assert.AreEqual(solution["notTouched"], result["notTouched"]);
            Assert.AreEqual(solution["points"], result["points"]);
        }

        private int[,] board_maker(int zx, int zy)
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
            int[,] attack = new int[amount, amount];
            for (int zz = 0; zz < amount; zz++)
            {
                bool pos = true;
                int zxc = 0;
                int zyc = 0;
                while (pos)
                {
                    zxc = ran.Next(1, zx - 2);
                    zyc = ran.Next(1, zy - 2);
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
        /// 简洁的语义代码
        /// Simple semantic code
        /// </summary>
        public static Dictionary<string, double> damagedOrSunk(int[,] board, int[,] attacks)
        {
            var result = new Dictionary<string, double>();

            var boardBefore = board.Cast<int>().Where(x => x != 0)
             .GroupBy(x => x)
             .ToDictionary(gr => gr.Key, gr => gr.Count());

            // Apply attacks
            for (var i = 0; i < attacks.GetLength(0); i++)
                board[board.GetLength(0) - attacks[i, 1], attacks[i, 0] - 1] = 0;

            var boardAfter = board.Cast<int>().Where(x => x != 0)
              .GroupBy(x => x)
              .ToDictionary(gr => gr.Key, gr => gr.Count());

            result["sunk"] = boardBefore.Keys.Count - boardAfter.Keys.Count;
            result["notTouched"] = boardAfter.Count(x => x.Value == boardBefore[x.Key]);

            result["damaged"] = boardBefore.Keys.Count - result["sunk"] - result["notTouched"];
            result["points"] = result["sunk"] + 0.5 * result["damaged"] - 1 * result["notTouched"];

            return result;
        }
    }
}
