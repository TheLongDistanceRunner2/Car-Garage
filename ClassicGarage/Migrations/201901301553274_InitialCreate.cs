namespace ClassicGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvertismentModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarId = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarModels", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        VIN = c.Int(nullable: false),
                        Name = c.String(),
                        Picture = c.String(),
                        PurchaseDate = c.DateTime(nullable: false),
                        PurchaseAmount = c.Double(nullable: false),
                        SalesDate = c.DateTime(nullable: false),
                        SalesAmount = c.Double(nullable: false),
                        OwnerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OwnerModels", t => t.OwnerID, cascadeDelete: true)
                .Index(t => t.OwnerID);
            
            CreateTable(
                "dbo.OwnerModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNo = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PartsModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarId = c.Int(nullable: false),
                        Name = c.String(),
                        CatalogNo = c.Int(nullable: false),
                        PurchaseAmount = c.Double(nullable: false),
                        SalesAmount = c.Double(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        SalesDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarModels", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId);
            
            CreateTable(
                "dbo.RepairsModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        RepairPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarModels", t => t.CarId, cascadeDelete: true)
                .Index(t => t.CarId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AdvertismentModels", "CarId", "dbo.CarModels");
            DropForeignKey("dbo.RepairsModels", "CarId", "dbo.CarModels");
            DropForeignKey("dbo.PartsModels", "CarId", "dbo.CarModels");
            DropForeignKey("dbo.CarModels", "OwnerID", "dbo.OwnerModels");
            DropIndex("dbo.RepairsModels", new[] { "CarId" });
            DropIndex("dbo.PartsModels", new[] { "CarId" });
            DropIndex("dbo.CarModels", new[] { "OwnerID" });
            DropIndex("dbo.AdvertismentModels", new[] { "CarId" });
            DropTable("dbo.RepairsModels");
            DropTable("dbo.PartsModels");
            DropTable("dbo.OwnerModels");
            DropTable("dbo.CarModels");
            DropTable("dbo.AdvertismentModels");
        }
    }
}
