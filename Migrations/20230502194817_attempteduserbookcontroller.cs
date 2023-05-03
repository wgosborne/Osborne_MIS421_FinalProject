using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _521Final.Migrations
{
    public partial class attempteduserbookcontroller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBook_AspNetUsers_ApplicationUser",
                table: "UserBook");

            migrationBuilder.DropIndex(
                name: "IX_UserBook_ApplicationUser",
                table: "UserBook");

            migrationBuilder.DropColumn(
                name: "ApplicationUser",
                table: "UserBook");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserBook",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserBook");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUser",
                table: "UserBook",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserBook_ApplicationUser",
                table: "UserBook",
                column: "ApplicationUser");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBook_AspNetUsers_ApplicationUser",
                table: "UserBook",
                column: "ApplicationUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
