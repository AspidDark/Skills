﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Skills.DataBase.DataAccess;

#nullable disable

namespace Skills.DataBase.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Skills.DataBase.DataAccess.Entities.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("BuildName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("build_name");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("edit_date");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("integer")
                        .HasColumnName("is_deleted");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.Property<Guid?>("PhotoId")
                        .HasColumnType("uuid")
                        .HasColumnName("photo_id");

                    b.Property<int>("Priority")
                        .HasColumnType("integer")
                        .HasColumnName("priority");

                    b.Property<DateOnly>("StartingDate")
                        .HasColumnType("date")
                        .HasColumnName("starting_date");

                    b.Property<string>("Story")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("story");

                    b.Property<Guid?>("photo_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("photo_id");

                    b.ToTable("caharacter", "public", t =>
                        {
                            t.Property("photo_id")
                                .HasColumnName("photo_id1");
                        });
                });

            modelBuilder.Entity("Skills.DataBase.DataAccess.Entities.FileEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("edit_date");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("integer")
                        .HasColumnName("is_deleted");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("path");

                    b.HasKey("Id");

                    b.ToTable("file_entity", "public");
                });

            modelBuilder.Entity("Skills.DataBase.DataAccess.Entities.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CahracterId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("edit_date");

                    b.Property<Guid?>("ImageId")
                        .HasColumnType("uuid")
                        .HasColumnName("image_id");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("integer")
                        .HasColumnName("is_deleted");

                    b.Property<int>("IsMain")
                        .HasColumnType("integer")
                        .HasColumnName("is_main");

                    b.Property<int>("Level")
                        .HasColumnType("integer")
                        .HasColumnName("level");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.Property<int>("Priority")
                        .HasColumnType("integer")
                        .HasColumnName("priority");

                    b.Property<string>("SkillName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("skill_name");

                    b.Property<Guid?>("image_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CahracterId");

                    b.HasIndex("image_id");

                    b.ToTable("skill", "public", t =>
                        {
                            t.Property("image_id")
                                .HasColumnName("image_id1");
                        });
                });

            modelBuilder.Entity("Skills.DataBase.DataAccess.Entities.Character", b =>
                {
                    b.HasOne("Skills.DataBase.DataAccess.Entities.FileEntity", "Photo")
                        .WithMany()
                        .HasForeignKey("photo_id");

                    b.Navigation("Photo");
                });

            modelBuilder.Entity("Skills.DataBase.DataAccess.Entities.Skill", b =>
                {
                    b.HasOne("Skills.DataBase.DataAccess.Entities.Character", "Character")
                        .WithMany("Skills")
                        .HasForeignKey("CahracterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Skills.DataBase.DataAccess.Entities.FileEntity", "Image")
                        .WithMany()
                        .HasForeignKey("image_id");

                    b.Navigation("Character");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Skills.DataBase.DataAccess.Entities.Character", b =>
                {
                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}