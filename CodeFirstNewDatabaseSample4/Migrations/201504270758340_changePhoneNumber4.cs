namespace CodeFirstNewDatabaseSample4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePhoneNumber4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Passangers", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Passangers", "PhoneNumber", c => c.String());
        }
    }
}
