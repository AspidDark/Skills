using Newtonsoft.Json;
﻿using System.Text.Json.Serialization;

namespace Skills.Shared.V1.Response;

public class CharacterResponse : BaseResponseEntity
{
    [JsonPropertyName("priority")]
    public int Priority { get; set; }

    [JsonPropertyName("buildName")]
    public string BuildName { get; set; }
    [JsonPropertyName("startingDate")]
    public DateTime StartingDate { get; set; }
    [JsonPropertyName("skills")]
    public IEnumerable<SkillResponse>? Skills { get; set; }
    [JsonPropertyName("story")]
    public string? Story { get; set; }
    [JsonPropertyName("photoId")]
    public Guid? PhotoId { get; set; }
    [JsonPropertyName("photo")]
    public FileEntityResponse? Photo { get; set; }
}
