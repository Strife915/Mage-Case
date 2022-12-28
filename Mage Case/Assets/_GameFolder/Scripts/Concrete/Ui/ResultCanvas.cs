using Magecase.Abstract.Uis;
using MageCase.Scriptableobjects;
using Magecase.ScriptableObjects.GameEventListeners;
using TMPro;
using UnityEngine;

namespace Magecase.Uis
{
    public class ResultCanvas : BaseCanvasGroup
    {
        [SerializeField] ResultcanvasMessageSo resultcanvasMessageSo;
        [SerializeField] NormalGameEventListener _answerClickEventListener;
        TMP_Text _messageText;

        public override void Awake()
        {
            base.Awake();
            GetReference();
        }

        void OnEnable()
        {
            _answerClickEventListener.ParameterEventWithObject += HandleMessageOnAnswerClick;
        }

        void HandleMessageOnAnswerClick(object context)
        {
            var answer = context as AnswerButton;
            if (answer == null) return;
            if (answer.IsCorrectAnswer)
                _messageText.text = resultcanvasMessageSo.CanvasSuccessMessage;
            else
                _messageText.text = resultcanvasMessageSo.CanvasFailMessage;
        }

        public void HandleMessageOnTimesUp()
        {
            _messageText.text = resultcanvasMessageSo.TimeUpMessage;
        }

        void OnValidate()
        {
            GetReference();
        }

        void GetReference()
        {
            if (_messageText == null)
                _messageText = GetComponentInChildren<TMP_Text>();
        }

        void OnDisable()
        {
            _answerClickEventListener.ParameterEventWithObject -= HandleMessageOnAnswerClick;
        }
    }
}