using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BACAgent.Models.DBTable
{
    public class ContractXDocumentInput: AuditBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractXDocumentInputId { get; set; }
        public int ContractXDocumentId { get; set; }
        public int DocumentInputId { get; set; }
        public string Value { get; set; }

        public ContractXDocument ContractXDocument { get; set; }
        public DocumentInput DocumentInput { get; set; }

    }
}