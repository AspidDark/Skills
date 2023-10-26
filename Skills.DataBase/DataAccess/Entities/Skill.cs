﻿namespace Skills.DataBase.DataAccess.Entities;

public class Skill : BaseEntity
{
    public required string DefaultName { get; set; }

    public string? Description { get; set; }

    public Guid SkillSetId { get; set; }

    public SkillSet SkillSet { get; set; } = null!;

    public List<SkillInfo> SkillData { get; set; } = null!;
}
