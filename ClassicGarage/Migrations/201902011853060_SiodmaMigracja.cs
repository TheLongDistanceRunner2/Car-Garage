namespace ClassicGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SiodmaMigracja : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarModels", "SalesDate", c => c.DateTime());
            AlterColumn("dbo.CarModels", "SalesAmount", c => c.Double());
            AlterColumn("dbo.PartsModels", "SalesAmount", c => c.Double());
            AlterColumn("dbo.PartsModels", "SalesDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PartsModels", "SalesDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PartsModels", "SalesAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.CarModels", "SalesAmount", c => c.Double(nullable: false));
            AlterColumn("dbo.CarModels", "SalesDate", c => c.DateTime(nullable: false));
        }
    }
}
