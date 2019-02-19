namespace RestaurantApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Restaurants", "Name", c => c.String());
            AlterColumn("dbo.Restaurants", "Address", c => c.String());
            AlterColumn("dbo.Restaurants", "Schedule", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Restaurants", "Schedule", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false));
        }
    }
}
