using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NoteApp.App.Database.Data
{
    public partial class Permission
    {
        public Permission()
        {
            Roles = new HashSet<Role>();
        }

        public int PermissionId { get; set; }
        public string? PermissionName { get; set; }
        [JsonIgnore]

        public virtual ICollection<Role> Roles { get; set; }
    }
}
