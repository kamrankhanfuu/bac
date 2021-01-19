using BACAgent.Models.DBTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BACAgent.Models.Response
{
    public class UserInviteResponse
    {
        public string InviterName { get; set; }
        public string InviteeFirstName { get; set; }
        public string InviteeLastName { get; set; }
        public string InviteeEmail { get; set; }
        public string RoleId { get; set; }
        public string Role { get; set; }
        public Company Company { get; set; }
    }
}