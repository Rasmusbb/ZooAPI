using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZooAPI.Interfaces;

namespace ZooAPI.models
{
    public class Enclosure : IEnclosure
    {
        [Key]
        public Guid EnclosureID { get; set; }
        public string EnclosureName { get; set; }
        public string Location { get; set; }
        [ForeignKey("UserID")]
        public Guid UserID { get; set; }
        public User User { get; set; }
        [ForeignKey("SpeciesID")]
        public Guid SpeciesID { get; set; }
        public Species Species { get; set; }


    }

    
}
