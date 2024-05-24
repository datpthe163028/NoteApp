using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Hosting;
using NoteApp.App.Database.Data;
using System.Security.Principal;

namespace NoteApp.App.DesignPatterns.Repository
{

    public class UnitOfWork
    {


        private readonly IRepository<Club> clubs;
        private readonly IRepository<CandidateRecruit> candidateRecruits;
        private readonly IRepository<Notification> notifications;
        private readonly IRepository<Foldernote> folderNotes;
        private readonly IRepository<Grade> grades;
        private readonly IRepository<Major> majors;
        private readonly IRepository<Permission> permissions;
        private readonly IRepository<Role> roles;
        private readonly IRepository<Semester> semesters;
        private readonly IRepository<SimpleNote> simpleNotes;
        private readonly IRepository<Subject> subjects;
        private readonly IRepository<SubjectTypeScore> subjectTypeScores;
        private readonly IRepository<ToDoListNote> toDoListNotes;
        private readonly IRepository<TypeScore> typeScores;
        private readonly IRepository<University> universities;
        private readonly IRepository<UniversityMajor> universityMajors;
        private readonly IRepository<UniversityMajorSemester> universityMajorSemesters;
        private readonly IRepository<User> users;
        private readonly IRepository<Filenote> fileNotes;
        private readonly noteappContext DbContext;

        public UnitOfWork(noteappContext dbContext)
        {
            DbContext = dbContext;
        }

        public IRepository<Filenote> FileNotes => fileNotes ?? new Repository<Filenote>(DbContext);
        public IRepository<Club> Clubs => clubs ?? new Repository<Club>(DbContext);
        public IRepository<CandidateRecruit> CandidateRecruits => candidateRecruits ?? new Repository<CandidateRecruit>(DbContext);
        public IRepository<Notification> Notifications => notifications ?? new Repository<Notification>(DbContext);
        public IRepository<Foldernote> FolderNotes => folderNotes ?? new Repository<Foldernote>(DbContext);
        public IRepository<Grade> Grades => grades ?? new Repository<Grade>(DbContext);
        public IRepository<Major> Majors => majors ?? new Repository<Major>(DbContext);
        public IRepository<Permission> Permissions => permissions ?? new Repository<Permission>(DbContext);
        public IRepository<Role> Roles => roles ?? new Repository<Role>(DbContext);
        public IRepository<Semester> Semesters => semesters ?? new Repository<Semester>(DbContext);
        public IRepository<SimpleNote> SimpleNotes => simpleNotes ?? new Repository<SimpleNote>(DbContext);
        public IRepository<Subject> Subjects => subjects ?? new Repository<Subject>(DbContext);
        public IRepository<SubjectTypeScore> SubjectTypeScores => subjectTypeScores ?? new Repository<SubjectTypeScore>(DbContext);
        public IRepository<ToDoListNote> ToDoListNotes => toDoListNotes ?? new Repository<ToDoListNote>(DbContext);
        public IRepository<TypeScore> TypeScores => typeScores ?? new Repository<TypeScore>(DbContext);
        public IRepository<University> Universities => universities ?? new Repository<University>(DbContext);
        public IRepository<UniversityMajor> UniversityMajors => universityMajors ?? new Repository<UniversityMajor>(DbContext);

        public IRepository<UniversityMajorSemester> UniversityMajorSemesters => universityMajorSemesters ?? new Repository<UniversityMajorSemester>(DbContext);
        public IRepository<User> Users => users ?? new Repository<User>(DbContext);


        public void SaveChanges()
        {
            using (var transactionResult = DbContext.Database.BeginTransaction(System.Data.IsolationLevel.Snapshot))
            {
                try
                {
                    DbContext.SaveChanges();
                    transactionResult.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SaveChanges: " + ex.GetBaseException());
                    transactionResult.Rollback();
                    throw;
                }
            }

        }

        public async Task SaveChangesAsync()
        {
            using (var transactionResult = await DbContext.Database.BeginTransactionAsync(System.Data.IsolationLevel.Snapshot))
            {
                try
                {
                    await DbContext.SaveChangesAsync();
                    await transactionResult.CommitAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SaveChangesAsync: " + ex.GetBaseException());
                    await transactionResult.RollbackAsync();
                    throw;
                }
            }
        }


        public IDbContextTransaction BeginTransaction()
        {
            return DbContext.Database.BeginTransaction();
        }

    }
}
