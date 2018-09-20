using Projet_Web.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Projet_Web.Migrations
{
    public class Configuration : DbMigrationsConfiguration<BoVoyageDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
    }
}