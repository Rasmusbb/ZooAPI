using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooAPI.models
{
    public class Animal
    {
        [Key]
        public Guid AnimalID { get; set; }

        [ForeignKey("EnclosureID")]
        public Guid EnclosureID {  get; set; }
        public Enclosure Enclosure { get; set; }
 
    }
}
