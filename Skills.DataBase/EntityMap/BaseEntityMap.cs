﻿using Skills.DataBase.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Skills.DataBase.EntityMap;

public abstract class BaseEntityMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
{
    private readonly string _tableName;
    public BaseEntityMap(string tableName)
    {
        _tableName = tableName;
    }
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.ToTable(_tableName);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id").IsRequired();

        builder.Property(x => x.OwnerId).HasColumnName("owner_id").IsRequired();

        builder.Property(x => x.CreateDate).HasConversion(typeof(DateTimeToDateTimeUtc)).HasColumnName("create_date").IsRequired();

        builder.Property(x => x.EditDate).HasConversion(typeof(DateTimeToDateTimeUtc)).HasColumnName("edit_date").IsRequired();

        builder.Property(x => x.IsDeleted).HasColumnName("is_deleted");

    }
}

public class DateTimeToDateTimeUtc : ValueConverter<DateTime, DateTime>
{
    public DateTimeToDateTimeUtc() : base(c => DateTime.SpecifyKind(c, DateTimeKind.Utc), c => c)
    {
    }
}
