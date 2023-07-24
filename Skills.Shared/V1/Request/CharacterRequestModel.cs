using System.ComponentModel.DataAnnotations;

namespace Skills.Shared.V1.Request;

public class CharacterRequestModel
{
    public int Priority { get; init; }
    [MaxLength(100)]
    public string BuildName { get; init; }

    public string StartingDate { get; set; }

    public Guid? PhotoId { get; set; }

    [MaxLength(8)]
    public IEnumerable<SkillRequestModel> Skills { get; init; }
    [MaxLength(1000)]
    public string? Story { get; set; }
}
