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
            return new string[] { };
        }

        public string Run(Func<string, double> fitness, int length, double p_c, double p_m, int iterations = 100)
        {
            return "";
        }
    }
}
