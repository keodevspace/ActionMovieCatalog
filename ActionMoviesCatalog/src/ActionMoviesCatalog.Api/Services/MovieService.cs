using ActionMoviesCatalog.Api.Data;
using ActionMoviesCatalog.Api.Repositories;

namespace ActionMoviesCatalog.Api.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync() =>
            await _repository.GetAllMoviesAsync();

        public async Task<Movie?> GetMovieByIdAsync(int id) =>
            await _repository.GetMovieByIdAsync(id);

        public async Task AddMovieAsync(Movie movie) =>
            await _repository.AddMovieAsync(movie);

        public async Task UpdateMovieAsync(Movie movie) =>
            await _repository.UpdateMovieAsync(movie);

        public async Task DeleteMovieAsync(int id) =>
            await _repository.DeleteMovieAsync(id);
    }
}
