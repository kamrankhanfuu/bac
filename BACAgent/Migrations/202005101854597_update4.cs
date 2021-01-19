namespace BACAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInvites",
                c => new
                    {
                        UserInviteId = c.Int(nullable: false, identity: true),
                        UserInviteGuid = c.Guid(nullable: false, identity: true),
                        InviterUserId = c.Int(nullable: false),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        EmailBody = c.String(),
                        EmailSent = c.Boolean(nullable: false),
                        RoleId = c.Int(nullable: false),
                        IsInviteAcceptated = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyBy = c.String(nullable: false, maxLength: 100),
                        ModifyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserInviteId);
            
            AddColumn("dbo.Companies", "CreateBy", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Companies", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Companies", "ModifyBy", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Companies", "ModifyDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserXCompanies", "CreateBy", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.UserXCompanies", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserXCompanies", "ModifyBy", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.UserXCompanies", "ModifyDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserXCompanies", "ModifyDate");
            DropColumn("dbo.UserXCompanies", "ModifyBy");
            DropColumn("dbo.UserXCompanies", "CreateDate");
            DropColumn("dbo.UserXCompanies", "CreateBy");
            DropColumn("dbo.Companies", "ModifyDate");
            DropColumn("dbo.Companies", "ModifyBy");
            DropColumn("dbo.Companies", "CreateDate");
            DropColumn("dbo.Companies", "CreateBy");
            DropTable("dbo.UserInvites");
        }
    }
}
