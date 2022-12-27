using Magecase.DataEntities;

namespace Magecase.Abstract.Backend
{
    public interface ILeaderboardApiCall
    {
        LeaderBoardDataEntities GetLeaderboard(int pageCount);
    }
}