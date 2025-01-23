using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Linq;

public static async Task Login(HttpContext context)
    {
    if (context.Request.Method != "POST")
        {
        context.Response.StatusCode = 405; // Method Not Allowed
        return;
        }

    var dbContext = context.RequestServices.GetService<DatabaseContext>();
    var configuration = context.RequestServices.GetService<IConfiguration>();
    var loginRequest = await JsonSerializer.DeserializeAsync<User>(context.Request.Body);

    if (loginRequest == null || string.IsNullOrWhiteSpace(loginRequest.Username) || string.IsNullOrWhiteSpace(loginRequest.PasswordHash))
        {
        context.Response.StatusCode = 400; // Bad Request
        await context.Response.WriteAsync("Invalid request.");
        return;
        }

    var existingUser = dbContext.Users.FirstOrDefault(u => u.Username == loginRequest.Username);

    if (existingUser == null || existingUser.PasswordHash != loginRequest.PasswordHash)
        {
        context.Response.StatusCode = 401; // Unauthorized
        return;
        }

    var token = JwtTokenHandler.GenerateToken(
        existingUser.Username,
        existingUser.Role,
        configuration["Jwt:Key"],
        configuration["Jwt:Issuer"],
        configuration["Jwt:Audience"]
    );

    context.Response.ContentType = "application/json";
    await context.Response.WriteAsync(JsonSerializer.Serialize(new { Token = token }));
    }

