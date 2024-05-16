using System;
using System.Collections.Generic;

namespace NoteApp.App.Database.Data
{
    public partial class User
    {
        public User()
        {
            Foldernotes = new HashSet<Foldernote>();
            Grades = new HashSet<Grade>();
        }

        public int UserId { get; set; }
        public int? RoleId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Pass { get; set; }
        public int? CurrentStudyInfoId { get; set; }

        public virtual UniversityMajorSemester? CurrentStudyInfo { get; set; }
        public virtual Role? Role { get; set; }
        public virtual ICollection<Foldernote> Foldernotes { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
