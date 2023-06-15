using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameApplication.Models.Entities;

namespace VideoGameApplication.Database.Configuring
{
    public static class FluentApiConfiguration
    {
        public static void ConfigureFluentApi(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Game>(e =>
            {
                e.HasKey(e => e.Id);
                e.Property(p => p.ReleaseDate)
                .HasColumnType("date");
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
                e.Property(e =>e.Certified)
                .HasDefaultValue(false);
            });
            modelBuilder.Entity<Screenshot>(e =>
            {
                e.HasKey(e => e.Id);
            });
        }
    }
}
