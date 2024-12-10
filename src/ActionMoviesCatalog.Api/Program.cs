using Microsoft.EntityFrameworkCore;
using ActionMoviesCatalog.Api.Data;
using ActionMoviesCatalog.Api.Repositories;
using ActionMoviesCatalog.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure DbContext with Oracle
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection")));

// Add repositories and services
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

var app = builder.Build();

app.UseAuthorization();
app.MapControllers();
app.Run();