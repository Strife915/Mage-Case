using Magecase.ScriptableObjects;
using MageCase.Scriptableobjects;
using Magecase.Uis;
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
        IPowerAbilityWithEvent _extraTimePowerUp;

        public GameOnPlayState(TMP_Text tmpText, QuestionAttributes questionAttributes, GameEvent timeIsUpEvent)
        {
            _gameTimeCountText = tmpText;
            _questionAttributes = questionAttributes;
            _elapsedTime = questionAttributes.GiveAnswerTime;
            _extraTimePowerUp = new ExtraTimePowerUp();
            _timeIsUpEvent = timeIsUpEvent;
            _extraTimePowerUp.PowerUpAction += IncreaseTime;
        }

        void IncreaseTime()
        {
            _elapsedTime += 10;
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
            _gameTimeCountText.text = _elapsedTime.ToString("0");
        }

        public void IncreaseTimePowerUp()
        {
            _extraTimePowerUp.PowerUp();
        }
    }
}