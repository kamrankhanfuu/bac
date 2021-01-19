using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace BACAgent.Models.DBTable
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AgentLicenseNumber { get; set; }
        public bool? IsDisabled { get; set; } = false;
        public bool? IsDeleted { get; set; } = false;

        public int CompanyId { get; set; }
        public Company Company { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

}