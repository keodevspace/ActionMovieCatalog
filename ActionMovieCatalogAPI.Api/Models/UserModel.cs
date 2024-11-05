namespace ActionMovieCatalogAPI.Api.Models;

public class UserModel
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
