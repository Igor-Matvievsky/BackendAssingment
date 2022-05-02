using System;
using System.Collections.Generic;
using System.Text;
using DL.Entities.Base;

namespace DL.Entities
{
    public class QuestionResult : BaseEntity
    {
        public QuestionItem QuestionItem { get; set; }

        public long QuestionItemId { get; set; }
    }
}
