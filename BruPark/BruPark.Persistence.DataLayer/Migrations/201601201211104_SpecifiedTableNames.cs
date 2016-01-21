namespace BruPark.Persistence.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpecifiedTableNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ParkingPOes", newName: "PARKINGS");
            RenameTable(name: "dbo.AddressPOes", newName: "ADDRESSES");
            RenameTable(name: "dbo.CompanyPOes", newName: "COMPANIES");
            RenameTable(name: "dbo.LocationPOes", newName: "LOCATIONS");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.LOCATIONS", newName: "LocationPOes");
            RenameTable(name: "dbo.COMPANIES", newName: "CompanyPOes");
            RenameTable(name: "dbo.ADDRESSES", newName: "AddressPOes");
            RenameTable(name: "dbo.PARKINGS", newName: "ParkingPOes");
        }
    }
}
