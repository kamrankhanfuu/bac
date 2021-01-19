namespace BACAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInvites", "InviterUserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInvites", "InviterUserId", c => c.Int(nullable: false));
        }
    }
}
