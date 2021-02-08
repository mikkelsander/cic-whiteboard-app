using Microsoft.EntityFrameworkCore.Migrations;

namespace cic_whiteboard_app.Data.Migrations
{
    public partial class UserRoleAndAzureActiveDirectoryIdOnUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AzureActiveDirectoryId",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserRole",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AzureActiveDirectoryId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserRole",
                table: "Users");
        }
    }
}
