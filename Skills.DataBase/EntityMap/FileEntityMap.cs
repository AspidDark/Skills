using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skills.DataBase.DataAccess.Entities;

namespace Skills.DataBase.EntityMap;

public class FileEntityMap : BaseEntityMap<FileEntity>
{
    public FileEntityMap() : base("file_entity") { }

    public override void Configure(EntityTypeBuilder<FileEntity> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Path).HasColumnName("path").IsRequired();
       
    }
}
