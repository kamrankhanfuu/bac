namespace BACAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "IsDisabled", c => c.Boolean());
            AddColumn("dbo.User", "IsDeleted", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "IsDeleted");
            DropColumn("dbo.User", "IsDisabled");
        }
    }
}
