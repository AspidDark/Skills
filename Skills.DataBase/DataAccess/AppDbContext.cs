using Microsoft.EntityFrameworkCore;
using Skills.DataBase.DataAccess.Entities;
using Skills.DataBase.EntityMap;
using System.Security.Principal;

namespace Skills.DataBase.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //inmemory
            //Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("public");
            //Table name mapping
            modelBuilder.ApplyConfiguration(new CharacterMap());
            modelBuilder.ApplyConfiguration(new SkillMap());
            modelBuilder.ApplyConfiguration(new FileEntityMap());

            modelBuilder.Entity<Character>()
                .HasMany(s => s.Skills)
                .WithOne(c => c.Character)
                .HasForeignKey(p => p.CahracterId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public DbSet<FileEntity> Files { get; set; }
    }
}
