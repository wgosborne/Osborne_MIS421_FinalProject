using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _521Final.Migrations
{
    public partial class UpdatingUserBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "MyReview",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "userRating",
                table: "Book");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "UserBook",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "UserBook",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UserRating",
                table: "UserBook",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserReview",
                table: "UserBook",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "AvgRating",
                table: "Book",
                type: "float",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "UserBook");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "UserBook");

            migrationBuilder.DropColumn(
                name: "UserRating",
                table: "UserBook");

            migrationBuilder.DropColumn(
                name: "UserReview",
                table: "UserBook");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AvgRating",
                table: "Book",
                type: "int",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Book",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Book",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MyReview",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Book",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userRating",
                table: "Book",
                type: "int",
                nullable: true);
        }
    }
}
