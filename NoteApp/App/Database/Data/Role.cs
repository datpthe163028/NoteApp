using System;
using System.Collections.Generic;

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

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
