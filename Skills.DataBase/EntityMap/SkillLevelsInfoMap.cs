using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skills.DataBase.DataAccess.Entities;

namespace Skills.DataBase.EntityMap;

public class SkillLevelsInfoMap : BaseEntityMap<SkillLevelsInfo>
{
    public SkillLevelsInfoMap() : base("skill_levels_data") { }

    public override void Configure(EntityTypeBuilder<SkillLevelsInfo> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Path).HasColumnName("path").HasMaxLength(500).IsRequired();
        builder.Property(x => x.Level).HasColumnName("level").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name").IsRequired();
        builder.Property(x => x.Source).HasColumnName("source").IsRequired();
    }
}
