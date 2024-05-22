﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NoteApp.App.Database.Data;

#nullable disable

namespace NoteApp.Migrations
{
    [DbContext(typeof(noteappContext))]
    [Migration("20240522153242_FirstMigrations")]
    partial class FirstMigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("NoteApp.App.Database.Data.CandidateRecruit", b =>
                {
                    b.Property<int>("CandidateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("candidate_id");

                    b.Property<int?>("ClubId")
                        .HasColumnType("int")
                        .HasColumnName("club_id");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .HasColumnType("char(255)")
                        .HasColumnName("name")
                        .IsFixedLength();

                    b.Property<string>("StudentCode")
                        .HasMaxLength(255)
                        .HasColumnType("char(255)")
                        .HasColumnName("student_code")
                        .IsFixedLength();

                    b.HasKey("CandidateId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "ClubId" }, "club_id");

                    b.ToTable("candidate_recruit", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Club", b =>
                {
                    b.Property<int>("ClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("club_id");

                    b.Property<int?>("ClubOwnerId")
                        .HasColumnType("int")
                        .HasColumnName("club_owner_id");

                    b.Property<string>("DateInterview")
                        .HasMaxLength(255)
                        .HasColumnType("char(255)")
                        .HasColumnName("date_interview")
                        .IsFixedLength();

                    b.Property<string>("DateProcedure")
                        .HasMaxLength(255)
                        .HasColumnType("char(255)")
                        .HasColumnName("date_procedure")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("char(100)")
                        .HasColumnName("name")
                        .IsFixedLength();

                    b.Property<string>("Positions")
                        .HasMaxLength(255)
                        .HasColumnType("char(255)")
                        .HasColumnName("positions")
                        .IsFixedLength();

                    b.Property<ulong?>("StatusRecruitment")
                        .HasColumnType("bit(1)")
                        .HasColumnName("status_recruitment");

                    b.Property<string>("UrlImg")
                        .HasMaxLength(250)
                        .HasColumnType("char(250)")
                        .HasColumnName("url_img")
                        .IsFixedLength();

                    b.HasKey("ClubId");

                    b.HasIndex(new[] { "ClubOwnerId" }, "club_owner_id");

                    b.ToTable("club", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.DetailToDoList", b =>
                {
                    b.Property<int>("DetailToDoListId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("detail_to_do_list_id");

                    b.Property<DateTime?>("Due")
                        .HasColumnType("datetime")
                        .HasColumnName("due");

                    b.Property<ulong?>("Status")
                        .HasColumnType("bit(1)")
                        .HasColumnName("status");

                    b.Property<string>("TaskName")
                        .HasMaxLength(255)
                        .HasColumnType("char(255)")
                        .HasColumnName("task_name")
                        .IsFixedLength();

                    b.Property<int?>("ToDoListNoteId")
                        .HasColumnType("int")
                        .HasColumnName("to_do_list_note_id");

                    b.HasKey("DetailToDoListId");

                    b.HasIndex(new[] { "ToDoListNoteId" }, "to_do_list_note_id");

                    b.ToTable("detail_to_do_list", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Filenote", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("file_id");

                    b.Property<string>("FileName")
                        .HasMaxLength(30)
                        .HasColumnType("char(30)")
                        .HasColumnName("file_name")
                        .IsFixedLength();

                    b.Property<string>("Filetype")
                        .HasMaxLength(50)
                        .HasColumnType("char(50)")
                        .HasColumnName("filetype")
                        .IsFixedLength();

                    b.Property<int?>("FolderId")
                        .HasColumnType("int")
                        .HasColumnName("folder_id");

                    b.HasKey("FileId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "FolderId" }, "folder_id");

                    b.ToTable("filenote", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Foldernote", b =>
                {
                    b.Property<int>("FolderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("folder_id");

                    b.Property<string>("FolderName")
                        .HasMaxLength(30)
                        .HasColumnType("char(30)")
                        .HasColumnName("folder_name")
                        .IsFixedLength();

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("FolderId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "UserId" }, "user_id");

                    b.ToTable("foldernote", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("grade_id");

                    b.Property<float?>("Score")
                        .HasColumnType("float")
                        .HasColumnName("score");

                    b.Property<int?>("SubjectTypeScoreId")
                        .HasColumnType("int")
                        .HasColumnName("subject_type_score_id");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("GradeId");

                    b.HasIndex(new[] { "SubjectTypeScoreId" }, "subject_type_score_id");

                    b.HasIndex(new[] { "UserId" }, "user_id")
                        .HasDatabaseName("user_id1");

                    b.ToTable("grade", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Hostel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ExistenceTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("GoogleMapAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("OwnerName")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("hostel", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Major", b =>
                {
                    b.Property<int>("MajorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("major_id");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("char(100)")
                        .HasColumnName("name")
                        .IsFixedLength();

                    b.HasKey("MajorId");

                    b.ToTable("major", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Notification_id");

                    b.Property<string>("Content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.Property<string>("Header")
                        .HasMaxLength(255)
                        .HasColumnType("char(255)")
                        .HasColumnName("header")
                        .IsFixedLength();

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("NotificationId");

                    b.HasIndex(new[] { "UserId" }, "user_id")
                        .HasDatabaseName("user_id2");

                    b.ToTable("notification", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("permission_id");

                    b.Property<string>("PermissionName")
                        .HasMaxLength(25)
                        .HasColumnType("char(25)")
                        .HasColumnName("permission_name")
                        .IsFixedLength();

                    b.HasKey("PermissionId");

                    b.ToTable("permission", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<string>("RoleName")
                        .HasMaxLength(25)
                        .HasColumnType("char(25)")
                        .HasColumnName("role_name")
                        .IsFixedLength();

                    b.HasKey("RoleId");

                    b.ToTable("role", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Semester", b =>
                {
                    b.Property<int>("SemesterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("semester_id");

                    b.Property<string>("SemesterName")
                        .HasMaxLength(25)
                        .HasColumnType("char(25)")
                        .HasColumnName("semester_name")
                        .IsFixedLength();

                    b.HasKey("SemesterId");

                    b.ToTable("semester", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.SimpleNote", b =>
                {
                    b.Property<int>("SimpleNoteId")
                        .HasColumnType("int")
                        .HasColumnName("simple_note_id");

                    b.Property<string>("Content")
                        .HasColumnType("text")
                        .HasColumnName("content");

                    b.HasKey("SimpleNoteId");

                    b.ToTable("simple_note", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("subject_id");

                    b.Property<int?>("Belong")
                        .HasColumnType("int")
                        .HasColumnName("belong");

                    b.Property<string>("SubjectName")
                        .HasMaxLength(255)
                        .HasColumnType("char(255)")
                        .HasColumnName("subject_name")
                        .IsFixedLength();

                    b.HasKey("SubjectId");

                    b.HasIndex(new[] { "Belong" }, "fk_current_study_info2");

                    b.ToTable("subject", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.SubjectTypeScore", b =>
                {
                    b.Property<int>("SubjectTypeScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("subject_type_score_id");

                    b.Property<int?>("SubjectId")
                        .HasColumnType("int")
                        .HasColumnName("subject_id");

                    b.Property<int?>("TypeScoreId")
                        .HasColumnType("int")
                        .HasColumnName("type_score_id");

                    b.HasKey("SubjectTypeScoreId");

                    b.HasIndex(new[] { "SubjectId" }, "subject_id");

                    b.HasIndex(new[] { "TypeScoreId" }, "type_score_id");

                    b.ToTable("subject_type_score", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.ToDoListNote", b =>
                {
                    b.Property<int>("ToDoListNoteId")
                        .HasColumnType("int")
                        .HasColumnName("to_do_list_note_id");

                    b.Property<string>("Header")
                        .HasMaxLength(255)
                        .HasColumnType("char(255)")
                        .HasColumnName("header")
                        .IsFixedLength();

                    b.HasKey("ToDoListNoteId");

                    b.ToTable("to_do_list_note", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.TypeScore", b =>
                {
                    b.Property<int>("TypeScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("type_score_id");

                    b.Property<string>("Name")
                        .HasMaxLength(25)
                        .HasColumnType("char(25)")
                        .HasColumnName("name")
                        .IsFixedLength();

                    b.HasKey("TypeScoreId");

                    b.ToTable("type_score", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.University", b =>
                {
                    b.Property<int>("UniversityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("university_id");

                    b.Property<string>("UniversityName")
                        .HasMaxLength(100)
                        .HasColumnType("char(100)")
                        .HasColumnName("university_name")
                        .IsFixedLength();

                    b.HasKey("UniversityId");

                    b.ToTable("university", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.UniversityMajor", b =>
                {
                    b.Property<int>("UniversityMajorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("university_major_id");

                    b.Property<int?>("MajorId")
                        .HasColumnType("int")
                        .HasColumnName("major_id");

                    b.Property<int?>("UniversityId")
                        .HasColumnType("int")
                        .HasColumnName("university_id");

                    b.HasKey("UniversityMajorId");

                    b.HasIndex(new[] { "MajorId" }, "major_id");

                    b.HasIndex(new[] { "UniversityId" }, "university_id");

                    b.ToTable("university_major", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.UniversityMajorSemester", b =>
                {
                    b.Property<int>("UniversityMajorSemesterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("university_major_semester_id");

                    b.Property<int?>("SemesterId")
                        .HasColumnType("int")
                        .HasColumnName("semester_id");

                    b.Property<int?>("UniversityMajorId")
                        .HasColumnType("int")
                        .HasColumnName("university_major_id");

                    b.HasKey("UniversityMajorSemesterId");

                    b.HasIndex(new[] { "SemesterId" }, "semester_id");

                    b.HasIndex(new[] { "UniversityMajorId" }, "university_major_id");

                    b.ToTable("university_major_semester", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.Property<ulong?>("Active")
                        .HasColumnType("bit(1)")
                        .HasColumnName("active");

                    b.Property<int?>("CurrentStudyInfoId")
                        .HasColumnType("int")
                        .HasColumnName("current_study_info_id");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("char(255)")
                        .HasColumnName("email")
                        .IsFixedLength();

                    b.Property<string>("FirstName")
                        .HasMaxLength(255)
                        .HasColumnType("char(255)")
                        .HasColumnName("first_name")
                        .IsFixedLength();

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("char(255)")
                        .HasColumnName("last_name")
                        .IsFixedLength();

                    b.Property<string>("Pass")
                        .HasMaxLength(255)
                        .HasColumnType("char(255)")
                        .HasColumnName("pass")
                        .IsFixedLength();

                    b.Property<int?>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("UserId");

                    b.HasIndex(new[] { "CurrentStudyInfoId" }, "fk_current_study_info");

                    b.HasIndex(new[] { "RoleId" }, "role_id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("RolePermission", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int")
                        .HasColumnName("permission_id");

                    b.HasKey("RoleId", "PermissionId")
                        .HasName("PRIMARY")
                        .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                    b.HasIndex(new[] { "PermissionId" }, "permission_id");

                    b.ToTable("role_permission", (string)null);
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.CandidateRecruit", b =>
                {
                    b.HasOne("NoteApp.App.Database.Data.Club", "Club")
                        .WithMany("CandidateRecruits")
                        .HasForeignKey("ClubId")
                        .HasConstraintName("candidate_recruit_ibfk_1");

                    b.Navigation("Club");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Club", b =>
                {
                    b.HasOne("NoteApp.App.Database.Data.User", "ClubOwner")
                        .WithMany("Clubs")
                        .HasForeignKey("ClubOwnerId")
                        .HasConstraintName("club_ibfk_1");

                    b.Navigation("ClubOwner");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.DetailToDoList", b =>
                {
                    b.HasOne("NoteApp.App.Database.Data.ToDoListNote", "ToDoListNote")
                        .WithMany("DetailToDoLists")
                        .HasForeignKey("ToDoListNoteId")
                        .HasConstraintName("detail_to_do_list_ibfk_1");

                    b.Navigation("ToDoListNote");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Filenote", b =>
                {
                    b.HasOne("NoteApp.App.Database.Data.Foldernote", "Folder")
                        .WithMany("Filenotes")
                        .HasForeignKey("FolderId")
                        .HasConstraintName("filenote_ibfk_1");

                    b.Navigation("Folder");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Foldernote", b =>
                {
                    b.HasOne("NoteApp.App.Database.Data.User", "User")
                        .WithMany("Foldernotes")
                        .HasForeignKey("UserId")
                        .HasConstraintName("foldernote_ibfk_1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Grade", b =>
                {
                    b.HasOne("NoteApp.App.Database.Data.SubjectTypeScore", "SubjectTypeScore")
                        .WithMany("Grades")
                        .HasForeignKey("SubjectTypeScoreId")
                        .HasConstraintName("grade_ibfk_2");

                    b.HasOne("NoteApp.App.Database.Data.User", "User")
                        .WithMany("Grades")
                        .HasForeignKey("UserId")
                        .HasConstraintName("grade_ibfk_1");

                    b.Navigation("SubjectTypeScore");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Notification", b =>
                {
                    b.HasOne("NoteApp.App.Database.Data.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .HasConstraintName("notification_ibfk_1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.SimpleNote", b =>
                {
                    b.HasOne("NoteApp.App.Database.Data.Filenote", "SimpleNoteNavigation")
                        .WithOne("SimpleNote")
                        .HasForeignKey("NoteApp.App.Database.Data.SimpleNote", "SimpleNoteId")
                        .IsRequired()
                        .HasConstraintName("simple_note_ibfk_1");

                    b.Navigation("SimpleNoteNavigation");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Subject", b =>
                {
                    b.HasOne("NoteApp.App.Database.Data.UniversityMajorSemester", "BelongNavigation")
                        .WithMany("Subjects")
                        .HasForeignKey("Belong")
                        .HasConstraintName("fk_current_study_info2");

                    b.Navigation("BelongNavigation");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.SubjectTypeScore", b =>
                {
                    b.HasOne("NoteApp.App.Database.Data.Subject", "Subject")
                        .WithMany("SubjectTypeScores")
                        .HasForeignKey("SubjectId")
                        .HasConstraintName("subject_type_score_ibfk_1");

                    b.HasOne("NoteApp.App.Database.Data.TypeScore", "TypeScore")
                        .WithMany("SubjectTypeScores")
                        .HasForeignKey("TypeScoreId")
                        .HasConstraintName("subject_type_score_ibfk_2");

                    b.Navigation("Subject");

                    b.Navigation("TypeScore");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.ToDoListNote", b =>
                {
                    b.HasOne("NoteApp.App.Database.Data.Filenote", "ToDoListNoteNavigation")
                        .WithOne("ToDoListNote")
                        .HasForeignKey("NoteApp.App.Database.Data.ToDoListNote", "ToDoListNoteId")
                        .IsRequired()
                        .HasConstraintName("to_do_list_note_ibfk_1");

                    b.Navigation("ToDoListNoteNavigation");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.UniversityMajor", b =>
                {
                    b.HasOne("NoteApp.App.Database.Data.Major", "Major")
                        .WithMany("UniversityMajors")
                        .HasForeignKey("MajorId")
                        .HasConstraintName("university_major_ibfk_2");

                    b.HasOne("NoteApp.App.Database.Data.University", "University")
                        .WithMany("UniversityMajors")
                        .HasForeignKey("UniversityId")
                        .HasConstraintName("university_major_ibfk_1");

                    b.Navigation("Major");

                    b.Navigation("University");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.UniversityMajorSemester", b =>
                {
                    b.HasOne("NoteApp.App.Database.Data.Semester", "Semester")
                        .WithMany("UniversityMajorSemesters")
                        .HasForeignKey("SemesterId")
                        .HasConstraintName("university_major_semester_ibfk_2");

                    b.HasOne("NoteApp.App.Database.Data.UniversityMajor", "UniversityMajor")
                        .WithMany("UniversityMajorSemesters")
                        .HasForeignKey("UniversityMajorId")
                        .HasConstraintName("university_major_semester_ibfk_1");

                    b.Navigation("Semester");

                    b.Navigation("UniversityMajor");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.User", b =>
                {
                    b.HasOne("NoteApp.App.Database.Data.UniversityMajorSemester", "CurrentStudyInfo")
                        .WithMany("Users")
                        .HasForeignKey("CurrentStudyInfoId")
                        .HasConstraintName("fk_current_study_info");

                    b.HasOne("NoteApp.App.Database.Data.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("user_ibfk_1");

                    b.Navigation("CurrentStudyInfo");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("RolePermission", b =>
                {
                    b.HasOne("NoteApp.App.Database.Data.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .IsRequired()
                        .HasConstraintName("role_permission_ibfk_2");

                    b.HasOne("NoteApp.App.Database.Data.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("role_permission_ibfk_1");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Club", b =>
                {
                    b.Navigation("CandidateRecruits");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Filenote", b =>
                {
                    b.Navigation("SimpleNote");

                    b.Navigation("ToDoListNote");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Foldernote", b =>
                {
                    b.Navigation("Filenotes");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Major", b =>
                {
                    b.Navigation("UniversityMajors");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Semester", b =>
                {
                    b.Navigation("UniversityMajorSemesters");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.Subject", b =>
                {
                    b.Navigation("SubjectTypeScores");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.SubjectTypeScore", b =>
                {
                    b.Navigation("Grades");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.ToDoListNote", b =>
                {
                    b.Navigation("DetailToDoLists");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.TypeScore", b =>
                {
                    b.Navigation("SubjectTypeScores");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.University", b =>
                {
                    b.Navigation("UniversityMajors");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.UniversityMajor", b =>
                {
                    b.Navigation("UniversityMajorSemesters");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.UniversityMajorSemester", b =>
                {
                    b.Navigation("Subjects");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("NoteApp.App.Database.Data.User", b =>
                {
                    b.Navigation("Clubs");

                    b.Navigation("Foldernotes");

                    b.Navigation("Grades");

                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}