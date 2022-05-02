using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL.Entities;

namespace DL.ApiInterfaces
{
    public interface IQuestionRepository
    {
        Task<List<PollQuestion>> GetPolls();
        
        Task<List<TriviaQuestion>> GetTrivias();

        Task<List<Question>> GetAllQuestions();

        Task<Question> GetSingle(long id);

    }
}
