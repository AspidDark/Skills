namespace Skills.DataBase.DataAccess.Entities;

public class SkillLevelsInfo : BaseEntity
{
    public required string Path { get; set; }
    public int Level { get; set; }
    public required string Name { get; set; }
    public int Source { get; set; }
    public Guid SkillId { get; set; }
    public Skill Skill { get; set; }
}
