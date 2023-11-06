namespace Skills.DataBase.DataAccess.Entities;

public class CharacterSkill : BaseEntity
{
    public int Priority { get; set; }

    public string? CustomName { get; set; }

    public int Level { get; set; }

    public Guid CharacterId { get; set; }

    public Character Character { get; set; } = null!;

    public Guid SkillId { get; set; }

    public Skill Skill { get; set; } = null!;

    public int IsMain { get; set; }
}
