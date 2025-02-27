
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ZooAPI.models;

namespace ZooAPI.DTOs
{
    public class AnimalDTO
    {
        public string physicalID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public statues statues { get; set; }
        public DateTime birthday { get; set; }
        public string specie { get; set; }
    }

    public class AnimalDTOID : AnimalDTO
    {
        public Guid AnimalID { get; set; }
    }
    public class animalDTOProfil: AnimalDTOID
    {
        public string characteristics { get; set; }
        public Guid HealthJournalID { get; set; }
        public DateTime DeathDay { get; set; }
        public Guid EnclosureID { get; set; }
        public string Comments { get; set; }
        public string specialNeeds { get; set; }

    }

}
