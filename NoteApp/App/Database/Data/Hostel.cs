using System.ComponentModel.DataAnnotations.Schema;

namespace NoteApp.App.Database.Data
{
    public class Hostel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? OwnerName { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? GoogleMapAddress { get; set; }
        public DateTime? ExistenceTime { get; set; }
    }
}
