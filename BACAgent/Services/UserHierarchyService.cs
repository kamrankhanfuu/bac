using BACAgent.Models.Context;
using BACAgent.Models.DBTable;
using BACAgent.Models.Request;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BACAgent.Services
{
    public class UserHierarchyService
    {
        public async Task<List<UserHierarchy>> GetUserHierarchy(string id)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    var d =  await context.UserHierarchies.Where(x => x.Id == id).ToListAsync();
                    return d;
                }
                catch (Exception E)
                {
                    throw E;
                }

            }
        }

        public string AddUserHierarchy (UserHierarchyRequest request)
        {
            using (var context = new ApplicationDbContext())
            {
                try
                {
                    string parentId = request.Item.UserId;
                    foreach (var item in request.Item.ChildItems)
                    {
                        context.UserHierarchies.Add(new UserHierarchy
                        {
                            ParentUserId = parentId,
                            ChildUserId = item.UserId
                        });
                    }

                    context.SaveChanges();

                    return parentId;
                }
                catch (Exception E)
                {
                    throw E;
                }

            }

        }
    }
}