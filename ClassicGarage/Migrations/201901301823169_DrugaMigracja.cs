namespace ClassicGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DrugaMigracja : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarModels", "Rok", c => c.Int(nullable: false));
            DropColumn("dbo.CarModels", "Year");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarModels", "Year", c => c.Int(nullable: false));
            DropColumn("dbo.CarModels", "Rok");
        }
    }
}
