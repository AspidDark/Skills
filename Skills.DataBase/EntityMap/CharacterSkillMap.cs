using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skills.DataBase.DataAccess.Entities;

namespace Skills.DataBase.EntityMap;

public class CharacterSkillMap : BaseEntityMap<CharacterSkill>
{
    public CharacterSkillMap() : base("character_skill") { }

    public override void Configure(EntityTypeBuilder<CharacterSkill> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Priority).HasColumnName("priority").IsRequired();
        builder.Property(x => x.Level).HasColumnName("level").IsRequired();
        builder.Property(x => x.IsMain).HasColumnName("is_main").IsRequired();
        builder.Property(x => x.CustomName).HasColumnName("skill_name").HasMaxLength(100);
    }
}