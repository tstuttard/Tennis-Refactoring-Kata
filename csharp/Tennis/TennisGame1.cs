using System.Collections.Generic;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private string player1Name;
        private string player2Name;
        private Dictionary<string, int> score = new Dictionary<string, int>();

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
            score[player1Name] = 0;
            score[player2Name] = 0;
        }

        public void WonPoint(string playerName)
        {
            // todo use map to track points won.
            // todo use a ValueObject to represent a Point
            
            if (!score.ContainsKey(playerName))
            {
                throw new PlayerNotFoundException($"{playerName} not found.");
            }

            score[playerName] += 1;
        }

        public string GetScore()
        {
            string scoreOutput = "";
            var tempScore = 0;
            
            // todo allow the changing of how the scores are displayed
            // todo show which players are winning
            // todo add a wimbledon scoreboard display
            if (isScoreTied())
            {
                switch (score[player1Name])
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
            else if (isDuece())
            {
                var minusResult = score[player1Name] - score[player2Name];
                if (minusResult == 1) scoreOutput = "Advantage player1";
                else if (minusResult == -1) scoreOutput = "Advantage player2";
                else if (minusResult >= 2) scoreOutput = "Win for player1";
                else scoreOutput = "Win for player2";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = score[player1Name];
                    else { scoreOutput += "-"; tempScore = score[player2Name]; }
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

        private bool isDuece()
        {
            return score[player1Name] >= 4 || score[player2Name] >= 4;
        }

        private bool isScoreTied()
        {
            return score[player1Name] == score[player2Name];
        }
    }
}

