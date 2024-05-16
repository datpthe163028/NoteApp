using System;
using System.Collections.Generic;

namespace NoteApp.App.Database.Data
{
    public partial class University
    {
        public University()
        {
            UniversityMajors = new HashSet<UniversityMajor>();
        }

        public int UniversityId { get; set; }
        public string? UniversityName { get; set; }

        public virtual ICollection<UniversityMajor> UniversityMajors { get; set; }
    }
}
