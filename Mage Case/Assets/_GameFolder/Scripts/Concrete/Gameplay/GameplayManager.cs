using System.Collections;
using MageCase.GamePlay.States;
using Magecase.ScriptableObjects;
using MageCase.Scriptableobjects;
using Magecase.ScriptableObjects.GameEventListeners;
using Magecase.Uis;
using TMPro;
using UnityEngine;

namespace MageCase.GamePlay
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField] QuestionAttributes _questionAttributes;
        [SerializeField] NormalGameEventListener _answerEventListener;
        [SerializeField] TMP_Text _timeCountText, _scoreText;
        [SerializeField] GameEvent _timeIsUpEvent;
        [SerializeField] GameEvent _showingResultEvent;

        PlayerScore _score;
        MyStatemachine _statemachine;

        Coroutine _switchToResultCoroutine;
        GameplayOnHoldState _gameplayOnHoldState;
        GameOnPlayState _gameOnPlayState;
        GamePlayShowResultState _gamePlayShowResultState;

        void OnEnable()
        {
            _answerEventListener.ParameterEventWithObject += HandleGamePlayOnAnswerClick;
        }

        void Awake()
        {
            _score = new PlayerScore(_scoreText);
            _statemachine = new MyStatemachine();
            _gameplayOnHoldState = new GameplayOnHoldState();
            _gameOnPlayState = new GameOnPlayState(_timeCountText, _questionAttributes, _timeIsUpEvent);
            _gamePlayShowResultState = new GamePlayShowResultState();
            _statemachine.InitiliazeState(_gameplayOnHoldState);
        }

        void Update()
        {
            _statemachine.Currentstate.Tick();
        }

        void HandleGamePlayOnAnswerClick(object context)
        {
            var answer = context as AnswerButton;
            if (answer == null) return;
            if (answer.IsCorrectAnswer)
                _score.UpdateScoreText(_questionAttributes.CorrectAnswerPoint);
            else
                _score.UpdateScoreText(_questionAttributes.UnCorrectAnswerPoint);
            StartShowResultRoutine();
        }

        public void ChangeGamePlayToPlayState()
        {
            _statemachine.ChangeState(_gameOnPlayState);
        }

        void StartShowResultRoutine()
        {
            _switchToResultCoroutine = StartCoroutine(SwitchToResultCanvasRoutine());
        }

        IEnumerator SwitchToResultCanvasRoutine()
        {
            _statemachine.ChangeState(_gamePlayShowResultState);
            yield return new WaitForSeconds(5f);
            _showingResultEvent.InvokeEvents();
        }

        void OnDisable()
        {
            _answerEventListener.ParameterEventWithObject -= HandleGamePlayOnAnswerClick;
        }
    }
}