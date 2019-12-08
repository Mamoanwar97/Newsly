namespace news.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class date : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Newsletters", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Newsletters", "Date", c => c.String());
        }
    }
}
