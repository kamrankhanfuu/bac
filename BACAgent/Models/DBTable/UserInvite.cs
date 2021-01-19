using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BACAgent.Models.DBTable
{
    public class UserInvite: AuditBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserInviteId { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserInviteGuid { get; set; }

        public string InviterUserId { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailBody { get; set; }
        public bool EmailSent { get; set; }
        public string RoleId { get; set; }
        public bool IsInviteAcceptated { get; set; }
    }
}