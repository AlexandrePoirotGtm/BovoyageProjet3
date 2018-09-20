using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projet_Web.Models
{
    public class Voyage
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateAller { get; set; }

        [Required]
        public DateTime DateRetour { get; set; }

        [Required]
        public int PlacesDisponibles { get; set; }

        [Required]
        public decimal PrixParPersonne { get; set; }

        public int IdDestination { get; set; }

        [ForeignKey("IdDestination")]
        public  Destination Destination { get; set; }

        public int IdAgenceVoyage { get; set; }

        [ForeignKey("IdAgenceVoyage")]
        public  AgenceVoyage AgenceVoyage { get; set; }

        //Implementation du constructeur par defaut nécéssaire à Entity
        public Voyage() { }

        public Voyage(DateTime dateAller, DateTime dateRetour, int placesDisponibles, decimal prixParPersonne,
                      Destination destination, AgenceVoyage agenceVoyage)
        {
            DateAller = dateAller;
            DateRetour = dateRetour;
            PlacesDisponibles = placesDisponibles;
            PrixParPersonne = prixParPersonne;
            IdDestination = destination.Id;
            IdAgenceVoyage = agenceVoyage.Id;
        }

        public Voyage(DateTime dateAller, DateTime dateRetour, int placesDisponibles, decimal prixParPersonne,
                      int idDestination, int idAgenceVoyage)
        {
            DateAller = dateAller;
            DateRetour = dateRetour;
            PlacesDisponibles = placesDisponibles;
            PrixParPersonne = prixParPersonne;
            IdDestination = idDestination;
            IdAgenceVoyage = idAgenceVoyage;
        }

        public void Reserver(int places)
        {

        }

        public override string ToString()
        {
            return $"{Destination} du {DateAller.ToShortDateString()} au {DateRetour.ToShortDateString()}";
        }
    }
}