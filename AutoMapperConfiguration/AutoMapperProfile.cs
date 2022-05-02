using AutoMapper;
using DL.Entities;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using BL.ViewModels;
using BL.ViewModels.Requests;
using BL.ViewModels.Requests.Questions;
using BL.ViewModels.Response;

namespace AutoMapperConfiguration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Question, QuestionDTO>()
                .ForMember(x => x.Type, d => d.MapFrom(c => c.IsPollQuestion() ? QuestionType.Poll : QuestionType.Trivia));
            CreateMap<QuestionItem, QuestionItemDTO>();

            CreateMap<CreatePollQuestionModel, PollQuestion>();
            CreateMap<CreateTriviaQuestionModel, TriviaQuestion>();
            CreateMap<CreateQuestionItemModel, QuestionItem>();

            CreateMap<Enums.Correctness, Correctness>().ReverseMap();
        }
    }
}
