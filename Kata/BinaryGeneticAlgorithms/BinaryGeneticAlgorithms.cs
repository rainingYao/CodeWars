namespace BinaryGeneticAlgorithms
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    // TODO: Replace examples and use TDD development by writing your own tests

    [TestFixture]
    public class SolutionTest
    {
        static string ideal = "1001100110011001";
        GeneticAlgorithm genetic = new GeneticAlgorithm();

        [Test]
        public void MyTest()
        {
            ideal = genetic.Generate(4);
            Assert.AreEqual(ideal, genetic.Run(fitness, ideal.Length, 0.6, 0.002));
            ideal = genetic.Generate(35);
            Assert.AreEqual(ideal, genetic.Run(fitness, ideal.Length, 0.6, 0.002));
        }

        public readonly Func<string, double> fitness = (c) =>
        {
            double r = 0;
            for (int i = 0; i < c.Length; ++i)
            {
                if (c[i] == ideal[i])
                {
                    r++;
                }
            }
            return r / (double)ideal.Length;
        };
    }

    public class GeneticAlgorithm
    {
        private Random random = new Random();

        public string Generate(int length)
        {
            return string.Concat(new int[length].Select(i => random.Next(2)));
        }

        public string Select(IEnumerable<string> population, IEnumerable<double> fitnesses, double sum = 0)
        {
            double surviving = random.NextDouble() * sum;
            int i = 0;
            while (surviving > 0) surviving -= fitnesses.ElementAt(i++);
            return population.ElementAt(--i);
        }

        public string Mutate(string chromosome, double probability)
        {
            return string.Concat(chromosome.Select(c => random.NextDouble() >= probability ? c : c == '1' ? '0' : '1'));
        }

        public IEnumerable<string> Crossover(string chromosome1, string chromosome2)
        {
            int cut = random.Next(chromosome1.Length, chromosome1.Length);
            return new string[] { chromosome1.Substring(0, cut) + chromosome2.Substring(cut),
            chromosome2.Substring(0, cut) + chromosome1.Substring(cut)};
        }

        public string Run(Func<string, double> fitness, int length, double p_c, double p_m, int iterations = 1000)
        {
            string[] population = new string[20];
            double[] fitnesses = new double[20];
            for (int i = 0; i < 20; i++)
            {
                string chromosome = Generate(length);
                population[i] = chromosome;
                fitnesses[i] = fitness(chromosome);
            }
            for (int i = 0; i < iterations; i++)
            {
                string[] sons = new string[20];
                double[] sonsfitnesses = new double[20];
                for (int j = 0; j < 10; j++)
                {
                    string q = Select(population, fitnesses, fitnesses.Sum());
                    string p = Select(population, fitnesses, fitnesses.Sum());
                    if (random.NextDouble() > p_c)
                    {
                        int cut = random.Next(q.Length, p.Length);
                        (q, p) = (q.Substring(0, cut) + p.Substring(cut), p.Substring(0, cut) + q.Substring(cut));
                    }
                    q = Mutate(q, p_m); p = Mutate(p, p_m);
                    sons[j] = q;
                    sons[j + 10] = p;
                    sonsfitnesses[j] = fitness(q);
                    sonsfitnesses[j + 10] = fitness(p);
                }
                sons.CopyTo(population, 0);
                sonsfitnesses.CopyTo(fitnesses, 0);
            }
            return population[Array.IndexOf(fitnesses, fitnesses.Max())];
        }
    }

    [TestFixture]
    public class KataTest
    {
        private GeneticAlgorithm GA = new GeneticAlgorithm();
        private const int CL = 35;
        private Random random = new Random();


        [Test]
        public void _0_SmallTests()
        {
            StringBuilder sb;
            string goal;
            Func<string, double> f;
            int size = 4;

            for (int i = 0; i < 2; ++i)
            {
                sb = new StringBuilder(size);

                for (int j = 0; j < size; ++j)
                {
                    sb.Append(Math.Floor(2 * random.NextDouble()).ToString());
                }
                goal = sb.ToString();
                f = Fitness(goal);

                Assert.AreEqual(goal, GA.Run(f, size, 0.6, 0.002));
            }
        }

        [Test]
        public void _1_GeneticAlgorithm()
        {
            StringBuilder sb = new StringBuilder(CL);
            string goal;
            Func<string, double> f;

            for (int j = 0; j < CL; ++j)
            {
                sb.Append(Math.Floor(2 * random.NextDouble()).ToString());
            }
            goal = sb.ToString();
            f = Fitness(goal);

            Assert.AreEqual(goal, GA.Run(f, CL, 0.6, 0.002));
        }

        Func<string, double> Fitness(string goal)
        {
            return (c) =>
            {
                double r = 0;
                for (int i = 0; i < c.Length; ++i)
                {
                    if (c[i] == goal[i])
                    {
                        r++;
                    }
                }
                return r / (double)goal.Length;
            };
        }
    }
}
