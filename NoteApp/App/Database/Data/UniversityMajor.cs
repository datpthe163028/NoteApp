using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonIgnore]

        public virtual Major? Major { get; set; }
        [JsonIgnore]
        public virtual University? University { get; set; }
        [JsonIgnore]
        public virtual ICollection<UniversityMajorSemester> UniversityMajorSemesters { get; set; }
    }
}
