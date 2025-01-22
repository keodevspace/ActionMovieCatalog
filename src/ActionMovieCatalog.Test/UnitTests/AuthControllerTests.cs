using ActionMoviesCatalog.Api.Controllers;
using ActionMoviesCatalog.Api.Data;
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
            var result = controller.Login(new { Username = "invalid", Password = "invalid" });

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
            }
        }
    }
