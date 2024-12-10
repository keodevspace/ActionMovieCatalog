using Microsoft.EntityFrameworkCore;
using ActionMoviesCatalog.Api.Data;
using ActionMoviesCatalog.Api.Models;

namespace ActionMoviesCatalog.Api.Repositories;

public class MovieRepository : IMovieRepository
    {
    private readonly MovieDbContext _context;

    public MovieRepository(MovieDbContext context)
        {
        _context = context;
        }

    public async Task<IEnumerable<Movie>> GetAllMoviesAsync() =>
        await _context.Movies.ToListAsync();

    public async Task<Movie?> GetMovieByIdAsync(int id) =>
        await _context.Movies.FindAsync(id);

    public async Task AddMovieAsync(Movie movie)
        {
        await _context.Movies.AddAsync(movie);
        await _context.SaveChangesAsync();
        }

    public async Task UpdateMovieAsync(Movie movie)
        {
        _context.Movies.Update(movie);
        await _context.SaveChangesAsync();
        }

    public async Task DeleteMovieAsync(int id)
        {
        var movie = await _context.Movies.FindAsync(id);
        if (movie != null)
            {
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
            }
        }
    }
