using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        public virtual ICollection<UniversityMajor> UniversityMajors { get; set; }
    }
}
