namespace Tennis
{
    internal interface IGameScore
    {
        void winPoint(string playerName);
        bool isTie();
        bool isDeuce();
        string getCurrentTiedScore();
        string getCurrentDeuceScore();
        string getCurrentScore();
    }
}