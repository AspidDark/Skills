namespace Skills.Shared.V1.Request;

public class CharacterRequestModel
{
    public required Guid Id { get; init; }

    public required string BuildName { get; init; }

    public required int Age { get; init; }

    public required int Month { get; init; }

    public required ImageRequestModel Photo { get; init; }

    public required SkillsRequestModel MainSkill { get; init; }

    public IEnumerable<SkillsRequestModel>? Skills { get; init; }
}
