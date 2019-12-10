namespace news.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subscriberequried : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Subscribers", "email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Subscribers", "email", c => c.String());
        }
    }
}
