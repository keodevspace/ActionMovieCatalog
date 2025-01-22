using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

[Authorize]
public static async Task GetAllMovies(HttpContext context)
    {
    var dbContext = context.RequestServices.GetService<DatabaseContext>();
    var movies = dbContext.Movies.ToList();
    context.Response.ContentType = "application/json";
    await context.Response.WriteAsync(JsonSerializer.Serialize(movies));
    }
