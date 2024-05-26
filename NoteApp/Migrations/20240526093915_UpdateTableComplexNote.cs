using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteApp.Migrations
{
    public partial class UpdateTableComplexNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplextNote_filenote_FileNoteId",
                table: "ComplextNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComplextNote",
                table: "ComplextNote");

            migrationBuilder.RenameTable(
                name: "ComplextNote",
                newName: "ComplextNotes");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ComplextNotes",
                newName: "Header3");

            migrationBuilder.RenameColumn(
                name: "Header",
                table: "ComplextNotes",
                newName: "Header2");

            migrationBuilder.RenameIndex(
                name: "IX_ComplextNote_FileNoteId",
                table: "ComplextNotes",
                newName: "IX_ComplextNotes_FileNoteId");

            migrationBuilder.AddColumn<string>(
                name: "Content1",
                table: "ComplextNotes",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Content2",
                table: "ComplextNotes",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Content3",
                table: "ComplextNotes",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Header1",
                table: "ComplextNotes",
                type: "longtext",
                nullable: false,
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComplextNotes",
                table: "ComplextNotes",
                column: "ComplexNoteId");

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Header = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ComplextNoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_ComplextNotes_ComplextNoteId",
                        column: x => x.ComplextNoteId,
                        principalTable: "ComplextNotes",
                        principalColumn: "ComplexNoteId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ComplextNoteId",
                table: "Documents",
                column: "ComplextNoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplextNotes_filenote_FileNoteId",
                table: "ComplextNotes",
                column: "FileNoteId",
                principalTable: "filenote",
                principalColumn: "file_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplextNotes_filenote_FileNoteId",
                table: "ComplextNotes");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComplextNotes",
                table: "ComplextNotes");

            migrationBuilder.DropColumn(
                name: "Content1",
                table: "ComplextNotes");

            migrationBuilder.DropColumn(
                name: "Content2",
                table: "ComplextNotes");

            migrationBuilder.DropColumn(
                name: "Content3",
                table: "ComplextNotes");

            migrationBuilder.DropColumn(
                name: "Header1",
                table: "ComplextNotes");

            migrationBuilder.RenameTable(
                name: "ComplextNotes",
                newName: "ComplextNote");

            migrationBuilder.RenameColumn(
                name: "Header3",
                table: "ComplextNote",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Header2",
                table: "ComplextNote",
                newName: "Header");

            migrationBuilder.RenameIndex(
                name: "IX_ComplextNotes_FileNoteId",
                table: "ComplextNote",
                newName: "IX_ComplextNote_FileNoteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComplextNote",
                table: "ComplextNote",
                column: "ComplexNoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplextNote_filenote_FileNoteId",
                table: "ComplextNote",
                column: "FileNoteId",
                principalTable: "filenote",
                principalColumn: "file_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
