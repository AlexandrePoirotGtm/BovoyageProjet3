using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Projet_Web.Enumeration;

namespace Projet_Web.Models
{
    public class DossierReservation
    {
        public int ID { get; set; }

        public string NumeroCarteBancaire { get; set; }

        public decimal PrixParPersonne { get; set; }

        public Etat EtatDossierReservation { get; set; }

        public RaisonAnnulationDossier RaisonAnnulationDossier { get; set; }

        public decimal PrixTotal { get; set; }

        public int IDVoyage { get; set; }
        [ForeignKey("IDVoyage")]
        public Voyage Voyage { get; set; }

        public int IDClient { get; set; }
        [ForeignKey("IDClient")]
        public Client Client { get; set; }

        public List<int> IDParticipants { get; set; }
        [ForeignKey("IDParticipants")]
        public List<Participant> Participants { get; set; }

        [ForeignKey("IDAssurances")]
        public List<int> IDAssurances { get; set; }
        public List<Assurance> Assurances { get; set; }

        public DossierReservation()
        {
        }
        public DossierReservation(string ncb, decimal prix, Voyage v, Client c)
        {
            NumeroCarteBancaire = ncb;
            PrixParPersonne = prix;
            Voyage = v;
            Client = c;
            EtatDossierReservation = Etat.EnAttente;
        }
        public DossierReservation(string ncb, decimal prix, Voyage v, Client c, List<Participant> p_s)
        {
            NumeroCarteBancaire = ncb;
            PrixParPersonne = prix;
            Voyage = v;
            Client = c;
            Participants = p_s;
            EtatDossierReservation = Etat.EnAttente;
        }

        void Annuler(RaisonAnnulationDossier raison)
        {
            RaisonAnnulationDossier = raison;
            EtatDossierReservation = Etat.Refusee;

        }

        void ValiderSolvabiliter()
        {
            EtatDossierReservation = Etat.EnCours;
        }

        void Accepter()
        {
            EtatDossierReservation = Etat.Acceptee;
        }
    }
}