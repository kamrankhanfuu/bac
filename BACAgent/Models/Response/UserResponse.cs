using BACAgent.Models.DBTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BACAgent.Models.Response
{
    public class UserResponse
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string[] Roles { get; set; }
        public string AgentLicenseNumber { get; set; }

        public Company Company { get; set; }
    }
}