namespace Skills.Domain.Models;

public class SkillsModel
{
    public required Guid Id { get; init; }

    public Guid UserId { get; set; }
}
