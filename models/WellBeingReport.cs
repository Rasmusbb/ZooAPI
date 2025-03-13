using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZooAPI.models
{
    public class WellBeingReport
    {
        [Key]
        public Guid WellBeingReportID { get; set; }
        public DateTime created { get; set; }
        public DateTime LastUpdated { get; set; }
        public ICollection<Incidents> Incidents {get; set;}

        [ForeignKey("UserID")]
        public Guid UserID { get; set; }
        public User User { get; set; }
    }
}
