using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BL.ApiInterfaces;
using BL.ViewModels;
using BL.ViewModels.Requests;
using BL.ViewModels.Requests.Questions;
using BL.ViewModels.Response;
using DL.ApiInterfaces;
using DL.Entities;
using DL.IUnitOfWork;
using Correctness = Enums.Correctness;

namespace BL.ApiServices
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionService(IUnitOfWork unitOfWork, 
            IQuestionRepository questionRepository, 
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<long> CreateQuestion(CreateQuestionRequest model)
        {
            var items = model.Items.Select(x => new CreateQuestionItemModel(x.Title, _mapper.Map<Correctness>(x.Correctness))).ToList();

            CreateQuestionModel createModel = null;
            Question entity = null;

            if (model.Type == QuestionType.Poll)
            {
                createModel = new CreatePollQuestionModel(model.Title, items);
                entity = _mapper.Map<PollQuestion>(createModel);
            }
            else
            {
                createModel = new CreateTriviaQuestionModel(model.Title, items);
                entity = _mapper.Map<TriviaQuestion>(createModel);
            }

            await _unitOfWork.AddAsync(entity);

            await _unitOfWork.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<QuestionDTO> GetByIdAsync(long id)
        {
            var entity = await _questionRepository.GetSingle(id);

            return _mapper.Map<QuestionDTO>(entity);
        }

        public async Task<VoteQuestionDTO> VoteQuestion(VoteQuestionRequest request)
        {
            var question = await _questionRepository.GetSingle(request.QuestionId);

            if (question == null || question.QuestionItems.All(x => x.Id != request.QuestionItemId))
            {
                throw new Exception();
            }

            await _unitOfWork.AddAsync(new QuestionResult
            {
                QuestionItemId = request.QuestionItemId
            });

            await _unitOfWork.SaveChangesAsync();

            return GetVoteResult(question, request.QuestionItemId);
        }

        private VoteQuestionDTO GetVoteResult(Question question, long questionItemId)
        {
            var items = question.QuestionItems.Select(x => new VoteQuestionDTO.VoteQuestionItemDto
            {
                QuestionItemId = x.Id,
                Count = x.QuestionResults.Count
            }).ToList();

            var result = new VoteQuestionDTO
            {
                Items = items,
            };

            if (!question.IsPollQuestion())
            {
                var correct = question.QuestionItems.Single(x => x.Id == questionItemId).Correctness == Correctness.Valid
                    ? ViewModels.Response.Correctness.Valid
                    : ViewModels.Response.Correctness.Invalid;

                result.Correctness = correct;
            }

            return result;
        }

    }
}
