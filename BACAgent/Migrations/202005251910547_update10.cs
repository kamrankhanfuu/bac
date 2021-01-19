namespace BACAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update10 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInvites", "RoleId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInvites", "RoleId", c => c.Int(nullable: false));
        }
    }
}
