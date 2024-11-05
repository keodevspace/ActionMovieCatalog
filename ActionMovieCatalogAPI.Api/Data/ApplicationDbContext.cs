using Microsoft.EntityFrameworkCore;
using ActionMovieCatalogAPI.Api.Models;

namespace ActionMovieCatalogAPI.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<UserModel> Users { get; set; }
}