using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skills.DataBase.DataAccess.Entities;

namespace Skills.DataBase.EntityMap;

internal class SkillImageMap : BaseEntityMap<FileEntity>
{
    public SkillImageMap() : base("skill_image") { }

    public override void Configure(EntityTypeBuilder<FileEntity> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Path).HasColumnName("path").HasMaxLength(1000).IsRequired();

    }
}