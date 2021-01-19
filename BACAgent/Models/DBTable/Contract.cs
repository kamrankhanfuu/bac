using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BACAgent.Models.DBTable
{
    public class Contract: AuditBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractId { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public int ContractStatusId { get; set; }
        public string Description { get; set; }

        public ContractStatus ContractStatus { get; set; }
    }
}