using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteApp.Migrations
{
    public partial class AddTableComplexNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<ulong>(
                name: "status",
                table: "detail_to_do_list",
                type: "bit(1)",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(ulong),
                oldType: "bit(1)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ComplextNote",
                columns: table => new
                {
                    ComplexNoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileNoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplextNote", x => x.ComplexNoteId);
                    table.ForeignKey(
                        name: "FK_ComplextNote_filenote_FileNoteId",
                        column: x => x.FileNoteId,
                        principalTable: "filenote",
                        principalColumn: "file_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_ComplextNote_FileNoteId",
                table: "ComplextNote",
                column: "FileNoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComplextNote");

            migrationBuilder.AlterColumn<ulong>(
                name: "status",
                table: "detail_to_do_list",
                type: "bit(1)",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bit(1)");
        }
    }
}
