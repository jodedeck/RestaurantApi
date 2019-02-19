namespace RestaurantApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "Schedule", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "Schedule");
        }
    }
}
