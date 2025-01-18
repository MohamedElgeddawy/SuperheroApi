using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperheroApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Superheroes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Spider-Man" },
                    { 3, "Iron Man" },
                    { 4, "Wonder Woman" },
                    { 5, "Batman" }
                });

            migrationBuilder.InsertData(
                table: "Appearances",
                columns: new[] { "Id", "EyeColor", "Gender", "HairColor", "Height", "Race", "SuperheroId", "Weight" },
                values: new object[,]
                {
                    { 2, "Hazel", "Male", "Brown", "[\"5\\u002710\",\"178 cm\"]", "Human", 2, "[\"165 lb\",\"74 kg\"]" },
                    { 3, "Blue", "Male", "Black", "[\"6\\u00276\",\"198 cm\"]", "Human", 3, "[\"425 lb\",\"191 kg\"]" },
                    { 4, "Blue", "Female", "Black", "[\"6\\u00270\",\"183 cm\"]", "Amazon", 4, "[\"165 lb\",\"75 kg\"]" },
                    { 5, "Blue", "Male", "Black", "[\"6\\u00272\",\"188 cm\"]", "Human", 5, "[\"210 lb\",\"95 kg\"]" }
                });

            migrationBuilder.InsertData(
                table: "Biographies",
                columns: new[] { "Id", "Aliases", "Alignment", "AlterEgos", "FirstAppearance", "FullName", "PlaceOfBirth", "Publisher", "SuperheroId" },
                values: new object[,]
                {
                    { 2, "[\"Spiderman\",\"Bag-Man\"]", "good", "No alter egos found.", "Amazing Fantasy #15", "Peter Parker", "New York, New York", "Marvel Comics", 2 },
                    { 3, "[\"Iron Knight\",\"The Golden Avenger\"]", "good", "No alter egos found.", "Tales of Suspense #39", "Tony Stark", "Long Island, New York", "Marvel Comics", 3 },
                    { 4, "[\"Princess Diana\"]", "good", "No alter egos found.", "All-Star Comics #8", "Diana Prince", "Themyscira", "DC Comics", 4 },
                    { 5, "[\"The Dark Knight\",\"The Caped Crusader\"]", "good", "No alter egos found.", "Detective Comics #27", "Bruce Wayne", "Gotham City", "DC Comics", 5 }
                });

            migrationBuilder.InsertData(
                table: "Connections",
                columns: new[] { "Id", "GroupAffiliation", "Relatives", "SuperheroId" },
                values: new object[,]
                {
                    { 2, "Avengers, formerly Secret Defenders, \"New Fantastic Four\", the Outlaws", "Richard Parker (father), Mary Parker (mother), Benjamin Parker (uncle, deceased), May Parker (aunt), Mary Jane Watson-Parker (wife)", 2 },
                    { 3, "Avengers, S.H.I.E.L.D., Stark Industries", "Howard Stark (father), Maria Stark (mother), Morgan Stark (cousin)", 3 },
                    { 4, "Justice League of America, Justice Society of America", "Hippolyta (mother), Steve Trevor (love interest)", 4 },
                    { 5, "Justice League of America, Batman Family", "Thomas Wayne (father), Martha Wayne (mother), Dick Grayson (adopted son), Jason Todd (adopted son), Tim Drake (adopted son), Damian Wayne (son)", 5 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "SuperheroId", "Url" },
                values: new object[,]
                {
                    { 2, 2, "https://www.superherodb.com/pictures2/portraits/10/100/133.jpg" },
                    { 3, 3, "https://www.superherodb.com/pictures2/portraits/10/100/85.jpg" },
                    { 4, 4, "https://www.superherodb.com/pictures2/portraits/10/100/807.jpg" },
                    { 5, 5, "https://www.superherodb.com/pictures2/portraits/10/100/639.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Powerstats",
                columns: new[] { "Id", "Combat", "Durability", "Intelligence", "Power", "Speed", "Strength", "SuperheroId" },
                values: new object[,]
                {
                    { 2, 85, 75, 90, 74, 67, 55, 2 },
                    { 3, 64, 85, 100, 100, 58, 85, 3 },
                    { 4, 100, 100, 88, 100, 79, 100, 4 },
                    { 5, 100, 50, 100, 47, 27, 26, 5 }
                });

            migrationBuilder.InsertData(
                table: "Works",
                columns: new[] { "Id", "Base", "Occupation", "SuperheroId" },
                values: new object[,]
                {
                    { 2, "New York, New York", "Freelance photographer, superhero", 2 },
                    { 3, "Seattle, Washington", "Inventor, Industrialist; former United States Secretary of Defense", 3 },
                    { 4, "Themyscira", "Adventurer, Emissary to the world of Man, Protector of Paradise Island", 4 },
                    { 5, "Gotham City", "Businessman, CEO of Wayne Enterprises", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appearances",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appearances",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Appearances",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Appearances",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Biographies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Connections",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Connections",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Connections",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Connections",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Powerstats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Powerstats",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Powerstats",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Powerstats",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Works",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Superheroes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Superheroes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Superheroes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Superheroes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
