namespace BinaryGeneticAlgorithms
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // TODO: Replace examples and use TDD development by writing your own tests

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void MyTest()
        {
            Assert.AreEqual("expected", "actual");
        }
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
            int cut = random.Next(chromosome1.Length / 3, chromosome1.Length * 2 / 3);
            return new string[] { chromosome1.Substring(0, cut) + chromosome2.Substring(cut),
            chromosome2.Substring(0, cut) + chromosome1.Substring(cut)};
        }

        public string Run(Func<string, double> fitness, int length, double p_c, double p_m, int iterations = 100)
        {
            List<string> population = new List<string>();
            List<double> fitnesses = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                string chromosome = Generate(length);
                population.Add(chromosome);
                fitnesses.Add(fitness(chromosome));
            }
            for (int i = 0; i < iterations; i++)
            {
                string q = Select(population, fitnesses, fitnesses.Sum());
                string p = Select(population, fitnesses, fitnesses.Sum());
                if (random.NextDouble() > p_c)
                {
                    int cut = random.Next(q.Length, p.Length);
                    (q, p) = (q.Substring(0, cut) + p.Substring(cut), p.Substring(0, cut) + q.Substring(cut));
                }
                q = Mutate(q, p_m); p = Mutate(p, p_m);
                population.Add(q); population.Add(p);
                fitnesses.Add(fitness(q)); fitnesses.Add(fitness(p));
            }
            return population[fitnesses.IndexOf(fitnesses.Max())];
        }
    }
}
