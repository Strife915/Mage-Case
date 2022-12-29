using System.Collections.Generic;
using MageCase.DataEntities;

namespace MageCase.Backend
{
    public interface IQuestionApiCall
    {
        List<QuestionDataEntities> GetQuestions();
    }
}