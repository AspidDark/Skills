namespace Skills.DataBase.DataAccess.Entities;

public class SkillSet : BaseEntity
{
    public required string Name { get; set; }

    public List<Skill>? Skills { get; set; }
}
