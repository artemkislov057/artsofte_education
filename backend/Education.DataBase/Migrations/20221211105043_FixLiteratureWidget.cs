using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.DataBase.Migrations
{
    public partial class FixLiteratureWidget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiteraturePurchaseLinks_LiteratureWidgets_LiteratureId",
                table: "LiteraturePurchaseLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_PresentationSlides_PresentationWidgets_PresentationId",
                table: "PresentationSlides");

            migrationBuilder.DropIndex(
                name: "IX_LiteraturePurchaseLinks_LiteratureId",
                table: "LiteraturePurchaseLinks");

            migrationBuilder.DropColumn(
                name: "CoverSrc",
                table: "LiteratureWidgets");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "LiteratureWidgets");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LiteratureWidgets");

            migrationBuilder.DropColumn(
                name: "LiteratureId",
                table: "LiteraturePurchaseLinks");

            migrationBuilder.AlterColumn<int>(
                name: "PresentationId",
                table: "PresentationSlides",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LiteratureElementId",
                table: "LiteraturePurchaseLinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "LiteratureElement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Order = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoverSrc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LiteratureWidgetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiteratureElement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiteratureElement_LiteratureWidgets_LiteratureWidgetId",
                        column: x => x.LiteratureWidgetId,
                        principalTable: "LiteratureWidgets",
                        principalColumn: "WidgetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiteraturePurchaseLinks_LiteratureElementId",
                table: "LiteraturePurchaseLinks",
                column: "LiteratureElementId");

            migrationBuilder.CreateIndex(
                name: "IX_LiteratureElement_LiteratureWidgetId",
                table: "LiteratureElement",
                column: "LiteratureWidgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_LiteraturePurchaseLinks_LiteratureElement_LiteratureElementId",
                table: "LiteraturePurchaseLinks",
                column: "LiteratureElementId",
                principalTable: "LiteratureElement",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PresentationSlides_PresentationWidgets_PresentationId",
                table: "PresentationSlides",
                column: "PresentationId",
                principalTable: "PresentationWidgets",
                principalColumn: "WidgetId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiteraturePurchaseLinks_LiteratureElement_LiteratureElementId",
                table: "LiteraturePurchaseLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_PresentationSlides_PresentationWidgets_PresentationId",
                table: "PresentationSlides");

            migrationBuilder.DropTable(
                name: "LiteratureElement");

            migrationBuilder.DropIndex(
                name: "IX_LiteraturePurchaseLinks_LiteratureElementId",
                table: "LiteraturePurchaseLinks");

            migrationBuilder.DropColumn(
                name: "LiteratureElementId",
                table: "LiteraturePurchaseLinks");

            migrationBuilder.AlterColumn<int>(
                name: "PresentationId",
                table: "PresentationSlides",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CoverSrc",
                table: "LiteratureWidgets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "LiteratureWidgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LiteratureWidgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LiteratureId",
                table: "LiteraturePurchaseLinks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LiteraturePurchaseLinks_LiteratureId",
                table: "LiteraturePurchaseLinks",
                column: "LiteratureId");

            migrationBuilder.AddForeignKey(
                name: "FK_LiteraturePurchaseLinks_LiteratureWidgets_LiteratureId",
                table: "LiteraturePurchaseLinks",
                column: "LiteratureId",
                principalTable: "LiteratureWidgets",
                principalColumn: "WidgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_PresentationSlides_PresentationWidgets_PresentationId",
                table: "PresentationSlides",
                column: "PresentationId",
                principalTable: "PresentationWidgets",
                principalColumn: "WidgetId");
        }
    }
}
