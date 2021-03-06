﻿using System;
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
        [StringLength(40)]
        public string Continent { get; set; }

        [Required]
        [StringLength(40)]
        public string Pays { get; set; }

        [Required]
        [StringLength(40)]
        public string Region { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

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