using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NoteApp.App.Database.Data
{
    public partial class User
    {
        public User()
        {
            Foldernotes = new HashSet<Foldernote>();
            Grades = new HashSet<Grade>();
        }

        public int UserId { get; set; }
        public int? RoleId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public string? Pass { get; set; }
        public int? CurrentStudyInfoId { get; set; }
        public bool? Active { get; set; }
        [JsonIgnore]

        public virtual UniversityMajorSemester? CurrentStudyInfo { get; set; }
        [JsonIgnore]
        public virtual Role? Role { get; set; }
        [JsonIgnore]
        public virtual ICollection<Club> Clubs { get; set; }
        [JsonIgnore]
        public virtual ICollection<Foldernote> Foldernotes { get; set; }
        [JsonIgnore]
        public virtual ICollection<Grade> Grades { get; set; }
        [JsonIgnore]
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
