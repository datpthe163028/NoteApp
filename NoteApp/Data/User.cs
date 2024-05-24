﻿using System;
using System.Collections.Generic;

namespace NoteApp.Data
{
    public partial class User
    {
        public User()
        {
            Clubs = new HashSet<Club>();
            Foldernotes = new HashSet<Foldernote>();
            Grades = new HashSet<Grade>();
            Notifications = new HashSet<Notification>();
        }

        public int UserId { get; set; }
        public int? RoleId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Pass { get; set; }
        public int? CurrentStudyInfoId { get; set; }
        public ulong? Active { get; set; }

        public virtual UniversityMajorSemester? CurrentStudyInfo { get; set; }
        public virtual Role? Role { get; set; }
        public virtual ICollection<Club> Clubs { get; set; }
        public virtual ICollection<Foldernote> Foldernotes { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
