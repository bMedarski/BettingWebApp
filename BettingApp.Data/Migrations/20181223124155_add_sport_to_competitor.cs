using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingApp.Data.Migrations
{
    public partial class add_sport_to_competitor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitor_Sports_Team_SportId",
                table: "Competitor");

            migrationBuilder.DropIndex(
                name: "IX_Competitor_Team_SportId",
                table: "Competitor");

            migrationBuilder.DropColumn(
                name: "Team_SportId",
                table: "Competitor");

            migrationBuilder.AlterColumn<int>(
                name: "SportId",
                table: "Competitor",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SportId",
                table: "Competitor",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Team_SportId",
                table: "Competitor",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competitor_Team_SportId",
                table: "Competitor",
                column: "Team_SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitor_Sports_Team_SportId",
                table: "Competitor",
                column: "Team_SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
