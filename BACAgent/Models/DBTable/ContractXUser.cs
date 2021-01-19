using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BACAgent.Models.DBTable
{
    public class ContractXUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractXUserId { get; set; }
        public int ContractId { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}