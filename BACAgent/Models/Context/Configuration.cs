namespace BACAgent.Migrations
{
    using BACAgent.Models.Context;
    using BACAgent.Models.DBTable;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.DocumentStatuses.AddOrUpdate(x => x.Name,
                new DocumentStatus { Name = "Active", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new DocumentStatus { Name = "Executed", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new DocumentStatus { Name = "OOC", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new DocumentStatus { Name = "Pending-Signature", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new DocumentStatus { Name = "Pending-Verification", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow }
                    );

            context.InputTypes.AddOrUpdate(x => x.Name,
                new InputType { Name = "Date", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new InputType { Name = "Number", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new InputType { Name = "String", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new InputType { Name = "Currency", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow }
                );

            context.ContractStatuses.AddOrUpdate(x => x.Name,
                new ContractStatus { Name = "Active", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new ContractStatus { Name = "Coming Soon", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new ContractStatus { Name = "Active Contingent", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new ContractStatus { Name = "Active Kick Out", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new ContractStatus { Name = "Active Option Contract", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new ContractStatus { Name = "Cancelled", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new ContractStatus { Name = "Expired", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new ContractStatus { Name = "Pending", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new ContractStatus { Name = "Sold", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new ContractStatus { Name = "Temp Off Market", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new ContractStatus { Name = "Withdrawn", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new ContractStatus { Name = "Withdrawn Sublisting", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow }
                );

            context.DocumentTypes.AddOrUpdate(x => x.Name,
                new DocumentType { Name = "Contract", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow },
                new DocumentType { Name = "Typical", CreateBy = "admin", CreateDate = DateTime.UtcNow, ModifyBy = "admin", ModifyDate = DateTime.UtcNow }
                );

            context.Roles.AddOrUpdate(x => x.Name,
                new IdentityRole { Name = "SuperAdmin" },
                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "Manager" },
                new IdentityRole { Name = "TeamLead" },
                new IdentityRole { Name = "Agent" },
                new IdentityRole { Name = "Client" }
                );


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
