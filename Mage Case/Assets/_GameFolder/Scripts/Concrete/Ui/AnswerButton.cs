using Magecase.DataEntities;
using TMPro;
using UnityEngine;

namespace Magecase.Uis
{
    public class AnswerButton : ButtonWithGameEvent
    {
        [SerializeField] TMP_Text _answerText;
        [SerializeField] bool _isCorrectAnswer;

        public bool IsCorrectAnswer => _isCorrectAnswer;

        protected override void HandleOnButtonClicked()
        {
            _gameEvent.InvokeEventsWithObject(this);
        }

        protected override void OnValidate()
        {
            base.OnValidate();
            GetReference();
        }

        protected override void Awake()
        {
            base.Awake();
            GetReference();
        }

        protected override void GetReference()
        {
            base.GetReference();
            if (_answerText == null)
                _answerText = GetComponentInChildren<TMP_Text>();
        }

        public void Bind(AnswerSlotModel slotModel)
        {
            _answerText.text = slotModel.AnswerText;
            _isCorrectAnswer = slotModel.IsCorrectAnswer;
        }
    }
}