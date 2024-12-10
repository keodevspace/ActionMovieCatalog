using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using ActionMoviesCatalog.Data;
using ActionMoviesCatalog.Entities;
using ActionMoviesCatalog.Services;

namespace UnitTests
{
    public class ActionMoviesCatalogTest
    {
        private readonly Mock<IMovieRepository> _mockRepo;
        private readonly MovieService _movieService;

        public ActionMoviesCatalogTest()
        {
            _mockRepo = new Mock<IMovieRepository>();
            _movieService = new MovieService(_mockRepo.Object);
        }

        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public async Task AddMovie_ShouldAddMovie()
        {
            var movie = new Movie { Title = "Inception", Director = "Christopher Nolan", ReleaseYear = 2010, Genre = "Action", Rating = 8.8 };
            _mockRepo.Setup(repo => repo.AddMovieAsync(movie)).Returns(Task.CompletedTask);

            await _movieService.AddMovieAsync(movie);

            _mockRepo.Verify(repo => repo.AddMovieAsync(movie), Times.Once);
        }

        [Fact]
        public async Task GetMovies_ShouldReturnMovies()
        {
            var movies = new List<Movie>
            {
                new Movie { Title = "Inception", Director = "Christopher Nolan", ReleaseYear = 2010, Genre = "Action", Rating = 8.8 },
                new Movie { Title = "The Dark Knight", Director = "Christopher Nolan", ReleaseYear = 2008, Genre = "Action", Rating = 9.0 }
            };
            _mockRepo.Setup(repo => repo.GetMoviesAsync()).ReturnsAsync(movies);

            var result = await _movieService.GetMoviesAsync();

            Assert.Equal(2, result.Count());
            Assert.Equal("Inception", result.First().Title);
        }

        [Fact]
        public async Task DeleteMovie_ShouldDeleteMovie()
        {
            var movieId = 1;
            _mockRepo.Setup(repo => repo.DeleteMovieAsync(movieId)).Returns(Task.CompletedTask);

            await _movieService.DeleteMovieAsync(movieId);

            _mockRepo.Verify(repo => repo.DeleteMovieAsync(movieId), Times.Once);
        }
    }
}