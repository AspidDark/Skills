using System.Text.Json.Serialization;

namespace Skills.Shared.V1.Response;

public class SkillResponse : BaseResponseEntity
{
    [JsonPropertyName("isDefault")]
    public bool IsDefault { get; set; }
    [JsonPropertyName("defaultName")]
    public required string DefaultName { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("skillLevelsData")]
    public List<SkillLevelsInfoResponse> SkillLevelsData { get; set; }

}
