using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Domain.Enum;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Priority
{
    Low,
    Medium,
    High,
}