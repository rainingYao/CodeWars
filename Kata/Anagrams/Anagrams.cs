namespace Anagrams
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Collections.Generic;

    [TestFixture]
    public class AnagramsTest
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(new List<string> { "a" }, Kata.Anagrams("a", new List<string> { "a", "b", "c", "d" }));
            Assert.AreEqual(new List<string> { "carer", "arcre", "carre" }, Kata.Anagrams("racer", new List<string> { "carer", "arcre", "carre", "racrs", "racers", "arceer", "raccer", "carrer", "cerarr" }));
        }

        [Test]
        public void FixedTest()
        {
            Assert.AreEqual(new List<string> { "ab", "ba" }, Kata.Anagrams("ab", new List<string> { "ab", "aa", "bb", "cc", "ac", "bc", "cd", "ba" }));
            Assert.AreEqual(new List<string> { "aabb", "bbaa", "abab", "baba", "baab" }, Kata.Anagrams("abba", new List<string> { "aabb", "bbaa", "abcd", "abbba", "baaab", "abbab", "abbaa", "babaa", "abab", "baba", "baab" }));
            Assert.AreEqual(new List<string> { }, Kata.Anagrams("big", new List<string> { "gig", "dib", "bid", "biig" }));
        }

        [Test]
        public void EdgeTest()
        {
            Assert.AreEqual(new List<string>(), Kata.Anagrams("dddddd", new List<string> { "xxxxx" }));
            Assert.AreEqual(new List<string>(), Kata.Anagrams("ddddddddddd", new List<string> { "nnnnnnnnnn" }));
            Assert.AreEqual(new List<string>(), Kata.Anagrams("ln", new List<string> { "cx" }));
        }

        private static Random rnd = new Random();

        private static List<string> solution(string word, List<string> words)
        {
            // Hash of the count of each character in word
            Dictionary<char, int> wordCount = word.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count(c => c == c));

            // Filter words due to the following predicate
            return words.Where(w =>
            {
                // Hash of the count of each character of a word in words
                Dictionary<char, int> wCount = w.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count(c => c == c));

                // Check if the two hashes are equal
                return wCount.Count == wordCount.Count && !wCount.Except(wordCount).Any();
            }).ToList();
        }

        private static string generateWord() =>
          String.Concat(new char[rnd.Next(2, 12)].Select(_ => (char)rnd.Next(97, 123)));

        [Test]
        public void RandomTest()
        {
            const int Tests = 1000;

            for (int i = 0; i < Tests; ++i)
            {
                string word = generateWord();
                List<string> words = new string[rnd.Next(3, 20)].Select(_ => rnd.Next(0, 2) == 0 ? String.Concat(word.OrderBy(__ => rnd.Next())) : generateWord()).ToList();

                List<string> expected = solution(word, words);
                List<string> actual = Kata.Anagrams(word, words);

                Assert.AreEqual(expected, actual);
            }
        }
    }

    public static class Kata
    {
        public static List<string> Anagrams(string word, List<string> words)
        {
            //One of the best
            return words.Where(w => w.OrderBy(p => p).SequenceEqual(word.OrderBy(p => p))).ToList();

            //My Solutions
            //return words.Where(w => new string(w.OrderBy(c => (int)c).ToArray()) == new string(word.OrderBy(c => (int)c).ToArray())).ToList();

            //My wrong plan
            //return words.Where(w => (w + word).Select(c => (int)c).Aggregate((x, y) => x ^ y) == 0 && w.Length == word.Length).ToList();

        }
    }
}