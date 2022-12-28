using System.Collections.Generic;
using System.Linq;
using Magecase.Backend;
using Magecase.DataEntities;
using MageCase.Scriptableobjects;
using TMPro;
using UnityEngine;

namespace Magecase.Uis
{
    public class QuestionManager : MonoBehaviour
    {
        [SerializeField] ApiUrlDataContainer _urlDataContainer;
        IQuestionApiCall _questionApiCall;
        [SerializeField] SpinWheelManager _spinWheelManager;
        List<QuestionDataEntities> _questions;
        [SerializeField] TMP_Text _questionText;


        int _listCount;
        Dictionary<string, List<QuestionDataEntities>> _questionDictionary = new();


        void Awake()
        {
            //To Do refact
            var categories = new List<string>();
            _questionApiCall = new QuestionApiCall(_urlDataContainer);
            _questions = _questionApiCall.GetQuestions();
            for (var i = 0; i < _questions.Count; i++) categories.Add(_questions[i].Category);
            categories = categories.Distinct().ToList();
            _listCount = categories.Count;
            for (var i = 0; i < _listCount; i++) _questionDictionary.Add(categories[i], new List<QuestionDataEntities>());

            for (var i = 0; i < _questions.Count; i++)
                if (_questionDictionary.ContainsKey(_questions[i].Category))
                    _questionDictionary[_questions[i].Category].Add(_questions[i]);
        }

        QuestionDataEntities GetQuestion(string key)
        {
            return _questionDictionary[key][Random.Range(0, _questionDictionary[key].Count)];
        }

        public void UpdateText()
        {
            _questionText.text = GetQuestion(_spinWheelManager.Key).Question;
        }
    }
}