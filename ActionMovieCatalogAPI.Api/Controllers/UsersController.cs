using ActionMovieCatalogAPI.Api.Data;
using ActionMovieCatalogAPI.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace ActionMovieCatalogAPI.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<UserModel>> GetUsers()
    {
        return _context.Users.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<UserModel> GetUser(int id)
    {
        var user = _context.Users.Find(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }
}