using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Education.DataBase.Migrations
{
    public partial class add_files_entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoadedFiles",
                columns: table => new
                {
                    FileGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileType = table.Column<int>(type: "int", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadedFiles", x => x.FileGuid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoadedFiles");
        }
    }
}
