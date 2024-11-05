using Microsoft.AspNetCore.Mvc;
using ActionMovieCatalogAPI.Api.Data;
using ActionMovieCatalogAPI.Api.Models;

namespace ActionMovieCatalogAPI.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MoviesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Movie>> GetMovies()
    {
        return _context.Movies.ToList();
    }

    [HttpPost]
    public ActionResult<Movie> CreateMovie(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovies), new { id = movie.Id }, movie);
    }
}