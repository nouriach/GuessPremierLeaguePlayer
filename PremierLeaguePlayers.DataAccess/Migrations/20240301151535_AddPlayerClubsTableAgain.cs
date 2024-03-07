using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PremierLeaguePlayers.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerClubsTableAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerClub");

            migrationBuilder.AddColumn<int>(
                name: "ClubId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Players",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AbbreviatedName",
                table: "Clubs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShortName",
                table: "Clubs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PlayerClubs",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
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
                name: "IX_Players_ClubId",
                table: "Players",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_PlayerId",
                table: "Players",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerClubs_ClubId",
                table: "PlayerClubs",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerClubs_PlayerId",
                table: "PlayerClubs",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Clubs_ClubId",
                table: "Players",
                column: "ClubId",
                principalTable: "Clubs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Players_PlayerId",
                table: "Players",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Clubs_ClubId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Players_PlayerId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "PlayerClubs");

            migrationBuilder.DropIndex(
                name: "IX_Players_ClubId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_PlayerId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ClubId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "AbbreviatedName",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "ShortName",
                table: "Clubs");

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
    }
}
