using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skills.DataBase.DataAccess.Entities;

namespace Skills.DataBase.EntityMap;

public class CharacterMap : BaseEntityMap<Character>
{
    public CharacterMap() : base("caharacter") { }

    public override void Configure(EntityTypeBuilder<Character> builder)
    {
        base.Configure(builder);
    }
}
