using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooAPI.models
{
    public class HealthJournal
    {
        [Key]
        public Guid HealthJournalID { get; set; }

        public double lenght { get; set; }
        public  double height { get;set; }
        public double weight { get; set; }

        public DateTime Created { get; set; } 
        public DateTime LastUpdated { get; set; }

        public ICollection<Injurie> injuries { get; set; }
        public ICollection<Prescription> prescriptions { get; set; }

        [ForeignKey("UserID")]
        public Guid UserID { get; set; }
        public User User { get;set; }



    }
}
