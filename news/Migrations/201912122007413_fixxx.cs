namespace news.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixxx : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "Role", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Role", c => c.String());
        }
    }
}
