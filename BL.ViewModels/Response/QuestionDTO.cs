using System.Collections.Generic;
using BL.ViewModels.Requests;
using BL.ViewModels.Requests.Questions;

namespace BL.ViewModels.Response
{
    public class QuestionDTO
    {
        public long Id { get; set;}
        public string Title { get; set; }
        public QuestionType Type { get; set; }
        public List<QuestionItemDTO> QuestionItems { get; set; }
    }
}
