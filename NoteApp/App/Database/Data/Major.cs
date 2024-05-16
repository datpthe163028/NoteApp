using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NoteApp.App.Database.Data
{
    public partial class Major
    {
        public Major()
        {
            UniversityMajors = new HashSet<UniversityMajor>();
        }

        public int MajorId { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<UniversityMajor> UniversityMajors { get; set; }
    }
}
