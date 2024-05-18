using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NoteApp.App.Database.Data
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
            Permissions = new HashSet<Permission>();
        }

        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        [JsonIgnore]

        public virtual ICollection<User> Users { get; set; }
        [JsonIgnore]

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
