using Magecase.Abstract.Backend;
using Magecase.DataEntities;
using MageCase.Scriptableobjects;

namespace Magecase.Backend
{
    public class QuestionApiCall : BasseApiCallClass, IQuestionApiCall
    {
        public QuestionDataEntities GetLeaderQuestions()
        {
            var result = GetApiCall<QuestionDataEntities>(_urlDataContainer);
            return result;
        }

        public QuestionApiCall(ApiUrlDataContainer apiUrlDataContainer) : base(apiUrlDataContainer)
        {
        }
    }
}