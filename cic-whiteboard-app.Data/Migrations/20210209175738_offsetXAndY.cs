using Microsoft.EntityFrameworkCore.Migrations;

namespace cic_whiteboard_app.Data.Migrations
{
    public partial class offsetXAndY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Left",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Top",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "OffsetX",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OffsetY",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OffsetX",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "OffsetY",
                table: "Posts");

            migrationBuilder.AddColumn<int>(
                name: "Left",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Top",
                table: "Posts",
                type: "int",
                nullable: true);
        }
    }
}
