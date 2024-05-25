using System;
using System.Collections.Generic;

namespace NoteApp.Data
{
    public partial class Major
    {
        public Major()
        {
            UniversityMajors = new HashSet<UniversityMajor>();
        }

        public int MajorId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<UniversityMajor> UniversityMajors { get; set; }
    }
}
