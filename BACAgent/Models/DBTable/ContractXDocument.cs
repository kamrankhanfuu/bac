using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BACAgent.Models.DBTable
{
    public class ContractXDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContractXDocumentId { get; set; }
        public int ContractId { get; set; }
        public int DocumentId { get; set; }
        public int TemplateId { get; set; }
        public int DocumentStatusId { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime AlertDate { get; set; }

        public Contract Contract { get; set; }
        public Document Document { get; set; }
        public Template Template { get; set; }
        public DocumentStatus DocumentStatus { get; set; }

    }
}