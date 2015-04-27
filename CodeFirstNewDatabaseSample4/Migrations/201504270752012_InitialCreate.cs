namespace CodeFirstNewDatabaseSample4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inspectors",
                c => new
                    {
                        InspectorId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.InspectorId);
            
            CreateTable(
                "dbo.Passangers",
                c => new
                    {
                        PassangerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        City = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        IdentityCard = c.String(),
                    })
                .PrimaryKey(t => t.PassangerId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        StartOfValidity = c.DateTime(nullable: false),
                        StopOfValidity = c.DateTime(nullable: false),
                        Passanger_PassangerId = c.Int(),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Passangers", t => t.Passanger_PassangerId)
                .Index(t => t.Passanger_PassangerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "Passanger_PassangerId", "dbo.Passangers");
            DropIndex("dbo.Tickets", new[] { "Passanger_PassangerId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Passangers");
            DropTable("dbo.Inspectors");
        }
    }
}
