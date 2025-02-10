using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooAPI.models
{
    public class HealthJournal
    {
        [Key]
        public Guid HealthJournalID { get; set; }


        [ForeignKey("AnimalID")]
        public Guid AnimalID { get; set; }
    }
}
