using System;
using Magecase.Abstract.Backend;
using Magecase.Backend;
using MageCase.Scriptableobjects;
using UnityEngine;

namespace Magecase.Uis
{
    public class LeaderboardSlotManager : MonoBehaviour
    {
        [SerializeField] ApiUrlDataContainer _apiUrlDataContainer;
        [SerializeField] LeaderboardSlotController[] _leaderboardSlotControllers;
        ILeaderboardApiCall _leaderboardApiCall;

        void Awake()
        {
            _leaderboardApiCall = new LeaderboardApiCall(_apiUrlDataContainer);
        }

        void Start()
        {
            GetLeaderBoard(0);
        }

        void GetLeaderBoard(int pageNumber)
        {
            var entities = _leaderboardApiCall.GetLeaderboard(pageNumber).Data;
            var count = entities.Count;
            for (var i = 0; i < count; i++) _leaderboardSlotControllers[i].BindEntities(entities[i]);
        }
    }
}