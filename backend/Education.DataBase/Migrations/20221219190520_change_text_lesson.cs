using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.DataBase.Migrations
{
    public partial class change_text_lesson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "TextLessons",
                newName: "Version");

            migrationBuilder.AddColumn<long>(
                name: "Time",
                table: "TextLessons",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "TextBlocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    BlockId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataLevel = table.Column<int>(type: "int", nullable: true),
                    DataStyle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TextLessonLessonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextBlocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextBlocks_TextLessons_TextLessonLessonId",
                        column: x => x.TextLessonLessonId,
                        principalTable: "TextLessons",
                        principalColumn: "LessonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextBlockId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListItems_TextBlocks_TextBlockId",
                        column: x => x.TextBlockId,
                        principalTable: "TextBlocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListItems_TextBlockId",
                table: "ListItems",
                column: "TextBlockId");

            migrationBuilder.CreateIndex(
                name: "IX_TextBlocks_TextLessonLessonId",
                table: "TextBlocks",
                column: "TextLessonLessonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListItems");

            migrationBuilder.DropTable(
                name: "TextBlocks");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "TextLessons");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "TextLessons",
                newName: "Value");
        }
    }
}
