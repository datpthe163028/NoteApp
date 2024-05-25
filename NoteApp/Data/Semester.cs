using System;
using System.Collections.Generic;

namespace NoteApp.Data
{
    public partial class Semester
    {
        public Semester()
        {
            UniversityMajorSemesters = new HashSet<UniversityMajorSemester>();
        }

        public int SemesterId { get; set; }
        public string? SemesterName { get; set; }

        public virtual ICollection<UniversityMajorSemester> UniversityMajorSemesters { get; set; }
    }
}
