using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingApp.Data.Migrations
{
    public partial class add_sport_to_competitors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitor_Sports_SportId",
                table: "Competitor");

            migrationBuilder.DropIndex(
                name: "IX_Competitor_SportId",
                table: "Competitor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Competitor_SportId",
                table: "Competitor",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitor_Sports_SportId",
                table: "Competitor",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
