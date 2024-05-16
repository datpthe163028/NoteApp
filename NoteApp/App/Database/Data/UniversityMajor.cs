using System;
using System.Collections.Generic;

namespace NoteApp.App.Database.Data
{
    public partial class UniversityMajor
    {
        public UniversityMajor()
        {
            UniversityMajorSemesters = new HashSet<UniversityMajorSemester>();
        }

        public int UniversityMajorId { get; set; }
        public int? UniversityId { get; set; }
        public int? MajorId { get; set; }

        public virtual Major? Major { get; set; }
        public virtual University? University { get; set; }
        public virtual ICollection<UniversityMajorSemester> UniversityMajorSemesters { get; set; }
    }
}
