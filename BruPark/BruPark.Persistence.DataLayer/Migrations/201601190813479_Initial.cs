namespace BruPark.Persistence.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parkings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressDutchId = c.Int(nullable: false),
                        AddressFrenchId = c.Int(nullable: false),
                        Company_Name = c.String(),
                        CompanyId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        RecordId = c.String(nullable: false),
                        Spaces = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressDutchId, cascadeDelete: true)
                .ForeignKey("dbo.Addresses", t => t.AddressFrenchId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.AddressDutchId)
                .Index(t => t.AddressFrenchId)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parkings", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Parkings", "AddressFrenchId", "dbo.Addresses");
            DropForeignKey("dbo.Parkings", "AddressDutchId", "dbo.Addresses");
            DropIndex("dbo.Parkings", new[] { "LocationId" });
            DropIndex("dbo.Parkings", new[] { "AddressFrenchId" });
            DropIndex("dbo.Parkings", new[] { "AddressDutchId" });
            DropTable("dbo.Locations");
            DropTable("dbo.Addresses");
            DropTable("dbo.Parkings");
        }
    }
}
