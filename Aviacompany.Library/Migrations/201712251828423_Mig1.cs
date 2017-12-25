namespace Aviacompany.Library.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "AppUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Requests", new[] { "AppUserId" });
            DropColumn("dbo.Requests", "AppUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "AppUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Requests", "AppUserId");
            AddForeignKey("dbo.Requests", "AppUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
