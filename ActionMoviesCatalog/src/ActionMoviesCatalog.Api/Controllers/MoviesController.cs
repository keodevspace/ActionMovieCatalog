using Microsoft.AspNetCore.Mvc;
using ActionMoviesCatalog.Api.Data;
using ActionMoviesCatalog.Api.Services;

namespace ActionMoviesCatalog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;

        public MoviesController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetMovies() =>
            Ok(await _service.GetAllMoviesAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie(int id) =>
            Ok(await _service.GetMovieByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> AddMovie([FromBody] Movie movie)
        {
            await _service.AddMovieAsync(movie);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, [FromBody] Movie movie)
        {
            if (id != movie.Id) return BadRequest();
            await _service.UpdateMovieAsync(movie);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            await _service.DeleteMovieAsync(id);
            return NoContent();
        }
    }
}
