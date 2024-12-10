using Microsoft.EntityFrameworkCore;
using ActionMoviesCatalog.Api.Models;
using Oracle.ManagedDataAccess.Client;

namespace ActionMoviesCatalog.Api.Data;

public class MovieDbContext : DbContext
    {
    public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options) { }

    public DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        if (!optionsBuilder.IsConfigured)
            {
            optionsBuilder.UseOracle(OracleConnection);
            }
        }
    }
