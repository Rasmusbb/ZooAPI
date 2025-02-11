using System.ComponentModel.DataAnnotations.Schema;

namespace ZooAPI.models
{
    public class ZooKeeper
    {
        [ForeignKey("UserID")]
        public Guid UserID { get; set; }
        public User User { get; set; }

        [ForeignKey("EnclosureID")]
        public Guid EnclosureID { get; set; }
        public Enclosure Enclosure { get; set; }

    }
}
