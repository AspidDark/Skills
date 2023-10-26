namespace Skills.DataBase.DataAccess.Entities;

public class HeroSkill : BaseEntity
{
    public int Priority { get; set; }

    public required string SkillName { get; set; }

    public required int Level { get; set; }

    public Guid CahracterId { get; set; }

    public Character Character { get; set; } = null!;

    public Guid? ImageId { get; set; }
    public FileEntity? Image { get; set; }

    public int IsMain { get; set; }

    public string Type { get; set; } = null!;
}
