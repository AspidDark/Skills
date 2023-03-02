namespace Skills.DataBase.DataAccess.Entities;

public class Skill : BaseEntity
{
    public int Priority { get; set; }

    public required string SkillName { get; set; }

    public required int Level { get; set; }

    public Guid CahracterId { get; set; }

    public Character Character { get; set; }

    public Guid? PhotoId { get; set; }
    public FileEntity? Photo { get; set; }
}
