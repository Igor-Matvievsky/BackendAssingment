using Enums;

namespace BL.ViewModels
{
    public class CreateQuestionItemModel
    {
        public string Title { get; }

        public Correctness Correctness { get;}

        public long QuestionId { get; set; }

        public CreateQuestionItemModel(string title, Correctness correctness)
        {
            Title = title;
            Correctness = correctness;
        }
    }
}
