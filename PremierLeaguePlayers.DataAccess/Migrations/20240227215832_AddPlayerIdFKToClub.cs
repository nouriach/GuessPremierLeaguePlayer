using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremierLeaguePlayers.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerIdFKToClub : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Players_PlayerId",
                table: "Clubs");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Clubs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Players_PlayerId",
                table: "Clubs",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Players_PlayerId",
                table: "Clubs");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Clubs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Players_PlayerId",
                table: "Clubs",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
