using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NoteApp.Data
{
    public partial class noteappContext : DbContext
    {
        public noteappContext()
        {
        }

        public noteappContext(DbContextOptions<noteappContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CandidateRecruit> CandidateRecruits { get; set; } = null!;
        public virtual DbSet<Club> Clubs { get; set; } = null!;
        public virtual DbSet<DetailToDoList> DetailToDoLists { get; set; } = null!;
        public virtual DbSet<Filenote> Filenotes { get; set; } = null!;
        public virtual DbSet<Foldernote> Foldernotes { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Major> Majors { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Semester> Semesters { get; set; } = null!;
        public virtual DbSet<SimpleNote> SimpleNotes { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<SubjectTypeScore> SubjectTypeScores { get; set; } = null!;
        public virtual DbSet<ToDoListNote> ToDoListNotes { get; set; } = null!;
        public virtual DbSet<TypeScore> TypeScores { get; set; } = null!;
        public virtual DbSet<University> Universities { get; set; } = null!;
        public virtual DbSet<UniversityMajor> UniversityMajors { get; set; } = null!;
        public virtual DbSet<UniversityMajorSemester> UniversityMajorSemesters { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=noteapp;user=root;password=dat123456", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.3.0-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<CandidateRecruit>(entity =>
            {
                entity.HasKey(e => e.CandidateId)
                    .HasName("PRIMARY");

                entity.ToTable("candidate_recruit");

                entity.HasIndex(e => e.ClubId, "club_id");

                entity.Property(e => e.CandidateId).HasColumnName("candidate_id");

                entity.Property(e => e.ClubId).HasColumnName("club_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name")
                    .IsFixedLength();

                entity.Property(e => e.StudentCode)
                    .HasMaxLength(255)
                    .HasColumnName("student_code")
                    .IsFixedLength();

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.CandidateRecruits)
                    .HasForeignKey(d => d.ClubId)
                    .HasConstraintName("candidate_recruit_ibfk_1");
            });

            modelBuilder.Entity<Club>(entity =>
            {
                entity.ToTable("club");

                entity.HasIndex(e => e.ClubOwnerId, "club_owner_id");

                entity.Property(e => e.ClubId).HasColumnName("club_id");

                entity.Property(e => e.ClubOwnerId).HasColumnName("club_owner_id");

                entity.Property(e => e.DateInterview)
                    .HasMaxLength(255)
                    .HasColumnName("date_interview")
                    .IsFixedLength();

                entity.Property(e => e.DateProcedure)
                    .HasMaxLength(255)
                    .HasColumnName("date_procedure")
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name")
                    .IsFixedLength();

                entity.Property(e => e.Positions)
                    .HasMaxLength(255)
                    .HasColumnName("positions")
                    .IsFixedLength();

                entity.Property(e => e.StatusRecruitment)
                    .HasColumnType("bit(1)")
                    .HasColumnName("status_recruitment");

                entity.Property(e => e.UrlImg)
                    .HasMaxLength(250)
                    .HasColumnName("url_img")
                    .IsFixedLength();

                entity.HasOne(d => d.ClubOwner)
                    .WithMany(p => p.Clubs)
                    .HasForeignKey(d => d.ClubOwnerId)
                    .HasConstraintName("club_ibfk_1");
            });

            modelBuilder.Entity<DetailToDoList>(entity =>
            {
                entity.ToTable("detail_to_do_list");

                entity.HasIndex(e => e.ToDoListNoteId, "to_do_list_note_id");

                entity.Property(e => e.DetailToDoListId).HasColumnName("detail_to_do_list_id");

                entity.Property(e => e.Due)
                    .HasColumnType("datetime")
                    .HasColumnName("due");

                entity.Property(e => e.Status)
                    .HasColumnType("bit(1)")
                    .HasColumnName("status");

                entity.Property(e => e.TaskName)
                    .HasMaxLength(255)
                    .HasColumnName("task_name")
                    .IsFixedLength();

                entity.Property(e => e.ToDoListNoteId).HasColumnName("to_do_list_note_id");

                entity.HasOne(d => d.ToDoListNote)
                    .WithMany(p => p.DetailToDoLists)
                    .HasForeignKey(d => d.ToDoListNoteId)
                    .HasConstraintName("detail_to_do_list_ibfk_1");
            });

            modelBuilder.Entity<Filenote>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PRIMARY");

                entity.ToTable("filenote");

                entity.HasIndex(e => e.FolderId, "folder_id");

                entity.Property(e => e.FileId).HasColumnName("file_id");

                entity.Property(e => e.FileName)
                    .HasMaxLength(30)
                    .HasColumnName("file_name")
                    .IsFixedLength();

                entity.Property(e => e.Filetype)
                    .HasMaxLength(50)
                    .HasColumnName("filetype")
                    .IsFixedLength();

                entity.Property(e => e.FolderId).HasColumnName("folder_id");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.Filenotes)
                    .HasForeignKey(d => d.FolderId)
                    .HasConstraintName("filenote_ibfk_1");
            });

            modelBuilder.Entity<Foldernote>(entity =>
            {
                entity.HasKey(e => e.FolderId)
                    .HasName("PRIMARY");

                entity.ToTable("foldernote");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.FolderId).HasColumnName("folder_id");

                entity.Property(e => e.FolderName)
                    .HasMaxLength(30)
                    .HasColumnName("folder_name")
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Foldernotes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("foldernote_ibfk_1");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("grade");

                entity.HasIndex(e => e.SubjectTypeScoreId, "subject_type_score_id");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.GradeId).HasColumnName("grade_id");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.SubjectTypeScoreId).HasColumnName("subject_type_score_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.SubjectTypeScore)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.SubjectTypeScoreId)
                    .HasConstraintName("grade_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("grade_ibfk_1");
            });

            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("major");

                entity.Property(e => e.MajorId).HasColumnName("major_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("notification");

                entity.HasIndex(e => e.UserId, "user_id");

                entity.Property(e => e.NotificationId).HasColumnName("Notification_id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.Property(e => e.Header)
                    .HasMaxLength(255)
                    .HasColumnName("header")
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("notification_ibfk_1");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("permission");

                entity.Property(e => e.PermissionId).HasColumnName("permission_id");

                entity.Property(e => e.PermissionName)
                    .HasMaxLength(25)
                    .HasColumnName("permission_name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(25)
                    .HasColumnName("role_name")
                    .IsFixedLength();

                entity.HasMany(d => d.Permissions)
                    .WithMany(p => p.Roles)
                    .UsingEntity<Dictionary<string, object>>(
                        "RolePermission",
                        l => l.HasOne<Permission>().WithMany().HasForeignKey("PermissionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("role_permission_ibfk_2"),
                        r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("role_permission_ibfk_1"),
                        j =>
                        {
                            j.HasKey("RoleId", "PermissionId").HasName("PRIMARY").HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                            j.ToTable("role_permission");

                            j.HasIndex(new[] { "PermissionId" }, "permission_id");

                            j.IndexerProperty<int>("RoleId").HasColumnName("role_id");

                            j.IndexerProperty<int>("PermissionId").HasColumnName("permission_id");
                        });
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("semester");

                entity.Property(e => e.SemesterId).HasColumnName("semester_id");

                entity.Property(e => e.SemesterName)
                    .HasMaxLength(25)
                    .HasColumnName("semester_name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<SimpleNote>(entity =>
            {
                entity.ToTable("simple_note");

                entity.Property(e => e.SimpleNoteId)
                    .ValueGeneratedNever()
                    .HasColumnName("simple_note_id");

                entity.Property(e => e.Content)
                    .HasColumnType("text")
                    .HasColumnName("content");

                entity.HasOne(d => d.SimpleNoteNavigation)
                    .WithOne(p => p.SimpleNote)
                    .HasForeignKey<SimpleNote>(d => d.SimpleNoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("simple_note_ibfk_1");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subject");

                entity.HasIndex(e => e.Belong, "fk_current_study_info2");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.Belong).HasColumnName("belong");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(255)
                    .HasColumnName("subject_name")
                    .IsFixedLength();

                entity.HasOne(d => d.BelongNavigation)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.Belong)
                    .HasConstraintName("fk_current_study_info2");
            });

            modelBuilder.Entity<SubjectTypeScore>(entity =>
            {
                entity.ToTable("subject_type_score");

                entity.HasIndex(e => e.SubjectId, "subject_id");

                entity.HasIndex(e => e.TypeScoreId, "type_score_id");

                entity.Property(e => e.SubjectTypeScoreId).HasColumnName("subject_type_score_id");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.TypeScoreId).HasColumnName("type_score_id");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectTypeScores)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("subject_type_score_ibfk_1");

                entity.HasOne(d => d.TypeScore)
                    .WithMany(p => p.SubjectTypeScores)
                    .HasForeignKey(d => d.TypeScoreId)
                    .HasConstraintName("subject_type_score_ibfk_2");
            });

            modelBuilder.Entity<ToDoListNote>(entity =>
            {
                entity.ToTable("to_do_list_note");

                entity.Property(e => e.ToDoListNoteId)
                    .ValueGeneratedNever()
                    .HasColumnName("to_do_list_note_id");

                entity.Property(e => e.Header)
                    .HasMaxLength(255)
                    .HasColumnName("header")
                    .IsFixedLength();

                entity.HasOne(d => d.ToDoListNoteNavigation)
                    .WithOne(p => p.ToDoListNote)
                    .HasForeignKey<ToDoListNote>(d => d.ToDoListNoteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("to_do_list_note_ibfk_1");
            });

            modelBuilder.Entity<TypeScore>(entity =>
            {
                entity.ToTable("type_score");

                entity.Property(e => e.TypeScoreId).HasColumnName("type_score_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .HasColumnName("name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<University>(entity =>
            {
                entity.ToTable("university");

                entity.Property(e => e.UniversityId).HasColumnName("university_id");

                entity.Property(e => e.UniversityName)
                    .HasMaxLength(100)
                    .HasColumnName("university_name")
                    .IsFixedLength();
            });

            modelBuilder.Entity<UniversityMajor>(entity =>
            {
                entity.ToTable("university_major");

                entity.HasIndex(e => e.MajorId, "major_id");

                entity.HasIndex(e => e.UniversityId, "university_id");

                entity.Property(e => e.UniversityMajorId).HasColumnName("university_major_id");

                entity.Property(e => e.MajorId).HasColumnName("major_id");

                entity.Property(e => e.UniversityId).HasColumnName("university_id");

                entity.HasOne(d => d.Major)
                    .WithMany(p => p.UniversityMajors)
                    .HasForeignKey(d => d.MajorId)
                    .HasConstraintName("university_major_ibfk_2");

                entity.HasOne(d => d.University)
                    .WithMany(p => p.UniversityMajors)
                    .HasForeignKey(d => d.UniversityId)
                    .HasConstraintName("university_major_ibfk_1");
            });

            modelBuilder.Entity<UniversityMajorSemester>(entity =>
            {
                entity.ToTable("university_major_semester");

                entity.HasIndex(e => e.SemesterId, "semester_id");

                entity.HasIndex(e => e.UniversityMajorId, "university_major_id");

                entity.Property(e => e.UniversityMajorSemesterId).HasColumnName("university_major_semester_id");

                entity.Property(e => e.SemesterId).HasColumnName("semester_id");

                entity.Property(e => e.UniversityMajorId).HasColumnName("university_major_id");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.UniversityMajorSemesters)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("university_major_semester_ibfk_2");

                entity.HasOne(d => d.UniversityMajor)
                    .WithMany(p => p.UniversityMajorSemesters)
                    .HasForeignKey(d => d.UniversityMajorId)
                    .HasConstraintName("university_major_semester_ibfk_1");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.CurrentStudyInfoId, "fk_current_study_info");

                entity.HasIndex(e => e.RoleId, "role_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Active)
                    .HasColumnType("bit(1)")
                    .HasColumnName("active");

                entity.Property(e => e.CurrentStudyInfoId).HasColumnName("current_study_info_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .HasColumnName("email")
                    .IsFixedLength();

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .HasColumnName("first_name")
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .HasColumnName("last_name")
                    .IsFixedLength();

                entity.Property(e => e.Pass)
                    .HasMaxLength(255)
                    .HasColumnName("pass")
                    .IsFixedLength();

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.CurrentStudyInfo)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CurrentStudyInfoId)
                    .HasConstraintName("fk_current_study_info");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("user_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
