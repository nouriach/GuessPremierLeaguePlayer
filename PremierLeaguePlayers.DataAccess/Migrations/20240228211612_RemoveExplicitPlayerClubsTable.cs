using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremierLeaguePlayers.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemoveExplicitPlayerClubsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerClubs");

            migrationBuilder.CreateTable(
                name: "PlayerClub",
                columns: table => new
                {
                    ClubsId = table.Column<int>(type: "int", nullable: false),
                    PlayersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerClub", x => new { x.ClubsId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_PlayerClub_Clubs_ClubsId",
                        column: x => x.ClubsId,
                        principalTable: "Clubs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerClub_Players_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerClub_PlayersId",
                table: "PlayerClub",
                column: "PlayersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerClub");

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
    }
}
