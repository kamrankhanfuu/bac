namespace BACAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.UserXCompanies",
                c => new
                    {
                        UserXCompanyId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserXCompanyId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserXCompanies", "CompanyId", "dbo.Companies");
            DropIndex("dbo.UserXCompanies", new[] { "CompanyId" });
            DropTable("dbo.UserXCompanies");
            DropTable("dbo.Companies");
        }
    }
}
