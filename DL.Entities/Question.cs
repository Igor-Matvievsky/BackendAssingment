using System;
using System.Collections.Generic;
using System.Text;
using DL.Entities.Base;

namespace DL.Entities
{
    public abstract class Question : BaseEntity
    {
        public string Title { get; set; }
        
        public List<QuestionItem> QuestionItems { get; set; }

        public abstract bool IsPollQuestion();

    }
}
