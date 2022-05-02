using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL.ApiInterfaces;
using DL.DatabaseContext;
using DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DL.ApiRepositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public QuestionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<PollQuestion>> GetPolls()
        {
            throw new NotImplementedException();
        }

        public Task<List<TriviaQuestion>> GetTrivias()
        {
            throw new NotImplementedException();
        }

        public Task<List<Question>> GetAllQuestions()
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetSingle(long id)
        {
            return _dbContext
                .Questions
                .Include(x => x.QuestionItems)
                .ThenInclude(x => x.QuestionResults)
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
