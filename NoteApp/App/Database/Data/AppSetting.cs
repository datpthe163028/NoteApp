using System.ComponentModel.DataAnnotations.Schema;

namespace NoteApp.App.Database.Data
{
    public partial class AppSetting
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
       
        public string Key { get; set; }

        public string Value { get; set; }
    }
}
