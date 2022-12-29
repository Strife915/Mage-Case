using MageCase.Abstract.Backend;
using MageCase.DataEntities;
using MageCase.Scriptableobjects;

namespace MageCase.Backend
{
    public class LeaderboardApiCall : BasseApiCallClass, ILeaderboardApiCall
    {
        public LeaderBoardDataEntities GetLeaderboard(int pageCount)
        {
            var result = GetApiCall<LeaderBoardDataEntities>(UrlDataContainerSo, pageCount);
            return result;
        }

        public LeaderboardApiCall(ApiUrlDataContainerSo apiUrlDataContainerSo) : base(apiUrlDataContainerSo)
        {
        }
    }
}