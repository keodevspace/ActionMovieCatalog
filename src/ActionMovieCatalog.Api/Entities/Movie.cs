namespace ActionMovieCatalog.Api.Entities
{
    public class Movie
    {
        public int MovieId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public int ReleaseYear { get; set; } = string.Empty;
        public float Rating { get; set; } = string.Empty;
    }
}
