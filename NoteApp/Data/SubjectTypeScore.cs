using System;
using System.Collections.Generic;

namespace NoteApp.Data
{
    public partial class SubjectTypeScore
    {
        public SubjectTypeScore()
        {
            Grades = new HashSet<Grade>();
        }

        public int SubjectTypeScoreId { get; set; }
        public int? SubjectId { get; set; }
        public int? TypeScoreId { get; set; }

        public virtual Subject? Subject { get; set; }
        public virtual TypeScore? TypeScore { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
