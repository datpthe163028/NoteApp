using System;
using System.Collections.Generic;

namespace NoteApp.Data
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

        public virtual UniversityMajorSemester? BelongNavigation { get; set; }
        public virtual ICollection<SubjectTypeScore> SubjectTypeScores { get; set; }
    }
}
