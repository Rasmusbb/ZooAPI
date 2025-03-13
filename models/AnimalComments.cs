using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooAPI.models
{
    public class AnimalComments
    {
        [Key]
        public Guid CommentID { get; set; }
        public string Comment { get; set; }

        [ForeignKey("AnimalID")]
        public Guid AnimalID { get; set; }
        public Animal Animal { get; set; }
    }
}
