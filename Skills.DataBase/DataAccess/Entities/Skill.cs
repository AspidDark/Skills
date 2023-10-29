namespace Skills.DataBase.DataAccess.Entities;

public class Skill : BaseEntity
{
    public bool IsDefault { get; set; }
    public required string DefaultName { get; set; }

    public string? Description { get; set; }

    public Guid SkillSetId { get; set; }

    public SkillSet SkillSet { get; set; } = null!;

    public List<SkillLevelInfo> SkillLevelData { get; set; } = null!;
}
