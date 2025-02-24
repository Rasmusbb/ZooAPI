using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ZooAPI.Interfaces;

namespace ZooAPI.models
{

    public enum statues
    {
        Healthy,
        Sick,
        Dead
    }

    public class Animal : IAnimal
    {
        [Key]
        public Guid AnimalID { get; set; }
        public string physicalID { get; set; }
        public string Name { get; set; }
        public statues statues { get; set; }
        public DateTime birthday { get; set; }
        public DateTime DeathDay { get; set; }
        public string characteristics { get; set; }

        public string specialNeeds { get; set; }
        public string Comments { get; set; }


        [ForeignKey("HealthJournalID")]
        public Guid? HealthJournalID { get; set; }
        public HealthJournal HealthJournal { get; set; }

        [ForeignKey("WellBeingReportID")]
        public Guid? WellBeingReportID { get; set; }
        public WellBeingReport wellBeingReport { get; set; }


        [ForeignKey("Species")]
        public Guid? SpeciesID {  get; set; }
        public Species Species { get; set; }
 
    }
}
