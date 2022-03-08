using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class CategoryUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriesID",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CategoriesID",
                table: "Courses",
                column: "CategoriesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Categories_CategoriesID",
                table: "Courses",
                column: "CategoriesID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Categories_CategoriesID",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CategoriesID",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CategoriesID",
                table: "Courses");
        }
    }
}
