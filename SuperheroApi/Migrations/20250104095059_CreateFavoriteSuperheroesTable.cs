using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperheroApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateFavoriteSuperheroesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Superhero",
                table: "Superhero");

            migrationBuilder.RenameTable(
                name: "Superhero",
                newName: "Superheroes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Superheroes",
                table: "Superheroes",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteSuperheroes_SuperheroId",
                table: "FavoriteSuperheroes",
                column: "SuperheroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteSuperheroes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Superheroes",
                table: "Superheroes");

            migrationBuilder.RenameTable(
                name: "Superheroes",
                newName: "Superhero");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Superhero",
                table: "Superhero",
                column: "Id");
        }
    }
}
