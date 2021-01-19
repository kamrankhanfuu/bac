using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BACAgent.Models.DBTable
{
    public class TemplateXDocument: AuditBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TemplateXDocumentId { get; set; }
        public int TemplateId { get; set; }
        public int DocumentId { get; set; }
        public int DocumentOrder { get; set; }
        public bool IsRequired { get; set; }

        public Document Document { get; set; }
        public Template Template { get; set; }



    }
}