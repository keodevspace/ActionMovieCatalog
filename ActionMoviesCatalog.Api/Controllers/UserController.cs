using ActionMoviesCatalog.Api.Entities;
using ActionMoviesCatalog.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ActionMoviesCatalog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IRepository<User> _userRepository;

    public UserController(IRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] User user)
    {
        // Validation
        if (string.IsNullOrEmpty(user.Username) || string.IsNullOrEmpty(user.Password))
            return BadRequest("Username and password are required.");

        // Add user
        await _userRepository.AddAsync(user);

        return CreatedAtAction(nameof(RegisterUser), new { id = user.Id }, user);
    }
}