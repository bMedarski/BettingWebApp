using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingApp.Data.Migrations
{
    public partial class somenewentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Seasons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    CompetitionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<int>(nullable: false),
                    CurrentSeasonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitions_Seasons_CurrentSeasonId",
                        column: x => x.CurrentSeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Competitor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    SeasonId = table.Column<int>(nullable: true),
                    Position = table.Column<int>(nullable: true),
                    TeamId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitor_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Competitor_Competitor_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Competitor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CurrentSeasonId",
                table: "Competitions",
                column: "CurrentSeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitor_SeasonId",
                table: "Competitor",
                column: "SeasonId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitor_TeamId",
                table: "Competitor",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_CompetitionId",
                table: "Seasons",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Competitions_CompetitionId",
                table: "Seasons",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competitions_Seasons_CurrentSeasonId",
                table: "Competitions");

            migrationBuilder.DropTable(
                name: "Competitor");

            migrationBuilder.DropTable(
                name: "Seasons");

            migrationBuilder.DropTable(
                name: "Competitions");
        }
    }
}
