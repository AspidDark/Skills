namespace Skills.DataBase.DataAccess.Entities;

public class SkillLevelInfo : BaseEntity
{
    public required string Path { get; set; }
    public int Level { get; set; }
    public required string Name { get; set; }
    public int IsLocal { get; set; }
    public List<Skill>? Skills { get; set; }
}
