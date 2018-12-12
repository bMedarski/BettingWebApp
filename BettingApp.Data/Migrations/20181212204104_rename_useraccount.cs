using Microsoft.EntityFrameworkCore.Migrations;

namespace BettingApp.Data.Migrations
{
    public partial class rename_useraccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserAccounts_AccountId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "AspNetUsers",
                newName: "UserAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_AccountId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserAccounts_UserAccountId",
                table: "AspNetUsers",
                column: "UserAccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserAccounts_UserAccountId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserAccountId",
                table: "AspNetUsers",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUsers_UserAccountId",
                table: "AspNetUsers",
                newName: "IX_AspNetUsers_AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserAccounts_AccountId",
                table: "AspNetUsers",
                column: "AccountId",
                principalTable: "UserAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
