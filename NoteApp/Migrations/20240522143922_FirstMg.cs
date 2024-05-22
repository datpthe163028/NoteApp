using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NoteApp.Migrations
{
    public partial class FirstMg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "major",
                columns: table => new
                {
                    major_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "char(100)", fixedLength: true, maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_major", x => x.major_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "permission",
                columns: table => new
                {
                    permission_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    permission_name = table.Column<string>(type: "char(25)", fixedLength: true, maxLength: 25, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission", x => x.permission_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    role_name = table.Column<string>(type: "char(25)", fixedLength: true, maxLength: 25, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.role_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "semester",
                columns: table => new
                {
                    semester_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    semester_name = table.Column<string>(type: "char(25)", fixedLength: true, maxLength: 25, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_semester", x => x.semester_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "type_score",
                columns: table => new
                {
                    type_score_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "char(25)", fixedLength: true, maxLength: 25, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_type_score", x => x.type_score_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "university",
                columns: table => new
                {
                    university_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    university_name = table.Column<string>(type: "char(100)", fixedLength: true, maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_university", x => x.university_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "role_permission",
                columns: table => new
                {
                    role_id = table.Column<int>(type: "int", nullable: false),
                    permission_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => new { x.role_id, x.permission_id })
                        .Annotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                    table.ForeignKey(
                        name: "role_permission_ibfk_1",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "role_id");
                    table.ForeignKey(
                        name: "role_permission_ibfk_2",
                        column: x => x.permission_id,
                        principalTable: "permission",
                        principalColumn: "permission_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "university_major",
                columns: table => new
                {
                    university_major_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    university_id = table.Column<int>(type: "int", nullable: true),
                    major_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_university_major", x => x.university_major_id);
                    table.ForeignKey(
                        name: "university_major_ibfk_1",
                        column: x => x.university_id,
                        principalTable: "university",
                        principalColumn: "university_id");
                    table.ForeignKey(
                        name: "university_major_ibfk_2",
                        column: x => x.major_id,
                        principalTable: "major",
                        principalColumn: "major_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "university_major_semester",
                columns: table => new
                {
                    university_major_semester_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    university_major_id = table.Column<int>(type: "int", nullable: true),
                    semester_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_university_major_semester", x => x.university_major_semester_id);
                    table.ForeignKey(
                        name: "university_major_semester_ibfk_1",
                        column: x => x.university_major_id,
                        principalTable: "university_major",
                        principalColumn: "university_major_id");
                    table.ForeignKey(
                        name: "university_major_semester_ibfk_2",
                        column: x => x.semester_id,
                        principalTable: "semester",
                        principalColumn: "semester_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    subject_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    subject_name = table.Column<string>(type: "char(255)", fixedLength: true, maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    belong = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject", x => x.subject_id);
                    table.ForeignKey(
                        name: "fk_current_study_info2",
                        column: x => x.belong,
                        principalTable: "university_major_semester",
                        principalColumn: "university_major_semester_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    role_id = table.Column<int>(type: "int", nullable: true),
                    first_name = table.Column<string>(type: "char(255)", fixedLength: true, maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    last_name = table.Column<string>(type: "char(255)", fixedLength: true, maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "char(255)", fixedLength: true, maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pass = table.Column<string>(type: "char(255)", fixedLength: true, maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    current_study_info_id = table.Column<int>(type: "int", nullable: true),
                    active = table.Column<ulong>(type: "bit(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.user_id);
                    table.ForeignKey(
                        name: "fk_current_study_info",
                        column: x => x.current_study_info_id,
                        principalTable: "university_major_semester",
                        principalColumn: "university_major_semester_id");
                    table.ForeignKey(
                        name: "user_ibfk_1",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "role_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "subject_type_score",
                columns: table => new
                {
                    subject_type_score_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    subject_id = table.Column<int>(type: "int", nullable: true),
                    type_score_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subject_type_score", x => x.subject_type_score_id);
                    table.ForeignKey(
                        name: "subject_type_score_ibfk_1",
                        column: x => x.subject_id,
                        principalTable: "subject",
                        principalColumn: "subject_id");
                    table.ForeignKey(
                        name: "subject_type_score_ibfk_2",
                        column: x => x.type_score_id,
                        principalTable: "type_score",
                        principalColumn: "type_score_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "club",
                columns: table => new
                {
                    club_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "char(100)", fixedLength: true, maxLength: 100, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    url_img = table.Column<string>(type: "char(250)", fixedLength: true, maxLength: 250, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    club_owner_id = table.Column<int>(type: "int", nullable: true),
                    status_recruitment = table.Column<ulong>(type: "bit(1)", nullable: true),
                    positions = table.Column<string>(type: "char(255)", fixedLength: true, maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_procedure = table.Column<string>(type: "char(255)", fixedLength: true, maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    date_interview = table.Column<string>(type: "char(255)", fixedLength: true, maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_club", x => x.club_id);
                    table.ForeignKey(
                        name: "club_ibfk_1",
                        column: x => x.club_owner_id,
                        principalTable: "user",
                        principalColumn: "user_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "foldernote",
                columns: table => new
                {
                    folder_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    folder_name = table.Column<string>(type: "char(30)", fixedLength: true, maxLength: 30, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.folder_id);
                    table.ForeignKey(
                        name: "foldernote_ibfk_1",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    Notification_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    header = table.Column<string>(type: "char(255)", fixedLength: true, maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    content = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification", x => x.Notification_id);
                    table.ForeignKey(
                        name: "notification_ibfk_1",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "grade",
                columns: table => new
                {
                    grade_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    score = table.Column<float>(type: "float", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    subject_type_score_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grade", x => x.grade_id);
                    table.ForeignKey(
                        name: "grade_ibfk_1",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "grade_ibfk_2",
                        column: x => x.subject_type_score_id,
                        principalTable: "subject_type_score",
                        principalColumn: "subject_type_score_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "candidate_recruit",
                columns: table => new
                {
                    candidate_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    student_code = table.Column<string>(type: "char(255)", fixedLength: true, maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "char(255)", fixedLength: true, maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    club_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.candidate_id);
                    table.ForeignKey(
                        name: "candidate_recruit_ibfk_1",
                        column: x => x.club_id,
                        principalTable: "club",
                        principalColumn: "club_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "filenote",
                columns: table => new
                {
                    file_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    file_name = table.Column<string>(type: "char(30)", fixedLength: true, maxLength: 30, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    filetype = table.Column<string>(type: "char(50)", fixedLength: true, maxLength: 50, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    folder_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.file_id);
                    table.ForeignKey(
                        name: "filenote_ibfk_1",
                        column: x => x.folder_id,
                        principalTable: "foldernote",
                        principalColumn: "folder_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "simple_note",
                columns: table => new
                {
                    simple_note_id = table.Column<int>(type: "int", nullable: false),
                    content = table.Column<string>(type: "text", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_simple_note", x => x.simple_note_id);
                    table.ForeignKey(
                        name: "simple_note_ibfk_1",
                        column: x => x.simple_note_id,
                        principalTable: "filenote",
                        principalColumn: "file_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "to_do_list_note",
                columns: table => new
                {
                    to_do_list_note_id = table.Column<int>(type: "int", nullable: false),
                    header = table.Column<string>(type: "char(255)", fixedLength: true, maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_to_do_list_note", x => x.to_do_list_note_id);
                    table.ForeignKey(
                        name: "to_do_list_note_ibfk_1",
                        column: x => x.to_do_list_note_id,
                        principalTable: "filenote",
                        principalColumn: "file_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "detail_to_do_list",
                columns: table => new
                {
                    detail_to_do_list_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    status = table.Column<ulong>(type: "bit(1)", nullable: true),
                    task_name = table.Column<string>(type: "char(255)", fixedLength: true, maxLength: 255, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    due = table.Column<DateTime>(type: "datetime", nullable: true),
                    to_do_list_note_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detail_to_do_list", x => x.detail_to_do_list_id);
                    table.ForeignKey(
                        name: "detail_to_do_list_ibfk_1",
                        column: x => x.to_do_list_note_id,
                        principalTable: "to_do_list_note",
                        principalColumn: "to_do_list_note_id");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "club_id",
                table: "candidate_recruit",
                column: "club_id");

            migrationBuilder.CreateIndex(
                name: "club_owner_id",
                table: "club",
                column: "club_owner_id");

            migrationBuilder.CreateIndex(
                name: "to_do_list_note_id",
                table: "detail_to_do_list",
                column: "to_do_list_note_id");

            migrationBuilder.CreateIndex(
                name: "folder_id",
                table: "filenote",
                column: "folder_id");

            migrationBuilder.CreateIndex(
                name: "user_id",
                table: "foldernote",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "subject_type_score_id",
                table: "grade",
                column: "subject_type_score_id");

            migrationBuilder.CreateIndex(
                name: "user_id1",
                table: "grade",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "user_id2",
                table: "notification",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "permission_id",
                table: "role_permission",
                column: "permission_id");

            migrationBuilder.CreateIndex(
                name: "fk_current_study_info2",
                table: "subject",
                column: "belong");

            migrationBuilder.CreateIndex(
                name: "subject_id",
                table: "subject_type_score",
                column: "subject_id");

            migrationBuilder.CreateIndex(
                name: "type_score_id",
                table: "subject_type_score",
                column: "type_score_id");

            migrationBuilder.CreateIndex(
                name: "major_id",
                table: "university_major",
                column: "major_id");

            migrationBuilder.CreateIndex(
                name: "university_id",
                table: "university_major",
                column: "university_id");

            migrationBuilder.CreateIndex(
                name: "semester_id",
                table: "university_major_semester",
                column: "semester_id");

            migrationBuilder.CreateIndex(
                name: "university_major_id",
                table: "university_major_semester",
                column: "university_major_id");

            migrationBuilder.CreateIndex(
                name: "fk_current_study_info",
                table: "user",
                column: "current_study_info_id");

            migrationBuilder.CreateIndex(
                name: "role_id",
                table: "user",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "candidate_recruit");

            migrationBuilder.DropTable(
                name: "detail_to_do_list");

            migrationBuilder.DropTable(
                name: "grade");

            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropTable(
                name: "role_permission");

            migrationBuilder.DropTable(
                name: "simple_note");

            migrationBuilder.DropTable(
                name: "club");

            migrationBuilder.DropTable(
                name: "to_do_list_note");

            migrationBuilder.DropTable(
                name: "subject_type_score");

            migrationBuilder.DropTable(
                name: "permission");

            migrationBuilder.DropTable(
                name: "filenote");

            migrationBuilder.DropTable(
                name: "subject");

            migrationBuilder.DropTable(
                name: "type_score");

            migrationBuilder.DropTable(
                name: "foldernote");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "university_major_semester");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "university_major");

            migrationBuilder.DropTable(
                name: "semester");

            migrationBuilder.DropTable(
                name: "university");

            migrationBuilder.DropTable(
                name: "major");
        }
    }
}
