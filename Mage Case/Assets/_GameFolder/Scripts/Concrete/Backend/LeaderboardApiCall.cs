using Magecase.Abstract.Backend;
using Magecase.DataEntities;
using MageCase.Scriptableobjects;

namespace Magecase.Backend
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