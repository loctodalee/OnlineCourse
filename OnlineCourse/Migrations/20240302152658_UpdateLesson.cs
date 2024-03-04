using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineCourse.Migrations
{
    public partial class UpdateLesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_user_per",
                table: "tbl_user_per");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_user_course_lesson_progress",
                table: "tbl_user_course_lesson_progress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_user_course",
                table: "tbl_user_course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_per_action",
                table: "tbl_per_action");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "tbl_user_per",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "tbl_user_course_lesson_progress",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "tbl_user_course",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "tbl_per_action",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "VideoUrl",
                table: "tbl_lesson",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NextLessonId",
                table: "tbl_lesson",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "tbl_lesson",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_user_per",
                table: "tbl_user_per",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_user_course_lesson_progress",
                table: "tbl_user_course_lesson_progress",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_user_course",
                table: "tbl_user_course",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_per_action",
                table: "tbl_per_action",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_user_per",
                table: "tbl_user_per");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_user_course_lesson_progress",
                table: "tbl_user_course_lesson_progress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_user_course",
                table: "tbl_user_course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_per_action",
                table: "tbl_per_action");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tbl_user_per");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tbl_user_course_lesson_progress");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tbl_user_course");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "tbl_per_action");

            migrationBuilder.AlterColumn<string>(
                name: "VideoUrl",
                table: "tbl_lesson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NextLessonId",
                table: "tbl_lesson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "tbl_lesson",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_user_per",
                table: "tbl_user_per",
                column: "CreateTimes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_user_course_lesson_progress",
                table: "tbl_user_course_lesson_progress",
                column: "CreateTimes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_user_course",
                table: "tbl_user_course",
                column: "CreateTimes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_per_action",
                table: "tbl_per_action",
                column: "CreateTimes");
        }
    }
}
