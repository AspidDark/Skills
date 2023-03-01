namespace Skills.DataBase.DataAccess.Entities;

public class Skill : BaseEntity
{
    public required Guid ImageId { get; init; }

    public required int Priority { get; init; }

    public required string SkillName { get; init; }

    public required int Level { get; init; }

    public Guid CahracterId { get; set; }

    public Character Character { get; set; }

    public Guid? PhotoId { get; set; }
    public FileEntity? Photo { get; set; }
}
