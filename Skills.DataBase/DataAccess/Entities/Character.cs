namespace Skills.DataBase.DataAccess.Entities;

public class Character : BaseEntity
{
    public int Priority { get; set; }

    public  string BuildName { get; set; }
    public  DateTime StartingDate { get; set; }

    public List<CharacterSkill>? CharacterSkill { get; set; }

    public string? Story { get; set; }

    public Guid? PhotoId { get; set; }
    public FileEntity? Photo { get; set; }

    public Guid SkillSetId { get; set; }

    public SkillSet SkillSet { get; set; }

    public bool IsDraft { get; set; }

    public bool IsPublic { get; set; }
}
