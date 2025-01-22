using ActionMovieCatalog.Api.Data;
using ActionMovieCatalog.Api.Authentication;
using ActionMovieCatalog.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ActionMoviesCatalog.Api.Controllers
    {
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
        {
        private readonly DatabaseContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(DatabaseContext context, IConfiguration configuration)
            {
            _context = context;
            _configuration = configuration;
            }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
            {
            var existingUser = _context.Users.FirstOrDefault(u => u.Username == user.Username);

            if (existingUser == null || existingUser.PasswordHash != user.PasswordHash)
                return Unauthorized();

            var token = JwtTokenHandler.GenerateToken(
                user.Username,
                existingUser.Role,
                _configuration["Jwt:Key"],
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"]
            );

            return Ok(new { Token = token });
            }
        }
    }
