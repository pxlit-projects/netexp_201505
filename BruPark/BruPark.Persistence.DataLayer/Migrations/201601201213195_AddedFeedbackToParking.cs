namespace BruPark.Persistence.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFeedbackToParking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FEEDBACKS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Available = c.Boolean(nullable: false),
                        ParkingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PARKINGS", t => t.ParkingId, cascadeDelete: true)
                .Index(t => t.ParkingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FEEDBACKS", "ParkingId", "dbo.PARKINGS");
            DropIndex("dbo.FEEDBACKS", new[] { "ParkingId" });
            DropTable("dbo.FEEDBACKS");
        }
    }
}
