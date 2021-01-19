namespace BACAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserXCompanies", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserXCompanies", "UserId", c => c.Int(nullable: false));
        }
    }
}
