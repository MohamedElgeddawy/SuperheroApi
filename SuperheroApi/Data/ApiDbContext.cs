using Microsoft.EntityFrameworkCore;
using SuperheroApi.Models;

namespace SuperheroApi.Data
{
    // Represents the database context for the application
    public class ApiDbContext : DbContext
    {
        // DbSet properties represent collections of the specified entity types in the database
        public DbSet<Superhero> Superheroes { get; set; }
        public DbSet<FavoriteSuperhero> FavoriteSuperheroes { get; set; }

        // Constructor that accepts DbContextOptions and passes them to the base class constructor
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        // Override the OnModelCreating method to configure the model using the ModelBuilder API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Superhero entity to have owned types for its complex properties
            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Powerstats);
            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Biography);
            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Appearance);
            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Work);
            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Connections);
            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Image);

            // Seed data for the Superheroes table
            modelBuilder.Entity<Superhero>().HasData(
                new Superhero { Id = 1, Name = "Iron Man" },
                new Superhero { Id = 2, Name = "Spider-Man" },
                new Superhero { Id = 3, Name = "Batman" },
                new Superhero { Id = 4, Name = "Superman" },
                new Superhero { Id = 5, Name = "Wonder Woman" }
            );

            // Seed data for the Powerstats owned type
            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Powerstats).HasData(
                new { SuperheroId = 1, Intelligence = 100, Strength = 85, Speed = 58, Durability = 85, Power = 100, Combat = 64 },
                new { SuperheroId = 2, Intelligence = 90, Strength = 55, Speed = 67, Durability = 75, Power = 74, Combat = 85 },
                new { SuperheroId = 3, Intelligence = 100, Strength = 26, Speed = 27, Durability = 50, Power = 47, Combat = 100 },
                new { SuperheroId = 4, Intelligence = 94, Strength = 100, Speed = 100, Durability = 100, Power = 100, Combat = 85 },
                new { SuperheroId = 5, Intelligence = 88, Strength = 100, Speed = 79, Durability = 100, Power = 100, Combat = 100 }
            );

            // Seed data for the Biography owned type
            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Biography).HasData(
                new { SuperheroId = 1, FullName = "Tony Stark", AlterEgos = "No alter egos found.", PlaceOfBirth = "Long Island, New York", FirstAppearance = "Tales of Suspense #39 (March, 1963)", Publisher = "Marvel Comics", Alignment = "good" },
                new { SuperheroId = 2, FullName = "Peter Parker", AlterEgos = "No alter egos found.", PlaceOfBirth = "New York, New York", FirstAppearance = "Amazing Fantasy #15 (August, 1962)", Publisher = "Marvel Comics", Alignment = "good" },
                new { SuperheroId = 3, FullName = "Bruce Wayne", AlterEgos = "No alter egos found.", PlaceOfBirth = "Crest Hill, Bristol Township; Gotham County", FirstAppearance = "Detective Comics #27", Publisher = "DC Comics", Alignment = "good" },
                new { SuperheroId = 4, FullName = "Clark Kent", AlterEgos = "No alter egos found.", PlaceOfBirth = "Krypton", FirstAppearance = "Action Comics #1", Publisher = "DC Comics", Alignment = "good" },
                new { SuperheroId = 5, FullName = "Diana Prince", AlterEgos = "No alter egos found.", PlaceOfBirth = "Themyscira", FirstAppearance = "All Star Comics #8", Publisher = "DC Comics", Alignment = "good" }
            );

            // Seed data for the Appearance owned type
            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Appearance).HasData(
                new { SuperheroId = 1, Gender = "Male", Race = "Human", Height = new[] { "6'6", "198 cm" }, Weight = new[] { "425 lb", "193 kg" }, EyeColor = "Blue", HairColor = "Black" },
                new { SuperheroId = 2, Gender = "Male", Race = "Human", Height = new[] { "5'10", "178 cm" }, Weight = new[] { "167 lb", "76 kg" }, EyeColor = "Hazel", HairColor = "Brown" },
                new { SuperheroId = 3, Gender = "Male", Race = "Human", Height = new[] { "6'2", "188 cm" }, Weight = new[] { "210 lb", "95 kg" }, EyeColor = "Blue", HairColor = "Black" },
                new { SuperheroId = 4, Gender = "Male", Race = "Kryptonian", Height = new[] { "6'3", "191 cm" }, Weight = new[] { "235 lb", "107 kg" }, EyeColor = "Blue", HairColor = "Black" },
                new { SuperheroId = 5, Gender = "Female", Race = "Amazon", Height = new[] { "6'0", "183 cm" }, Weight = new[] { "165 lb", "75 kg" }, EyeColor = "Blue", HairColor = "Black" }
            );

            // Seed data for the Work owned type
            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Work).HasData(
                new { SuperheroId = 1, Occupation = "Inventor, Industrialist", Base = "Seattle, Washington" },
                new { SuperheroId = 2, Occupation = "Photographer", Base = "New York, New York" },
                new { SuperheroId = 3, Occupation = "Businessman", Base = "Gotham City" },
                new { SuperheroId = 4, Occupation = "Reporter", Base = "Metropolis" },
                new { SuperheroId = 5, Occupation = "Warrior", Base = "Themyscira" }
            );

            // Seed data for the Connections owned type
            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Connections).HasData(
                new { SuperheroId = 1, GroupAffiliation = "Avengers", Relatives = "Howard Anthony Stark (father), Maria Collins Carbonell Stark (mother)" },
                new { SuperheroId = 2, GroupAffiliation = "Avengers", Relatives = "Richard Parker (father), Mary Parker (mother)" },
                new { SuperheroId = 3, GroupAffiliation = "Justice League", Relatives = "Thomas Wayne (father), Martha Wayne (mother)" },
                new { SuperheroId = 4, GroupAffiliation = "Justice League", Relatives = "Jor-El (father), Lara Lor-Van (mother)" },
                new { SuperheroId = 5, GroupAffiliation = "Justice League", Relatives = "Hippolyta (mother)" }
            );

            // Seed data for the Image owned type
            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Image).HasData(
                new { SuperheroId = 1, Url = "https://www.superherodb.com/pictures2/portraits/10/100/85.jpg" },
                new { SuperheroId = 2, Url = "https://www.superherodb.com/pictures2/portraits/10/100/133.jpg" },
                new { SuperheroId = 3, Url = "https://www.superherodb.com/pictures2/portraits/10/100/639.jpg" },
                new { SuperheroId = 4, Url = "https://www.superherodb.com/pictures2/portraits/10/100/791.jpg" },
                new { SuperheroId = 5, Url = "https://www.superherodb.com/pictures2/portraits/10/100/807.jpg" }
            );

            // Configure the relationship between FavoriteSuperhero and Superhero
            modelBuilder.Entity<FavoriteSuperhero>()
                .HasOne(f => f.Superhero)
                .WithMany()
                .HasForeignKey(f => f.SuperheroId);
        }
    }
}
