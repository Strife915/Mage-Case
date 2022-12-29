using System.Collections.Generic;
using System.Linq;
using MageCase.Abstract.Backend;
using MageCase.DataEntities;
using MageCase.Scriptableobjects;

namespace MageCase.Backend
{
    public class QuestionApiCall : BasseApiCallClass, IQuestionApiCall
    {
        public List<QuestionDataEntities> GetQuestions()
        {
            var result = GetApiCall<QuestionEntityData>(UrlDataContainerSo);
            return result.Questions.ToList();
        }

        public QuestionApiCall(ApiUrlDataContainerSo apiUrlDataContainerSo) : base(apiUrlDataContainerSo)
        {
        }
    }
}