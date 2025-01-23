using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

[Authorize(Roles = "Admin")]
public static async Task AddMovie(HttpContext context)
    {
    if (context.Request.Method != "POST")
        {
        context.Response.StatusCode = 405; // Method Not Allowed
        return;
        }

    var dbContext = context.RequestServices.GetService<DatabaseContext>();
    var movie = await JsonSerializer.DeserializeAsync<Movie>(context.Request.Body);

    if (movie == null)
        {
        context.Response.StatusCode = 400; // Bad Request
        await context.Response.WriteAsync("Invalid movie data.");
        return;
        }

    dbContext.Movies.Add(movie);
    await dbContext.SaveChangesAsync();

    context.Response.StatusCode = 201; // Created
    context.Response.ContentType = "application/json";
    await context.Response.WriteAsync(JsonSerializer.Serialize(movie));
    }

