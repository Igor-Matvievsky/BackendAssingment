using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL.ApiInterfaces;
using BL.ViewModels;
using BL.ViewModels.Requests;
using BL.ViewModels.Requests.Questions;

namespace QuestionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]long id)
        {
            var question = await _questionService.GetByIdAsync(id);

            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateQuestionRequest request)
        {
            var questionId = await _questionService.CreateQuestion(request);

            return Ok(questionId);
        }

        [HttpPost("vote")]
        public async Task<IActionResult> Vote([FromBody] VoteQuestionRequest request)
        {
            var result = await _questionService.VoteQuestion(request);

            return Ok(result);
        }
    }
}
