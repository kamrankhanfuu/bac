namespace BACAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.User", "CompanyId");
            AddForeignKey("dbo.User", "CompanyId", "dbo.Companies", "CompanyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "CompanyId", "dbo.Companies");
            DropIndex("dbo.User", new[] { "CompanyId" });
            DropColumn("dbo.User", "CompanyId");
        }
    }
}
