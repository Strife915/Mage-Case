using Magecase.ScriptableObjects;
using MageCase.Scriptableobjects;
using TMPro;
using UnityEngine;

namespace MageCase.GamePlay.States
{
    public class GameOnPlayState : State
    {
        QuestionAttributes _questionAttributes;
        GameEvent _timeIsUpEvent;
        TMP_Text _gameTimeCountText;
        float _elapsedTime;

        public GameOnPlayState(TMP_Text tmpText, QuestionAttributes questionAttributes, GameEvent timeIsUpEvent)
        {
            _gameTimeCountText = tmpText;
            _questionAttributes = questionAttributes;
            _elapsedTime = questionAttributes.GiveAnswerTime;
            _timeIsUpEvent = timeIsUpEvent;
        }

        public override void Enter()
        {
            _elapsedTime = _questionAttributes.GiveAnswerTime;
        }

        public override void Tick()
        {
            if (_elapsedTime >= 0)
            {
                _elapsedTime -= Time.deltaTime;
                UpdateCounterText();
                if (_elapsedTime <= 0)
                {
                    Debug.Log("time is up");
                    _timeIsUpEvent.InvokeEvents();
                }
            }
        }

        void UpdateCounterText()
        {
            _gameTimeCountText.text = _elapsedTime.ToString("00");
        }
    }
}