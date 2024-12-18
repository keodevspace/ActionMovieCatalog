using ActionMoviesCatalog.Api.Entities;
using ActionMoviesCatalog.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ActionMoviesCatalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IRepository<Movie> _movieRepository;

    public MoviesController(IRepository<Movie> movieRepository)
    {
        _movieRepository = movieRepository;
    }

    [HttpGet]
    public async Task<IEnumerable<Movie>> GetAllMovies()
    {
        return await _movieRepository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovieById(int id)
    {
        var movie = await _movieRepository.GetByIdAsync(id);
        if (movie == null)
            return NotFound();

        return Ok(movie);
    }

    [HttpPost]
    public async Task<IActionResult> AddMovie(Movie newMovie)
{
    await _movieRepository.AddAsync(newMovie);
    return CreatedAtAction("GetMovieById", new { id = newMovie.Id }, newMovie); 
}

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie movie)
    {
        var existingMovie = await _movieRepository.GetByIdAsync(id);
        if (existingMovie == null)
            return NotFound();

        existingMovie.Title = movie.Title;
        existingMovie.Description = movie.Description;

        await _movieRepository.UpdateAsync(existingMovie);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        var movie = await _movieRepository.GetByIdAsync(id);
        if (movie == null)
            return NotFound();

        await _movieRepository.DeleteAsync(id);
        return NoContent();
    }
}