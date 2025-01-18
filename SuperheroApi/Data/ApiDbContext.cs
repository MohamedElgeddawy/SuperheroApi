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

        public DbSet<Powerstats> Powerstats { get; set; }
        public DbSet<Biography> Biographies { get; set; }
        public DbSet<Appearance> Appearances { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<Connections> Connections { get; set; }
        public DbSet<Image> Images { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-one relationships
            modelBuilder.Entity<Superhero>()
                .HasOne(s => s.Powerstats)
                .WithOne(p => p.Superhero)
                .HasForeignKey<Powerstats>(p => p.SuperheroId);

            modelBuilder.Entity<Superhero>()
                .HasOne(s => s.Biography)
                .WithOne(b => b.Superhero)
                .HasForeignKey<Biography>(b => b.SuperheroId);

            modelBuilder.Entity<Superhero>()
                .HasOne(s => s.Appearance)
                .WithOne(a => a.Superhero)
                .HasForeignKey<Appearance>(a => a.SuperheroId);

            modelBuilder.Entity<Superhero>()
                .HasOne(s => s.Work)
                .WithOne(w => w.Superhero)
                .HasForeignKey<Work>(w => w.SuperheroId);

            modelBuilder.Entity<Superhero>()
                .HasOne(s => s.Connections)
                .WithOne(c => c.Superhero)
                .HasForeignKey<Connections>(c => c.SuperheroId);

            modelBuilder.Entity<Superhero>()
                .HasOne(s => s.Image)
                .WithOne(i => i.Superhero)
                .HasForeignKey<Image>(i => i.SuperheroId);

            // Superhero 1: A-Bomb
            modelBuilder.Entity<Superhero>().HasData(
                new Superhero { Id = 1, Name = "A-Bomb" }
            );
            modelBuilder.Entity<Powerstats>().HasData(
                new Powerstats { Id = 1, Intelligence = 38, Strength = 100, Speed = 17, Durability = 80, Power = 24, Combat = 64, SuperheroId = 1 }
            );
            modelBuilder.Entity<Biography>().HasData(
                new Biography { Id = 1, FullName = "Richard Milhouse Jones", AlterEgos = "No alter egos found.", Aliases = new List<string> { "Rick Jones" }, PlaceOfBirth = "Scarsdale, Arizona", FirstAppearance = "Hulk Vol 2 #2 (April, 2008) (as A-Bomb)", Publisher = "Marvel Comics", Alignment = "good", SuperheroId = 1 }
            );
            modelBuilder.Entity<Appearance>().HasData(
                new Appearance { Id = 1, Gender = "Male", Race = "Human", Height = new List<string> { "6'8", "203 cm" }, Weight = new List<string> { "980 lb", "441 kg" }, EyeColor = "Yellow", HairColor = "No Hair", SuperheroId = 1 }
            );
            modelBuilder.Entity<Work>().HasData(
                new Work { Id = 1, Occupation = "Musician, adventurer, author; formerly talk show host", Base = "-", SuperheroId = 1 }
            );
            modelBuilder.Entity<Connections>().HasData(
                new Connections { Id = 1, GroupAffiliation = "Hulk Family; Excelsior (sponsor), Avengers (honorary member); formerly partner of the Hulk, Captain America and Captain Marvel; Teen Brigade; ally of Rom", Relatives = "Marlo Chandler-Jones (wife); Polly (aunt); Mrs. Chandler (mother-in-law); Keith Chandler, Ray Chandler, three unidentified others (brothers-in-law); unidentified father (deceased); Jackie Shorr (alleged mother; unconfirmed)", SuperheroId = 1 }
            );
            modelBuilder.Entity<Image>().HasData(
                new Image { Id = 1, Url = "https://www.superherodb.com/pictures2/portraits/10/100/10060.jpg", SuperheroId = 1 }
            );

            // Superhero 2: Spider-Man
            modelBuilder.Entity<Superhero>().HasData(
                new Superhero { Id = 2, Name = "Spider-Man" }
            );
            modelBuilder.Entity<Powerstats>().HasData(
                new Powerstats { Id = 2, Intelligence = 90, Strength = 55, Speed = 67, Durability = 75, Power = 74, Combat = 85, SuperheroId = 2 }
            );
            modelBuilder.Entity<Biography>().HasData(
                new Biography { Id = 2, FullName = "Peter Parker", AlterEgos = "No alter egos found.", Aliases = new List<string> { "Spiderman", "Bag-Man" }, PlaceOfBirth = "New York, New York", FirstAppearance = "Amazing Fantasy #15", Publisher = "Marvel Comics", Alignment = "good", SuperheroId = 2 }
            );
            modelBuilder.Entity<Appearance>().HasData(
                new Appearance { Id = 2, Gender = "Male", Race = "Human", Height = new List<string> { "5'10", "178 cm" }, Weight = new List<string> { "165 lb", "74 kg" }, EyeColor = "Hazel", HairColor = "Brown", SuperheroId = 2 }
            );
            modelBuilder.Entity<Work>().HasData(
                new Work { Id = 2, Occupation = "Freelance photographer, superhero", Base = "New York, New York", SuperheroId = 2 }
            );
            modelBuilder.Entity<Connections>().HasData(
                new Connections { Id = 2, GroupAffiliation = "Avengers, formerly Secret Defenders, \"New Fantastic Four\", the Outlaws", Relatives = "Richard Parker (father), Mary Parker (mother), Benjamin Parker (uncle, deceased), May Parker (aunt), Mary Jane Watson-Parker (wife)", SuperheroId = 2 }
            );
            modelBuilder.Entity<Image>().HasData(
                new Image { Id = 2, Url = "https://www.superherodb.com/pictures2/portraits/10/100/133.jpg", SuperheroId = 2 }
            );

            // Superhero 3: Iron Man
            modelBuilder.Entity<Superhero>().HasData(
                new Superhero { Id = 3, Name = "Iron Man" }
            );
            modelBuilder.Entity<Powerstats>().HasData(
                new Powerstats { Id = 3, Intelligence = 100, Strength = 85, Speed = 58, Durability = 85, Power = 100, Combat = 64, SuperheroId = 3 }
            );
            modelBuilder.Entity<Biography>().HasData(
                new Biography { Id = 3, FullName = "Tony Stark", AlterEgos = "No alter egos found.", Aliases = new List<string> { "Iron Knight", "The Golden Avenger" }, PlaceOfBirth = "Long Island, New York", FirstAppearance = "Tales of Suspense #39", Publisher = "Marvel Comics", Alignment = "good", SuperheroId = 3 }
            );
            modelBuilder.Entity<Appearance>().HasData(
                new Appearance { Id = 3, Gender = "Male", Race = "Human", Height = new List<string> { "6'6", "198 cm" }, Weight = new List<string> { "425 lb", "191 kg" }, EyeColor = "Blue", HairColor = "Black", SuperheroId = 3 }
            );
            modelBuilder.Entity<Work>().HasData(
                new Work { Id = 3, Occupation = "Inventor, Industrialist; former United States Secretary of Defense", Base = "Seattle, Washington", SuperheroId = 3 }
            );
            modelBuilder.Entity<Connections>().HasData(
                new Connections { Id = 3, GroupAffiliation = "Avengers, S.H.I.E.L.D., Stark Industries", Relatives = "Howard Stark (father), Maria Stark (mother), Morgan Stark (cousin)", SuperheroId = 3 }
            );
            modelBuilder.Entity<Image>().HasData(
                new Image { Id = 3, Url = "https://www.superherodb.com/pictures2/portraits/10/100/85.jpg", SuperheroId = 3 }
            );

            // Superhero 4: Wonder Woman
            modelBuilder.Entity<Superhero>().HasData(
                new Superhero { Id = 4, Name = "Wonder Woman" }
            );
            modelBuilder.Entity<Powerstats>().HasData(
                new Powerstats { Id = 4, Intelligence = 88, Strength = 100, Speed = 79, Durability = 100, Power = 100, Combat = 100, SuperheroId = 4 }
            );
            modelBuilder.Entity<Biography>().HasData(
                new Biography { Id = 4, FullName = "Diana Prince", AlterEgos = "No alter egos found.", Aliases = new List<string> { "Princess Diana" }, PlaceOfBirth = "Themyscira", FirstAppearance = "All-Star Comics #8", Publisher = "DC Comics", Alignment = "good", SuperheroId = 4 }
            );
            modelBuilder.Entity<Appearance>().HasData(
                new Appearance { Id = 4, Gender = "Female", Race = "Amazon", Height = new List<string> { "6'0", "183 cm" }, Weight = new List<string> { "165 lb", "75 kg" }, EyeColor = "Blue", HairColor = "Black", SuperheroId = 4 }
            );
            modelBuilder.Entity<Work>().HasData(
                new Work { Id = 4, Occupation = "Adventurer, Emissary to the world of Man, Protector of Paradise Island", Base = "Themyscira", SuperheroId = 4 }
            );
            modelBuilder.Entity<Connections>().HasData(
                new Connections { Id = 4, GroupAffiliation = "Justice League of America, Justice Society of America", Relatives = "Hippolyta (mother), Steve Trevor (love interest)", SuperheroId = 4 }
            );
            modelBuilder.Entity<Image>().HasData(
                new Image { Id = 4, Url = "https://www.superherodb.com/pictures2/portraits/10/100/807.jpg", SuperheroId = 4 }
            );

            // Superhero 5: Batman
            modelBuilder.Entity<Superhero>().HasData(
                new Superhero { Id = 5, Name = "Batman" }
            );
            modelBuilder.Entity<Powerstats>().HasData(
                new Powerstats { Id = 5, Intelligence = 100, Strength = 26, Speed = 27, Durability = 50, Power = 47, Combat = 100, SuperheroId = 5 }
            );
            modelBuilder.Entity<Biography>().HasData(
                new Biography { Id = 5, FullName = "Bruce Wayne", AlterEgos = "No alter egos found.", Aliases = new List<string> { "The Dark Knight", "The Caped Crusader" }, PlaceOfBirth = "Gotham City", FirstAppearance = "Detective Comics #27", Publisher = "DC Comics", Alignment = "good", SuperheroId = 5 }
            );
            modelBuilder.Entity<Appearance>().HasData(
                new Appearance { Id = 5, Gender = "Male", Race = "Human", Height = new List<string> { "6'2", "188 cm" }, Weight = new List<string> { "210 lb", "95 kg" }, EyeColor = "Blue", HairColor = "Black", SuperheroId = 5 }
            );
            modelBuilder.Entity<Work>().HasData(
                new Work { Id = 5, Occupation = "Businessman, CEO of Wayne Enterprises", Base = "Gotham City", SuperheroId = 5 }
            );
            modelBuilder.Entity<Connections>().HasData(
                new Connections { Id = 5, GroupAffiliation = "Justice League of America, Batman Family", Relatives = "Thomas Wayne (father), Martha Wayne (mother), Dick Grayson (adopted son), Jason Todd (adopted son), Tim Drake (adopted son), Damian Wayne (son)", SuperheroId = 5 }
            );
            modelBuilder.Entity<Image>().HasData(
                new Image { Id = 5, Url = "https://www.superherodb.com/pictures2/portraits/10/100/639.jpg", SuperheroId = 5 }
                    );
        }
    }
}