using System;
using System.Collections.Generic;

namespace NoteApp.App.Database.Data
{
    public partial class Club
    {
        public Club()
        {
            CandidateRecruits = new HashSet<CandidateRecruit>();
        }

        public int ClubId { get; set; }
        public string? Name { get; set; }
        public string? UrlImg { get; set; }
        public int? ClubOwnerId { get; set; }
        public ulong? StatusRecruitment { get; set; }
        public string? Positions { get; set; }
        public string? DateProcedure { get; set; }
        public string? DateInterview { get; set; }

        public virtual User? ClubOwner { get; set; }
        public virtual ICollection<CandidateRecruit> CandidateRecruits { get; set; }
    }
}
