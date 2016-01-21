namespace BruPark.Persistence.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PreparationsForDataImport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PARKINGS", "Disabled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ADDRESSES", "Street", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.COMPANIES", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.ADDRESSES", "Street");
            CreateIndex("dbo.COMPANIES", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.COMPANIES", new[] { "Name" });
            DropIndex("dbo.ADDRESSES", new[] { "Street" });
            AlterColumn("dbo.COMPANIES", "Name", c => c.String());
            AlterColumn("dbo.ADDRESSES", "Street", c => c.String());
            DropColumn("dbo.PARKINGS", "Disabled");
        }
    }
}
