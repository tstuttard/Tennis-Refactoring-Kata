using System.Collections.Generic;

namespace Tennis
{
    internal class TennisGame1 : ITennisGame
    {
        private IGameScore currentGameScore;
        private readonly Dictionary<string, int> gamesWon;

        public TennisGame1(IGameScore gameScore)
        {
            currentGameScore = gameScore;
            gamesWon = new Dictionary<string, int>
            {
                {gameScore.getPlayerOneName(), 0}, {gameScore.getPlayerTwoName(), 0}
            };
        }

        public void WonPoint(string playerName)
        {
            currentGameScore.winPoint(playerName);

            if (!currentGameScore.hasPlayerWon(playerName)) return;
            
            currentGameScore = new GameScore(currentGameScore.getPlayerOneName(), currentGameScore.getPlayerTwoName());
            gamesWon[playerName] += 1;
        }

        public string GetScore()
        {
            return currentGameScore.getCurrentScore();
        }

        public int GetGamesWon(string playerName)
        {
            return gamesWon[playerName];
        }
    }
}