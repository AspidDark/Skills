using System.ComponentModel.DataAnnotations;

namespace Skills.Shared.V1.Request;

public class CharacterRequest
{
    public int Priority { get; init; }
    [MaxLength(100)]
    public string BuildName { get; init; }

    public string StartingDate { get; set; }
    [MaxLength(1000)]
    public string? Story { get; set; }


    public Guid? PhotoId { get; set; }
    public Guid SkillSetId { get; set; }

    [MaxLength(8)]
    public IEnumerable<CharacterSkillRequest> Skills { get; init; }

}
