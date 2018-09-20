using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace Projet_Web.Models
{
    public class AgenceVoyage
    {
        public int ID { get; set; }

        [Required]
        public string Nom { get; set; }


        [ForeignKey("IDVoyages")]
        public List<Voyage> Voyages { get; set; }

        //Implementation du constructeur par defaut nécéssaire à Entity
        public AgenceVoyage() { }

        public AgenceVoyage(string nom)
        {
            Nom = Nom;
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}