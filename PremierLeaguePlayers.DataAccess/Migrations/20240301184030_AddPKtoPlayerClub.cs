using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremierLeaguePlayers.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPKtoPlayerClub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PlayerClubs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerClubs",
                table: "PlayerClubs",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerClubs",
                table: "PlayerClubs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlayerClubs");
        }
    }
}
