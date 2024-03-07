using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremierLeaguePlayers.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangePlayerClubsToManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clubs_Players_PlayerId",
                table: "Clubs");

            migrationBuilder.DropIndex(
                name: "IX_Clubs_PlayerId",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Clubs");

            migrationBuilder.CreateTable(
                name: "PlayerClubs",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerClubs", x => new { x.PlayerId, x.ClubId });
                    table.ForeignKey(
                        name: "FK_PlayerClubs_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerClubs_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerClubs_ClubId",
                table: "PlayerClubs",
                column: "ClubId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerClubs");

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Clubs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clubs_PlayerId",
                table: "Clubs",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clubs_Players_PlayerId",
                table: "Clubs",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
