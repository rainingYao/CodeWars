namespace RPS
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using NUnit.Framework;

    [TestFixture]
    public class KataTests
    {
        Kata kata = new Kata();

        [Test]
        public void Player1Win()
        {
            Assert.AreEqual("Player 1 won!", kata.Rps("rock", "scissors"));
            Assert.AreEqual("Player 1 won!", kata.Rps("scissors", "paper"));
            Assert.AreEqual("Player 1 won!", kata.Rps("paper", "rock"));
        }

        [Test]
        public void Player2Win()
        {
            Assert.AreEqual("Player 2 won!", kata.Rps("scissors", "rock"));
            Assert.AreEqual("Player 2 won!", kata.Rps("paper", "scissors"));
            Assert.AreEqual("Player 2 won!", kata.Rps("rock", "paper"));
        }

        [Test]
        public void Draw()
        {
            Assert.AreEqual("Draw!", kata.Rps("rock", "rock"));
            Assert.AreEqual("Draw!", kata.Rps("scissors", "scissors"));
            Assert.AreEqual("Draw!", kata.Rps("paper", "paper"));
        }
    }

    public class Kata
    {
        public string Rps(string p1, string p2)
        {
            return p1 == p2 ? "Draw!" : "rock>scissors>paper>rock".Contains(p1 + ">" + p2) ? "Player 1 won!" : "Player 2 won!";
        }
    }
}
