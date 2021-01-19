using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BACAgent.Models.Request
{
    public class UpdateUserRequest
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string AgentLicenseNumber { get; set; }
    }
}