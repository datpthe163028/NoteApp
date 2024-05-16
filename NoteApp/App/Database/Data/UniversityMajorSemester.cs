using System;
using System.Collections.Generic;

namespace NoteApp.App.Database.Data
{
    public partial class UniversityMajorSemester
    {
        public UniversityMajorSemester()
        {
            Subjects = new HashSet<Subject>();
            Users = new HashSet<User>();
        }

        public int UniversityMajorSemesterId { get; set; }
        public int? UniversityMajorId { get; set; }
        public int? SemesterId { get; set; }

        public virtual Semester? Semester { get; set; }
        public virtual UniversityMajor? UniversityMajor { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
