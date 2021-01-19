using BACAgent.Models.Context;
using BACAgent.Models.DBTable;
using BACAgent.Models.DTO;
using BACAgent.Models.Response;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BACAgent.Services
{
    public class UserService
    {
        public bool AddInviteUser(UserInvite userInvite, string inviterEmail)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    //Get UserId
                    var inviter = context.Users.FirstOrDefault(x => x.Email == inviterEmail);
                    userInvite.InviterUserId = inviter.Id;

                    context.UserInviites.Add(userInvite);
                    context.SaveChanges();
                    //SEND EMAIL
                    return true;
                }
                catch (Exception e)
                {
                    LogSingleton.ErrorException(e);
                    return false;
                }

            }
        }


        public UserInviteResponse GetUserInvite(string id)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var userInvite = context.UserInviites.FirstOrDefault(x => x.UserInviteGuid.ToString() == id);

                    var userInviter = context.Users
                        .Include("Company")
                        .FirstOrDefault(x => x.Id == userInvite.InviterUserId);

                    string role = string.Empty;
                    if (!string.IsNullOrEmpty(userInvite.RoleId))
                    {
                        role = context.Roles.FirstOrDefault(x => x.Id == userInvite.RoleId.ToString())?.Name;
                    }

                    return new UserInviteResponse
                    {
                        InviterName = $"{userInviter.FirstName} {userInviter.LastName}",
                        InviteeEmail = userInvite.Email,
                        InviteeFirstName = userInvite.FirstName,
                        InviteeLastName = userInvite.LastName,
                        RoleId = userInvite.RoleId,
                        Role = role,
                        Company = userInviter.Company
                    };

                }
                catch (Exception e)
                {
                    LogSingleton.ErrorException(e);
                    throw e;
                }
            }
        }

        public async Task<IEnumerable<UserResponse>> GetUsers()
        {
            using (var context = new ApplicationDbContext())
            {
                var users = await context.Users
                    .Include("Company")
                    .Where(x=>x.IsDeleted == null || x.IsDeleted == false)
                    .ToListAsync();

                var roles = await context.Roles.ToListAsync();

                List<UserResponse> userResponses = new List<UserResponse>();

                foreach (var user in users)
                {


                    userResponses.Add(new UserResponse
                    {
                        UserId = user.Id,
                        UserName = user.UserName,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        AgentLicenseNumber = user.AgentLicenseNumber,
                        Roles = user.Roles.Select(x => roles.FirstOrDefault(y => y.Id == x.RoleId)?.Name).ToArray(),
                        Company = user.Company
                    });
                }

                return userResponses;
            }
        }

        //
        public async Task<IEnumerable<UserResponse>> GetAllCompanyUsersByUser(string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var userXCompany = await context.UserXCompanies.FirstOrDefaultAsync(x => x.UserId == userId);
                if (userXCompany == null) throw new Exception("User company not found");

                var userXCompanies = await context.UserXCompanies.Where(x=>x.CompanyId == userXCompany.CompanyId).ToListAsync();
                var roles = await context.Roles.ToListAsync();

                List<UserResponse> userResponses = new List<UserResponse>();

                foreach (var item in userXCompanies)
                {

                    userResponses.Add(new UserResponse
                    {
                        UserId = item.UserId,
                        UserName = item.User.UserName,
                        FirstName = item.User.FirstName,
                        LastName = item.User.LastName,
                        AgentLicenseNumber = item.User.AgentLicenseNumber,
                        Roles = item.User.Roles.Select(x => roles.FirstOrDefault(y => y.Id == x.RoleId)?.Name).ToArray(),
                        Company = userXCompany.Company
                    });
                }

                return userResponses;
            }
        }

        public async Task<bool> DeleteUser(string userId)
        {
                var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var manager = new UserManager<ApplicationUser>(userStore);
                
                var user = await manager.FindByIdAsync(userId);

                user.IsDeleted = true;

                await manager.UpdateAsync(user);

            manager.Dispose();

                return true;
        }
    }
}