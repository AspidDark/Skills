namespace Skills.Models;

public class CharacterSkillModel
{
    public required int Priority { get; init; }
    public string? CustomName { get; init; }
    public required int Level { get; init; }
    public int IsMain { get; set; }
    public Guid SkillId { get; set; }
}