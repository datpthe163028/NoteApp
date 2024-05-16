using System;
using System.Collections.Generic;

namespace NoteApp.App.Database.Data
{
    public partial class Grade
    {
        public int GradeId { get; set; }
        public float? Score { get; set; }
        public int? UserId { get; set; }
        public int? SubjectTypeScoreId { get; set; }

        public virtual SubjectTypeScore? SubjectTypeScore { get; set; }
        public virtual User? User { get; set; }
    }
}
