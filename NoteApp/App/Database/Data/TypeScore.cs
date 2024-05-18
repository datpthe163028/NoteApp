using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NoteApp.App.Database.Data
{
    public partial class TypeScore
    {
        public TypeScore()
        {
            SubjectTypeScores = new HashSet<SubjectTypeScore>();
        }

        public int TypeScoreId { get; set; }
        public string? Name { get; set; }
        [JsonIgnore]

        public virtual ICollection<SubjectTypeScore> SubjectTypeScores { get; set; }
    }
}
