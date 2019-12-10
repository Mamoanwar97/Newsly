namespace news.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminClass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Newsletters", "Title", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Newsletters", "Title", c => c.String(nullable: false));
        }
    }
}
