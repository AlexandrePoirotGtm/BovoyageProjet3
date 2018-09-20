using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet_Web.Models
{
    public abstract class Personne
    {
        public int ID { get; set; }

        [Required]
        public string Civilite { get; set; }

        [Required]
        public string Nom { get; set; }

        [Required]
        public string Prenom { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required]
        public DateTime DateNaissance { get; set; }

        [NotMapped]
        public int Age
        {
            get
            {
                DateTime today = DateTime.Today;
                int age = today.Year - DateNaissance.Year;
                return age;
            }
        }
    }
}