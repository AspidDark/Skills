using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skills.DataBase.DataAccess.Entities;

namespace Skills.DataBase.EntityMap;

public class SkillSetMap : BaseEntityMap<SkillSet>
{
    public SkillSetMap() : base("skill_set") { }

    public override void Configure(EntityTypeBuilder<SkillSet> builder)
    {
        base.Configure(builder);
        builder.Property(x=>x.IsDefault).HasDefaultValue(false);
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(200).IsRequired();
    }
}
