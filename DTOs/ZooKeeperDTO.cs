namespace ZooAPI.DTOs
{
    public class ZooKeeperDTO : UserDTOID
    {
        public ICollection<EnclosureDTO> Enclosures { get; set; } 
    }
}
