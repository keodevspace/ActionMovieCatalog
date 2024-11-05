namespace ActionMovieCatalogAPI.Api.Models;

public class Review
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public int MovieId { get; set; } 
    public Movie Movie { get; set; } = new Movie();
}