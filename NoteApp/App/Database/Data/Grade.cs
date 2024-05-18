using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NoteApp.App.Database.Data
{
    public partial class Grade
    {
        public int GradeId { get; set; }
        public float? Score { get; set; }
        public int? UserId { get; set; }
        public int? SubjectTypeScoreId { get; set; }
        [JsonIgnore]

        public virtual SubjectTypeScore? SubjectTypeScore { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}
