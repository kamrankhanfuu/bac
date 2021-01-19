namespace BACAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        ContractId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        ContractStatusId = c.Int(nullable: false),
                        Description = c.String(),
                        CreateBy = c.String(maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyBy = c.String(maxLength: 100),
                        ModifyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContractId)
                .ForeignKey("dbo.ContractStatus", t => t.ContractStatusId)
                .Index(t => t.ContractStatusId);
            
            CreateTable(
                "dbo.ContractStatus",
                c => new
                    {
                        ContractStatusId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateBy = c.String(maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyBy = c.String(maxLength: 100),
                        ModifyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContractStatusId);
            
            CreateTable(
                "dbo.ContractXDocumentInputs",
                c => new
                    {
                        ContractXDocumentInputId = c.Int(nullable: false, identity: true),
                        ContractXDocumentId = c.Int(nullable: false),
                        DocumentInputId = c.Int(nullable: false),
                        Value = c.String(),
                        CreateBy = c.String(maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyBy = c.String(maxLength: 100),
                        ModifyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContractXDocumentInputId)
                .ForeignKey("dbo.ContractXDocuments", t => t.ContractXDocumentId)
                .ForeignKey("dbo.DocumentInputs", t => t.DocumentInputId)
                .Index(t => t.ContractXDocumentId)
                .Index(t => t.DocumentInputId);
            
            CreateTable(
                "dbo.ContractXDocuments",
                c => new
                    {
                        ContractXDocumentId = c.Int(nullable: false, identity: true),
                        ContractId = c.Int(nullable: false),
                        DocumentId = c.Int(nullable: false),
                        TemplateId = c.Int(nullable: false),
                        DocumentStatusId = c.Int(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        AlertDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ContractXDocumentId)
                .ForeignKey("dbo.Contracts", t => t.ContractId)
                .ForeignKey("dbo.Documents", t => t.DocumentId)
                .ForeignKey("dbo.DocumentStatus", t => t.DocumentStatusId)
                .ForeignKey("dbo.Templates", t => t.TemplateId)
                .Index(t => t.ContractId)
                .Index(t => t.DocumentId)
                .Index(t => t.TemplateId)
                .Index(t => t.DocumentStatusId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        Number = c.String(maxLength: 100),
                        State = c.String(maxLength: 50),
                        DocumentTypeId = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyBy = c.String(maxLength: 100),
                        ModifyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentTypeId)
                .Index(t => t.DocumentTypeId);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        DocumentTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateBy = c.String(maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyBy = c.String(maxLength: 100),
                        ModifyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentTypeId);
            
            CreateTable(
                "dbo.DocumentStatus",
                c => new
                    {
                        DocumentStatusId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateBy = c.String(maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyBy = c.String(maxLength: 100),
                        ModifyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentStatusId);
            
            CreateTable(
                "dbo.Templates",
                c => new
                    {
                        TemplateId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200),
                        DocumentId = c.Int(nullable: false),
                        DocumentOrder = c.Int(nullable: false),
                        IsRequired = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TemplateId)
                .ForeignKey("dbo.Documents", t => t.DocumentId)
                .Index(t => t.DocumentId);
            
            CreateTable(
                "dbo.DocumentInputs",
                c => new
                    {
                        DocumentInputId = c.Int(nullable: false, identity: true),
                        DocumentId = c.Int(nullable: false),
                        Name = c.String(maxLength: 200),
                        Description = c.String(),
                        InputTypeId = c.Int(nullable: false),
                        CreateBy = c.String(maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyBy = c.String(maxLength: 100),
                        ModifyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DocumentInputId)
                .ForeignKey("dbo.InputTypes", t => t.InputTypeId)
                .Index(t => t.InputTypeId);
            
            CreateTable(
                "dbo.InputTypes",
                c => new
                    {
                        InputTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateBy = c.String(maxLength: 100),
                        CreateDate = c.DateTime(nullable: false),
                        ModifyBy = c.String(maxLength: 100),
                        ModifyDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InputTypeId);
            
            CreateTable(
                "dbo.ContractXUsers",
                c => new
                    {
                        ContractXUserId = c.Int(nullable: false, identity: true),
                        ContractId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ContractXUserId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserHierarchies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ParentUserId = c.String(),
                        ChildUserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddForeignKey("dbo.UserRole", "RoleId", "dbo.Role", "Id");
            AddForeignKey("dbo.UserClaim", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.UserLogin", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.UserRole", "UserId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.ContractXUsers", "UserId", "dbo.User");
            DropForeignKey("dbo.ContractXDocumentInputs", "DocumentInputId", "dbo.DocumentInputs");
            DropForeignKey("dbo.DocumentInputs", "InputTypeId", "dbo.InputTypes");
            DropForeignKey("dbo.ContractXDocumentInputs", "ContractXDocumentId", "dbo.ContractXDocuments");
            DropForeignKey("dbo.ContractXDocuments", "TemplateId", "dbo.Templates");
            DropForeignKey("dbo.Templates", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.ContractXDocuments", "DocumentStatusId", "dbo.DocumentStatus");
            DropForeignKey("dbo.ContractXDocuments", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Documents", "DocumentTypeId", "dbo.DocumentTypes");
            DropForeignKey("dbo.ContractXDocuments", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Contracts", "ContractStatusId", "dbo.ContractStatus");
            DropIndex("dbo.ContractXUsers", new[] { "UserId" });
            DropIndex("dbo.DocumentInputs", new[] { "InputTypeId" });
            DropIndex("dbo.Templates", new[] { "DocumentId" });
            DropIndex("dbo.Documents", new[] { "DocumentTypeId" });
            DropIndex("dbo.ContractXDocuments", new[] { "DocumentStatusId" });
            DropIndex("dbo.ContractXDocuments", new[] { "TemplateId" });
            DropIndex("dbo.ContractXDocuments", new[] { "DocumentId" });
            DropIndex("dbo.ContractXDocuments", new[] { "ContractId" });
            DropIndex("dbo.ContractXDocumentInputs", new[] { "DocumentInputId" });
            DropIndex("dbo.ContractXDocumentInputs", new[] { "ContractXDocumentId" });
            DropIndex("dbo.Contracts", new[] { "ContractStatusId" });
            DropTable("dbo.UserHierarchies");
            DropTable("dbo.ContractXUsers");
            DropTable("dbo.InputTypes");
            DropTable("dbo.DocumentInputs");
            DropTable("dbo.Templates");
            DropTable("dbo.DocumentStatus");
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.Documents");
            DropTable("dbo.ContractXDocuments");
            DropTable("dbo.ContractXDocumentInputs");
            DropTable("dbo.ContractStatus");
            DropTable("dbo.Contracts");
            AddForeignKey("dbo.UserRole", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserLogin", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserClaim", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRole", "RoleId", "dbo.Role", "Id", cascadeDelete: true);
        }
    }
}
