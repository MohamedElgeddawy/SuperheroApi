﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperheroApi.Data.Data;

#nullable disable

namespace SuperheroApi.Data.Migrations
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SuperheroApi.Core.Models.Superhero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Response")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Superheroes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "A-Bomb",
                            Response = "success"
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SuperheroApi.Core.Models.Superhero", b =>
                {
                    b.OwnsOne("SuperheroApi.Core.Models.Appearance", "Appearance", b1 =>
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

                            b1.Property<string>("Height")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Race")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Weight")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SuperheroId");

                            b1.ToTable("Superheroes");

                            b1.WithOwner()
                                .HasForeignKey("SuperheroId");

                            b1.HasData(
                                new
                                {
                                    SuperheroId = 1,
                                    EyeColor = "Yellow",
                                    Gender = "Male",
                                    HairColor = "No Hair",
                                    Height = "6'8, 203 cm",
                                    Race = "Human",
                                    Weight = "980 lb, 441 kg"
                                });
                        });

                    b.OwnsOne("SuperheroApi.Core.Models.Biography", "Biography", b1 =>
                        {
                            b1.Property<int>("SuperheroId")
                                .HasColumnType("int");

                            b1.Property<string>("AliasesJson")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

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

                            b1.ToTable("Superheroes");

                            b1.WithOwner()
                                .HasForeignKey("SuperheroId");

                            b1.HasData(
                                new
                                {
                                    SuperheroId = 1,
                                    AliasesJson = "[\"Rick Jones\"]",
                                    Alignment = "good",
                                    AlterEgos = "No alter egos found.",
                                    FirstAppearance = "Hulk Vol 2 #2 (April, 2008)",
                                    FullName = "Richard Milhouse Jones",
                                    PlaceOfBirth = "Scarsdale, Arizona",
                                    Publisher = "Marvel Comics"
                                });
                        });

                    b.OwnsOne("SuperheroApi.Core.Models.Connections", "Connections", b1 =>
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

                            b1.ToTable("Superheroes");

                            b1.WithOwner()
                                .HasForeignKey("SuperheroId");

                            b1.HasData(
                                new
                                {
                                    SuperheroId = 1,
                                    GroupAffiliation = "Hulk Family; Excelsior (sponsor), Avengers (honorary member)",
                                    Relatives = "Marlo Chandler-Jones (wife); Polly (aunt)"
                                });
                        });

                    b.OwnsOne("SuperheroApi.Core.Models.Image", "Image", b1 =>
                        {
                            b1.Property<int>("SuperheroId")
                                .HasColumnType("int");

                            b1.Property<string>("Url")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SuperheroId");

                            b1.ToTable("Superheroes");

                            b1.WithOwner()
                                .HasForeignKey("SuperheroId");

                            b1.HasData(
                                new
                                {
                                    SuperheroId = 1,
                                    Url = "https://www.superherodb.com/pictures2/portraits/10/100/10060.jpg"
                                });
                        });

                    b.OwnsOne("SuperheroApi.Core.Models.PowerStats", "Powerstats", b1 =>
                        {
                            b1.Property<int>("SuperheroId")
                                .HasColumnType("int");

                            b1.Property<string>("Combat")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Durability")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Intelligence")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Power")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Speed")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Strength")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("SuperheroId");

                            b1.ToTable("Superheroes");

                            b1.WithOwner()
                                .HasForeignKey("SuperheroId");

                            b1.HasData(
                                new
                                {
                                    SuperheroId = 1,
                                    Combat = "64",
                                    Durability = "80",
                                    Intelligence = "38",
                                    Power = "24",
                                    Speed = "17",
                                    Strength = "100"
                                });
                        });

                    b.OwnsOne("SuperheroApi.Core.Models.Work", "Work", b1 =>
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

                            b1.ToTable("Superheroes");

                            b1.WithOwner()
                                .HasForeignKey("SuperheroId");

                            b1.HasData(
                                new
                                {
                                    SuperheroId = 1,
                                    Base = "-",
                                    Occupation = "Musician, adventurer, author; formerly talk show host"
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

            modelBuilder.Entity("SuperheroApi.Models.FavoriteSuperhero", b =>
                {
                    b.HasOne("SuperheroApi.Core.Models.Superhero", "Superhero")
                        .WithMany()
                        .HasForeignKey("SuperheroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Superhero");
                });
#pragma warning restore 612, 618
        }
    }
}
