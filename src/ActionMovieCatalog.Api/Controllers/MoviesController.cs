using ActionMovieCatalog.Api.Data;
using ActionMovieCatalog.Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ActionMoviesCatalog.Api.Controllers
    {
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
        {
        private readonly DatabaseContext _context;

        public MoviesController(DatabaseContext context)
            {
            _context = context;
            }

        [HttpGet]
        // [Authorize] // Temporarily remove this line for testing
        public IActionResult GetAll()
            {
            return Ok(_context.Movies.ToList());
            }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddMovie([FromBody] Movie movie)
            {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = movie.MovieId }, movie);
            }
        }
    }


