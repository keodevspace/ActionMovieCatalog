using Microsoft.AspNetCore.Mvc;
using ActionMovieCatalogAPI.Api.Data;
using ActionMovieCatalogAPI.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ActionMovieCatalogAPI.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ReviewsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Review>> GetReviews()
    {
        var reviews = _context.Reviews.ToList();
        return Ok(reviews);
    }

    [HttpPost]
    public ActionResult<Review> CreateReview(Review review)
    {
        _context.Reviews.Add(review);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetReviews), new { id = review.Id }, review);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateReview(int id, Review review)
    {
        if (id != review.Id)
        {
            return BadRequest();
        }

        _context.Entry(review).State = EntityState.Modified;
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteReview(int id)
    {
        var review = _context.Reviews.Find(id);

        if (review == null)
        {
            return NotFound();
        }

        _context.Reviews.Remove(review);
        _context.SaveChanges();

        return NoContent();
    }
}