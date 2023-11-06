using System;
using System.Text.Json.Serialization;

namespace Skills.Shared.V1.Response;

public class SkillLevelsInfoResponse : BaseResponseEntity
{
    [JsonPropertyName("path")]
    public required string Path { get; set; }
    [JsonPropertyName("level")]
    public int Level { get; set; }
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("source")]
    public int Source { get; set; }
}
