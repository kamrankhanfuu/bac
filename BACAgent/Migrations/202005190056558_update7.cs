namespace BACAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "AgentLicenseNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "AgentLicenseNumber");
        }
    }
}
