using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooAPI.models
{
    public class Incidents
    {
        [Key]
        public Guid IncidentsID { get; set; }
        public string Incident { get; set; }
        public DateTime created { get; set; }

        [ForeignKey("UserID")]
        public Guid UserID { get; set; }
        public User User { get; set; }
      
    }
}
