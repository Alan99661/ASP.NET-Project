using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoGameApplication.Database.Configuring;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Database
{
    public class VideoGameDBContext : IdentityDbContext<User, IdentityRole, string>
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
        //public DbSet<BackgroundImage> BackgroundImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureFluentApi();
            base.OnModelCreating(modelBuilder);
        }
    }
}