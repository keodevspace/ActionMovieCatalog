using Microsoft.EntityFrameworkCore;
using ActionMovieCatalog.Api.Entities;

namespace ActionMovieCatalog.Api.Data
    {
    public class DatabaseContext : DbContext
        {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
            {
            }

        // Tables
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            base.OnModelCreating(modelBuilder);

            // Movie Entity Configuration
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasKey(m => m.MovieId);
                entity.Property(m => m.Title)
                      .IsRequired()
                      .HasMaxLength(100);
                entity.Property(m => m.Description)
                      .HasMaxLength(500);
                entity.Property(m => m.ReleaseYear)
                      .IsRequired();
            });

            // User Entity Configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.Username)
                      .IsRequired()
                      .HasMaxLength(50);
                entity.Property(u => u.PasswordHash)
                      .IsRequired();
                entity.Property(u => u.Role)
                      .IsRequired()
                      .HasMaxLength(20);
            });
            }
        }
    }

