using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Hosting;
using NoteApp.App.Database.Data;
using NoteApp.App.DesignPatterns.Repository;
using System.Security.Principal;

namespace NoteApp.App.DesignPatterns.UnitOfWork
{

    public class UnitOfWork 
    {
        private readonly noteappContext DbContext;
        public IRepository<Filenote> FileNotes {  get;}
        public IRepository<Foldernote> FolderNotes { get; }
        public IRepository<Grade> Grades { get; }
        public IRepository<Major> Majors { get; }
        public IRepository<Permission> Permissions { get; }
        public IRepository<Role> Roles { get; }
        public IRepository<Semester> Semesters { get; }
        public IRepository<SimpleNote> SimpleNotes { get; }
        public IRepository<Subject> Subjects { get; }
        public IRepository<SubjectTypeScore> SubjectTypeScores { get; }
        public IRepository<ToDoListNote> ToDoListNotes { get; }
        public IRepository<TypeScore> TypeScores { get; }
        public IRepository<University> Universities { get; }
        public IRepository<UniversityMajor> UniversityMajors { get; }
        public IRepository<UniversityMajorSemester> UniversityMajorSemesters { get; }
        public IRepository<User> Users { get; }

        public UnitOfWork(noteappContext ct, IRepository<Filenote> FileNotes_, IRepository<Foldernote> FolderNotes_, IRepository<Grade> Grades_, IRepository<Major> Majors_, IRepository<Permission> Permissions_,
                          IRepository<Role> Roles_, IRepository<Semester> Semesters_, IRepository<SimpleNote> SimpleNotes_, IRepository<Subject> Subjects_, IRepository<SubjectTypeScore> SubjectTypeScores_,
        IRepository<ToDoListNote> ToDoListNotes_, IRepository<TypeScore> TypeScores_, IRepository<University> Universities_, IRepository<UniversityMajor> UniversityMajors_, IRepository<UniversityMajorSemester> UniversityMajorSemesters_, IRepository<User> Users_)
        {
            DbContext = ct;
            FileNotes = FileNotes_;
            FolderNotes = FolderNotes_;
            Grades = Grades_;
            Majors = Majors_;
            Permissions = Permissions_;
            Roles = Roles_;
            Semesters = Semesters_;
            SimpleNotes = SimpleNotes_;
            Subjects = Subjects_;
            SubjectTypeScores = SubjectTypeScores_;
            ToDoListNotes = ToDoListNotes_;
            TypeScores = TypeScores_;
            Universities = Universities_;
            UniversityMajors = UniversityMajors_;
            UniversityMajorSemesters = UniversityMajorSemesters_;
            Users = Users_;

        }



        public void SaveChanges()
        {
            using (var transactionResult = DbContext.Database.BeginTransaction(System.Data.IsolationLevel.Snapshot))
            {
                try
                {
                    DbContext.SaveChanges();
                    transactionResult.Commit();
                }
                catch (System.Exception ex)
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
                catch (System.Exception ex)
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
