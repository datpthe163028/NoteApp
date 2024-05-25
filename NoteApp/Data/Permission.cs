using System;
using System.Collections.Generic;

namespace NoteApp.Data
{
    public partial class Permission
    {
        public Permission()
        {
            Roles = new HashSet<Role>();
        }

        public int PermissionId { get; set; }
        public string? PermissionName { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
