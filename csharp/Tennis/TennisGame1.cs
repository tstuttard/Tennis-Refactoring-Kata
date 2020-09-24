using System.Collections.Generic;

namespace Tennis
{
    class GameScore
    {
        private string player1Name;
        private string player2Name;
        private Dictionary<string, int> points = new Dictionary<string, int>();

        public GameScore(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
            points[player1Name] = 0;
            points[player2Name] = 0;
        }

        public int getPlayerOnePointsWon()
        {
            return points[player1Name];
        }

        public int getPlayerTwoPointsWon()
        {
            return points[player2Name];
        }

        public void winPoint(string playerName)
        {
            if (!points.ContainsKey(playerName))
            {
                throw new PlayerNotFoundException($"{playerName} not found.");
            }

            points[playerName] += 1;
        }

        public bool isTie()
        {
            return points[player1Name] == points[player2Name];
        }

        public bool isDeuce()
        {
            return points[player1Name] >= 4 || points[player2Name] >= 4;
        }

        public string getCurrentTiedScore()
        {
            switch (getPlayerOnePointsWon())
            {
                case 0:
                    return "Love-All";
                case 1:
                    return "Fifteen-All";
                case 2:
                    return "Thirty-All";
                default:
                    return "Deuce";
            }
        }

        public string getCurrentDeuceScore()
        {
            var minusResult = this.getPlayerOnePointsWon() - this.getPlayerTwoPointsWon();
            if (minusResult == 1)
            {
                return "Advantage player1";
            }

            if (minusResult == -1)
            {
                return "Advantage player2";
            }

            if (minusResult >= 2)
            {
                return "Win for player1";
            }

            return "Win for player2";
        }

        public string getCurrentScore()
        {
            string scoreOutput = "";
            int tempScore;
            for (var i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = getPlayerOnePointsWon();
                else
                {
                    scoreOutput += "-";
                    tempScore = getPlayerTwoPointsWon();
                }

                switch (tempScore)
                {
                    case 0:
                        scoreOutput += "Love";
                        break;
                    case 1:
                        scoreOutput += "Fifteen";
                        break;
                    case 2:
                        scoreOutput += "Thirty";
                        break;
                    case 3:
                        scoreOutput += "Forty";
                        break;
                }
            }

            return scoreOutput;
        }
    }

    class TennisGame1 : ITennisGame
    {
        private GameScore currentGameScore;

        public TennisGame1(GameScore gameScore)
        {
            currentGameScore = gameScore;
        }

        public void WonPoint(string playerName)
        {
            currentGameScore.winPoint(playerName);
        }

        public string GetScore()
        {
            // todo allow the changing of how the scores are displayed
            // todo show which players are winning
            // todo add a wimbledon scoreboard display
            if (currentGameScore.isTie())
            {
                return currentGameScore.getCurrentTiedScore();
            }

            if (currentGameScore.isDeuce())
            {
                return currentGameScore.getCurrentDeuceScore();
            }

            return currentGameScore.getCurrentScore();
        }
    }
}