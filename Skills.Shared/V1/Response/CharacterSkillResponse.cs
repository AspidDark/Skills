using System.Text.Json.Serialization;

namespace Skills.Shared.V1.Response;
public class CharacterSkillResponse : BaseResponseEntity
{
    [JsonPropertyName("priority")]
    public int Priority { get; set; }
    [JsonPropertyName("customName")]
    public required string CustomName { get; set; }
    [JsonPropertyName("level")]
    public required int Level { get; set; }

    [JsonPropertyName("isMain")]
    public int IsMain { get; set; }
    [JsonPropertyName("skillId")]
    public Guid SkillId { get; set; }
}
