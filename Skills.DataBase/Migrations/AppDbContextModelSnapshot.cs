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

            modelBuilder.Entity("SkillSkillLevelsInfo", b =>
                {
                    b.Property<Guid>("SkillLevelDataId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("SkillsId")
                        .HasColumnType("uuid");

                    b.HasKey("SkillLevelDataId", "SkillsId");

                    b.HasIndex("SkillsId");

                    b.ToTable("SkillSkillLevelsInfo", "public");
                });

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

                    b.Property<Guid>("SkillSetId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartingDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("starting_date");

                    b.Property<string>("Story")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("story");

                    b.Property<Guid?>("photo_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SkillSetId");

                    b.HasIndex("photo_id");

                    b.ToTable("caharacter", "public", t =>
                        {
                            t.Property("photo_id")
                                .HasColumnName("photo_id1");
                        });
                });

            modelBuilder.Entity("Skills.DataBase.DataAccess.Entities.CharacterSkill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<string>("CustomName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("skill_name");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("edit_date");

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

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("SkillId");

                    b.ToTable("character_skill", "public");
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

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("create_date");

                    b.Property<string>("DefaultName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("default_name");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("edit_date");

                    b.Property<bool>("IsDefault")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<int>("IsDeleted")
                        .HasColumnType("integer")
                        .HasColumnName("is_deleted");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.Property<Guid>("SkillSetId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SkillSetId");

                    b.ToTable("skill", "public");
                });

            modelBuilder.Entity("Skills.DataBase.DataAccess.Entities.SkillLevelsInfo", b =>
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

                    b.Property<int>("Level")
                        .HasColumnType("integer")
                        .HasColumnName("level");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("path");

                    b.Property<int>("Source")
                        .HasColumnType("integer")
                        .HasColumnName("source");

                    b.HasKey("Id");

                    b.ToTable("skill_levels_data", "public");
                });

            modelBuilder.Entity("Skills.DataBase.DataAccess.Entities.SkillSet", b =>
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

                    b.Property<bool>("IsDefault")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<int>("IsDeleted")
                        .HasColumnType("integer")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("name");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("uuid")
                        .HasColumnName("owner_id");

                    b.HasKey("Id");

                    b.ToTable("skill_set", "public");
                });

            modelBuilder.Entity("SkillSkillLevelsInfo", b =>
                {
                    b.HasOne("Skills.DataBase.DataAccess.Entities.SkillLevelsInfo", null)
                        .WithMany()
                        .HasForeignKey("SkillLevelDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Skills.DataBase.DataAccess.Entities.Skill", null)
                        .WithMany()
                        .HasForeignKey("SkillsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Skills.DataBase.DataAccess.Entities.Character", b =>
                {
                    b.HasOne("Skills.DataBase.DataAccess.Entities.SkillSet", "SkillSet")
                        .WithMany("Characters")
                        .HasForeignKey("SkillSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Skills.DataBase.DataAccess.Entities.FileEntity", "Photo")
                        .WithMany()
                        .HasForeignKey("photo_id");

                    b.Navigation("Photo");

                    b.Navigation("SkillSet");
                });

            modelBuilder.Entity("Skills.DataBase.DataAccess.Entities.CharacterSkill", b =>
                {
                    b.HasOne("Skills.DataBase.DataAccess.Entities.Character", "Character")
                        .WithMany("CharacterSkill")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Skills.DataBase.DataAccess.Entities.Skill", "Skill")
                        .WithMany("CharacterSkills")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Skills.DataBase.DataAccess.Entities.Skill", b =>
                {
                    b.HasOne("Skills.DataBase.DataAccess.Entities.SkillSet", "SkillSet")
                        .WithMany("Skills")
                        .HasForeignKey("SkillSetId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SkillSet");
                });

            modelBuilder.Entity("Skills.DataBase.DataAccess.Entities.Character", b =>
                {
                    b.Navigation("CharacterSkill");
                });

            modelBuilder.Entity("Skills.DataBase.DataAccess.Entities.Skill", b =>
                {
                    b.Navigation("CharacterSkills");
                });

            modelBuilder.Entity("Skills.DataBase.DataAccess.Entities.SkillSet", b =>
                {
                    b.Navigation("Characters");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
