using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BACAgent.Models.DBTable
{
    public abstract class AuditBase
    {
        [StringLength(100)]
        [Required]
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        [StringLength(100)]
        [Required]
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }

    }
}