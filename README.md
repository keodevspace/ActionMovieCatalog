## Action Movie Catalog API

## Description
A RESTful API to manage a catalog of action movies, allowing users to add, search, update, remove movies, as well as rate and comment on them.

## Features
* Movie Management
  * List all movies
  * Search for movies by title, genre and other criteria
  * Add new movies
  * Edit existing movie information
  * Remove movies
* Ratings and Reviews
  * Add ratings and comments
  * View ratings and comments for a movie
**Users:**
  * Register new users
  * User login
  * Access permissions (e.g. users can edit their own comments)

## Technologies Used
- C# with ASP.NET Core
- SQL Server
- JWT
- Swagger

## How to Run
### Prerequisites
* .NET 8.0
* SQL Server

### Steps
1. **Clone the repository:**
   ```bash
   git clone [https://github.com/keodevspace/ActionMovieCatalogAPI.git](https://github.com/keodevspace/ActionMovieCatalogAPI.git)
2. **Restore the database:** 
   ```bash
   dotnet ef database update
3. **Configure the connection string:** Edit the `appsettings.json` file with your database information.
4. **Run the application:**
   ```bash
   dotnet run
   ```

## API documentation
The interactive API documentation is available at:
http://localhost:5000/swagger

## Author
Keo Coelho
