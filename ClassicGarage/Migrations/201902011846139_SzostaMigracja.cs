namespace ClassicGarage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SzostaMigracja : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OwnerModels", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.OwnerModels", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OwnerModels", "LastName", c => c.String());
            AlterColumn("dbo.OwnerModels", "FirstName", c => c.String());
        }
    }
}
