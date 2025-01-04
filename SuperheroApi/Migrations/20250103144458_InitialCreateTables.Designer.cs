﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperheroApi.Data;

#nullable disable

namespace SuperheroApi.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    [Migration("20250103144458_InitialCreateTables")]
    partial class InitialCreateTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SuperheroApi.Models.Superhero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Superhero");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Iron Man"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Spider-Man"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Batman"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Superman"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Wonder Woman"
                        });
                });

            modelBuilder.Entity("SuperheroApi.Models.Superhero", b =>
                {
                    b.OwnsOne("SuperheroApi.Models.Appearance", "Appearance", b1 =>
                        {
                            b1.Property<int>("SuperheroId")
                                .HasColumnType("int");

                            b1.Property<string>("EyeColor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Gender")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("HairColor")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.PrimitiveCollection<string>("Height")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Race")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.PrimitiveCollection<string>("Weight")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SuperheroId");

                            b1.ToTable("Superhero");

                            b1.WithOwner()
                                .HasForeignKey("SuperheroId");

                            b1.HasData(
                                new
                                {
                                    SuperheroId = 1,
                                    EyeColor = "Blue",
                                    Gender = "Male",
                                    HairColor = "Black",
                                    Height = "[\"6\\u00276\",\"198 cm\"]",
                                    Race = "Human",
                                    Weight = "[\"425 lb\",\"193 kg\"]"
                                },
                                new
                                {
                                    SuperheroId = 2,
                                    EyeColor = "Hazel",
                                    Gender = "Male",
                                    HairColor = "Brown",
                                    Height = "[\"5\\u002710\",\"178 cm\"]",
                                    Race = "Human",
                                    Weight = "[\"167 lb\",\"76 kg\"]"
                                },
                                new
                                {
                                    SuperheroId = 3,
                                    EyeColor = "Blue",
                                    Gender = "Male",
                                    HairColor = "Black",
                                    Height = "[\"6\\u00272\",\"188 cm\"]",
                                    Race = "Human",
                                    Weight = "[\"210 lb\",\"95 kg\"]"
                                },
                                new
                                {
                                    SuperheroId = 4,
                                    EyeColor = "Blue",
                                    Gender = "Male",
                                    HairColor = "Black",
                                    Height = "[\"6\\u00273\",\"191 cm\"]",
                                    Race = "Kryptonian",
                                    Weight = "[\"235 lb\",\"107 kg\"]"
                                },
                                new
                                {
                                    SuperheroId = 5,
                                    EyeColor = "Blue",
                                    Gender = "Female",
                                    HairColor = "Black",
                                    Height = "[\"6\\u00270\",\"183 cm\"]",
                                    Race = "Amazon",
                                    Weight = "[\"165 lb\",\"75 kg\"]"
                                });
                        });

                    b.OwnsOne("SuperheroApi.Models.Biography", "Biography", b1 =>
                        {
                            b1.Property<int>("SuperheroId")
                                .HasColumnType("int");

                            b1.Property<string>("Alignment")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("AlterEgos")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("FirstAppearance")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("FullName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("PlaceOfBirth")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Publisher")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SuperheroId");

                            b1.ToTable("Superhero");

                            b1.WithOwner()
                                .HasForeignKey("SuperheroId");

                            b1.HasData(
                                new
                                {
                                    SuperheroId = 1,
                                    Alignment = "good",
                                    AlterEgos = "No alter egos found.",
                                    FirstAppearance = "Tales of Suspense #39 (March, 1963)",
                                    FullName = "Tony Stark",
                                    PlaceOfBirth = "Long Island, New York",
                                    Publisher = "Marvel Comics"
                                },
                                new
                                {
                                    SuperheroId = 2,
                                    Alignment = "good",
                                    AlterEgos = "No alter egos found.",
                                    FirstAppearance = "Amazing Fantasy #15 (August, 1962)",
                                    FullName = "Peter Parker",
                                    PlaceOfBirth = "New York, New York",
                                    Publisher = "Marvel Comics"
                                },
                                new
                                {
                                    SuperheroId = 3,
                                    Alignment = "good",
                                    AlterEgos = "No alter egos found.",
                                    FirstAppearance = "Detective Comics #27",
                                    FullName = "Bruce Wayne",
                                    PlaceOfBirth = "Crest Hill, Bristol Township; Gotham County",
                                    Publisher = "DC Comics"
                                },
                                new
                                {
                                    SuperheroId = 4,
                                    Alignment = "good",
                                    AlterEgos = "No alter egos found.",
                                    FirstAppearance = "Action Comics #1",
                                    FullName = "Clark Kent",
                                    PlaceOfBirth = "Krypton",
                                    Publisher = "DC Comics"
                                },
                                new
                                {
                                    SuperheroId = 5,
                                    Alignment = "good",
                                    AlterEgos = "No alter egos found.",
                                    FirstAppearance = "All Star Comics #8",
                                    FullName = "Diana Prince",
                                    PlaceOfBirth = "Themyscira",
                                    Publisher = "DC Comics"
                                });
                        });

                    b.OwnsOne("SuperheroApi.Models.Connections", "Connections", b1 =>
                        {
                            b1.Property<int>("SuperheroId")
                                .HasColumnType("int");

                            b1.Property<string>("GroupAffiliation")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Relatives")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SuperheroId");

                            b1.ToTable("Superhero");

                            b1.WithOwner()
                                .HasForeignKey("SuperheroId");

                            b1.HasData(
                                new
                                {
                                    SuperheroId = 1,
                                    GroupAffiliation = "Avengers",
                                    Relatives = "Howard Anthony Stark (father), Maria Collins Carbonell Stark (mother)"
                                },
                                new
                                {
                                    SuperheroId = 2,
                                    GroupAffiliation = "Avengers",
                                    Relatives = "Richard Parker (father), Mary Parker (mother)"
                                },
                                new
                                {
                                    SuperheroId = 3,
                                    GroupAffiliation = "Justice League",
                                    Relatives = "Thomas Wayne (father), Martha Wayne (mother)"
                                },
                                new
                                {
                                    SuperheroId = 4,
                                    GroupAffiliation = "Justice League",
                                    Relatives = "Jor-El (father), Lara Lor-Van (mother)"
                                },
                                new
                                {
                                    SuperheroId = 5,
                                    GroupAffiliation = "Justice League",
                                    Relatives = "Hippolyta (mother)"
                                });
                        });

                    b.OwnsOne("SuperheroApi.Models.Image", "Image", b1 =>
                        {
                            b1.Property<int>("SuperheroId")
                                .HasColumnType("int");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SuperheroId");

                            b1.ToTable("Superhero");

                            b1.WithOwner()
                                .HasForeignKey("SuperheroId");

                            b1.HasData(
                                new
                                {
                                    SuperheroId = 1,
                                    Url = "https://www.superherodb.com/pictures2/portraits/10/100/85.jpg"
                                },
                                new
                                {
                                    SuperheroId = 2,
                                    Url = "https://www.superherodb.com/pictures2/portraits/10/100/133.jpg"
                                },
                                new
                                {
                                    SuperheroId = 3,
                                    Url = "https://www.superherodb.com/pictures2/portraits/10/100/639.jpg"
                                },
                                new
                                {
                                    SuperheroId = 4,
                                    Url = "https://www.superherodb.com/pictures2/portraits/10/100/791.jpg"
                                },
                                new
                                {
                                    SuperheroId = 5,
                                    Url = "https://www.superherodb.com/pictures2/portraits/10/100/807.jpg"
                                });
                        });

                    b.OwnsOne("SuperheroApi.Models.Powerstats", "Powerstats", b1 =>
                        {
                            b1.Property<int>("SuperheroId")
                                .HasColumnType("int");

                            b1.Property<int>("Combat")
                                .HasColumnType("int");

                            b1.Property<int>("Durability")
                                .HasColumnType("int");

                            b1.Property<int>("Intelligence")
                                .HasColumnType("int");

                            b1.Property<int>("Power")
                                .HasColumnType("int");

                            b1.Property<int>("Speed")
                                .HasColumnType("int");

                            b1.Property<int>("Strength")
                                .HasColumnType("int");

                            b1.HasKey("SuperheroId");

                            b1.ToTable("Superhero");

                            b1.WithOwner()
                                .HasForeignKey("SuperheroId");

                            b1.HasData(
                                new
                                {
                                    SuperheroId = 1,
                                    Combat = 64,
                                    Durability = 85,
                                    Intelligence = 100,
                                    Power = 100,
                                    Speed = 58,
                                    Strength = 85
                                },
                                new
                                {
                                    SuperheroId = 2,
                                    Combat = 85,
                                    Durability = 75,
                                    Intelligence = 90,
                                    Power = 74,
                                    Speed = 67,
                                    Strength = 55
                                },
                                new
                                {
                                    SuperheroId = 3,
                                    Combat = 100,
                                    Durability = 50,
                                    Intelligence = 100,
                                    Power = 47,
                                    Speed = 27,
                                    Strength = 26
                                },
                                new
                                {
                                    SuperheroId = 4,
                                    Combat = 85,
                                    Durability = 100,
                                    Intelligence = 94,
                                    Power = 100,
                                    Speed = 100,
                                    Strength = 100
                                },
                                new
                                {
                                    SuperheroId = 5,
                                    Combat = 100,
                                    Durability = 100,
                                    Intelligence = 88,
                                    Power = 100,
                                    Speed = 79,
                                    Strength = 100
                                });
                        });

                    b.OwnsOne("SuperheroApi.Models.Work", "Work", b1 =>
                        {
                            b1.Property<int>("SuperheroId")
                                .HasColumnType("int");

                            b1.Property<string>("Base")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Occupation")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SuperheroId");

                            b1.ToTable("Superhero");

                            b1.WithOwner()
                                .HasForeignKey("SuperheroId");

                            b1.HasData(
                                new
                                {
                                    SuperheroId = 1,
                                    Base = "Seattle, Washington",
                                    Occupation = "Inventor, Industrialist"
                                },
                                new
                                {
                                    SuperheroId = 2,
                                    Base = "New York, New York",
                                    Occupation = "Photographer"
                                },
                                new
                                {
                                    SuperheroId = 3,
                                    Base = "Gotham City",
                                    Occupation = "Businessman"
                                },
                                new
                                {
                                    SuperheroId = 4,
                                    Base = "Metropolis",
                                    Occupation = "Reporter"
                                },
                                new
                                {
                                    SuperheroId = 5,
                                    Base = "Themyscira",
                                    Occupation = "Warrior"
                                });
                        });

                    b.Navigation("Appearance")
                        .IsRequired();

                    b.Navigation("Biography")
                        .IsRequired();

                    b.Navigation("Connections")
                        .IsRequired();

                    b.Navigation("Image")
                        .IsRequired();

                    b.Navigation("Powerstats")
                        .IsRequired();

                    b.Navigation("Work")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}