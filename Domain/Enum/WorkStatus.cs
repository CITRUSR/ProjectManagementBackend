using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace Domain.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum WorkStatus
{
    Created,
    Stuck,
    OnWorking,
    Done,
}