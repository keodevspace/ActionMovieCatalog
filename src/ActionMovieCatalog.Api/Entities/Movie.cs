namespace ActionMovieCatalog.Api.Entities
{
    public class Movie
    {
        public int MovieId { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public int ReleaseYear { get; set; } = 0;
        public float Rating { get; set; } = 0;
    }
}
