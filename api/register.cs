using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

public static async Task Register(HttpContext context)
    {
    if (context.Request.Method != "POST")
        {
        context.Response.StatusCode = 405; // Method Not Allowed
        return;
        }

    var userManager = context.RequestServices.GetService<UserManager<IdentityUser>>();
    var registerRequest = await JsonSerializer.DeserializeAsync<RegisterRequest>(context.Request.Body);

    if (registerRequest == null || string.IsNullOrWhiteSpace(registerRequest.Username) || string.IsNullOrWhiteSpace(registerRequest.Password))
        {
        context.Response.StatusCode = 400; // Bad Request
        await context.Response.WriteAsync("Invalid request.");
        return;
        }

    var user = new IdentityUser { UserName = registerRequest.Username, Email = registerRequest.Email };
    var result = await userManager.CreateAsync(user, registerRequest.Password);

    if (!result.Succeeded)
        {
        context.Response.StatusCode = 400; // Bad Request
        await context.Response.WriteAsync(JsonSerializer.Serialize(result.Errors));
        return;
        }

    context.Response.StatusCode = 200; // OK
    await context.Response.WriteAsync("User registered successfully!");
    }

public class RegisterRequest
    {
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    }
