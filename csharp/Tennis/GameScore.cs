using System.Collections.Generic;

namespace Tennis
{
    class GameScore : IGameScore
    {
        private readonly string player1Name;
        private readonly string player2Name;
        private readonly Dictionary<string, int> points = new Dictionary<string, int>();

        public GameScore(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
            points[player1Name] = 0;
            points[player2Name] = 0;
        }

        private int getPlayerOnePointsWon()
        {
            return points[player1Name];
        }

        private int getPlayerTwoPointsWon()
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

        private bool isTie()
        {
            return points[player1Name] == points[player2Name];
        }

        private bool isDeuce()
        {
            return points[player1Name] >= 4 || points[player2Name] >= 4;
        }

        private string getCurrentTiedScore()
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

        private string getCurrentDeuceScore()
        {
            var minusResult = this.getPlayerOnePointsWon() - this.getPlayerTwoPointsWon();
            switch (minusResult)
            {
                case 1:
                    return "Advantage player1";
                case -1:
                    return "Advantage player2";
            }

            return minusResult >= 2 ? "Win for player1" : "Win for player2";
        }

        public string getCurrentScore()
        {
            if (isTie())
            {
                return getCurrentTiedScore();
            }

            if (isDeuce())
            {
                return getCurrentDeuceScore();
            }
            
            var scoreOutput = "";
            for (var i = 1; i < 3; i++)
            {
                int tempScore;
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

        public string getPlayerTwoName()
        {
            return player2Name;
        }

        public string getPlayerOneName()
        {
            return player1Name;
        }

        public bool hasPlayerWon(string playerName)
        {
            return getCurrentScore().Equals($"Win for {playerName}");
        }
    }
}