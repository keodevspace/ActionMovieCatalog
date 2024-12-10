using Microsoft.EntityFrameworkCore;
using ActionMoviesCatalog.Api.Models;

namespace ActionMoviesCatalog.Api.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
    }
}
