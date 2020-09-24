namespace Tennis
{
    internal interface IGameScore
    {
        void winPoint(string playerName);

        string getCurrentScore();
        string getPlayerTwoName();
        string getPlayerOneName();
        bool hasPlayerWon(string playerName);
    }
}