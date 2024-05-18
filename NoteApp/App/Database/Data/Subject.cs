using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NoteApp.App.Database.Data
{
    public partial class Subject
    {
        public Subject()
        {
            SubjectTypeScores = new HashSet<SubjectTypeScore>();
        }

        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public int? Belong { get; set; }
        [JsonIgnore]

        public virtual UniversityMajorSemester? BelongNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<SubjectTypeScore> SubjectTypeScores { get; set; }
    }
}
