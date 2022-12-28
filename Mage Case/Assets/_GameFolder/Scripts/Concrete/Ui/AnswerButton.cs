using Magecase.DataEntities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Magecase.Uis
{
    public class AnswerButton : ButtonWithGameEvent
    {
        [SerializeField] TMP_Text _answerText;
        [SerializeField] bool _isCorrectAnswer;
        Image _buttonImage;

        public bool IsCorrectAnswer => _isCorrectAnswer;

        protected override void HandleOnButtonClicked()
        {
            _gameEvent.InvokeEventsWithObject(this);
            if (_isCorrectAnswer)
                _buttonImage.color = Color.green;
            else
                _buttonImage.color = Color.red;
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
            if (_answerText == null || _buttonImage == null)
            {
                _answerText = GetComponentInChildren<TMP_Text>();
                _buttonImage = GetComponent<Image>();
            }
        }

        public void RevealCorrectAnswer()
        {
            if (_isCorrectAnswer)
                _buttonImage.color = Color.green;
        }

        public void ResetButtonImage()
        {
            _buttonImage.color = Color.white;
        }

        public void Bind(AnswerSlotModel slotModel)
        {
            _answerText.text = slotModel.AnswerText;
            _isCorrectAnswer = slotModel.IsCorrectAnswer;
        }
    }
}