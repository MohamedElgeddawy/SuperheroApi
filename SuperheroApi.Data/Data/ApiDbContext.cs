using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SuperheroApi.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using SuperheroApi.Core.Models.Superhero;
using SuperheroApi.Core.Models;

namespace SuperheroApi.Data.Data
{
    // Represents the database context for the application
    public class ApiDbContext : IdentityDbContext<AppUser>
    {
        // DbSet properties represent collections of the specified entity types in the database
        public DbSet<Superhero> Superheroes { get; set; }
        public DbSet<FavoriteSuperhero> FavoriteSuperheroes { get; set; }


        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optional: Customize Identity table names if needed
            modelBuilder.Entity<AppUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");

            modelBuilder.Entity<FavoriteSuperhero>()
                .HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Mark nested models as owned types
            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Powerstats).HasData(
                new { SuperheroId = 1, Intelligence = "38", Strength = "100", Speed = "17", Durability = "80", Power = "24", Combat = "64" }
            );

            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Biography).HasData(
                new { SuperheroId = 1, FullName = "Richard Milhouse Jones", AlterEgos = "No alter egos found.", AliasesJson = "[\"Rick Jones\"]", PlaceOfBirth = "Scarsdale, Arizona", FirstAppearance = "Hulk Vol 2 #2 (April, 2008)", Publisher = "Marvel Comics", Alignment = "good" }
            );

            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Appearance).HasData(
                new { SuperheroId = 1, Gender = "Male", Race = "Human", Height = "6'8, 203 cm", Weight = "980 lb, 441 kg", EyeColor = "Yellow", HairColor = "No Hair" }
            );

            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Work).HasData(
                new { SuperheroId = 1, Occupation = "Musician, adventurer, author; formerly talk show host", Base = "-" }
            );

            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Connections).HasData(
                new
                {
                    SuperheroId = 1,
                    GroupAffiliation = "Hulk Family; Excelsior (sponsor), Avengers (honorary member)",
                    Relatives = "Marlo Chandler-Jones (wife); Polly (aunt)"
                }
            );

            modelBuilder.Entity<Superhero>().OwnsOne(s => s.Image).HasData(
                new { SuperheroId = 1, Url = "https://www.superherodb.com/pictures2/portraits/10/100/10060.jpg" }
            );

            // Seed only basic Superhero info (NO NAVIGATION PROPERTIES)
            modelBuilder.Entity<Superhero>().HasData(
                new { Id = 1, Name = "A-Bomb", Response = "success" }
            );
        }

    }
        
    
    
}