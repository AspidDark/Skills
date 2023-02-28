namespace Skills.Shared.V1.Request;

public class SkillsRequestModel
{
    public required Guid ImageId { get; init; }

    public required string SkillName{ get; init; }

    public required int Level { get; init; }
}
