namespace Skills.Models;

public class CharacterModel
{
    public Guid UserId { get; set; }

    public Guid Id { get; set; }

    public required string BuildName { get; init; }

    public required int Age { get; init; }

    public required int Month { get; init; }

    public required ImageModel Photo { get; init; }

    public required SkillsModel MainSkill { get; init; }

    public IEnumerable<SkillsModel>? Skills { get; init; }
}
