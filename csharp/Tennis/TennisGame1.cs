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
    }
    
    class TennisGame1 : ITennisGame
    {
        private string player1Name;
        private string player2Name;
        private GameScore currentGameScore;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
            currentGameScore = new GameScore(player1Name, player2Name);
        }

        public void WonPoint(string playerName)
        {
            currentGameScore.winPoint(playerName);
        }

        public string GetScore()
        {
            string scoreOutput = "";
            var tempScore = 0;
            
            // todo allow the changing of how the scores are displayed
            // todo show which players are winning
            // todo add a wimbledon scoreboard display
            if (currentGameScore.isTie())
            {
                switch (currentGameScore.getPlayerOnePointsWon())
                {
                    case 0:
                        scoreOutput = "Love-All";
                        break;
                    case 1:
                        scoreOutput = "Fifteen-All";
                        break;
                    case 2:
                        scoreOutput = "Thirty-All";
                        break;
                    default:
                        scoreOutput = "Deuce";
                        break;

                }
            }
            else if (currentGameScore.isDeuce())
            {
                var minusResult = currentGameScore.getPlayerOnePointsWon() - currentGameScore.getPlayerTwoPointsWon();
                if (minusResult == 1) scoreOutput = "Advantage player1";
                else if (minusResult == -1) scoreOutput = "Advantage player2";
                else if (minusResult >= 2) scoreOutput = "Win for player1";
                else scoreOutput = "Win for player2";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = currentGameScore.getPlayerOnePointsWon();
                    else { scoreOutput += "-"; tempScore = currentGameScore.getPlayerTwoPointsWon(); }
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
            }
            return scoreOutput;
        }
    }
}

