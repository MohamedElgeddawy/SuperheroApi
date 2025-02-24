using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuperheroApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToFavorites : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FavoriteSuperheroes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteSuperheroes_UserId",
                table: "FavoriteSuperheroes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteSuperheroes_Users_UserId",
                table: "FavoriteSuperheroes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteSuperheroes_Users_UserId",
                table: "FavoriteSuperheroes");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteSuperheroes_UserId",
                table: "FavoriteSuperheroes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FavoriteSuperheroes");
        }
    }
}
