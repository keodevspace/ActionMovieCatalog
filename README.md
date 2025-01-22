# ActionMovieCatalog

This project is a RESTful API for managing an action movies catalog, built with .NET 9, SQLite, and JWT authentication. The API is deployed using serverless functions on Vercel and implements user management with Identity.

## Features

- JWT-based user authentication using Identity
- User registration and role-based access control
- CRUD operations for action movies
- Swagger for API documentation and testing
- Hosted using serverless functions on Vercel

## Project Structure

- `ActionMoviesCatalog.Api`: Contains the main API logic
- `ActionMoviesCatalog.Tests`: Unit tests for the API

## Setup

1. Install .NET SDK 9.0 or later from [here](https://dotnet.microsoft.com/download).
2. Run `dotnet restore` to install dependencies
3. Configure the database connection string as an environment variable `DATABASE_CONNECTION`.
4. Add environment variables for JWT:
   - `JWT_KEY`: The secret key for signing tokens.
   - `JWT_ISSUER`: The issuer of the tokens.
   - `JWT_AUDIENCE`: The audience for the tokens.
5. Deploy the project to Vercel by linking your GitHub repository and setting the above environment variables in the Vercel dashboard.

## Usage

### Local Development
1. Run the API locally:
   ```bash
   dotnet run --project src/ActionMovieCatalog.Api
   ```
2. Access the API documentation locally at `https://localhost:5000/swagger`.

### Deployed API
The API is deployed on Vercel and can be accessed via the provided public URL.

## Deploying on Vercel

1. Push the project to a GitHub repository.
2. Log in to [Vercel](https://vercel.com).
3. Create a new project and link it to your GitHub repository.
4. Configure the following environment variables in the Vercel dashboard:
   - `DATABASE_CONNECTION`
   - `JWT_KEY`
   - `JWT_ISSUER`
   - `JWT_AUDIENCE`
5. Deploy the project.

The API is designed as serverless functions, allowing efficient scaling and reduced overhead. It uses Identity for user management, including registration, authentication, and role-based authorization.

The API will be live and accessible at `https://actionmoviecatalog.vercel.app/swagger`.

## Author

Keo Coelho

