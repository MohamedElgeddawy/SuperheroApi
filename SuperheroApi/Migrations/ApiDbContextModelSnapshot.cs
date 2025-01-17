﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperheroApi.Data;

#nullable disable

namespace SuperheroApi.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Appearance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EyeColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HairColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.PrimitiveCollection<string>("Height")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Race")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuperheroId")
                        .HasColumnType("int");

                    b.PrimitiveCollection<string>("Weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SuperheroId")
                        .IsUnique();

                    b.ToTable("Appearances");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EyeColor = "Yellow",
                            Gender = "Male",
                            HairColor = "No Hair",
                            Height = "[\"6\\u00278\",\"203 cm\"]",
                            Race = "Human",
                            SuperheroId = 1,
                            Weight = "[\"980 lb\",\"441 kg\"]"
                        },
                        new
                        {
                            Id = 2,
                            EyeColor = "Hazel",
                            Gender = "Male",
                            HairColor = "Brown",
                            Height = "[\"5\\u002710\",\"178 cm\"]",
                            Race = "Human",
                            SuperheroId = 2,
                            Weight = "[\"165 lb\",\"74 kg\"]"
                        },
                        new
                        {
                            Id = 3,
                            EyeColor = "Blue",
                            Gender = "Male",
                            HairColor = "Black",
                            Height = "[\"6\\u00276\",\"198 cm\"]",
                            Race = "Human",
                            SuperheroId = 3,
                            Weight = "[\"425 lb\",\"191 kg\"]"
                        },
                        new
                        {
                            Id = 4,
                            EyeColor = "Blue",
                            Gender = "Female",
                            HairColor = "Black",
                            Height = "[\"6\\u00270\",\"183 cm\"]",
                            Race = "Amazon",
                            SuperheroId = 4,
                            Weight = "[\"165 lb\",\"75 kg\"]"
                        },
                        new
                        {
                            Id = 5,
                            EyeColor = "Blue",
                            Gender = "Male",
                            HairColor = "Black",
                            Height = "[\"6\\u00272\",\"188 cm\"]",
                            Race = "Human",
                            SuperheroId = 5,
                            Weight = "[\"210 lb\",\"95 kg\"]"
                        });
                });

            modelBuilder.Entity("Biography", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.PrimitiveCollection<string>("Aliases")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Alignment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlterEgos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstAppearance")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlaceOfBirth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuperheroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SuperheroId")
                        .IsUnique();

                    b.ToTable("Biographies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Aliases = "[\"Rick Jones\"]",
                            Alignment = "good",
                            AlterEgos = "No alter egos found.",
                            FirstAppearance = "Hulk Vol 2 #2 (April, 2008) (as A-Bomb)",
                            FullName = "Richard Milhouse Jones",
                            PlaceOfBirth = "Scarsdale, Arizona",
                            Publisher = "Marvel Comics",
                            SuperheroId = 1
                        },
                        new
                        {
                            Id = 2,
                            Aliases = "[\"Spiderman\",\"Bag-Man\"]",
                            Alignment = "good",
                            AlterEgos = "No alter egos found.",
                            FirstAppearance = "Amazing Fantasy #15",
                            FullName = "Peter Parker",
                            PlaceOfBirth = "New York, New York",
                            Publisher = "Marvel Comics",
                            SuperheroId = 2
                        },
                        new
                        {
                            Id = 3,
                            Aliases = "[\"Iron Knight\",\"The Golden Avenger\"]",
                            Alignment = "good",
                            AlterEgos = "No alter egos found.",
                            FirstAppearance = "Tales of Suspense #39",
                            FullName = "Tony Stark",
                            PlaceOfBirth = "Long Island, New York",
                            Publisher = "Marvel Comics",
                            SuperheroId = 3
                        },
                        new
                        {
                            Id = 4,
                            Aliases = "[\"Princess Diana\"]",
                            Alignment = "good",
                            AlterEgos = "No alter egos found.",
                            FirstAppearance = "All-Star Comics #8",
                            FullName = "Diana Prince",
                            PlaceOfBirth = "Themyscira",
                            Publisher = "DC Comics",
                            SuperheroId = 4
                        },
                        new
                        {
                            Id = 5,
                            Aliases = "[\"The Dark Knight\",\"The Caped Crusader\"]",
                            Alignment = "good",
                            AlterEgos = "No alter egos found.",
                            FirstAppearance = "Detective Comics #27",
                            FullName = "Bruce Wayne",
                            PlaceOfBirth = "Gotham City",
                            Publisher = "DC Comics",
                            SuperheroId = 5
                        });
                });

            modelBuilder.Entity("Connections", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GroupAffiliation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relatives")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuperheroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SuperheroId")
                        .IsUnique();

                    b.ToTable("Connections");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GroupAffiliation = "Hulk Family; Excelsior (sponsor), Avengers (honorary member); formerly partner of the Hulk, Captain America and Captain Marvel; Teen Brigade; ally of Rom",
                            Relatives = "Marlo Chandler-Jones (wife); Polly (aunt); Mrs. Chandler (mother-in-law); Keith Chandler, Ray Chandler, three unidentified others (brothers-in-law); unidentified father (deceased); Jackie Shorr (alleged mother; unconfirmed)",
                            SuperheroId = 1
                        },
                        new
                        {
                            Id = 2,
                            GroupAffiliation = "Avengers, formerly Secret Defenders, \"New Fantastic Four\", the Outlaws",
                            Relatives = "Richard Parker (father), Mary Parker (mother), Benjamin Parker (uncle, deceased), May Parker (aunt), Mary Jane Watson-Parker (wife)",
                            SuperheroId = 2
                        },
                        new
                        {
                            Id = 3,
                            GroupAffiliation = "Avengers, S.H.I.E.L.D., Stark Industries",
                            Relatives = "Howard Stark (father), Maria Stark (mother), Morgan Stark (cousin)",
                            SuperheroId = 3
                        },
                        new
                        {
                            Id = 4,
                            GroupAffiliation = "Justice League of America, Justice Society of America",
                            Relatives = "Hippolyta (mother), Steve Trevor (love interest)",
                            SuperheroId = 4
                        },
                        new
                        {
                            Id = 5,
                            GroupAffiliation = "Justice League of America, Batman Family",
                            Relatives = "Thomas Wayne (father), Martha Wayne (mother), Dick Grayson (adopted son), Jason Todd (adopted son), Tim Drake (adopted son), Damian Wayne (son)",
                            SuperheroId = 5
                        });
                });

            modelBuilder.Entity("Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SuperheroId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SuperheroId")
                        .IsUnique();

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SuperheroId = 1,
                            Url = "https://www.superherodb.com/pictures2/portraits/10/100/10060.jpg"
                        },
                        new
                        {
                            Id = 2,
                            SuperheroId = 2,
                            Url = "https://www.superherodb.com/pictures2/portraits/10/100/133.jpg"
                        },
                        new
                        {
                            Id = 3,
                            SuperheroId = 3,
                            Url = "https://www.superherodb.com/pictures2/portraits/10/100/85.jpg"
                        },
                        new
                        {
                            Id = 4,
                            SuperheroId = 4,
                            Url = "https://www.superherodb.com/pictures2/portraits/10/100/807.jpg"
                        },
                        new
                        {
                            Id = 5,
                            SuperheroId = 5,
                            Url = "https://www.superherodb.com/pictures2/portraits/10/100/639.jpg"
                        });
                });

            modelBuilder.Entity("Powerstats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Combat")
                        .HasColumnType("int");

                    b.Property<int>("Durability")
                        .HasColumnType("int");

                    b.Property<int>("Intelligence")
                        .HasColumnType("int");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("Strength")
                        .HasColumnType("int");

                    b.Property<int>("SuperheroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SuperheroId")
                        .IsUnique();

                    b.ToTable("Powerstats");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Combat = 64,
                            Durability = 80,
                            Intelligence = 38,
                            Power = 24,
                            Speed = 17,
                            Strength = 100,
                            SuperheroId = 1
                        },
                        new
                        {
                            Id = 2,
                            Combat = 85,
                            Durability = 75,
                            Intelligence = 90,
                            Power = 74,
                            Speed = 67,
                            Strength = 55,
                            SuperheroId = 2
                        },
                        new
                        {
                            Id = 3,
                            Combat = 64,
                            Durability = 85,
                            Intelligence = 100,
                            Power = 100,
                            Speed = 58,
                            Strength = 85,
                            SuperheroId = 3
                        },
                        new
                        {
                            Id = 4,
                            Combat = 100,
                            Durability = 100,
                            Intelligence = 88,
                            Power = 100,
                            Speed = 79,
                            Strength = 100,
                            SuperheroId = 4
                        },
                        new
                        {
                            Id = 5,
                            Combat = 100,
                            Durability = 50,
                            Intelligence = 100,
                            Power = 47,
                            Speed = 27,
                            Strength = 26,
                            SuperheroId = 5
                        });
                });

            modelBuilder.Entity("Superhero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Superheroes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "A-Bomb"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Spider-Man"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Iron Man"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Wonder Woman"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Batman"
                        });
                });

            modelBuilder.Entity("SuperheroApi.Models.FavoriteSuperhero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SuperheroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SuperheroId");

                    b.ToTable("FavoriteSuperheroes");
                });

            modelBuilder.Entity("Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Base")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuperheroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SuperheroId")
                        .IsUnique();

                    b.ToTable("Works");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Base = "-",
                            Occupation = "Musician, adventurer, author; formerly talk show host",
                            SuperheroId = 1
                        },
                        new
                        {
                            Id = 2,
                            Base = "New York, New York",
                            Occupation = "Freelance photographer, superhero",
                            SuperheroId = 2
                        },
                        new
                        {
                            Id = 3,
                            Base = "Seattle, Washington",
                            Occupation = "Inventor, Industrialist; former United States Secretary of Defense",
                            SuperheroId = 3
                        },
                        new
                        {
                            Id = 4,
                            Base = "Themyscira",
                            Occupation = "Adventurer, Emissary to the world of Man, Protector of Paradise Island",
                            SuperheroId = 4
                        },
                        new
                        {
                            Id = 5,
                            Base = "Gotham City",
                            Occupation = "Businessman, CEO of Wayne Enterprises",
                            SuperheroId = 5
                        });
                });

            modelBuilder.Entity("Appearance", b =>
                {
                    b.HasOne("Superhero", "Superhero")
                        .WithOne("Appearance")
                        .HasForeignKey("Appearance", "SuperheroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Superhero");
                });

            modelBuilder.Entity("Biography", b =>
                {
                    b.HasOne("Superhero", "Superhero")
                        .WithOne("Biography")
                        .HasForeignKey("Biography", "SuperheroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Superhero");
                });

            modelBuilder.Entity("Connections", b =>
                {
                    b.HasOne("Superhero", "Superhero")
                        .WithOne("Connections")
                        .HasForeignKey("Connections", "SuperheroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Superhero");
                });

            modelBuilder.Entity("Image", b =>
                {
                    b.HasOne("Superhero", "Superhero")
                        .WithOne("Image")
                        .HasForeignKey("Image", "SuperheroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Superhero");
                });

            modelBuilder.Entity("Powerstats", b =>
                {
                    b.HasOne("Superhero", "Superhero")
                        .WithOne("Powerstats")
                        .HasForeignKey("Powerstats", "SuperheroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Superhero");
                });

            modelBuilder.Entity("SuperheroApi.Models.FavoriteSuperhero", b =>
                {
                    b.HasOne("Superhero", "Superhero")
                        .WithMany()
                        .HasForeignKey("SuperheroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Superhero");
                });

            modelBuilder.Entity("Work", b =>
                {
                    b.HasOne("Superhero", "Superhero")
                        .WithOne("Work")
                        .HasForeignKey("Work", "SuperheroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Superhero");
                });

            modelBuilder.Entity("Superhero", b =>
                {
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
