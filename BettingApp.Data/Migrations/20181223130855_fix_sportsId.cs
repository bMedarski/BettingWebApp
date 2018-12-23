using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingApp.Data.Migrations
{
    public partial class fix_sportsId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SportId",
                table: "Competitor");

            migrationBuilder.DropColumn(
                name: "SportsId",
                table: "Competitor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "Competitor",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SportsId",
                table: "Competitor",
                nullable: true);
        }
    }
}
