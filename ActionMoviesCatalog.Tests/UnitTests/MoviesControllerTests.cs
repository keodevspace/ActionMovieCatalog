using Moq;
using ActionMoviesCatalog.Api.Controllers;
using ActionMoviesCatalog.Api.Entities;
using ActionMoviesCatalog.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ActionMoviesCatalog.Tests.UnitTests;
public class MoviesControllerTests
{
    [Fact]
    public async Task GetAllMovies_Should_Return_List_Of_Movies()
    {
        // Arrange
        var mockRepo = new Mock<IRepository<Movie>>();
        mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new List<Movie>
        {
            new Movie { Id = 1, Title = "Rocky", Description = "Action-drama." },
            new Movie { Id = 2, Title = "Rocky II, The Revenge", Description = "Action-drama." }
        });

        var controller = new MoviesController(mockRepo.Object);

        // Act
        var result = await controller.GetAllMovies() as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<List<Movie>>(result.Value);
        var movies = result.Value as List<Movie>;
        Assert.Equal(2, movies.Count);
    }


    [Fact]
    public async Task AddMovie_Should_Return_CreatedResult()
    {
        // Arrange
        var mockRepo = new Mock<IRepository<Movie>>();
        var controller = new MoviesController(mockRepo.Object);
        var newMovie = new Movie { Title = "John Wick", Description = "Hitman seeks revenge." };

        // Act
        var result = await controller.AddMovie(newMovie) as CreatedAtActionResult;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal("GetMovieById", result.ActionName);
    }
}