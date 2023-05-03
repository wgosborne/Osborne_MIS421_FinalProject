using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _521Final.Migrations
{
    public partial class changeduserbookid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBook_Book_BookId",
                table: "UserBook");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "UserBook",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_UserBook_BookId",
                table: "UserBook",
                newName: "IX_UserBook_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBook_Book_Id",
                table: "UserBook",
                column: "Id",
                principalTable: "Book",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserBook_Book_Id",
                table: "UserBook");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserBook",
                newName: "BookId");

            migrationBuilder.RenameIndex(
                name: "IX_UserBook_Id",
                table: "UserBook",
                newName: "IX_UserBook_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBook_Book_BookId",
                table: "UserBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id");
        }
    }
}
