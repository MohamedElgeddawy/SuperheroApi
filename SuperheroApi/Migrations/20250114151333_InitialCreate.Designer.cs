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
    [Migration("20250114151333_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
