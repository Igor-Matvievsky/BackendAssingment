using Enums;

namespace BL.ViewModels.Response
{
    public class QuestionItemDTO
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public Correctness Correctness { get; set; }
    }
}
