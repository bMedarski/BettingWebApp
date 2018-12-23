using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingApp.Data.Migrations
{
    public partial class add_sport_to_competitorss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SportId",
                table: "Competitor",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "SportsId",
                table: "Competitor",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SportsId",
                table: "Competitor");

            migrationBuilder.AlterColumn<int>(
                name: "SportId",
                table: "Competitor",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
