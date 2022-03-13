using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class AddUserModerator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CourseUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseUsers_UserId",
                table: "CourseUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseUsers_AspNetUsers_UserId",
                table: "CourseUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseUsers_AspNetUsers_UserId",
                table: "CourseUsers");

            migrationBuilder.DropIndex(
                name: "IX_CourseUsers_UserId",
                table: "CourseUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CourseUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
