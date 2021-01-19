using BACAgent.Models.DBTable;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
//using System.Web.Http;


using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BACAgent.Models;
using System.Web.Http;
using BACAgent.Models.Context;
using BACAgent.Services;
using BACAgent.Models.Response;
using BACAgent.Models.Request;

namespace BACAgent.Controllers
{
    public class AccountController : ApiController
    {
        [Route("api/User/Register")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IdentityResult> Register(AccountModel model)
        {
            model.Company.CreateBy = model.Email;
            model.Company.ModifyBy = model.Email;
            model.Company.CreateDate = DateTime.UtcNow;
            model.Company.ModifyDate = DateTime.UtcNow;

            int companyId = default(int);
            //AddCompany
            AdminService adminService = new AdminService();
            if (model.IsInvite)
            {
                companyId = model.Company.CompanyId;
            }
            else if (model.Company != null && !string.IsNullOrEmpty(model.Company.Name))
            {
                var newCompany = await adminService.AddCompany(model.Company);
                companyId = newCompany.CompanyId;
            }

            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser() 
            { 
                UserName = model.UserName, 
                Email = model.Email ,
                AgentLicenseNumber = model.AgentLicenseNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CompanyId = companyId
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3
            };
            IdentityResult result = manager.Create(user, model.Password);
            manager.AddToRoles(user.Id, model.Roles);

            return result;
        }

        [Route("api/User/RegisterInvite")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IdentityResult> RegisterInvite(AccountModel model)
        {
            //AddCompany
            AdminService adminService = new AdminService();
            var newCompany = await adminService.AddCompany(model.Company);


            var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
            var manager = new UserManager<ApplicationUser>(userStore);
            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                AgentLicenseNumber = model.AgentLicenseNumber,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CompanyId = newCompany.CompanyId
            };

            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 3
            };
            IdentityResult result = manager.Create(user, model.Password);
            manager.AddToRoles(user.Id, model.Roles);

            return result;
        }

        [HttpPut]
        [Route("api/Admin/User")]
        //public async Task<ApiResponse<User>> UpdateUser(UpdateUserRequest updateUserRequest)
        //{
        //    var identityClaims = (ClaimsIdentity)User.Identity;

        //    #region guard
        //    //if (string.IsNullOrEmpty(company.Name)) return await ApiResponse<Company>.ErrorResponse("missing companyName");
        //    #endregion

        //    var userStore = new UserStore<ApplicationUser>(new ApplicationDbContext());
        //    var manager = new UserManager<ApplicationUser>(userStore);

        //    var user = await manager.FindByIdAsync(updateUserRequest.UserId);

        //    user.FirstName = updateUserRequest.FirstName;
        //    user.LastName = updateUserRequest.LastName;
        //    user.AgentLicenseNumber = updateUserRequest.AgentLicenseNumber;
        //    if (user.Roles.fin.Contains())
        //        ;
        //    user.Roles.Add();

        //    var x = new IdentityUserRole();
        //    x.
        //    user.Roles.Clear();
        //    updateUserRequest.Role;

        //    manager.Up

        //    company.ModifyBy = identityClaims.FindFirst("UserName").Value;
        //    company.ModifyDate = DateTime.UtcNow;

        //    AppDomainManager

        //    var service = new AdminService();
        //    return await ApiResponse<Company>
        //        .CreateResponse(async () => await service.UpdateCompany(company));
        //}

        [HttpDelete]
        [Route("api/User")]
        public async Task<bool> DeleteUser(string id)
        {
            var service = new UserService();
            return await service.DeleteUser(id);
        }

        [Route("api/User/IsLoggedIn")]
        [HttpGet]
        [AllowAnonymous]
        public bool IsLoggedIn()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            return identityClaims.FindFirst("UserName") != null;
        }

        [Route("api/GetUserClaims")]
        [HttpGet]
        public AccountModel GetUserClaims()
        {
            var identityClaims = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identityClaims.Claims;
            var model = new AccountModel
            {
                UserName = identityClaims.FindFirst("UserName").Value,
                Email = identityClaims.FindFirst("Email").Value,
                FirstName = identityClaims.FindFirst("FirstName").Value,
                LastName = identityClaims.FindFirst("LastName").Value,
                LoggedOn = identityClaims.FindFirst("LoggedOn").Value
            };

            return model;
        }

        [Route("api/User/InviteUser")]
        [HttpPost]
        public bool InviteUser(UserInvite userInvite)
        {
            var identityClaims = (ClaimsIdentity)User.Identity;

            #region guard
            if (string.IsNullOrEmpty(userInvite.Email)) return false;
            if (string.IsNullOrEmpty(userInvite.FirstName) && string.IsNullOrEmpty(userInvite.LastName)) return false;
            #endregion

            userInvite.CreateBy = identityClaims.FindFirst("UserName").Value;
            userInvite.ModifyBy = identityClaims.FindFirst("UserName").Value;
            userInvite.CreateDate = DateTime.UtcNow;
            userInvite.ModifyDate = DateTime.UtcNow;

            UserService userService = new UserService();
            userService.AddInviteUser(userInvite, identityClaims.FindFirst("Email").Value);

            return true;
        }

        [Route("api/User/InviteUser")]
        [HttpGet]
        [AllowAnonymous]
        public UserInviteResponse InviteUser(string id)
        {
            UserService userService = new UserService();
            return userService.GetUserInvite(id);
        }

        [Route("api/User/GetUsers")]
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<UserResponse>>> GetUsers()
        {
            var service = new UserService();
            return await ApiResponse<IEnumerable<UserResponse>>
                .CreateResponse(async () => await service.GetUsers());
        }

        [Route("api/User/GetCompanyUsers")]
        [HttpGet]
        public async Task<ApiResponse<IEnumerable<UserResponse>>> GetCompanyUsers()
        {
            var userId = User.Identity.GetUserId();

            var service = new UserService();
            return await ApiResponse<IEnumerable<UserResponse>>
                .CreateResponse(async () => await service.GetAllCompanyUsersByUser(userId));
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("api/ForAdminRole")]
        public string ForAdminRole()
        {
            return "for admin role";
        }

        [HttpGet]
        [Authorize(Roles = "Author")]
        [Route("api/ForAuthorRole")]
        public string ForAuthorRole()
        {
            return "For author role";
        }

        [HttpGet]
        [Authorize(Roles = "Author,Reader")]
        [Route("api/ForAuthorOrReader")]
        public string ForAuthorOrReader()
        {
            return "For author/reader role";
        }

    }
}