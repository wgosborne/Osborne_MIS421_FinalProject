using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _521Final.Migrations
{
    public partial class addedSummaryField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Book",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Book");
        }
    }
}
