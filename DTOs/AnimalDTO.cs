
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ZooAPI.models;

namespace ZooAPI.DTOs
{
    public class AnimalDTO
    {
        public string Name { get; set; }
        public statues statues { get; set; }
        public DateTime birthday { get; set; }
        public string specie { get; set; }
        public string characteristics { get; set; }
        public string specialNeeds { get; set; }
        public string Comments { get; set; }
    }

    public class AnimalDTODeath : AnimalDTO
    {
        public DateTime DeathDay { get; set; }
    }
    public class AnimalDTOJournals : AnimalDTO
    {
        public Guid HealthJournalID { get; set; }
        public Guid EnclosureID { get; set; }
    }
    public class AnimalDTOID : AnimalDTO
    {
        public Guid AnimalID { get; set; }
    }

}
