namespace Skills.Models;

public class CharacterModel
{
    public Guid Id { get; set; }
    public required int Priority { get; init; }

    public required string BuildName { get; init; }
    public required DateOnly StartingDate { get; set; }

    public Guid? PhotoId { get; set; }
    public required IEnumerable<SkillsModel> Skills { get; init; }
    public string? Story { get; set; }
}
