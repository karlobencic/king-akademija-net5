using Microsoft.EntityFrameworkCore;

namespace KingICT.Academy2021.DddFileSystem.Repository
{
    public class KingAcademyDbContext : DbContext
    {
        public DbSet<Model.Folder> Folders { get; set; }
        public DbSet<Model.File> Files { get; set; }

        public KingAcademyDbContext(DbContextOptions<KingAcademyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model.Folder>()
                .ToTable("Folder");

            modelBuilder.Entity<Model.File>()
                .ToTable("File");
        }
    }
}
