using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Projet_Web.Models
{
    public class AgenceVoyage
    {
        public int Id { get; set; }

        [Required]
        public string Nom { get; set; }

        public virtual List<Voyage> Voyages { get; set; }

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