using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NoteApp.App.Database.Data
{
    public partial class UniversityMajorSemester
    {
        public UniversityMajorSemester()
        {
            Subjects = new HashSet<Subject>();
            Users = new HashSet<User>();
        }

        public int UniversityMajorSemesterId { get; set; }
        public int? UniversityMajorId { get; set; }
        public int? SemesterId { get; set; }
        [JsonIgnore]

        public virtual Semester? Semester { get; set; }
        [JsonIgnore]
        public virtual UniversityMajor? UniversityMajor { get; set; }
        [JsonIgnore]
        public virtual ICollection<Subject> Subjects { get; set; }
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
