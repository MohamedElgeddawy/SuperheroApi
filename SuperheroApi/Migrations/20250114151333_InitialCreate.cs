using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperheroApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Superheroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superheroes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Appearances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EyeColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HairColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuperheroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appearances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appearances_Superheroes_SuperheroId",
                        column: x => x.SuperheroId,
                        principalTable: "Superheroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Biographies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AlterEgos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aliases = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstAppearance = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alignment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuperheroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Biographies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Biographies_Superheroes_SuperheroId",
                        column: x => x.SuperheroId,
                        principalTable: "Superheroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupAffiliation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Relatives = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuperheroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Connections_Superheroes_SuperheroId",
                        column: x => x.SuperheroId,
                        principalTable: "Superheroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteSuperheroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SuperheroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteSuperheroes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteSuperheroes_Superheroes_SuperheroId",
                        column: x => x.SuperheroId,
                        principalTable: "Superheroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuperheroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Superheroes_SuperheroId",
                        column: x => x.SuperheroId,
                        principalTable: "Superheroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Powerstats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Durability = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    Combat = table.Column<int>(type: "int", nullable: false),
                    SuperheroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Powerstats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Powerstats_Superheroes_SuperheroId",
                        column: x => x.SuperheroId,
                        principalTable: "Superheroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Base = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuperheroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Works_Superheroes_SuperheroId",
                        column: x => x.SuperheroId,
                        principalTable: "Superheroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Superheroes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "A-Bomb" });

            migrationBuilder.InsertData(
                table: "Appearances",
                columns: new[] { "Id", "EyeColor", "Gender", "HairColor", "Height", "Race", "SuperheroId", "Weight" },
                values: new object[] { 1, "Yellow", "Male", "No Hair", "[\"6\\u00278\",\"203 cm\"]", "Human", 1, "[\"980 lb\",\"441 kg\"]" });

            migrationBuilder.InsertData(
                table: "Biographies",
                columns: new[] { "Id", "Aliases", "Alignment", "AlterEgos", "FirstAppearance", "FullName", "PlaceOfBirth", "Publisher", "SuperheroId" },
                values: new object[] { 1, "[\"Rick Jones\"]", "good", "No alter egos found.", "Hulk Vol 2 #2 (April, 2008) (as A-Bomb)", "Richard Milhouse Jones", "Scarsdale, Arizona", "Marvel Comics", 1 });

            migrationBuilder.InsertData(
                table: "Connections",
                columns: new[] { "Id", "GroupAffiliation", "Relatives", "SuperheroId" },
                values: new object[] { 1, "Hulk Family; Excelsior (sponsor), Avengers (honorary member); formerly partner of the Hulk, Captain America and Captain Marvel; Teen Brigade; ally of Rom", "Marlo Chandler-Jones (wife); Polly (aunt); Mrs. Chandler (mother-in-law); Keith Chandler, Ray Chandler, three unidentified others (brothers-in-law); unidentified father (deceased); Jackie Shorr (alleged mother; unconfirmed)", 1 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "SuperheroId", "Url" },
                values: new object[] { 1, 1, "https://www.superherodb.com/pictures2/portraits/10/100/10060.jpg" });

            migrationBuilder.InsertData(
                table: "Powerstats",
                columns: new[] { "Id", "Combat", "Durability", "Intelligence", "Power", "Speed", "Strength", "SuperheroId" },
                values: new object[] { 1, 64, 80, 38, 24, 17, 100, 1 });

            migrationBuilder.InsertData(
                table: "Works",
                columns: new[] { "Id", "Base", "Occupation", "SuperheroId" },
                values: new object[] { 1, "-", "Musician, adventurer, author; formerly talk show host", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Appearances_SuperheroId",
                table: "Appearances",
                column: "SuperheroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Biographies_SuperheroId",
                table: "Biographies",
                column: "SuperheroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Connections_SuperheroId",
                table: "Connections",
                column: "SuperheroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteSuperheroes_SuperheroId",
                table: "FavoriteSuperheroes",
                column: "SuperheroId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_SuperheroId",
                table: "Images",
                column: "SuperheroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Powerstats_SuperheroId",
                table: "Powerstats",
                column: "SuperheroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Works_SuperheroId",
                table: "Works",
                column: "SuperheroId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appearances");

            migrationBuilder.DropTable(
                name: "Biographies");

            migrationBuilder.DropTable(
                name: "Connections");

            migrationBuilder.DropTable(
                name: "FavoriteSuperheroes");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Powerstats");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Superheroes");
        }
    }
}
