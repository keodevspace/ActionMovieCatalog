using Moq;
using ActionMoviesCatalog.Api.Controllers;
using ActionMoviesCatalog.Api.Entities;
using ActionMoviesCatalog.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ActionMoviesCatalog.Tests.UnitTests;
public class UserControllerTests
{
    [Fact]
    public async Task RegisterUser_Should_Return_CreatedResult()
    {
        // Arrange
        var mockRepo = new Mock<IRepository<User>>();
        var controller = new UserController(mockRepo.Object);

        var newUser = new User { Username = "testuser", Password = "securepassword" };

        // Act
        var result = await controller.RegisterUser(newUser) as CreatedAtActionResult;

        // Assert
        Assert.NotNull(result);
        Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal("GetUserById", result.ActionName);
    }

    [Fact]
    public async Task RegisterUser_Should_Return_BadRequest_If_User_Is_Invalid()
    {
        // Arrange
        var mockRepo = new Mock<IRepository<User>>();
        var controller = new UserController(mockRepo.Object);
        var invalidUser = new User { /* campos inválidos */ };

        // Act
        var result = await controller.RegisterUser(invalidUser);

        // Assert
        Assert.IsType<BadRequestObjectResult>(result);
    }
}