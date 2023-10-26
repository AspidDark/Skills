using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skills.DataBase.DataAccess.Entities;

namespace Skills.DataBase.EntityMap;

public class SkillMap : BaseEntityMap<Skill>
{
    public SkillMap() : base("skill") { }

    public override void Configure(EntityTypeBuilder<Skill> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.DefaultName).HasColumnName("default_name").HasMaxLength(200).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description");
    }
}
