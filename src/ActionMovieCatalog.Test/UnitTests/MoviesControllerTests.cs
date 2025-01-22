using ActionMoviesCatalog.Api.Controllers;
using ActionMoviesCatalog.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ActionMoviesCatalog.Tests.UnitTests
    {
    public class MoviesControllerTests
        {
        [Fact]
        public void GetAll_ReturnsOkResult()
            {
            // Arrange
            var mockContext = new Mock<DatabaseContext>();
            var controller = new MoviesController(mockContext.Object);

            // Act
            var result = controller.GetAll();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            }
        }
    }
