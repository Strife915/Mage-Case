using System.Collections.Generic;
using Magecase.DataEntities;

namespace Magecase.Backend
{
    public interface IQuestionApiCall
    {
        List<QuestionDataEntities> GetQuestions();
    }
}