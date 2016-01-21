namespace BruPark.Persistence.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StandaloneLocations1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LOCATIONS", "Longitude", c => c.Decimal(nullable: false, precision: 11, scale: 8));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LOCATIONS", "Longitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
