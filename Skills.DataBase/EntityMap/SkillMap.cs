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
        builder.Property(x => x.Priority).HasColumnName("priority").IsRequired();
        builder.Property(x => x.Level).HasColumnName("level").IsRequired();
        builder.Property(x => x.CahracterId).HasColumnName("cahracter_id").IsRequired();
        builder.HasOne(x => x.Character).WithOne().HasForeignKey("cahracter_id");
        builder.Property(x => x.PhotoId).HasColumnName("photo_id");
        builder.HasOne(x => x.Photo).WithOne().HasForeignKey("photo_id");
    }
}




public Guid? PhotoId { get; set; }
public FileEntity? Photo { get; set; }