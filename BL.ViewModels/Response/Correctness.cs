using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BL.ViewModels.Response
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Correctness
    {
        [EnumMember(Value = "notSet")]
        NotSet,
        [EnumMember(Value = "valid")]
        Valid,
        [EnumMember(Value = "invalid")]
        Invalid
    }
}
