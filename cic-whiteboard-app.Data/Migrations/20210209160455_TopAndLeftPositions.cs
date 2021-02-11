using Microsoft.EntityFrameworkCore.Migrations;

namespace cic_whiteboard_app.Data.Migrations
{
    public partial class TopAndLeftPositions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Left",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Top",
                table: "Posts");
        }
    }
}
