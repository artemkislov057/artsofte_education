using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.DataBase.Migrations
{
    public partial class add_additional_text : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdditionalTextId",
                table: "Lessons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_AdditionalTextId",
                table: "Lessons",
                column: "AdditionalTextId",
                unique: true,
                filter: "[AdditionalTextId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Lessons_EditorJsObjects_AdditionalTextId",
                table: "Lessons",
                column: "AdditionalTextId",
                principalTable: "EditorJsObjects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lessons_EditorJsObjects_AdditionalTextId",
                table: "Lessons");

            migrationBuilder.DropIndex(
                name: "IX_Lessons_AdditionalTextId",
                table: "Lessons");

            migrationBuilder.DropColumn(
                name: "AdditionalTextId",
                table: "Lessons");
        }
    }
}
