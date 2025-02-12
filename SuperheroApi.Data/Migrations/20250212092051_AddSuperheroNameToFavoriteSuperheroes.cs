using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperheroApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSuperheroNameToFavoriteSuperheroes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SuperheroName",
                table: "FavoriteSuperheroes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SuperheroName",
                table: "FavoriteSuperheroes");
        }
    }
}
