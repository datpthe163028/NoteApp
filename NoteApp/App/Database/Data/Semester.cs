using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NoteApp.App.Database.Data
{
    public partial class Semester
    {
        public Semester()
        {
            UniversityMajorSemesters = new HashSet<UniversityMajorSemester>();
        }

        public int SemesterId { get; set; }
        public string? SemesterName { get; set; }
        [JsonIgnore]

        public virtual ICollection<UniversityMajorSemester> UniversityMajorSemesters { get; set; }
    }
}
