using System.Collections.Generic;
using BL.ViewModels.Response;

namespace BL.ViewModels.Requests.Questions
{
    public class CreateQuestionRequest
    {
        public string Title { get; set; }

        public List<QuestionItemRequest> Items { get; set; }

        public QuestionType Type { get; set; }

        public class QuestionItemRequest
        {
            public string Title { get; set; }

            public Correctness Correctness { get; set; }
        }
    }
}
