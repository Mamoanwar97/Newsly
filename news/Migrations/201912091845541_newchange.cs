namespace news.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Newsletters", "Author", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Newsletters", "Author", c => c.String(nullable: false));
        }
    }
}
