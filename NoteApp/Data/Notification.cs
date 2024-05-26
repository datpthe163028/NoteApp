using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NoteApp.Data
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public string? Header { get; set; }
        public string? Content { get; set; }
        public int? UserId { get; set; }
        [JsonIgnore]
        public virtual User? User { get; set; }
    }
}
