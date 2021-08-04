namespace ClassicGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CzwartaMigracja : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarModels", "Make", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CarModels", "Make", c => c.String());
        }
    }
}
