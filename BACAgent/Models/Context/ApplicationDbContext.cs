using BACAgent.Models.DBTable;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BACAgent.Models.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<UserHierarchy> UserHierarchies { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractStatus> ContractStatuses { get; set; }
        public DbSet<ContractXDocument> ContractXDocuments { get; set; }
        public DbSet<ContractXDocumentInput> ContractXDocumentInputs { get; set; }
        public DbSet<ContractXUser> ContractXUsers { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<DocumentInput> DocumentInputs { get; set; }
        public DbSet<DocumentStatus> DocumentStatuses { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<InputType> InputTypes { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplateXDocument> TemplateXDocuments { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<UserXCompany> UserXCompanies { get; set; }
        public DbSet<UserInvite> UserInviites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //AspNetUsers -> User
            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            //AspNetRoles -> Role
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            //AspNetUserRoles -> UserRole
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            //AspNetUserClaims -> UserClaim
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            //AspNetUserLogins -> UserLogin
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
        
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }



        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}