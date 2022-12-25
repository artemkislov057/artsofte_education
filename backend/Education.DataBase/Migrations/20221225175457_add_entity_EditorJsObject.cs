using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.DataBase.Migrations
{
    public partial class add_entity_EditorJsObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextBlocks_TextLessons_TextLessonLessonId",
                table: "TextBlocks");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "TextLessons");

            migrationBuilder.DropColumn(
                name: "Version",
                table: "TextLessons");

            migrationBuilder.RenameColumn(
                name: "TextLessonLessonId",
                table: "TextBlocks",
                newName: "EditorJsObjectId");

            migrationBuilder.RenameIndex(
                name: "IX_TextBlocks_TextLessonLessonId",
                table: "TextBlocks",
                newName: "IX_TextBlocks_EditorJsObjectId");

            migrationBuilder.AddColumn<int>(
                name: "EditorJsObjectId",
                table: "TextLessons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EditorJsObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<long>(type: "bigint", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EditorJsObjects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TextLessons_EditorJsObjectId",
                table: "TextLessons",
                column: "EditorJsObjectId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TextBlocks_EditorJsObjects_EditorJsObjectId",
                table: "TextBlocks",
                column: "EditorJsObjectId",
                principalTable: "EditorJsObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TextLessons_EditorJsObjects_EditorJsObjectId",
                table: "TextLessons",
                column: "EditorJsObjectId",
                principalTable: "EditorJsObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextBlocks_EditorJsObjects_EditorJsObjectId",
                table: "TextBlocks");

            migrationBuilder.DropForeignKey(
                name: "FK_TextLessons_EditorJsObjects_EditorJsObjectId",
                table: "TextLessons");

            migrationBuilder.DropTable(
                name: "EditorJsObjects");

            migrationBuilder.DropIndex(
                name: "IX_TextLessons_EditorJsObjectId",
                table: "TextLessons");

            migrationBuilder.DropColumn(
                name: "EditorJsObjectId",
                table: "TextLessons");

            migrationBuilder.RenameColumn(
                name: "EditorJsObjectId",
                table: "TextBlocks",
                newName: "TextLessonLessonId");

            migrationBuilder.RenameIndex(
                name: "IX_TextBlocks_EditorJsObjectId",
                table: "TextBlocks",
                newName: "IX_TextBlocks_TextLessonLessonId");

            migrationBuilder.AddColumn<long>(
                name: "Time",
                table: "TextLessons",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Version",
                table: "TextLessons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_TextBlocks_TextLessons_TextLessonLessonId",
                table: "TextBlocks",
                column: "TextLessonLessonId",
                principalTable: "TextLessons",
                principalColumn: "LessonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
