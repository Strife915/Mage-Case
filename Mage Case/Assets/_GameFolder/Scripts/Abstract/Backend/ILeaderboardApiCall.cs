using MageCase.DataEntities;

namespace MageCase.Abstract.Backend
{
    public interface ILeaderboardApiCall
    {
        LeaderBoardDataEntities GetLeaderboard(int pageCount);
    }
}