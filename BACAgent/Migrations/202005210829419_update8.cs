namespace BACAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update8 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserXCompanies", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserXCompanies", "UserId");
            AddForeignKey("dbo.UserXCompanies", "UserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserXCompanies", "UserId", "dbo.User");
            DropIndex("dbo.UserXCompanies", new[] { "UserId" });
            AlterColumn("dbo.UserXCompanies", "UserId", c => c.String());
        }
    }
}
