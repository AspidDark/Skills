using System.Text.Json.Serialization;

namespace Skills.Shared.V1.Response;

public class BaseResponseEntity
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    /// <summary>
    /// Дата создания
    /// </summary>
    [JsonPropertyName("createDate")]
    public DateTime CreateDate { get; set; }
    /// <summary>
    /// Дата последнего изменения
    /// </summary>
    [JsonPropertyName("editDate")]
    public DateTime EditDate { get; set; }
    /// <summary>
    /// Id пользователя
    /// </summary>
    [JsonPropertyName("ownerId")]
    public Guid OwnerId { get; set; }

    /// <summary>
    /// Удалено? 0 нет 1 да
    /// </summary>
    [JsonPropertyName("isDeleted")] 
    public int IsDeleted { get; set; }
}
