namespace ClassicGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OsmaMigracja : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AdvertismentModels", "SalesDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.AdvertismentModels", "SalesAmount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AdvertismentModels", "SalesAmount");
            DropColumn("dbo.AdvertismentModels", "SalesDate");
        }
    }
}
