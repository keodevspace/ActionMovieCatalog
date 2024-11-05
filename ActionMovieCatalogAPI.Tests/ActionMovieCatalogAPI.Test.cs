using ActionMovieCatalogAPI.Api.Controllers;
using ActionMovieCatalogAPI.Api.Data;
using ActionMovieCatalogAPI.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ActionMovieCatalogAPI.Tests;
public class UnitTest1
{
    private readonly ReviewsController _controller;
    private readonly ApplicationDbContext _context;

    public UnitTest1()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new ApplicationDbContext(options);
        _controller = new ReviewsController(_context);

        // Seed the in-memory database with test data
        _context.Reviews.AddRange(new List<Review>
            {
                new Review { Id = 1, Content = "Great movie!", Movie = new Movie { Id = 1, Title = "Movie 1", Genre = "Action" } },
                new Review { Id = 2, Content = "Not bad.", Movie = new Movie { Id = 2, Title = "Movie 2", Genre = "Drama" } }
            });
        _context.SaveChanges();
    }

    [Fact]
    public void GetReviews_ReturnsOkResult()
    {
        // Act
        var result = _controller.GetReviews();

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void GetReview_ReturnsOkResult()
    {
        // Act
        var result = _controller.GetReview(1);

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
    }

    [Fact]
    public void GetReview_ReturnsNotFoundResult()
    {
        // Act
        var result = _controller.GetReview(99);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
}