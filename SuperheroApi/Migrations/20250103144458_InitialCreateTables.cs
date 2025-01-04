using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperheroApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Superhero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Powerstats_Intelligence = table.Column<int>(type: "int", nullable: false),
                    Powerstats_Strength = table.Column<int>(type: "int", nullable: false),
                    Powerstats_Speed = table.Column<int>(type: "int", nullable: false),
                    Powerstats_Durability = table.Column<int>(type: "int", nullable: false),
                    Powerstats_Power = table.Column<int>(type: "int", nullable: false),
                    Powerstats_Combat = table.Column<int>(type: "int", nullable: false),
                    Biography_FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography_AlterEgos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography_PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography_FirstAppearance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography_Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Biography_Alignment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Appearance_Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Appearance_Race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Appearance_Height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Appearance_Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Appearance_EyeColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Appearance_HairColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Work_Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Work_Base = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Connections_GroupAffiliation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Connections_Relatives = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image_Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superhero", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Superhero",
                columns: new[] { "Id", "Appearance_EyeColor", "Appearance_Gender", "Appearance_HairColor", "Appearance_Height", "Appearance_Race", "Appearance_Weight", "Biography_Alignment", "Biography_AlterEgos", "Biography_FirstAppearance", "Biography_FullName", "Biography_PlaceOfBirth", "Biography_Publisher", "Connections_GroupAffiliation", "Connections_Relatives", "Image_Url", "Powerstats_Combat", "Powerstats_Durability", "Powerstats_Intelligence", "Powerstats_Power", "Powerstats_Speed", "Powerstats_Strength", "Name", "Work_Base", "Work_Occupation" },
                values: new object[,]
                {
                    { 1, "Blue", "Male", "Black", "[\"6\\u00276\",\"198 cm\"]", "Human", "[\"425 lb\",\"193 kg\"]", "good", "No alter egos found.", "Tales of Suspense #39 (March, 1963)", "Tony Stark", "Long Island, New York", "Marvel Comics", "Avengers", "Howard Anthony Stark (father), Maria Collins Carbonell Stark (mother)", "https://www.superherodb.com/pictures2/portraits/10/100/85.jpg", 64, 85, 100, 100, 58, 85, "Iron Man", "Seattle, Washington", "Inventor, Industrialist" },
                    { 2, "Hazel", "Male", "Brown", "[\"5\\u002710\",\"178 cm\"]", "Human", "[\"167 lb\",\"76 kg\"]", "good", "No alter egos found.", "Amazing Fantasy #15 (August, 1962)", "Peter Parker", "New York, New York", "Marvel Comics", "Avengers", "Richard Parker (father), Mary Parker (mother)", "https://www.superherodb.com/pictures2/portraits/10/100/133.jpg", 85, 75, 90, 74, 67, 55, "Spider-Man", "New York, New York", "Photographer" },
                    { 3, "Blue", "Male", "Black", "[\"6\\u00272\",\"188 cm\"]", "Human", "[\"210 lb\",\"95 kg\"]", "good", "No alter egos found.", "Detective Comics #27", "Bruce Wayne", "Crest Hill, Bristol Township; Gotham County", "DC Comics", "Justice League", "Thomas Wayne (father), Martha Wayne (mother)", "https://www.superherodb.com/pictures2/portraits/10/100/639.jpg", 100, 50, 100, 47, 27, 26, "Batman", "Gotham City", "Businessman" },
                    { 4, "Blue", "Male", "Black", "[\"6\\u00273\",\"191 cm\"]", "Kryptonian", "[\"235 lb\",\"107 kg\"]", "good", "No alter egos found.", "Action Comics #1", "Clark Kent", "Krypton", "DC Comics", "Justice League", "Jor-El (father), Lara Lor-Van (mother)", "https://www.superherodb.com/pictures2/portraits/10/100/791.jpg", 85, 100, 94, 100, 100, 100, "Superman", "Metropolis", "Reporter" },
                    { 5, "Blue", "Female", "Black", "[\"6\\u00270\",\"183 cm\"]", "Amazon", "[\"165 lb\",\"75 kg\"]", "good", "No alter egos found.", "All Star Comics #8", "Diana Prince", "Themyscira", "DC Comics", "Justice League", "Hippolyta (mother)", "https://www.superherodb.com/pictures2/portraits/10/100/807.jpg", 100, 100, 88, 100, 79, 100, "Wonder Woman", "Themyscira", "Warrior" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Superhero");
        }
    }
}
