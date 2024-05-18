using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NoteApp.App.Database.Data
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
        [JsonIgnore]

        public virtual Subject? Subject { get; set; }
        [JsonIgnore]
        public virtual TypeScore? TypeScore { get; set; }
        [JsonIgnore]
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
