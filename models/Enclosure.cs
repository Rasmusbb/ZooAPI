using System.ComponentModel.DataAnnotations;
using ZooAPI.Interfaces;

namespace ZooAPI.models
{
    public class Enclosure : IEnclosure
    {
        [Key]
        public Guid EnclosureID { get; set; }

        public ICollection<ZooKeeper> ZooKeepers { get; set; }

    }
}
