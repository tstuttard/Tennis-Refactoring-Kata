namespace Tennis
{
    internal interface IGameScore
    {
        void winPoint(string playerName);
        bool isTie();
        bool isDeuce();
        int getPlayerOnePointsWon();
        int getPlayerTwoPointsWon();
    }
}