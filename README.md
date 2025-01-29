# SuperheroApi

## Overview
The `SuperheroApi` is a RESTful API built using ASP.NET Core that provides information about superheroes. It leverages the repository pattern for data access, implements authentication to secure endpoints, and uses an in-memory cache to improve performance.

## Features
1. **Superhero Data Retrieval**
   - Get a list of all superheroes.
   - Get details of a specific superhero by ID.

2. **Repository Pattern**
   - Separation of concerns between business logic and data access.
   - Simplified unit testing.

3. **Authentication**
   - Secured endpoints using JWT (JSON Web Tokens).
   - Role-based authorization.

4. **In-Memory Cache**
   - Improved performance by caching frequently accessed data.
   - Reduces database load.

## Getting Started

### Prerequisites
- .NET Core SDK 8.0.
- An IDE like Visual Studio or VS Code.

### Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/MohamedElgeddawy/SuperheroApi.git
   cd SuperheroApi
   ```

2. Restore dependencies:
   ```sh
   dotnet restore
   ```

3. Set up the database (if applicable):
   - This project might use an in-memory database or a real database depending on configuration.

4. Run the application:
   ```sh
   dotnet run
   ```

### Endpoints
- **Get All Superheroes**:
  ```
  GET /api/superheroes
  ```
  Response:
  ```json
  [
    {
      "id": 1,
      "name": "Superman",
      "power": "Flight"
    },
    ...
  ]
  ```

- **Get Superhero by ID**:
  ```
  GET /api/superheroes/{id}
  ```
  Response:
  ```json
  {
    "id": 1,
    "name": "Superman",
    "power": "Flight"
  }
  ```

## Repository Pattern
The repository pattern is a design pattern that abstracts the data layer from the business logic. It separates the responsibilities, making the code more maintainable and testable.

### Implementation Details
- **Interfaces**: Define interfaces for repositories (`ISuperheroRepository`).
- **Concrete Classes**: Implement these interfaces (`SuperheroRepository`).
- **Dependency Injection**: Register the repository in the `Startup.cs` file to inject it into controllers.



## Authentication
This project uses JWT for securing endpoints. Users must provide valid credentials to obtain a token, which they then use to access protected resources.

### Implementation Details
- **JWT Configuration**: Configure JWT in `Startup.cs`.
- **Login Endpoint**: Create an endpoint to authenticate users and return a token.
- **Authorization Attributes**: Use `[Authorize]` attribute to protect endpoints.



## In-Memory Cache
In-memory caching is used to store frequently accessed data in memory, reducing the need to repeatedly query the database.

### Implementation Details
- **Cache Service**: Inject `IMemoryCache` into your services/controllers.
- **Set/Get Cache**: Use methods like `Set`, `Get`, `TryGetValue` to manage cached data.


## Contributing
Contributions are welcome! Please open an issue or submit a pull request.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

