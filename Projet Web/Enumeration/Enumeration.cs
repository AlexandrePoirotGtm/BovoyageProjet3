using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projet_Web.Enumeration
{
    public enum Etat
    {
        EnAttente,
        EnCours,
        Refusee,
        Acceptee
    }

    public enum TypeAssurance
    {
        Annulation
    }

    public enum RaisonAnnulationDossier
    {
        Client,
        PlacesInsuffisantes
    }
}
