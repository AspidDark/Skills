using System.Text.Json.Serialization;

namespace Skills.Shared.V1.Response;

public class SkillSetResponse : BaseResponseEntity
{
    [JsonPropertyName("isDefault")]
    public bool IsDefault { get; set; }
    [JsonPropertyName("name")]
    public required string Name { get; set; }
    [JsonPropertyName("skills")]
    public List<SkillResponse>? Skills { get; set; }
}
