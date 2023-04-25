using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _521Final.Data.Migrations
{
    public partial class GenreIDtoBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserBook",
                newName: "UserBookId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GenreBook",
                newName: "GenreBookId");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "UserBook",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserBook",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "GenreBook",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "GenreBook",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Genre",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Genre",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "BookPhoto",
                table: "Book",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserBook_BookId",
                table: "UserBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBook_UserId",
                table: "UserBook",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreBook_BookId",
                table: "GenreBook",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreBook_GenreId",
                table: "GenreBook",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_UserId",
                table: "Book",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_UserId1",
                table: "Book",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_User_UserId",
                table: "Book",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_User_UserId1",
                table: "Book",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreBook_Book_BookId",
                table: "GenreBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GenreBook_Genre_GenreId",
                table: "GenreBook",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBook_Book_BookId",
                table: "UserBook",
                column: "BookId",
                principalTable: "Book",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserBook_User_UserId",
                table: "UserBook",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_User_UserId",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_Book_User_UserId1",
                table: "Book");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreBook_Book_BookId",
                table: "GenreBook");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreBook_Genre_GenreId",
                table: "GenreBook");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBook_Book_BookId",
                table: "UserBook");

            migrationBuilder.DropForeignKey(
                name: "FK_UserBook_User_UserId",
                table: "UserBook");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_UserBook_BookId",
                table: "UserBook");

            migrationBuilder.DropIndex(
                name: "IX_UserBook_UserId",
                table: "UserBook");

            migrationBuilder.DropIndex(
                name: "IX_GenreBook_BookId",
                table: "GenreBook");

            migrationBuilder.DropIndex(
                name: "IX_GenreBook_GenreId",
                table: "GenreBook");

            migrationBuilder.DropIndex(
                name: "IX_Book_UserId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_UserId1",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "UserBook");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserBook");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "GenreBook");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "GenreBook");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "BookPhoto",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Book");

            migrationBuilder.RenameColumn(
                name: "UserBookId",
                table: "UserBook",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GenreBookId",
                table: "GenreBook",
                newName: "Id");
        }
    }
}
