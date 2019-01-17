using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeRunner
{
    [TestFixture]
    class KataTestClass
    {
        private int[,] maze = new int[,] { { 1, 1, 1, 1, 1, 1, 1 },
                                       { 1, 0, 0, 0, 0, 0, 3 },
                                       { 1, 0, 1, 0, 1, 0, 1 },
                                       { 0, 0, 1, 0, 0, 0, 1 },
                                       { 1, 0, 1, 0, 1, 0, 1 },
                                       { 1, 0, 0, 0, 0, 0, 1 },
                                       { 1, 2, 1, 0, 1, 0, 1 } };

        [TestCase]
        public void FinishTest1()
        {
            string[] directions = new string[] { "N", "N", "N", "N", "N", "E", "E", "E", "E", "E" };
            Kata test = new Kata();
            string result = test.mazeRunner(maze, directions);
            Assert.AreEqual("Finish", result, "Should return: 'Finish'");
        }

        [TestCase]
        public void FinishTest2()
        {
            string[] directions = new string[] { "N", "N", "N", "N", "N", "E", "E", "S", "S", "E", "E", "N", "N", "E" };
            Kata test = new Kata();
            string result = test.mazeRunner(maze, directions);
            Assert.AreEqual("Finish", result, "Should return: 'Finish'");
        }

        [TestCase]
        public void FinishTest3()
        {
            string[] directions = new string[] { "N", "N", "N", "N", "N", "E", "E", "E", "E", "E", "W", "W" };
            Kata test = new Kata();
            string result = test.mazeRunner(maze, directions);
            Assert.AreEqual("Finish", result, "Should return: 'Finish'");
        }

        [TestCase]
        public void DeadTest1()
        {
            string[] directions = new string[] { "N", "N", "N", "W", "W" };
            Kata test = new Kata();
            string result = test.mazeRunner(maze, directions);
            Assert.AreEqual("Dead", result, "Should return: 'Dead'");
        }

        [TestCase]
        public void DeadTest2()
        {
            string[] directions = new string[] { "N", "N", "N", "N", "N", "E", "E", "S", "S", "S", "S", "S", "S" };
            Kata test = new Kata();
            string result = test.mazeRunner(maze, directions);
            Assert.AreEqual("Dead", result, "Should return: 'Dead'");
        }

        [TestCase]
        public void LostTest1()
        {
            string[] directions = new string[] { "N", "E", "E", "E", "E" };
            Kata test = new Kata();
            string result = test.mazeRunner(maze, directions);
            Assert.AreEqual("Lost", result, "Should return: 'Lost'");
        }

        private Random ran = new Random();

        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        public void RandomTest()
        {
            int[,] maze = getMaze();
            string[] directions = getDirections();
            Kata test = new Kata();
            string result = test.mazeRunner(maze, directions);
            string solution = mazeRunner2(maze, directions);
            Assert.AreEqual(solution, result, "Should return: '" + solution + "'");
        }

        private string[] getDirections()
        {
            int size = ran.Next(1, 50);
            string[] directions = new string[size];
            for (int x = 0; x < size; x++)
            {
                int d = ran.Next(0, 3);
                if (d == 0) { directions[x] = "N"; }
                if (d == 1) { directions[x] = "E"; }
                if (d == 2) { directions[x] = "S"; }
                if (d == 3) { directions[x] = "W"; }
            }
            return directions;
        }

        private int[,] getMaze()
        {
            int size = ran.Next(10, 50);
            int[,] maze = new int[size, size];
            int len = Convert.ToInt32(Math.Sqrt(maze.Length));
            for (int x = 0; x < len; x++)
            {
                for (int y = 0; y < len; y++)
                {
                    maze[y, x] = 0;
                }
            }
            for (int x = 0; x < ran.Next(1, maze.Length); x++)
            {
                int a = ran.Next(0, len);
                int b = ran.Next(0, len);
                maze[a, b] = 1;
            }
            int g = ran.Next(0, len);
            int h = ran.Next(0, len);
            maze[g, h] = 3;
            g = ran.Next(0, len);
            h = ran.Next(0, len);
            maze[g, h] = 2;
            return maze;
        }

        private string mazeRunner2(int[,] maze, string[] directions)
        {
            int startX = 0;
            int startY = 0;
            double len = Math.Sqrt(maze.Length);
            for (int x = 0; x < len; x++)
            {
                for (int y = 0; y < len; y++)
                {
                    if (maze[y, x] == 2) { startX = x; startY = y; }
                }
            }
            for (int x = 0; x < directions.Length; x++)
            {
                switch (directions[x])
                {
                    case "N": startY -= 1; break;
                    case "E": startX += 1; break;
                    case "S": startY += 1; break;
                    case "W": startX -= 1; break;
                }
                if (startY < 0 || startY > len - 1 || startX < 0 || startX > len - 1 || maze[startY, startX] == 1) { return "Dead"; }
                if (maze[startY, startX] == 3) { return "Finish"; }
            }

            return "Lost";
        }
    }

    class Kata
    {
        public string mazeRunner(int[,] maze, string[] directions)
        {
            int i = 0, j = 0, n = maze.GetLength(0);
            // until i,j make maze eq 2 as Start Point
            // loop j from 0 to n step 1 and loop i from 0 step n after j on j is 0
            for (; maze[i, j] != 2; j = ++j % n, i = j > 0 ? i : ++i % n) ;
            // do action in directions to change i,j as Point
            // distribute the Point
            foreach (var act in directions)
            {
                // W  N  E  S
                // 0  1  2  3  index
                //-1  0  1  2  0 inneed can mod 2 by even
                //-1  0  1  0  need
                i += ("WNES".IndexOf(act) - 2) % 2;
                // W  N  E  S
                // 0  1  2  3  index
                //-2 -1  0  1  0 inneed can mod 2 by even
                // 0 -1  0  1  need
                j += ("WNES".IndexOf(act) - 1) % 2;
                if (i < 0 || j < 0 || i >= n || j >= n) return "Dead";//出界
                if (maze[i, j] == 1) return "Dead";//遇墙
                if (maze[i, j] == 3) return "Finish";//完成
            }
            return "Lost";//迷失
        }

        public string linqCode(int[,] maze, string[] directions)
        {
            int i = 0, j = 0, n = maze.GetLength(0);
            for (; maze[i, j] != 2; j = ++j % n, i = j > 0 ? i : ++i % n) ;
            foreach (var item in directions.Select(act => (i += ("WNES".IndexOf(act) - 2) % 2, j += ("WNES".IndexOf(act) - 1) % 2)))
                if (i < 0 || j < 0 || i >= n || j >= n || maze[i, j] == 1) return "Dead";
                else if (maze[i, j] == 3) return "Finish";
            return "Lost";
        }
    }
}