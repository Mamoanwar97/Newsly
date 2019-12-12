namespace news.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminattributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "AdminName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Role", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Role");
            DropColumn("dbo.AspNetUsers", "AdminName");
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
