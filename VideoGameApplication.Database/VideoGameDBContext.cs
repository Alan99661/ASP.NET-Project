using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Database
{
    public class VideoGameDBContext : IdentityDbContext<User>
    {
        public VideoGameDBContext(DbContextOptions<VideoGameDBContext> dbContextOptionsBuilder) : base(dbContextOptionsBuilder)
        {

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Developer> Developers { get; set;}
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Screenshot> Screenshots { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(e =>
            {
                e.HasKey(e => e.Id);
            });
            modelBuilder.Entity<Developer>(e =>
            {
                e.HasKey(e => e.Id);
            });
            modelBuilder.Entity<Genre>(e =>
            {
                e.HasKey(e => e.Id);
            });
            modelBuilder.Entity<Platform>(e =>
            {
                e.HasKey(e => e.Id);
            });
            modelBuilder.Entity<Review>(e =>
            {
                e.HasKey(e => e.Id);
            });
            modelBuilder.Entity<Screenshot>(e =>
            {
                e.HasKey(e => e.Id);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}