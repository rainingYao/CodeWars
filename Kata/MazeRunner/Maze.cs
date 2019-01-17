using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace MazeRunner
{
    [TestFixture]
    class Maze
    {
        static Random random = new Random(317);

        private static int N = random.Next(4, 10);

        private static (int, int) RandomStartPoint()
        {
            return (random.Next(N), random.Next(N));
        }

        private static int[,] RandomMaze()
        {
            int[,] ints = new int[N, N];
            ints.Cast<int>().Select(i => i = random.Next(0, 2));
            return ints;
        }

        public static (int, int) FindStartPoint() { return (1, 1); }


        [Test, TestCaseSource("LoopRandomCase")]
        public (int, int) LoopRandomTest(int[,] maze)
        {
            int i = 0, j = 0, n = maze.GetLength(0);
            // until i,j make maze eq 2 as Start Point
            // loop j from 0 to n-1 step 1 and loop i from 0 step n after j on j is 0
            for (; maze[i, j] != 2; j = ++j % n, i = j > 0 ? i : ++i % n) ;
            return (i, j);
        }

        private static IEnumerable<TestCaseData> LoopRandomCase
        {
            get
            {
                for (int i = 0; i < 100; i++)
                {
                    var point = RandomStartPoint();
                    var maze = RandomMaze();
                    maze[point.Item1, point.Item2] = 2;
                    yield return new TestCaseData(maze).Returns(point);
                }
            }
        }

        [Test, TestCaseSource("RandomCase")]
        public (int, int) RandomTest(int[,] maze)
        {
            int i = 0, j = 0, n = maze.GetLength(0);
            // until i,j make maze eq 2 as Start Point
            // loop j from 0 to n-1 step 1 and loop i from 0 step n after j on j is 0
            for (; maze[i, j] != 2; j = ++j % n, i = j > 0 ? i : ++i % n) ;
            return (i, j);
        }

        private static IEnumerable<TestCaseData> RandomCase
        {
            get
            {
                int i, j, n; ;
                i = 0; j = 0; n = 7;
                yield return new TestCaseData(RandomMaze(n, i, j)).Returns((i, j));
                i = 1; j = 1; n = 7;
                yield return new TestCaseData(RandomMaze(n, i, j)).Returns((i, j));
                i = 6; j = 6; n = 7;
                yield return new TestCaseData(RandomMaze(n, i, j)).Returns((i, j));
                i = 0; j = 6; n = 7;
                yield return new TestCaseData(RandomMaze(n, i, j)).Returns((i, j));
                i = 6; j = 0; n = 7;
                yield return new TestCaseData(RandomMaze(n, i, j)).Returns((i, j));
                i = 3; j = 5; n = 7;
                yield return new TestCaseData(RandomMaze(n, i, j)).Returns((i, j));
                i = 5; j = 3; n = 7;
                yield return new TestCaseData(RandomMaze(n, i, j)).Returns((i, j));
            }
        }

        private static int[,] RandomMaze(int n, int x, int y)
        {
            int[,] maze = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    maze[i, j] = random.Next(0, 2);
            maze[x, y] = 2;
            return maze;
        }


    }
}
