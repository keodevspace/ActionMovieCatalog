namespace ActionMoviesCatalog.Api.Entities
    {
    public class Movie
        {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }
        public string Director { get; set; }
        public double Rating { get; set; }
        }
    }
