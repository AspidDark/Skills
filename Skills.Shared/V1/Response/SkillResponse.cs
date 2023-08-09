using System.Text.Json.Serialization;

namespace Skills.Shared.V1.Response;
public class SkillResponse : BaseResponseEntity
{
    [JsonPropertyName("priority")]
    public int Priority { get; set; }
    [JsonPropertyName("skillName")]
    public required string SkillName { get; set; }
    [JsonPropertyName("level")]
    public required int Level { get; set; }
    [JsonPropertyName("imageId")]
    public Guid? ImageId { get; set; }
    [JsonPropertyName("image")]
    public FileEntityResponse? Image { get; set; }
    [JsonPropertyName("isMain")]
    public int IsMain { get; set; }
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;
}
