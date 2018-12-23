using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingApp.Data.Migrations
{
    public partial class add_sport_to_player_and_team : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "Competitor",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Team_SportId",
                table: "Competitor",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competitor_SportId",
                table: "Competitor",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitor_Team_SportId",
                table: "Competitor",
                column: "Team_SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitor_Sports_SportId",
                table: "Competitor",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Competitor_Sports_Team_SportId",
                table: "Competitor",
                column: "Team_SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitor_Sports_SportId",
                table: "Competitor");

            migrationBuilder.DropForeignKey(
                name: "FK_Competitor_Sports_Team_SportId",
                table: "Competitor");

            migrationBuilder.DropIndex(
                name: "IX_Competitor_SportId",
                table: "Competitor");

            migrationBuilder.DropIndex(
                name: "IX_Competitor_Team_SportId",
                table: "Competitor");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "Competitor");

            migrationBuilder.DropColumn(
                name: "Team_SportId",
                table: "Competitor");
        }
    }
}
