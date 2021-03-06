namespace RestaurantApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurants", "ImageUrl");
        }
    }
}
