using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projet_Web.Models
{
    public class Destination
    {
        public int Id { get; set; }

        [Required]
        public string Continent { get; set; }

        [Required]
        public string Pays { get; set; }

        [Required]
        public string Region { get; set; }

        public string Description { get; set; }

        public List<int> IDVoyages { get; set; }

        [ForeignKey("IDVoyages")]
        public List<Voyage> Voyages { get; set; }

        public Destination() { }

        public Destination(string continent, string pays, string region)
        {
            Continent = continent;
            Pays = pays;
            Region = region;
        }

        public override string ToString()
        {
            return $"{Pays} : {Region}";
        }
    }
}