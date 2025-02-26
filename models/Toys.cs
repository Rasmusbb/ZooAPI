using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooAPI.models
{
    public class Toys
    {
        [Key]
        public Guid ToyId { get; set; }
        public string ToyName { get; set; }

        [ForeignKey("EnclosureID")]
        public Guid EnclosureID { get; set; }
        public Enclosure Enclosure { get; set; }
    }
}
