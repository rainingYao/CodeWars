namespace GeneticAlgorithmSeries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using NUnit.Framework;

    public class Kata
    {
        Random random = new Random(new Guid().GetHashCode());

        public string Generate(int length)
        {
            return string.Concat(new int[length].Select(i => random.Next(2)));
            //StringBuilder sb = new StringBuilder();
            //for (int i = 0; i < length; i++)
            //    sb.Append(Convert.ToString(random.Next(2), 2));
            //return sb.ToString();
        }

        public string Mutate(string chromosome, double probability)
        {
            return string.Concat(chromosome.Select(c => random.NextDouble() >= probability ? c : c == '1' ? '0' : '1'));
        }

        public IEnumerable<string> Crossover(string chromosome1, string chromosome2, int cut)
        {
            yield return chromosome1.Substring(0, cut) + chromosome2.Substring(cut);
            yield return chromosome2.Substring(0, cut) + chromosome1.Substring(cut);
            //return new[] { chromosome1.Substring(0, cut) + chromosome2.Substring(cut),
            //    chromosome2.Substring(0, cut) + chromosome1.Substring(cut)};
        }

        public IEnumerable<ChromosomeWrap> MapPopulationFit(IEnumerable<string> population, Func<string, double> fitness)
        {
            return population.Select(chromosome => new ChromosomeWrap() { Chromosome = chromosome, Fitness = fitness(chromosome) });
        }

        public string Select(IEnumerable<string> population, IEnumerable<double> fitnesses)
        {
            //double surviving = random.NextDouble();//This line of code can still pass!
            double surviving = random.NextDouble() * fitnesses.Sum();//Why SampleTest.Sum=1 But RandomTest.Sum>1 ?
            int i = 0;
            while (surviving > 0) surviving -= fitnesses.ElementAt(i++);
            //for (; surviving > 0; surviving -= fitnesses.ElementAt(i++)) ;
            return population.ElementAt(--i);
        }
    }

    [TestFixture]
    public class KataTest
    {
        private Random random = new Random();
        private Kata kata = new Kata();

        [Test]
        public void _0_Generate_Should_Respect_Given_Length()
        {
            Assert.AreEqual(0, kata.Generate(0).Length);
            Assert.AreEqual(1, kata.Generate(1).Length);
            Assert.AreEqual(16, kata.Generate(16).Length);
            Assert.AreEqual(32, kata.Generate(32).Length);
            Assert.AreEqual(64, kata.Generate(64).Length);
            Assert.AreEqual(10000, kata.Generate(10000).Length);
        }

        [Test]
        public void _1_Generate_In_Chromosome_Length_50()
        {
            Assert.IsTrue(kata.Generate(50).Contains('1'), "It should (probably) have at least one '1'");
            Assert.IsTrue(kata.Generate(50).Contains('0'), "It should (probably) have at least one '0'");
        }

        [Test]
        public void _2_Generate_Length_L_Should_Return_All_Combinations()
        {
            var l = (int)Math.Floor(random.NextDouble() * 20) + 10;
            var s = new HashSet<string>();

            for (int i = 0; i < 2000; ++i)
            {
                s.Add(kata.Generate(l));
            }

            for (int i = 0; i < l; ++i)
            {
                Assert.IsTrue(s.Any(v => v.ElementAt(i) == '0') && s.Any(v => v.ElementAt(i) == '1'));
            }
        }

        private string zero = new String('0', 100);
        private string one = new String('1', 100);

        public const string errMsg = "it should probably mutate, try again";

        public string Solution(string chromosome, double probability)
        {
            return String.Join("", chromosome.Select(c => random.NextDouble() <= probability ? (c == '0' ? "1" : "0") : c.ToString()));
        }

        [Test]
        public void Mutate100()
        {
            Assert.AreEqual("1111", kata.Mutate("0000", 1));
            Assert.AreEqual("0000", kata.Mutate("1111", 1));
        }

        [Test]
        public void Mutate0()
        {
            Assert.AreEqual("0000", kata.Mutate("0000", 0));
            Assert.AreEqual("1111", kata.Mutate("1111", 0));
        }

        [Test]
        public void Mutate50()
        {
            Assert.IsTrue(kata.Mutate(zero, 0.5).Any(o => o == '1'));
            Assert.IsTrue(kata.Mutate(one, 0.5).Any(o => o == '1'));
        }

        [Test]
        public void Mutate_Random()
        {
            var r = kata.Mutate(zero, random.NextDouble());
            Assert.IsTrue(r != zero, errMsg);
            Assert.IsTrue(r.Any(o => o == '1'), errMsg);
            Assert.AreEqual(zero.Length, r.Length, "length is supposed to be the same");
        }

        [Test]
        public void _0_Crossover_Basic_Tests()
        {
            Assert.AreEqual("111", kata.Crossover("110", "001", 2).ElementAt(0));
            Assert.AreEqual("000", kata.Crossover("110", "001", 2).ElementAt(1));

            Assert.AreEqual("111110", kata.Crossover("111000", "000110", 3).ElementAt(0));
            Assert.AreEqual("000000", kata.Crossover("111000", "000110", 3).ElementAt(1));
        }

        public class KataSolution
        {
            public IEnumerable<ChromosomeWrap> MapPopulationFit(IEnumerable<string> population, Func<string, double> fitness)
            {
                return population.Select(c => new ChromosomeWrap { Chromosome = c, Fitness = fitness(c) });
            }
        }

        private KataSolution solution = new KataSolution();

        public readonly IEnumerable<string> population = new List<string> { "10100111", "11011100",
      "01101000", "01100111", "01000010", "10001001", "10111100", "11111000", "11001100",
      "00001011", "01011011", "01000111", "11010101", "00101101", "00100111", "00000111",
      "00101000", "00101011", "01011011", "10100001", "00111000", "00010110", "00101100",
      "11111110", "10101001", "11101001", "00011001", "10100011", "11000001", "11010101",
      "11000110", "01111000", "11011000", "00111010", "11110100", "00100111", "10001101",
      "11000100", "01110010", "10011111", "10110101", "11001100", "00110111", "00000100",
      "10010010", "00011000", "10111010", "10001000", "00010011", "01001011", "00100010",
      "01111000", "01110111", "11101011", "00001010", "00000000", "01100011", "00011111",
      "10000001", "01100010", "11011100", "10001100", "01110010", "11011011", "00000111",
      "10100100", "00101101", "00001101", "10010110", "10101110", "00111010", "00011001",
      "11000110", "01010101", "00101000", "00000110", "11001000", "11000110", "01010100",
      "01011010", "00101101", "00011001", "00010101", "10101110", "01100010", "01110101",
      "01111011", "00111000", "11101110", "00110100", "11100100", "01011101", "10000110",
      "11111101", "11000001", "11000111", "11000111", "01011000", "10011011", "10110101" };

        public readonly Func<string, double> fitness = (c) =>
        {
            var ideal = "10011001";
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

        [Test]
        public void _0_Map_Should_Return_Correct_Values()
        {
            var correct = solution.MapPopulationFit(population, fitness);
            var result = kata.MapPopulationFit(population, fitness);

            foreach (var item in correct)
            {
                var f = result.FirstOrDefault(c => c.Chromosome == item.Chromosome);
                if (f == null)
                {
                    Assert.Fail($"Chromosome {item.Chromosome} not found!");
                }
                Assert.AreEqual(item.Fitness, f.Fitness);
            }
        }

        [Test]
        public void _0_Select_High_Chance_Should_Probably_Return()
        {
            string[] population = new string[] { "1", "2", "3" };
            double[] fitnesses = new double[] { 0.05, 0.05, 0.90 };
            for (int i = 0; i < 10; i++)
            {
                var results = new List<string>();
                for (int j = 0; j < 10; j++)
                {
                    results.Add(kata.Select(population, fitnesses));
                }

                var threes = results.Count(c => c == "3");
                Assert.IsTrue(threes >= 6, $"3 should be the most returned element, got {threes} returns");
            }
        }

        [Test]
        public void _1_Select_Random_Tests()
        {
            var population = new List<string> { "0", "42", "1337" };
            var fitnesses = new List<double> { 1e-20, 0.55, 0.99999999 };

            for (int i = 0; i < 50; i++)
            {
                population.Add(random.NextDouble().ToString());
                fitnesses.Add(0.01 * random.NextDouble());
            }

            for (int i = 0; i < 10; i++)
            {
                var results = new List<string>();
                for (int j = 0; j < 15; j++)
                {
                    results.Add(kata.Select(population, fitnesses));
                }

                var l33t = results.Count(x => x == "1337");
                var isMostRet = results.Where(x => x != "42" && x != "1337").All(x =>
                {
                    var r = results.Count(y => x == y);
                    return l33t > r;
                });

                Assert.IsTrue(isMostRet, "1337 and 42 should be the most returned");
                Assert.IsTrue(results.Any(x => x == "42"), "should sometimes return 42");
                Assert.IsTrue(!results.Any(x => x == "0"), $"should almost never return 0, got {results.Count(x => x == "0")} times");
            }
        }
    }

    public class ChromosomeWrap
    {
        public string Chromosome { get; set; }
        public double Fitness { get; set; }
    }
}
