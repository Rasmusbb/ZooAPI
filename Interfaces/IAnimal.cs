﻿using System.ComponentModel.DataAnnotations.Schema;
using ZooAPI.models;

namespace ZooAPI.Interfaces
{
    public interface IAnimal
    {
        public Guid AnimalID { get; set; }
        public string Name { get; set; }

        public statues statues { get; set; }
        public DateTime birthday { get; set; }
        public DateTime DeathDay { get; set; }
        public string specie { get; set; }
        public string characteristics { get; set; }
        public string specialNeeds { get; set; }
        public string Comments { get; set; }

        public Guid? WellBeingReportID { get; set; }
        public WellBeingReport wellBeingReport { get; set; }

        public Guid? EnclosureID { get; set; }
        public Enclosure Enclosure { get; set; }
    }
}
