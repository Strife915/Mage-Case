using System;
using MageCase.GamePlay.States;
using Magecase.ScriptableObjects;
using MageCase.Scriptableobjects;
using TMPro;
using UnityEngine;

namespace MageCase.GamePlay
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField] QuestionAttributes _questionAttributes;
        [SerializeField] TMP_Text _timeCountText;
        [SerializeField] GameEvent _timeIsUpEvent;

        MyStatemachine _statemachine;
        public GameplayOnHoldState GameplayOnHoldState { get; private set; }
        public GameOnPlayState GameOnPlayState { get; private set; }

        void Awake()
        {
            _statemachine = new MyStatemachine();
            GameplayOnHoldState = new GameplayOnHoldState();
            GameOnPlayState = new GameOnPlayState(_timeCountText, _questionAttributes, _timeIsUpEvent);
            _statemachine.InitiliazeState(GameplayOnHoldState);
        }

        void Update()
        {
            _statemachine.Currentstate.Tick();
        }

        public void ChangeGamePlayToPlayState()
        {
            _statemachine.ChangeState(GameOnPlayState);
        }
    }
}