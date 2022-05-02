using System;
using System.Collections.Generic;
using System.Text;

namespace BL.ViewModels.Response
{
    public class VoteQuestionDTO
    {
        public List<VoteQuestionItemDto> Items { get; set; }

        public Correctness? Correctness { get; set; }

        public class VoteQuestionItemDto
        {
            public long QuestionItemId { get; set; }
            public int Count { get; set; }
        }
    }
}
