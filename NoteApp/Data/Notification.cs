using System;
using System.Collections.Generic;

namespace NoteApp.Data
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public string? Header { get; set; }
        public string? Content { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
