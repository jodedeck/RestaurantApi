namespace RestaurantApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "UserName");
            DropColumn("dbo.Comments", "CommentDate");
        }
    }
}
