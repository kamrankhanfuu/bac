namespace BACAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Templates", "DocumentId", "dbo.Documents");
            DropIndex("dbo.Templates", new[] { "DocumentId" });
            CreateTable(
                "dbo.TemplateXDocuments",
                c => new
                    {
                        TemplateXDocumentId = c.Int(nullable: false, identity: true),
                        TemplateId = c.Int(nullable: false),
                        DocumentId = c.Int(nullable: false),
                        DocumentOrder = c.Int(nullable: false),
                        IsRequired = c.Boolean(nullable: false),
                        CreateBy = c.String(nullable: false, maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyBy = c.String(nullable: false, maxLength: 100),
                        ModifyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TemplateXDocumentId)
                .ForeignKey("dbo.Documents", t => t.DocumentId)
                .ForeignKey("dbo.Templates", t => t.TemplateId)
                .Index(t => t.TemplateId)
                .Index(t => t.DocumentId);
            
            DropColumn("dbo.Templates", "DocumentId");
            DropColumn("dbo.Templates", "DocumentOrder");
            DropColumn("dbo.Templates", "IsRequired");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Templates", "IsRequired", c => c.Boolean(nullable: false));
            AddColumn("dbo.Templates", "DocumentOrder", c => c.Int(nullable: false));
            AddColumn("dbo.Templates", "DocumentId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TemplateXDocuments", "TemplateId", "dbo.Templates");
            DropForeignKey("dbo.TemplateXDocuments", "DocumentId", "dbo.Documents");
            DropIndex("dbo.TemplateXDocuments", new[] { "DocumentId" });
            DropIndex("dbo.TemplateXDocuments", new[] { "TemplateId" });
            DropTable("dbo.TemplateXDocuments");
            CreateIndex("dbo.Templates", "DocumentId");
            AddForeignKey("dbo.Templates", "DocumentId", "dbo.Documents", "DocumentId");
        }
    }
}
