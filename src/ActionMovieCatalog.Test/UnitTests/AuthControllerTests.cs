using ActionMovieCatalog.Api.Data;
using ActionMovieCatalog.Api.Entities; // Add this import
using ActionMoviesCatalog.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace ActionMoviesCatalog.Tests.UnitTests
    {
    public class AuthControllerTests
        {
        [Fact]
        public void Login_WithInvalidUser_ReturnsUnauthorized()
            {
            // Arrange
            var mockContext = new Mock<DatabaseContext>();
            var mockConfig = new Mock<IConfiguration>();
            var controller = new AuthController(mockContext.Object, mockConfig.Object);

            // Act
            var result = controller.Login(new User { Username = "invalid", PasswordHash = "invalid" });

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
            }
        }
    }
