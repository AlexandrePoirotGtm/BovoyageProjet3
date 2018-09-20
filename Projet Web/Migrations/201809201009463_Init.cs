namespace Projet_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AgenceVoyages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nom = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Voyages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateAller = c.DateTime(nullable: false),
                        DateRetour = c.DateTime(nullable: false),
                        PlacesDisponibles = c.Int(nullable: false),
                        PrixParPersonne = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDDestination = c.Int(nullable: false),
                        IDAgenceVoyage = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AgenceVoyages", t => t.IDAgenceVoyage, cascadeDelete: false)
                .ForeignKey("dbo.Destinations", t => t.IDDestination, cascadeDelete: false)
                .Index(t => t.IDDestination)
                .Index(t => t.IDAgenceVoyage);
            
            CreateTable(
                "dbo.Destinations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Continent = c.String(nullable: false, maxLength: 40),
                        Pays = c.String(nullable: false, maxLength: 40),
                        Region = c.String(nullable: false, maxLength: 40),
                        Description = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Assurances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TypeAssurance = c.Int(nullable: false),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DossierReservations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NumeroCarteBancaire = c.String(maxLength: 40),
                        PrixParPersonne = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EtatDossierReservation = c.Int(nullable: false),
                        RaisonAnnulationDossier = c.Int(nullable: false),
                        PrixTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IDVoyage = c.Int(nullable: false),
                        IDClient = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clients", t => t.IDClient, cascadeDelete: false)
                .ForeignKey("dbo.Voyages", t => t.IDVoyage, cascadeDelete: false)
                .Index(t => t.IDVoyage)
                .Index(t => t.IDClient);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 40),
                        Civilite = c.String(nullable: false, maxLength: 4),
                        Nom = c.String(nullable: false, maxLength: 40),
                        Prenom = c.String(nullable: false, maxLength: 40),
                        Adresse = c.String(nullable: false, maxLength: 100),
                        Telephone = c.String(nullable: false, maxLength: 40),
                        DateNaissance = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IDDossierReservation = c.Int(nullable: false),
                        Civilite = c.String(nullable: false, maxLength: 4),
                        Nom = c.String(nullable: false, maxLength: 40),
                        Prenom = c.String(nullable: false, maxLength: 40),
                        Adresse = c.String(nullable: false, maxLength: 100),
                        Telephone = c.String(nullable: false, maxLength: 40),
                        DateNaissance = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.DossierReservations", t => t.IDDossierReservation, cascadeDelete: false)
                .Index(t => t.IDDossierReservation);
            
            CreateTable(
                "dbo.DossierReservationAssurances",
                c => new
                    {
                        DossierReservation_ID = c.Int(nullable: false),
                        Assurance_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DossierReservation_ID, t.Assurance_ID })
                .ForeignKey("dbo.DossierReservations", t => t.DossierReservation_ID, cascadeDelete: false)
                .ForeignKey("dbo.Assurances", t => t.Assurance_ID, cascadeDelete: false)
                .Index(t => t.DossierReservation_ID)
                .Index(t => t.Assurance_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DossierReservations", "IDVoyage", "dbo.Voyages");
            DropForeignKey("dbo.Participants", "IDDossierReservation", "dbo.DossierReservations");
            DropForeignKey("dbo.DossierReservations", "IDClient", "dbo.Clients");
            DropForeignKey("dbo.DossierReservationAssurances", "Assurance_ID", "dbo.Assurances");
            DropForeignKey("dbo.DossierReservationAssurances", "DossierReservation_ID", "dbo.DossierReservations");
            DropForeignKey("dbo.Voyages", "IDDestination", "dbo.Destinations");
            DropForeignKey("dbo.Voyages", "IDAgenceVoyage", "dbo.AgenceVoyages");
            DropIndex("dbo.DossierReservationAssurances", new[] { "Assurance_ID" });
            DropIndex("dbo.DossierReservationAssurances", new[] { "DossierReservation_ID" });
            DropIndex("dbo.Participants", new[] { "IDDossierReservation" });
            DropIndex("dbo.DossierReservations", new[] { "IDClient" });
            DropIndex("dbo.DossierReservations", new[] { "IDVoyage" });
            DropIndex("dbo.Voyages", new[] { "IDAgenceVoyage" });
            DropIndex("dbo.Voyages", new[] { "IDDestination" });
            DropTable("dbo.DossierReservationAssurances");
            DropTable("dbo.Participants");
            DropTable("dbo.Clients");
            DropTable("dbo.DossierReservations");
            DropTable("dbo.Assurances");
            DropTable("dbo.Destinations");
            DropTable("dbo.Voyages");
            DropTable("dbo.AgenceVoyages");
        }
    }
}
