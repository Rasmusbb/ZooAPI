using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooAPI.models
{
    public class Injurie
    {
        [Key]
        public Guid InjurieID { get; set; }
        public string injuie { get; set; }

        [ForeignKey("HealthJournalID")]
        public Guid HealthJournalID { get; set;}
        public HealthJournal healthJournal { get; set; }

    }
}
