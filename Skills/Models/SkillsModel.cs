namespace Skills.Models;

public class SkillsModel
{
    public required Guid ImageId { get; init; }

    public required int Priority { get; init; }

    public required string SkillName { get; init; }

    public required int Level { get; init; }
}