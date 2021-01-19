//using BACAgent.Models.DBTable;
//using Microsoft.Owin.Security;
//using Microsoft.Owin.Security.OAuth;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http.Cors;

//namespace BACAgent
//{
//    [EnableCors(origins: "*", headers: "*", methods:"*")]
//    public class BacAgentAuthServerProvider: OAuthAuthorizationServerProvider
//    {

//        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
//        {
//            context.Validated();
//        }

//        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
//        {
//            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

//            //context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[]({"*"});

//            using(var db = new ApplicationDbContext())
//            {
//                if(db!= null)
//                {
//                    var user = db.Users.ToList();
//                    if(user != null){
//                        if(!string.IsNullOrEmpty(user.Where(x=>x.UserName == context.UserName && x.Password == context.Password)
//                            .FirstOrDefault().UserName))
//                        {
//                            var currentUser = user.Where(x => x.UserName == context.UserName && x.Password == context.Password).FirstOrDefault();
//                            identity.AddClaim(new Claim("Role", currentUser.Role));
//                            identity.AddClaim(new Claim("Id", Convert.ToString(currentUser.Id)));

//                            var props = new AuthenticationProperties(new Dictionary<string, string>
//                            {
//                                {
//                                    "DisplayName", context.UserName
//                                },
//                                {
//                                    "Role", currentUser.Role
//                                }
//                            });

//                            var ticket = new AuthenticationTicket(identity, props);
//                            context.Validated(ticket);
//                        }
//                        else
//                        {
//                            context.SetError("invalid_grant", "Provided username and password is not matching, Please retry");
//                            context.Rejected();
//                        }
//                    }
//                    else
//                    {
//                        context.SetError("invalid_grant", "Provided username and password is not matching, Please retry");
//                        context.Rejected();
//                    }
//                    return;
//                }
//            }
//        }

//    }
//}