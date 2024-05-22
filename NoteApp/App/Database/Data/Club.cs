using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonIgnore]
        public int? ClubOwnerId { get; set; }
        [JsonIgnore]
        public bool? StatusRecruitment { get; set; }
        public string? Positions { get; set; }
        public string? DateProcedure { get; set; }
        public string? DateInterview { get; set; }
        [JsonIgnore]

        public virtual User? ClubOwner { get; set; }
        [JsonIgnore]
        public virtual ICollection<CandidateRecruit> CandidateRecruits { get; set; }
    }
}
