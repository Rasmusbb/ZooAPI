using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZooAPI.Interfaces;

namespace ZooAPI.models
{

    public enum EnclosureStatues
    {
        Empty,
        Maintenance,
        Operational
    }
    public class Enclosure : IEnclosure
    {
        [Key]
        public Guid EnclosureID { get; set; }
        public string EnclosureName { get; set; }
        public EnclosureStatues Statues { get; set; }
        public ICollection<Specie> Species { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Toys> Toys { get; set; }


    }

    
}
