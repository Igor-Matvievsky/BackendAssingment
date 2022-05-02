using System;
using System.Collections.Generic;
using System.Linq;
using Enums;

namespace BL.ViewModels
{
    public class CreateTriviaQuestionModel : CreateQuestionModel
    {
        public CreateTriviaQuestionModel(string title, List<CreateQuestionItemModel> questionItems) : base(title, questionItems)
        {
            if (questionItems == null || questionItems.Count == 0 || string.IsNullOrEmpty(title))
            {
                throw new ArgumentException();
            }

            if (questionItems.Any(x => x.Correctness == Correctness.NotSet))
            {
                throw new ArgumentException();
            }
        }
    }
}
