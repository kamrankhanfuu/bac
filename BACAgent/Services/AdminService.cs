using BACAgent.Models.Context;
using BACAgent.Models.DBTable;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BACAgent.Services
{
    public class AdminService
    {
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            using (var context = new ApplicationDbContext())
            {
                return await context.Companies.ToListAsync();
            }
        }

        public async Task<Company> GetCompanyByUser(string userId)
        {
            using (var context = new ApplicationDbContext())
            {
                var userCompany = await context.UserXCompanies.FirstOrDefaultAsync(x => x.UserId == userId);
                if (userCompany != null)
                {
                    return await context.Companies.FirstOrDefaultAsync(x => x.CompanyId == userCompany.CompanyId);
                }
            }

            return null;
        }

        public async Task<Company> AddCompany(Company company)
        {
            using (var context = new ApplicationDbContext())
            {
                context.Companies.Add(company);

                await context.SaveChangesAsync();

                return company;
            }
        }

        public async Task<Company> UpdateCompany(Company company)
        {
            using (var context = new ApplicationDbContext())
            {
                var origCompany = await context.Companies.FirstOrDefaultAsync(x => x.CompanyId == company.CompanyId);
                if (origCompany == null) throw new ArgumentException("missing company id");

                origCompany.Name = company.Name;
                origCompany.Address1 = company.Address1;
                origCompany.Address2 = company.Address2;
                origCompany.City = company.City;
                origCompany.State = company.State;
                origCompany.Zip = company.Zip;
                origCompany.ModifyBy = company.ModifyBy;
                origCompany.ModifyDate = company.ModifyDate;

                await context.SaveChangesAsync();

                return origCompany;
            }
        }

        public async Task<bool> DeleteCompany(int companyId)
        {
            using (var context = new ApplicationDbContext())
            {
                var foundCompany = await context.Companies.FirstOrDefaultAsync(x => x.CompanyId == companyId);
                if (foundCompany == null) return false;

                context.Companies.Remove(foundCompany);
                await context.SaveChangesAsync();

                return true;
            }
        }

        //public async Task<UserXCompany> AddCompany(AccountModel accountModel, Company company)
        //{
        //    using (var context = new ApplicationDbContext())
        //    {
        //        context.Companies.Add(company);

        //        await context.SaveChangesAsync();

        //        return company;
        //    }
        //}
    }
}