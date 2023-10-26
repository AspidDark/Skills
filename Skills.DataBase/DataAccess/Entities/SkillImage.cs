namespace Skills.DataBase.DataAccess.Entities;

public class SkillInfo : BaseEntity
{
    public string Path { get; set; }
    public int Level { get; set; }
    public required string Name { get; set; }

    public int IsLocal { get; set; }
}
