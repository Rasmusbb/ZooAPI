using ZooAPI.Interfaces;
using ZooAPI.models;

namespace ZooAPI.DTOs
{
    public class SpeciesDTO
    {
        public string SpeciesName { get; set; }
        public bool Gotindividuals { get; set; }
        public ICollection<Animal> Animals { get; set; }
        public ICollection<Enclosure> enclosures { get; set; }


    }
    public class SpeciesDTOID : SpeciesDTO
    {
        public Guid SpeciesID { get; set; }
    }
}
