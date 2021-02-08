using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cic_whiteboard_app.Data.Migrations
{
    public partial class UserReactionCompositeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReactions_Posts_PostId",
                table: "UserReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReactions_Users_UserId",
                table: "UserReactions");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserReactions",
                table: "UserReactions");

            migrationBuilder.DropIndex(
                name: "IX_UserReactions_PostId",
                table: "UserReactions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserReactions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserReactions",
                table: "UserReactions",
                columns: new[] { "PostId", "UserId" });

            migrationBuilder.CreateTable(
                name: "UserComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserComments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_PostId",
                table: "UserComments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_UserId",
                table: "UserComments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReactions_Posts_PostId",
                table: "UserReactions",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserReactions_Users_UserId",
                table: "UserReactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserReactions_Posts_PostId",
                table: "UserReactions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserReactions_Users_UserId",
                table: "UserReactions");

            migrationBuilder.DropTable(
                name: "UserComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserReactions",
                table: "UserReactions");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserReactions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserReactions",
                table: "UserReactions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserReactions_PostId",
                table: "UserReactions",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReactions_Posts_PostId",
                table: "UserReactions",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserReactions_Users_UserId",
                table: "UserReactions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
