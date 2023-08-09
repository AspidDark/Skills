using System.Text.Json.Serialization;

namespace Skills.Shared.V1.Response;

public class FileEntityResponse: BaseResponseEntity
{
    [JsonPropertyName("path")]
    public string Path { get; set; }
}
