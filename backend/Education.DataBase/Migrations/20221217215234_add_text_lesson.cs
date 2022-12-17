using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.DataBase.Migrations
{
    public partial class add_text_lesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TextLessons",
                columns: table => new
                {
                    LessonId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextLessons", x => x.LessonId);
                    table.ForeignKey(
                        name: "FK_TextLessons_Lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextLessons");
        }
    }
}
