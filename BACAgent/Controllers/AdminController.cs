using BACAgent.Models.DBTable;
using BACAgent.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BACAgent.Services;
using BACAgent.Models.Response;
using Microsoft.AspNet.Identity;
using System.Web.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BACAgent.Controllers
{
    public class AdminController : ApiController
    {

        [HttpGet]
        [Route("api/Admin/UserHierarchy")]
        public async Task<ApiResponse<List<UserHierarchy>>> GetUserHierarchy()
        {
            var userId = User.Identity.GetUserId();
            var service = new UserHierarchyService();

            return await ApiResponse<List<UserHierarchy>>
                .CreateResponse(async () => await service.GetUserHierarchy(userId));


            //var identityClaims = (ClaimsIdentity)User.Identity;
            //IEnumerable<Claim> claims = identityClaims.Claims;
            //var model = new AccountModel
            //{
            //    UserName = identityClaims.FindFirst("UserName").Value,
            //    Email = identityClaims.FindFirst("Email").Value,
            //    FirstName = identityClaims.FindFirst("FirstName").Value,
            //    LastName = identityClaims.FindFirst("LastName").Value,
            //    LoggedOn = identityClaims.FindFirst("LoggedOn").Value
            //};

            //return model;
        }

        [HttpGet]
        [Route("api/Admin/Company")]
        public async Task<ApiResponse<Company>> GetCompanyByUser()
        {
            var userId = User.Identity.GetUserId();
            var service = new AdminService();
            return await ApiResponse<Company>
                .CreateResponse(async () => await service.GetCompanyByUser(userId));
        }

        [HttpGet]
        [Route("api/Admin/Companies")]
        public async Task<ApiResponse<IEnumerable<Company>>> GetCompanies()
        {
            var service = new AdminService();
            return await ApiResponse<IEnumerable<Company>>
                .CreateResponse(async () => await service.GetCompanies());
        }

        [HttpPost]
        [Route("api/Admin/Company")]
        public async Task<ApiResponse<Company>> AddCompany(Company company)
        {
            var identityClaims = (ClaimsIdentity)User.Identity;

            #region guard
            if (string.IsNullOrEmpty(company.Name)) return await ApiResponse<Company>.ErrorResponse("missing companyName");
            #endregion

            company.CreateBy = identityClaims.FindFirst("UserName").Value;
            company.ModifyBy = identityClaims.FindFirst("UserName").Value;
            company.CreateDate = DateTime.UtcNow;
            company.ModifyDate = DateTime.UtcNow;

            var service = new AdminService();
            return await ApiResponse<Company>
                .CreateResponse(async () => await service.AddCompany(company));
            //return await service.AddCompany(company);
        }

        [HttpPut]
        [Route("api/Admin/Company")]
        public async Task<ApiResponse<Company>> UpdateCompany(Company company)
        {
            var identityClaims = (ClaimsIdentity)User.Identity;

            #region guard
            if (string.IsNullOrEmpty(company.Name)) return await ApiResponse<Company>.ErrorResponse("missing companyName");
            #endregion

            company.ModifyBy = identityClaims.FindFirst("UserName").Value;
            company.ModifyDate = DateTime.UtcNow;

            var service = new AdminService();
            return await ApiResponse<Company>
                .CreateResponse(async () => await service.UpdateCompany(company));
        }

        [HttpDelete]
        [Route("api/Admin/Company")]
        public async Task<bool> DeleteCompany(int id)
        {
            var service = new AdminService();
            return await service.DeleteCompany(id);
        }
    }
}