using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingApp.Data.Migrations
{
    public partial class addsports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "Seasons",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SportId",
                table: "Seasons",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Sports_SportId",
                table: "Seasons",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Sports_SportId",
                table: "Seasons");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_SportId",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "Seasons");
        }
    }
}
