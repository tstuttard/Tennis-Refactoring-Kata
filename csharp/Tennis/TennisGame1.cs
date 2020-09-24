namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private IGameScore currentGameScore;

        public TennisGame1(IGameScore gameScore)
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

            return currentGameScore.getCurrentScore();
        }
    }
}