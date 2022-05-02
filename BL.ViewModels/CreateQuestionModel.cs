using System;
using System.Collections.Generic;

namespace BL.ViewModels
{
    public class CreateQuestionModel
    {
        public string Title { get; }
        public List<CreateQuestionItemModel> QuestionItems { get; }

        public CreateQuestionModel(string title, List<CreateQuestionItemModel> questionItems)
        {
            Title = title;
            QuestionItems = questionItems;

            if (questionItems == null || questionItems.Count == 0)
            {
                throw new ArgumentException();
            }
        }
    }
}
