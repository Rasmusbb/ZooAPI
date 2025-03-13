using System.ComponentModel.DataAnnotations.Schema;
using ZooAPI.models;

namespace ZooAPI.DTOs
{
    public class EnclosureDTO
    {
        public string EnclosureName { get; set; }
        public double Size { get; set; }

        public double State { get; set;
        }
    }


    public  class EnclosureDTOID : EnclosureDTO
    {
        public Guid EnclosureID { get; set; }
    }
}
