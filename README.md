# Action Movies Catalog

This project is an action movie catalog, developed with **.NET 8** and **Oracle Database**, using **JWT** for authentication and **Docker** for containerization.

## Features

- **JWT Authentication**: Protects the API endpoints.
- **Movie CRUD**: Allows you to create, list, edit, and delete action movies.
- **Oracle Database**: Uses PL/SQL to store and manage data.

## Requirements

- [Docker](https://www.docker.com/products/docker-desktop) for running Oracle Database
- [Postman](https://www.postman.com/) to test the API

## How to Run

### 1. Clone the repository

```bash
git clone https://github.com/keodevspace/ActionMovieCatalog.git
cd ActionMovieCatalog
```

### 2. Start Docker

```bash
docker-compose up -d
```

### 3. Configure the Database

Edit the database settings in the `appsettings.json` file to point to your Oracle database.

### 4. Run the API

```bash
dotnet build
dotnet run
```

### 5. Test the API

-   **POST /api/auth/login**: Authenticates the user and returns a JWT.
-   **GET /api/movies**: Lists the registered movies.
-   **POST /api/movies**: Creates a new movie.
-   **PUT /api/movies/{id}**: Updates a movie.
-   **DELETE /api/movies/{id}**: Deletes a movie.

Use the generated **JWT** from the login to authorize subsequent requests.

## Technologies Used

-   **.NET 8**: Framework for the API.
-   **JWT**: User authentication.
-   **Oracle Database (PL/SQL)**: Database for data persistence.
-   **Docker**: To run the database and application in containers.


## Created by 

[Keo Coelho](https://keodevspace.vercel.app/index.html) 
