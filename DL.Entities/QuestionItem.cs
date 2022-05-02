using System;
using System.Collections.Generic;
using System.Text;
using DL.Entities.Base;
using Enums;

namespace DL.Entities
{
    public class QuestionItem : BaseEntity
    {
        public string Title { get; set; }

        public Correctness Correctness { get; set; }

        public List<QuestionResult> QuestionResults { get; set; }

        public long QuestionId { get; set; }
        

    }
}
