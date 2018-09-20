namespace Projet_Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Participants", "IDDossierReservation", "dbo.DossierReservations");
            DropIndex("dbo.Participants", new[] { "IDDossierReservation" });
            AlterColumn("dbo.Participants", "IDDossierReservation", c => c.Int());
            CreateIndex("dbo.Participants", "IDDossierReservation");
            AddForeignKey("dbo.Participants", "IDDossierReservation", "dbo.DossierReservations", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participants", "IDDossierReservation", "dbo.DossierReservations");
            DropIndex("dbo.Participants", new[] { "IDDossierReservation" });
            AlterColumn("dbo.Participants", "IDDossierReservation", c => c.Int(nullable: false));
            CreateIndex("dbo.Participants", "IDDossierReservation");
            AddForeignKey("dbo.Participants", "IDDossierReservation", "dbo.DossierReservations", "ID", cascadeDelete: false);
        }
    }
}
