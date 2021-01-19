namespace BACAgent.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contracts", "CreateBy", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Contracts", "ModifyBy", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ContractStatus", "CreateBy", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ContractStatus", "ModifyBy", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ContractXDocumentInputs", "CreateBy", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.ContractXDocumentInputs", "ModifyBy", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Documents", "CreateBy", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Documents", "ModifyBy", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.DocumentTypes", "CreateBy", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.DocumentTypes", "ModifyBy", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.DocumentStatus", "CreateBy", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.DocumentStatus", "ModifyBy", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.DocumentInputs", "CreateBy", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.DocumentInputs", "ModifyBy", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.InputTypes", "CreateBy", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.InputTypes", "ModifyBy", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InputTypes", "ModifyBy", c => c.String(maxLength: 100));
            AlterColumn("dbo.InputTypes", "CreateBy", c => c.String(maxLength: 100));
            AlterColumn("dbo.DocumentInputs", "ModifyBy", c => c.String(maxLength: 100));
            AlterColumn("dbo.DocumentInputs", "CreateBy", c => c.String(maxLength: 100));
            AlterColumn("dbo.DocumentStatus", "ModifyBy", c => c.String(maxLength: 100));
            AlterColumn("dbo.DocumentStatus", "CreateBy", c => c.String(maxLength: 100));
            AlterColumn("dbo.DocumentTypes", "ModifyBy", c => c.String(maxLength: 100));
            AlterColumn("dbo.DocumentTypes", "CreateBy", c => c.String(maxLength: 100));
            AlterColumn("dbo.Documents", "ModifyBy", c => c.String(maxLength: 100));
            AlterColumn("dbo.Documents", "CreateBy", c => c.String(maxLength: 100));
            AlterColumn("dbo.ContractXDocumentInputs", "ModifyBy", c => c.String(maxLength: 100));
            AlterColumn("dbo.ContractXDocumentInputs", "CreateBy", c => c.String(maxLength: 100));
            AlterColumn("dbo.ContractStatus", "ModifyBy", c => c.String(maxLength: 100));
            AlterColumn("dbo.ContractStatus", "CreateBy", c => c.String(maxLength: 100));
            AlterColumn("dbo.Contracts", "ModifyBy", c => c.String(maxLength: 100));
            AlterColumn("dbo.Contracts", "CreateBy", c => c.String(maxLength: 100));
        }
    }
}
