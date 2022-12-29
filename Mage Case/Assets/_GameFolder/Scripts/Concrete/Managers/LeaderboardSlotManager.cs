using MageCase.Abstract.Backend;
using MageCase.Abstract.Behaviours;
using MageCase.Backend;
using MageCase.Scriptableobjects;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MageCase.Uis
{
    public class LeaderboardSlotManager : MonoBehaviour
    {
        [FormerlySerializedAs("_apiUrlDataContainer")] [SerializeField]
        ApiUrlDataContainerSo apiUrlDataContainerSo;

        [SerializeField] LeaderboardSlotController[] _leaderboardSlotControllers;
        [SerializeField] Button _prevButton, _nextButton;
        [SerializeField] TMP_Text _pageText;
        ILeaderboardApiCall _leaderboardApiCall;

        INumberLimitor _numberLimitor;
        int _currentPageNumber = 0;
        bool _isLastPage => _currentPageNumber == apiUrlDataContainerSo.PageLength - 1;
        bool _isFirstPage => _currentPageNumber == 0;

        void Awake()
        {
            _numberLimitor = new NumberLimitor();
            _leaderboardApiCall = new LeaderboardApiCall(apiUrlDataContainerSo);
            UpdateButtons();
            UpdatePageText(_currentPageNumber + 1);
            GetLeaderBoard(_currentPageNumber);
        }

        void GetLeaderBoard(int pageNumber)
        {
            var entities = _leaderboardApiCall.GetLeaderboard(pageNumber).Data;
            var count = entities.Count;
            for (var i = 0; i < count; i++) _leaderboardSlotControllers[i].BindEntities(entities[i]);
        }

        public void GetNextPage()
        {
            _currentPageNumber++;
            _numberLimitor.LimitValue(_currentPageNumber, apiUrlDataContainerSo.PageLength);
            UpdateButtons();
            GetLeaderBoard(_currentPageNumber);
        }

        public void GetPreviousPage()
        {
            _currentPageNumber--;
            _numberLimitor.LimitValue(_currentPageNumber, apiUrlDataContainerSo.PageLength);
            UpdateButtons();
            GetLeaderBoard(_currentPageNumber);
        }

        void UpdateButtons()
        {
            _prevButton.interactable = !_isFirstPage;
            _nextButton.interactable = !_isLastPage;
            UpdatePageText(_currentPageNumber + 1);
        }

        void UpdatePageText(int value)
        {
            _pageText.text = value.ToString();
        }
    }
}