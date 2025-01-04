## Superhero API

This API allows you to manage superheroes and their favorite status. It provides endpoints to search for superheroes, add them to favorites, retrieve the list of favorite superheroes, and delete a favorite superhero by name.

### Endpoints

#### Search for Superheroes

**GET** `/api/superhero/search/{name}`

Search for superheroes by name.

- **Parameters:**
  - `name` (string): The name of the superhero to search for.

- **Response:**
  - `200 OK`: Returns a list of superheroes that match the search criteria.

#### Add a Favorite Superhero

**POST** `/api/superhero/favorites`

Add a superhero to the list of favorites.

- **Request Body:**
  - `superheroName` (string): The name of the superhero to add to favorites.

- **Response:**
  - `201 Created`: Returns the added favorite superhero.
  - `400 Bad Request`: If the superhero is not found or is already in favorites.

#### Get Favorite Superheroes

**GET** `/api/superhero/favorites`

Retrieve the list of favorite superheroes.

- **Response:**
  - `200 OK`: Returns a list of favorite superheroes.

#### Delete a Favorite Superhero by Name

**DELETE** `/api/superhero/favorites/{name}`

Delete a favorite superhero by name.

- **Parameters:**
  - `name` (string): The name of the superhero to delete from favorites.

- **Response:**
  - `200 OK`: If the favorite superhero is successfully removed.
  - `404 Not Found`: If the favorite superhero is not found.

### Models

#### Superhero

Represents a superhero with various properties.

- `int Id`: The unique identifier of the superhero.
- `string Name`: The name of the superhero.
- `Powerstats Powerstats`: The power stats of the superhero.
- `Biography Biography`: The biography of the superhero.
- `Appearance Appearance`: The appearance details of the superhero.
- `Work Work`: The work details of the superhero.
- `Connections Connections`: The connections of the superhero.
- `Image Image`: The image of the superhero.

#### FavoriteSuperhero

Represents a favorite superhero with a reference to the Superhero entity.

- `int Id`: The unique identifier of the favorite superhero.
- `int SuperheroId`: The unique identifier of the superhero.
- `Superhero Superhero`: The superhero entity.

### Database Context

#### ApiDbContext

Represents the database context for the application.

- `DbSet<Superhero> Superheroes`: Represents the collection of superheroes in the database.
- `DbSet<FavoriteSuperhero> FavoriteSuperheroes`: Represents the collection of favorite superheroes in the database.

### Usage

1. Clone the repository.
2. Configure the database connection string in `appsettings.json`.
3. Run the migrations to create the database schema.
4. Start the application.
5. Use the provided endpoints to manage superheroes and their favorite status.

### Requirements

- .NET 8
- Entity Framework Core

### Installation

1. Install the required .NET SDK.
2. Restore the dependencies using `dotnet restore`.
3. Build the project using `dotnet build`.
4. Run the application using `dotnet run`.
