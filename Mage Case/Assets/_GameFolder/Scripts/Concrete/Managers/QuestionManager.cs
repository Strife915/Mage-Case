using System.Collections.Generic;
using System.Linq;
using Magecase.Backend;
using Magecase.DataEntities;
using MageCase.Scriptableobjects;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Magecase.Uis
{
    public class QuestionManager : MonoBehaviour
    {
        [FormerlySerializedAs("_urlDataContainer")] [SerializeField]
        ApiUrlDataContainerSo urlDataContainerSo;

        [SerializeField] SpinWheelManager _spinWheelManager;
        [SerializeField] TMP_Text _questionText;
        [SerializeField] AnswerButton[] _answerButtons;


        List<QuestionDataEntities> _questions;
        QuestionDataEntities _currentQuestion;
        IQuestionApiCall _questionApiCall;
        IPowerupAbility _revealWrongAnswersPowerUp;
        int _listCount;
        Dictionary<string, List<QuestionDataEntities>> _questionDictionary = new();


        void Awake()
        {
            _revealWrongAnswersPowerUp = new RevealTwoWrongAnswerPowerUp(_answerButtons);
            _questionApiCall = new QuestionApiCall(urlDataContainerSo);
            GenerateListAccordingCategories();
            AddQuestionsToListAccordingCategories();
        }

        void GenerateListAccordingCategories()
        {
            var categories = new List<string>();
            _questions = _questionApiCall.GetQuestions();
            for (var i = 0; i < _questions.Count; i++) categories.Add(_questions[i].Category);
            categories = categories.Distinct().ToList();
            _listCount = categories.Count;
            for (var i = 0; i < _listCount; i++) _questionDictionary.Add(categories[i], new List<QuestionDataEntities>());
        }

        void AddQuestionsToListAccordingCategories()
        {
            for (var i = 0; i < _questions.Count; i++)
                if (_questionDictionary.ContainsKey(_questions[i].Category))
                    _questionDictionary[_questions[i].Category].Add(_questions[i]);
        }


        QuestionDataEntities GetQuestionWithAnswers(string key)
        {
            _currentQuestion = _questionDictionary[key][Random.Range(0, _questionDictionary[key].Count)];
            var models = new AnswerSlotModel[_answerButtons.Length];
            for (var i = 0; i < models.Length; i++)
            {
                models[i].AnswerText = _currentQuestion.Choices[i];
                models[i].IsCorrectAnswer = models[i].AnswerText.StartsWith(_currentQuestion.Answer);
                _answerButtons[i].Bind(models[i]);
            }

            return _currentQuestion;
        }

        public void UpdateText()
        {
            _questionText.text = GetQuestionWithAnswers(_spinWheelManager.Key).Question;
        }

        public void RevealTwoWrongAnswerPowerUp()
        {
            _revealWrongAnswersPowerUp.PowerUp();
        }
    }
}