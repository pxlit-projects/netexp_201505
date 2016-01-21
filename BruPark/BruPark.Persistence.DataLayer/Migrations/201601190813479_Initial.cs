namespace BruPark.Persistence.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ParkingPOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressDutchId = c.Int(),
                        AddressFrenchId = c.Int(),
                        CompanyId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        RecordId = c.String(nullable: false, maxLength: 255),
                        Spaces = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressPOes", t => t.AddressDutchId)
                .ForeignKey("dbo.AddressPOes", t => t.AddressFrenchId)
                .ForeignKey("dbo.CompanyPOes", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.LocationPOes", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.AddressDutchId)
                .Index(t => t.AddressFrenchId)
                .Index(t => t.CompanyId)
                .Index(t => t.LocationId)
                .Index(t => t.RecordId, unique: true);
            
            CreateTable(
                "dbo.AddressPOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyPOes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LocationPOes",
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
            DropForeignKey("dbo.ParkingPOes", "LocationId", "dbo.LocationPOes");
            DropForeignKey("dbo.ParkingPOes", "CompanyId", "dbo.CompanyPOes");
            DropForeignKey("dbo.ParkingPOes", "AddressFrenchId", "dbo.AddressPOes");
            DropForeignKey("dbo.ParkingPOes", "AddressDutchId", "dbo.AddressPOes");
            DropIndex("dbo.ParkingPOes", new[] { "RecordId" });
            DropIndex("dbo.ParkingPOes", new[] { "LocationId" });
            DropIndex("dbo.ParkingPOes", new[] { "CompanyId" });
            DropIndex("dbo.ParkingPOes", new[] { "AddressFrenchId" });
            DropIndex("dbo.ParkingPOes", new[] { "AddressDutchId" });
            DropTable("dbo.LocationPOes");
            DropTable("dbo.CompanyPOes");
            DropTable("dbo.AddressPOes");
            DropTable("dbo.ParkingPOes");
        }
    }
}
