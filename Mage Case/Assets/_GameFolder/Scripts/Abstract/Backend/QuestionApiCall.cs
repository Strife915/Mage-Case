using System.Collections.Generic;
using System.Linq;
using Magecase.Abstract.Backend;
using Magecase.DataEntities;
using MageCase.Scriptableobjects;

namespace Magecase.Backend
{
    public class QuestionApiCall : BasseApiCallClass, IQuestionApiCall
    {
        public List<QuestionDataEntities> GetQuestions()
        {
            var result = GetApiCall<QuestionEntityData>(_urlDataContainer);
            return result.Questions.ToList();
        }

        public QuestionApiCall(ApiUrlDataContainer apiUrlDataContainer) : base(apiUrlDataContainer)
        {
        }
    }
}