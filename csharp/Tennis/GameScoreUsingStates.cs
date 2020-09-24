using System.Collections.Generic;

namespace Tennis
{
    public class GameScoreUsingStates: IGameScore
    {
        private enum States
        {
            Love,
            Fifteen,
            Thirty,
            Forty,
            Deuce,
            Advantage,
            GameWon
        }
        
        private string player1Name;
        private string player2Name;
        private Dictionary<string, States> pointsStates = new Dictionary<string, States>();
        public GameScoreUsingStates(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
            pointsStates[player1Name] = States.Love;
            pointsStates[player2Name] = States.Love;
            
        }

        public void winPoint(string playerName)
        {
            if (!pointsStates.ContainsKey(playerName))
            {
                throw new PlayerNotFoundException($"{playerName} not found.");
            }

            transitionCurrentScore(playerName);
        }

        private void transitionCurrentScore(string playerName)
        {
            if (getCurrentScore() == $"{States.Love}-All")
            {
                pointsStates[playerName] = States.Fifteen;
            }
            
            
        }

        private string getCurrentScore()
        {
            if (isTie())
            {
                return $"{pointsStates[player1Name]}-All";
            }

            return $"{pointsStates[player1Name]}-{pointsStates[player2Name]}";
        }
        
        public bool isTie()
        {
            return pointsStates[player1Name] == pointsStates[player2Name];
        }

        public bool isDeuce()
        {
            throw new System.NotImplementedException();
        }

        public int getPlayerOnePointsWon()
        {
            throw new System.NotImplementedException();
        }

        public int getPlayerTwoPointsWon()
        {
            throw new System.NotImplementedException();
        }
    }
}