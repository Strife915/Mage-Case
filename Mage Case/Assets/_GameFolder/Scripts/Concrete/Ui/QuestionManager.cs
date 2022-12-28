using System;
using System.Collections.Generic;
using Magecase.Backend;
using Magecase.DataEntities;
using Magecase.Enums;
using MageCase.Scriptableobjects;
using UnityEngine;

namespace Magecase.Uis
{
    public class QuestionManager : MonoBehaviour
    {
        [SerializeField] ApiUrlDataContainer _urlDataContainer;
        IQuestionApiCall _questionApiCall;
        List<QuestionDataEntities> _questions;
        Dictionary<QuestionTypes, List<QuestionDataEntities>> _questionDictionary;

        void Awake()
        {
            _questionApiCall = new QuestionApiCall(_urlDataContainer);
            _questions = _questionApiCall.GetQuestions();
        }
    }
}