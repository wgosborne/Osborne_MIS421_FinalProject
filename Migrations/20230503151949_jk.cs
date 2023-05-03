using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _521Final.Migrations
{
    public partial class jk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Roles",
                table: "AspNetUsers",
                newName: "Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Role",
                table: "AspNetUsers",
                newName: "Roles");
        }
    }
}
