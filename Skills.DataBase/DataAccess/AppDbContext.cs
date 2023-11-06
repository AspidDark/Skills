using Microsoft.EntityFrameworkCore;
using Skills.DataBase.DataAccess.Entities;
using Skills.DataBase.EntityMap;

namespace Skills.DataBase.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //inmemory
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("public");

            //Table name mapping
            modelBuilder.ApplyConfiguration(new SkillSetMap());
            modelBuilder.ApplyConfiguration(new SkillMap());
            modelBuilder.ApplyConfiguration(new SkillLevelsInfoMap());
            modelBuilder.ApplyConfiguration(new CharacterMap());
            modelBuilder.ApplyConfiguration(new CharacterSkillMap());
            modelBuilder.ApplyConfiguration(new FileEntityMap());


            modelBuilder.Entity<SkillSet>()
                .HasMany(s => s.Skills)
                .WithOne(c => c.SkillSet)
                .HasForeignKey(p => p.SkillSetId);

            modelBuilder.Entity<Skill>()
                .HasMany(e => e.SkillLevelData)
                .WithMany(e => e.Skills);

            modelBuilder.Entity<Character>()
                .HasOne(x => x.SkillSet)
                .WithMany(x => x.Characters)
                .HasForeignKey(x => x.SkillSetId);

            modelBuilder.Entity<CharacterSkill>()
                .HasOne(x=>x.Skill)
                .WithMany(x=>x.CharacterSkills).
                HasForeignKey(x => x.SkillId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<SkillSet> SkillSets { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SkillLevelsInfo> SkillLevelsInfo { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }
        public DbSet<FileEntity> Files { get; set; }
    }
}
