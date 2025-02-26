using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ZooAPI.Interfaces;

namespace ZooAPI.models
{
    public class Specie : ISpecies
    {
        public Guid SpecieID { get; set; }
        public string SpeciesName { get; set; }
        public bool Gotindividuals { get; set; }
        public ICollection<Animal> Animals { get; set; }
        public ICollection<Enclosure> Enclosures {get; set;}


    }
}
