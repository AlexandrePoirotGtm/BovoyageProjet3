using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projet_Web.Enumeration;

namespace Projet_Web.Models
{
    public class Assurance
    {
        public int ID { get; set; }

        public TypeAssurance TypeAssurance { get; set; }
        public decimal Montant { get; set; }
    }
}