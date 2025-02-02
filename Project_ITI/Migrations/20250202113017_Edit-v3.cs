using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_ITI.Migrations
{
    /// <inheritdoc />
    public partial class Editv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instractors_Courses_CourseId",
                table: "Instractors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instractors_Departments_DepartmentId",
                table: "Instractors");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Instractors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Instractors",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Instractors_Courses_CourseId",
                table: "Instractors",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instractors_Departments_DepartmentId",
                table: "Instractors",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Instractors_Courses_CourseId",
                table: "Instractors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instractors_Departments_DepartmentId",
                table: "Instractors");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Instractors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Instractors",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Instractors_Courses_CourseId",
                table: "Instractors",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Instractors_Departments_DepartmentId",
                table: "Instractors",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
