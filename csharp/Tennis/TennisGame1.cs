using System.Collections.Generic;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;
        private Dictionary<string, int> score = new Dictionary<string, int>();

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
            this.score[player1Name] = 0;
            this.score[player2Name] = 0;
        }

        public void WonPoint(string playerName)
        {
            // todo use map to track points won.
            // todo use a ValueObject to represent a Point

            // todo add test for different player names
            if (!this.score.ContainsKey(playerName))
            {
                throw new PlayerNotFoundException($"{playerName} not found.");
            }
            if (playerName == "player1")
            {
                m_score1 += 1;
            }
            else
            {
                m_score2 += 1;
            }
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            
            // todo allow the changing of how the scores are displayed
            // todo show which players are winning
            // todo add a wimbledon scoreboard display
            if (isScoreTied())
            {
                switch (m_score1)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;

                }
            }
            else if (isDuece())
            {
                var minusResult = m_score1 - m_score2;
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = m_score1;
                    else { score += "-"; tempScore = m_score2; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }

        private bool isDuece()
        {
            return m_score1 >= 4 || m_score2 >= 4;
        }

        private bool isScoreTied()
        {
            return m_score1 == m_score2;
        }
    }
}

