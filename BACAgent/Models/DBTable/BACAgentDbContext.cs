//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;

//namespace BACAgent.Models.DBTable
//{
//    public class BACAgentDbContext : DbContext
//    {
//        public BACAgentDbContext() : base("name=DefaultConnection")
//        {
//        }

//        public DbSet<UserHierarchy> UserHierarchies { get; set; }

//        protected override void OnModelCreating(DbModelBuilder ModelBuilder)

//        {

//            //Configure Domain classes using fluent API here.

//            base.OnModelCreating(ModelBuilder);

//        }
//    }
//}