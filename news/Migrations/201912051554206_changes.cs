namespace news.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Newsletters", "Author", c => c.String());
            AlterColumn("dbo.Newsletters", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Newsletters", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Newsletters", "Description", c => c.String());
            AlterColumn("dbo.Newsletters", "Title", c => c.String());
            DropColumn("dbo.Newsletters", "Author");
        }
    }
}
