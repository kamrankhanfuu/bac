using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BACAgent.Models.DBTable
{
    public class DocumentInput: AuditBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentInputId { get; set; }
        public int DocumentId { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public string Description { get; set; }
        public int InputTypeId { get; set; }

        public InputType InputType { get; set; }
    }
}