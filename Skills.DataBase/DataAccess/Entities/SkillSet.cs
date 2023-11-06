namespace Skills.DataBase.DataAccess.Entities;

public class SkillSet : BaseEntity
{
    public bool IsDefault { get; set; }
    public required string Name { get; set; }

    public List<Skill>? Skills { get; set; }

    public List<Character>? Characters { get; set; }
}
