namespace ClassicGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DziewiataSymfonia : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CarModels", "SalesDate");
            DropColumn("dbo.CarModels", "SalesAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarModels", "SalesAmount", c => c.Double());
            AddColumn("dbo.CarModels", "SalesDate", c => c.DateTime());
        }
    }
}
