namespace Skills.Models;

public class SkillsModel
{
    public Guid Id { get; set; }
    public required int Priority { get; init; }
    public required string SkillName { get; init; }
    public required int Level { get; init; }
    public SkillImageModel Image { get; init; }
    public int IsMain { get; set; }

    public string Type { get; init; } = null!;
}