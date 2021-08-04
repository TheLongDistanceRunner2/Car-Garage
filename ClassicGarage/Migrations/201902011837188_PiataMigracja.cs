namespace ClassicGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PiataMigracja : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CarModels", "Model", c => c.String(nullable: false));
            AlterColumn("dbo.CarModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.CarModels", "Picture", c => c.String(nullable: false));
            AlterColumn("dbo.PartsModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.RepairsModels", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.RepairsModels", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RepairsModels", "Description", c => c.String());
            AlterColumn("dbo.RepairsModels", "Name", c => c.String());
            AlterColumn("dbo.PartsModels", "Name", c => c.String());
            AlterColumn("dbo.CarModels", "Picture", c => c.String());
            AlterColumn("dbo.CarModels", "Name", c => c.String());
            AlterColumn("dbo.CarModels", "Model", c => c.String());
        }
    }
}
