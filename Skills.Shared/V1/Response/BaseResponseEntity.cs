using System.Text.Json.Serialization;

namespace Skills.Shared.V1.Response;

public class BaseResponseEntity
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    /// <summary>
    /// Id пользователя
    /// </summary>
    [JsonPropertyName("ownerId")]
    public Guid OwnerId { get; set; }
}
