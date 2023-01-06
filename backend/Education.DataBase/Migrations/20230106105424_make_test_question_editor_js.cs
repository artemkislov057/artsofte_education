using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.DataBase.Migrations
{
    public partial class make_test_question_editor_js : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question",
                table: "TestQuestions");

            migrationBuilder.AlterColumn<string>(
                name: "Src",
                table: "VideoLessons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "EditorJsId",
                table: "TestQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TestQuestions_EditorJsId",
                table: "TestQuestions",
                column: "EditorJsId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TestQuestions_EditorJsObjects_EditorJsId",
                table: "TestQuestions",
                column: "EditorJsId",
                principalTable: "EditorJsObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TestQuestions_EditorJsObjects_EditorJsId",
                table: "TestQuestions");

            migrationBuilder.DropIndex(
                name: "IX_TestQuestions_EditorJsId",
                table: "TestQuestions");

            migrationBuilder.DropColumn(
                name: "EditorJsId",
                table: "TestQuestions");

            migrationBuilder.AlterColumn<string>(
                name: "Src",
                table: "VideoLessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "TestQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
