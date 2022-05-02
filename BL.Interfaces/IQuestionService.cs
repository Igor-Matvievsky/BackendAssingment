using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BL.ViewModels;
using BL.ViewModels.Requests;
using BL.ViewModels.Requests.Questions;
using BL.ViewModels.Response;

namespace BL.ApiInterfaces
{
    public interface IQuestionService
    {
        Task<long> CreateQuestion(CreateQuestionRequest request);

        Task<QuestionDTO> GetByIdAsync(long id);

        Task<VoteQuestionDTO> VoteQuestion(VoteQuestionRequest request);
    }
}
