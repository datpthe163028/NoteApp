using System;
using System.Collections.Generic;

namespace NoteApp.Data
{
    public partial class TypeScore
    {
        public TypeScore()
        {
            SubjectTypeScores = new HashSet<SubjectTypeScore>();
        }

        public int TypeScoreId { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<SubjectTypeScore> SubjectTypeScores { get; set; }
    }
}
