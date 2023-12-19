namespace Skills.Models;

public class CharacterModel
{
    public required int Priority { get; init; }

    public required string BuildName { get; init; }
    public required DateTime StartingDate { get; set; }
    public string? Story { get; set; }

    public Guid? PhotoId { get; set; }
    public required IEnumerable<CharacterSkillModel> Skills { get; init; }
    public Guid SkillSetId { get; set; }
    public bool IsPublic { get; set; }
}
