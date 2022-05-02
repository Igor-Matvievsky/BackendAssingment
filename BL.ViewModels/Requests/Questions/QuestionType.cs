using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BL.ViewModels.Requests.Questions
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum QuestionType
    {
        [EnumMember(Value = "poll")]
        Poll,
        [EnumMember(Value = "trivia")]
        Trivia
    }
}
