using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingApp.Data.Migrations
{
    public partial class addpositionsandreworkplayerandteam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Competitor");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Competitor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Competitor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Competitor",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Competitor",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Competitor",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoUrl",
                table: "Competitor",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    SportId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Position_Sports_SportId",
                        column: x => x.SportId,
                        principalTable: "Sports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitor_PositionId",
                table: "Competitor",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Position_SportId",
                table: "Position",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitor_Position_PositionId",
                table: "Competitor",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitor_Position_PositionId",
                table: "Competitor");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropIndex(
                name: "IX_Competitor_PositionId",
                table: "Competitor");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Competitor");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Competitor");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Competitor");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Competitor");

            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Competitor");

            migrationBuilder.DropColumn(
                name: "LogoUrl",
                table: "Competitor");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Competitor",
                nullable: true);
        }
    }
}
