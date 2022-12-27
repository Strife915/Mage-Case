using System.Collections.Generic;

namespace Magecase.DataEntities
{
    public struct LeaderBoardDataEntities
    {
        public int Page { get; set; }
        public bool IsLast { get; set; }
        public List<LeaderBoardPlayerEntityData> Data { get; set; }
    }
}