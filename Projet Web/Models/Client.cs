using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_Web.Models
{
    public class Client : Personne
    {
        public string Email { get; set; }

        public Client()
        {
        }
        public Client(string civ, string nom, string prenom, string adresse, string tel, DateTime dateNaissance)
        {
            Nom = nom;
            Prenom = prenom;
            Adresse = adresse;
            Civilite = civ;
            Telephone = tel;
            DateNaissance = dateNaissance;
        }
        public List<int> IDDossierReservation { get; set; }

        [ForeignKey("IDDossierReservation")]
        public List<DossierReservation> DossiersReservation { get; set; }
    }
}