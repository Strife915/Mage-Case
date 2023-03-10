using MageCase.Abstract.Uis;
using MageCase.ScriptableObjects;
using MageCase.ScriptableObjects.GameEventListeners;
using TMPro;
using UnityEngine;

namespace MageCase.Uis
{
    public class ResultCanvasButton : ButtonWithGameEvent
    {
        [SerializeField] NormalGameEventListener _answerClickEvent;
        [SerializeField] GameEvent _alternativeMainMenuButtonEvent;
        TMP_Text _buttonText;

        protected override void GetReference()
        {
            base.GetReference();
            if (_buttonText == null)
                _buttonText = GetComponentInChildren<TMP_Text>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _answerClickEvent.ParameterEventWithObject += UpdateResultCanvasDependsOnAnswer;
        }


        void UpdateResultCanvasDependsOnAnswer(object context)
        {
            var answer = context as AnswerButton;
            if (answer == null) return;
            if (answer.IsCorrectAnswer)
                _buttonText.text = "Next Question";
            else
                UpdateButtonEventToAlternative();
        }

        public void UpdateButtonEventToAlternative()
        {
            _gameEvent = _alternativeMainMenuButtonEvent;
            _buttonText.text = "Main Menu";
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _answerClickEvent.ParameterEventWithObject -= UpdateResultCanvasDependsOnAnswer;
        }
    }
}