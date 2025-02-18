using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ZooAPI.models
{
    public class WellBeingReport
    {
        [Key]
        public Guid WellBeingReportID { get; set; }
    }
}
