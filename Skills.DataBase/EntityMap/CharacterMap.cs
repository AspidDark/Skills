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
        builder.Property(x => x.BuildName).HasColumnName("build_name").IsRequired();
        builder.Property(x => x.StartingDate).HasColumnName("starting_date").IsRequired();
        builder.Property(x => x.SpecialityId).HasColumnName("speciality_id").IsRequired();
        builder.HasOne(x => x.Speciality).WithOne().HasForeignKey("speciality_id");
        builder.HasMany(x => x.Skills).WithOne();
        builder.Property(x => x.PhotoId).HasColumnName("photo_id");
        builder.HasOne(x => x.Photo).WithOne().HasForeignKey("photo_id");
    }
}