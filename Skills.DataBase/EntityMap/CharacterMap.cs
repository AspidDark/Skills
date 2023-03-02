using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skills.DataBase.DataAccess.Entities;

namespace Skills.DataBase.EntityMap;

public class CharacterMap : BaseEntityMap<Character>
{
    public CharacterMap() : base("caharacter") { }

    public override void Configure(EntityTypeBuilder<Character> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Priority).HasColumnName("priority").IsRequired();
        builder.Property(x => x.BuildName).HasColumnName("build_name").HasMaxLength(500).IsRequired();
        builder.Property(x => x.StartingDate).HasColumnName("starting_date").IsRequired();
        builder.Property(x => x.PhotoId).HasColumnName("photo_id");
        builder.HasOne(x => x.Photo).WithMany().HasForeignKey("photo_id");
        builder.Property(x=> x.Story).HasColumnName("story").HasMaxLength(1000);
    }
}