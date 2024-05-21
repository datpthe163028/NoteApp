using System;
using System.Collections.Generic;

namespace NoteApp.App.Database.Data
{
    public partial class CandidateRecruit
    {
        public int CandidateId { get; set; }
        public string? StudentCode { get; set; }
        public string? Name { get; set; }
        public int? ClubId { get; set; }

        public virtual Club? Club { get; set; }
    }
}
