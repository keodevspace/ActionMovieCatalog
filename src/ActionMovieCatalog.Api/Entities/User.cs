namespace ActionMovieCatalog.Api.Entities
{
    public class User
    {
        public int UserId { get; set; } = string.Empty;
        public required string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
