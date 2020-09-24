using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tennis
{
    internal class Point
    {
        public string playerName { get; }
        public string score { get; }

        public Point(string playerName, string score)
        {
            this.playerName = playerName;
            this.score = score;
        }
    }
    
    [TestFixture(0, 0, "Love-All")]
    [TestFixture(1, 1, "Fifteen-All")]
    [TestFixture(2, 2, "Thirty-All")]
    [TestFixture(3, 3, "Deuce")]
    [TestFixture(4, 4, "Deuce")]
    [TestFixture(1, 0, "Fifteen-Love")]
    [TestFixture(0, 1, "Love-Fifteen")]
    [TestFixture(2, 0, "Thirty-Love")]
    [TestFixture(0, 2, "Love-Thirty")]
    [TestFixture(3, 0, "Forty-Love")]
    [TestFixture(0, 3, "Love-Forty")]
    [TestFixture(4, 0, "Win for player1")]
    [TestFixture(0, 4, "Win for player2")]
    [TestFixture(2, 1, "Thirty-Fifteen")]
    [TestFixture(1, 2, "Fifteen-Thirty")]
    [TestFixture(3, 1, "Forty-Fifteen")]
    [TestFixture(1, 3, "Fifteen-Forty")]
    [TestFixture(4, 1, "Win for player1")]
    [TestFixture(1, 4, "Win for player2")]
    [TestFixture(3, 2, "Forty-Thirty")]
    [TestFixture(2, 3, "Thirty-Forty")]
    [TestFixture(4, 2, "Win for player1")]
    [TestFixture(2, 4, "Win for player2")]
    [TestFixture(4, 3, "Advantage player1")]
    [TestFixture(3, 4, "Advantage player2")]
    [TestFixture(5, 4, "Advantage player1")]
    [TestFixture(4, 5, "Advantage player2")]
    [TestFixture(15, 14, "Advantage player1")]
    [TestFixture(14, 15, "Advantage player2")]
    [TestFixture(6, 4, "Win for player1")]
    [TestFixture(4, 6, "Win for player2")]
    [TestFixture(16, 14, "Win for player1")]
    [TestFixture(14, 16, "Win for player2")]
    public class TennisTests
    {
        private readonly int player1Score;
        private readonly int player2Score;
        private readonly string expectedScore;
        private const string player1Name = "player1";
        private const string player2Name = "player2";

        public TennisTests(int player1Score, int player2Score, string expectedScore)
        {
            this.player1Score = player1Score;
            this.player2Score = player2Score;
            this.expectedScore = expectedScore;
        }

        [Test]
        public void CheckGameScore()
        {
            var gameScore = new GameScore(player1Name, player2Name);
            CheckAllScores(gameScore);
        }

        private void CheckAllScores(IGameScore game)
        {
            var highestScore = Math.Max(player1Score, player2Score);
            for (var i = 0; i < highestScore; i++)
            {
                if (i < player1Score)
                    game.winPoint(player1Name);
                if (i < player2Score)
                    game.winPoint(player2Name);
            }

            Assert.AreEqual(expectedScore, game.getCurrentScore());
        }
    }

    [TestFixture]
    public class ExampleGameTennisTest
    {
        private const string player1Name = "player1";
        private const string player2Name = "player2";

        [Test]
        public void CheckGame1()
        {
            var game = new TennisGame1(new GameScore(player1Name, player2Name));
            RealisticTennisGame(game);
        }

        [Test]
        public void OnlyAllowTwoPlayers()
        {
            var game = new TennisGame1(new GameScore(player1Name, player2Name));

            var exception = Assert.Throws<PlayerNotFoundException>(() => game.WonPoint("player3"));
            Assert.AreEqual("player3 not found.", exception.Message);
        }

        [Test]
        public void PlayerOneWinsTwoGamesWithSecondGameGoingToAdvantage()
        {
            var game = new TennisGame1(new GameScore(player1Name, player2Name));

            var pointsWon = new List<Point>
            {
                new Point(player1Name, "Fifteen-Love"),
                new Point(player1Name, "Thirty-Love"),
                new Point(player2Name,"Thirty-Fifteen"),
                new Point(player2Name,"Thirty-All"),
                new Point(player1Name,"Forty-Thirty"),
                new Point(player1Name,"Love-All"),
                new Point(player1Name,"Fifteen-Love"),
                new Point(player2Name,"Fifteen-All"),
                new Point(player1Name,"Thirty-Fifteen"),
                new Point(player2Name,"Thirty-All"),
                new Point(player2Name,"Thirty-Forty"),
                new Point(player1Name,"Deuce"),
                new Point(player1Name,"Advantage player1"),
                new Point(player2Name,"Deuce"),
                new Point(player1Name,"Advantage player1"),
                new Point(player1Name,"Love-All"),
            };

            foreach (var pointWon in pointsWon)
            {
                game.WonPoint(pointWon.playerName);
                Assert.AreEqual(pointWon.score, game.GetScore());
            }

            Assert.AreEqual(2, game.GetGamesWon(player1Name));
            Assert.AreEqual(0, game.GetGamesWon(player2Name));
            
        }

        private static void RealisticTennisGame(ITennisGame game)
        {
            var pointsWon = new List<Point>
            {
                new Point(player1Name, "Fifteen-Love"),
                new Point(player1Name, "Thirty-Love"),
                new Point(player2Name, "Thirty-Fifteen"),
                new Point(player2Name, "Thirty-All"),
                new Point(player1Name, "Forty-Thirty"),
                new Point(player1Name, "Love-All"),
            };
            
            foreach (var pointWon in pointsWon)
            {
                game.WonPoint(pointWon.playerName);
                Assert.AreEqual(pointWon.score, game.GetScore());
            }
        }
    }
}