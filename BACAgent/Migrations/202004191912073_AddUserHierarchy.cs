namespace BACAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddUserHierarchy : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserHierarchy",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    ParentUserId = c.String(nullable: false, maxLength: 128),
                    ChildUserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.Id })
                .ForeignKey("dbo.User", t => t.ParentUserId)
                .ForeignKey("dbo.User", t => t.ChildUserId)
                .Index(t => t.ChildUserId)
                .Index(t => t.ParentUserId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.UserHierarchy", "ParentUserId", "dbo.User");
            DropForeignKey("dbo.UserHierarchy", "ChildUserId", "dbo.User");
            DropTable("dbo.UserHierarchy");
        }
    }
}
