using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skills.DataBase.DataAccess.Entities;

namespace Skills.DataBase.EntityMap;

public class SkillMap : BaseEntityMap<HeroSkill>
{
    public SkillMap() : base("skill") { }

    public override void Configure(EntityTypeBuilder<HeroSkill> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Priority).HasColumnName("priority").IsRequired();
        builder.Property(x => x.Level).HasColumnName("level").IsRequired();
        builder.Property(x => x.ImageId).HasColumnName("image_id");
        builder.HasOne(x => x.Image).WithMany().HasForeignKey("image_id");
        builder.Property(x => x.IsMain).HasColumnName("is_main").IsRequired();
        builder.Property(x => x.SkillName).HasColumnName("skill_name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Type).HasColumnName("skillType").HasMaxLength(100).IsRequired();
    }
}