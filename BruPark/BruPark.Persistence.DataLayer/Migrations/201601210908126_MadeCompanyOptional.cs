namespace BruPark.Persistence.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeCompanyOptional : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PARKINGS", "CompanyId", "dbo.COMPANIES");
            DropIndex("dbo.PARKINGS", new[] { "CompanyId" });
            AlterColumn("dbo.PARKINGS", "CompanyId", c => c.Int());
            CreateIndex("dbo.PARKINGS", "CompanyId");
            AddForeignKey("dbo.PARKINGS", "CompanyId", "dbo.COMPANIES", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PARKINGS", "CompanyId", "dbo.COMPANIES");
            DropIndex("dbo.PARKINGS", new[] { "CompanyId" });
            AlterColumn("dbo.PARKINGS", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.PARKINGS", "CompanyId");
            AddForeignKey("dbo.PARKINGS", "CompanyId", "dbo.COMPANIES", "Id", cascadeDelete: true);
        }
    }
}
